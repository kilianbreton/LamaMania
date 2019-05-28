/* ----------------------------------------------------------------------------------
 * Project : LamaMania
 * Launch Authenticate Manage & Access ManiaPlanet Servers
 * Inspired by ServerMania by Cyrlaur
 * 
 * ----------------------------------------------------------------------------------
 * Author:	    Breton Kilian
 * Copyright:	April 2019 by Breton Kilian
 * ----------------------------------------------------------------------------------
 *
 * LICENSE: This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.If not, see<http://www.gnu.org/licenses/>.
 *
 * ----------------------------------------------------------------------------------*/

using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Compression;
using NTK.IO.Xml;
using static NTK.Other.NTKF;
using LamaLang;
using LamaPlugin;

namespace LAMAMAnia
{
    /// <summary>
    /// Server configuration
    /// </summary>
    public partial class ConfigServ : Form
    {
        //Name ex : 0, 1, 2 ...

        private XmlDocument config;
        private XmlDocument dedicated_config;
        private string serverPath;
        private string configPath;
        private XmlDocument matchSettings;
        private Dictionary<string, string> mapFiles = new Dictionary<string, string>();
        private int index;

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Constructeurs ///////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
      
        /// <summary>
        /// New Local Server
        /// </summary>
        public ConfigServ(string name)
        {
            InitializeComponent();
            this.index = Lama.mainConfig[0]["servers"].count();
            this.serverPath = @"Servers\" + index + @"\";
            this.configPath = @"Config\Servers\" + index + ".xml";

            loadLang();

            //Make server-----------------------------------------------------------------
            Directory.CreateDirectory(this.serverPath);
            DirectoryInfo mps = new DirectoryInfo(@"Ressources\mps\");
            copyDirectory(mps, this.serverPath);

            //MakeConfig------------------------------------------------------------------
            this.config = new XmlDocument(this.configPath);
            var root = this.config.addNode("server_config");
            root.addChild("matchSettings");
            root.addChild("remote").addAttribute("value","false")
                                   .addChild("ip","")
                                   .addChild("port","")
                                   .addChild("login","");

            root.addChild("plugins");
            this.config.save();

            //Actualize main Config
            Lama.mainConfig[0]["servers"].addChild("server")
                                         .addAttribute("id", this.index.ToString())
                                         .Value = name;

            Lama.mainConfig.save();
            Lama.mainConfig = new XmlDocument(@"Config\Main.xml");


            loadPlugins();
            loadMain();
            loadDedicated();
            loadMaps();
        }

        /// <summary>
        /// Edit Local Server
        /// </summary>
        /// <param name="index"></param>
        public ConfigServ(int index)
        {
            InitializeComponent();
            this.serverPath = @"Servers\" + index + @"\";
            this.configPath = @"Config\Servers\" + index + ".xml";
            this.index = index;

            if (Lama.lang != null)
                loadLang();

            this.tb_name.Text = Lama.mainConfig[0]["servers"].getChildsByAttribute("id", index.ToString())[0].Value;

            loadPlugins();
            loadMain();
            loadDedicated();
            loadMaps();
           
        }
        
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Methodes ////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        void copyDirectory(DirectoryInfo dir, string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            foreach (FileInfo file in dir.EnumerateFiles())
            {
                try
                {
                    File.Copy(file.FullName, path + file.Name);
                }
                catch (Exception) {  }
            }

            foreach (DirectoryInfo child in dir.EnumerateDirectories())
            {
                copyDirectory(child, path + child.Name + "\\");
            }
            
        }

        void loadLang()
        {
        }

        void loadMain()
        {
            this.config = new XmlDocument(configPath);
            tb_matchFile.Text = this.config[0]["matchSettings"].Value;
            if(tb_matchFile.Text != "")
            {
                loadMatchSettings(this.serverPath + @"\UserData\Maps\MatchSettings\" + tb_matchFile.Text);
            }
            else
            {
                this.matchSettings = new XmlDocument(this.serverPath + @"\UserData\Maps\MatchSettings\Default.txt");
            }
            //manage Plugins checked
        }

        void loadPlugins()
        {
            //Load Plugins List
            if (Lama.plugins != null)
            {
                checkedListBox1.Items.Clear();
                foreach (BasePlugin plugin in Lama.plugins)
                {
                    checkedListBox1.Items.Add(plugin.Name);
                }
            }
        }

        void loadDedicated()
        {
            this.dedicated_config = new XmlDocument(serverPath + @"UserData\Config\dedicated_cfg.txt");
            var root = this.dedicated_config[0];  //dedicated

            //Authorisations --------------------------------------------------------------------------
            var auth = root["authorization_levels"];
            foreach (XmlNode node in auth.getChildList("level"))
            {
                switch (node["name"].Value)
                {
                    case "SuperAdmin":
                        tb_superPass.Text = node["password"].Value;
                        break;

                    case "Admin":
                        tb_adminPass.Text = node["password"].Value;
                        break;

                    case "User":
                        tb_userPass.Text = node["password"].Value;
                        break;
                }
            }

            //Master Account --------------------------------------------------------------------------
            var master = root["masterserver_account"];
            tb_serverLogin.Text = master["login"].Value;
            tb_ServerPass.Text = master["password"].Value;
            tb_validKey.Text = master["validation_key"].Value;

            //Server Options --------------------------------------------------------------------------
            var servOptions = root["server_options"];
            tb_ingameName.Text = servOptions["name"].Value;
            tb_description.Text = servOptions["comment"].Value;
            tb_playerPass.Text = servOptions["password"].Value;
            tb_specPass.Text = servOptions["password_spectator"].Value;
            tb_refereePass.Text = servOptions["referee_password"].Value;
            tb_voteRatio.Text = servOptions["callvote_ratio"].Value;

            n_voteTimeout.Value = servOptions["callvote_timeout"].LValue;
            n_playersLimit.Value = servOptions["max_players"].LValue;
            n_specsLimit.Value = servOptions["max_spectators"].LValue;
            n_maxLat.Value = servOptions["clientinputs_maxlatency"].LValue;

            ch_keepPlayerSlot.Checked = servOptions["keep_player_slots"].BValue;
            ch_ladder.Checked = (servOptions["ladder_mode"].Value.Equals("forced"));
            ch_p2pUp.Checked = servOptions["enable_p2p_upload"].BValue;
            ch_p2pDown.Checked = servOptions["enable_p2p_download"].BValue;
            ch_mapDown.Checked = servOptions["allow_map_download"].BValue;
            ch_autoSaveReplay.Checked = servOptions["autosave_replays"].BValue;
            ch_saveValReplay.Checked = servOptions["autosave_validation_replays"].BValue;

            cb_refereeValid.SelectedIndex = (int)servOptions["referee_validation_mode"].LValue;
            ch_horns.Checked = servOptions["disable_horns"].BValue;

            //System Config --------------------------------------------------------------------------
            var systemConfig = root["system_config"];

            n_UpRate.Value = systemConfig["connection_uploadrate"].LValue;
            n_DownRate.Value = systemConfig["connection_downloadrate"].LValue;

            tb_ServerPort.Text = systemConfig["server_port"].Value;
            tb_p2pPort.Text = systemConfig["server_p2p_port"].Value;
            tb_XmlRpcPort.Text = systemConfig["xmlrpc_port"].Value;
            tb_proxy.Text = systemConfig["proxy_url"].Value;

            ch_xmlRpcRemote.Checked = systemConfig["xmlrpc_allowremote"].BValue;
            ch_proxy.Checked = systemConfig["use_proxy"].BValue;


            tb_title.Text = systemConfig["title"].Value;
        }

        void loadMatchSettings(string path)
        {
            this.matchSettings = new XmlDocument(path);
            var root = this.matchSettings[0];

            foreach(XmlNode map in root.getChildList("map"))
            {
                l_mapsMatch.Items.Add(Path.GetFileName(map["file"].Value));
                mapFiles.Add(Path.GetFileName(map["file"].Value), Path.GetFullPath(map["file"].Value));
            }
            foreach(XmlNode setting in root["mode_script_settings"].getChildList("setting"))
            {
                switch (setting.getAttibuteV("name"))
                {
                    case "S_TimeLimit":
                        int time = int.Parse(setting.getAttibuteV("value"));

                        int h, m, s;
                        Lama.parseTime(time, out h, out m, out s);
                                 
                        n_time_h.Value = h;
                        n_time_m.Value = m;
                        n_time_s.Value = s;
                        n_time_h.Update();
                        break;
                    case "S_WarmUpNb":
                        n_nbwarm.Value = int.Parse(setting.getAttibuteV("value"));
                        break;
                    case "S_WarmUpDuration":
                        int timew = int.Parse(setting.getAttibuteV("value"));

                        int hw, mw, sw;
                        Lama.parseTime(timew, out hw, out mw, out sw);

                        n_warm_h.Value = hw;
                        n_warm_m.Value = mw;
                        n_warm_s.Value = sw;
                        break;
                    case "S_ForceLapsNb":
                        n_forcelaps.Value = int.Parse(setting.getAttibuteV("value"));
                        break;
                }
            }

        }

        void loadMaps()
        {
            DirectoryInfo dir = new DirectoryInfo(serverPath + @"UserData\Maps\");
            makeTreeview(dir, treeView1.Nodes.Add("Maps"));
        }
       
        void makeTreeview(DirectoryInfo dir, TreeNode node)
        {
            foreach (DirectoryInfo child in dir.GetDirectories())
            {
                makeTreeview(child, node.Nodes.Add(child.Name));
            }
        }

        //Save -----------------------------------------------------------------------------------------------------------

        void saveMain()
        {
            this.config[0]["matchSettings"].Value = tb_matchFile.Text;
            //Save Plugin List
            this.config.save();
            var c = Lama.mainConfig[0]["servers"].getChildsByAttribute("id", this.index.ToString());
            if(c.Count <= 1 && c.Count > 0)
            {
                c[0].Value = tb_name.Text;
                Lama.mainConfig.save();
            }
            
        }

        void saveDedicated()
        {
            try
            {
                var root = this.dedicated_config[0];  //dedicated

                //Authorisations --------------------------------------------------------------------------
                var auth = root["authorization_levels"];
                foreach (XmlNode n in auth.getChildList("level"))
                {
                    switch (n["name"].Value)
                    {
                        case "SuperAdmin":
                            n["password"].Value = tb_superPass.Text;
                            break;

                        case "Admin":
                            n["password"].Value = tb_adminPass.Text;
                            break;

                        case "User":
                            n["password"].Value = tb_userPass.Text;
                            break;
                    }
                }

                //Master Account --------------------------------------------------------------------------
                var master = root["masterserver_account"];
                master["login"].Value = tb_serverLogin.Text;
                master["password"].Value = tb_ServerPass.Text;
                master["validation_key"].Value = tb_validKey.Text;


                //Server Options --------------------------------------------------------------------------
                var servOptions = root["server_options"];
                servOptions["name"].Value = tb_ingameName.Text;
                servOptions["comment"].Value = tb_description.Text;
                servOptions["password"].Value = tb_playerPass.Text;
                servOptions["password_spectator"].Value = tb_specPass.Text;
                servOptions["referee_password"].Value = tb_refereePass.Text;
                servOptions["callvote_ratio"].Value = tb_voteRatio.Text;

                servOptions["callvote_timeout"].Value = n_voteTimeout.Value.ToString();
                servOptions["max_players"].Value = n_playersLimit.Value.ToString();
                servOptions["max_spectators"].Value = n_specsLimit.Value.ToString();
                servOptions["clientinputs_maxlatency"].Value = n_maxLat.Value.ToString();

                servOptions["keep_player_slots"].Value = ch_keepPlayerSlot.Checked.ToString();

                if (ch_ladder.Checked)
                    servOptions["ladder_mode"].Value = "forced";
                else
                    servOptions["ladder_mode"].Value = "incative";

                servOptions["enable_p2p_upload"].Value = ch_p2pUp.Checked.ToString();
                servOptions["enable_p2p_download"].Value = ch_p2pDown.Checked.ToString();
                servOptions["allow_map_download"].Value = ch_mapDown.Checked.ToString();
                servOptions["autosave_replays"].Value = ch_autoSaveReplay.Checked.ToString();
                servOptions["autosave_validation_replays"].Value = ch_saveValReplay.Checked.ToString();

                servOptions["referee_validation_mode"].Value = cb_refereeValid.SelectedIndex.ToString();
                servOptions["disable_horns"].Value = ch_horns.Checked.ToString();


                //System Config --------------------------------------------------------------------------
                var systemConfig = root["system_config"];

                systemConfig["connection_uploadrate"].Value = n_UpRate.Value.ToString();
                systemConfig["connection_downloadrate"].Value = n_DownRate.Value.ToString();

                systemConfig["server_port"].Value = tb_ServerPort.Text;
                systemConfig["server_p2p_port"].Value = tb_p2pPort.Text;
                systemConfig["xmlrpc_port"].Value = tb_XmlRpcPort.Text;
                systemConfig["proxy_url"].Value = tb_proxy.Text;

                systemConfig["xmlrpc_allowremote"].Value = ch_xmlRpcRemote.Checked.ToString();
                systemConfig["use_proxy"].Value = ch_proxy.Checked.ToString();


                systemConfig["title"].Value = tb_title.Text;
                this.dedicated_config.save();
            }
            catch (Exception er)
            {
                Lama.log("ERROR", "[ConfigServ]Unable to save dedicated : " + er.Message);
                Lama.onError(this, "Error", "Unable to save dedicated\n" + er.Message + "\n" + er.StackTrace);
            }
        }

        void saveMatchSettings()
        {
            var root = this.matchSettings[0];
            root.deleteAllChildLike("map");
            foreach(string map in l_mapsMatch.Items)
            {
                string path = mapFiles[map];
                path = subsep(path, "Maps\\");
                root.addChild("map").addChild("file", path);

                

                if (root.isChildExist("mode_script_settings"))
                {
                    var modscript = root["mode_script_settings"];
                    modscript.deleteAllChildLike("setting");
                    //TimeLimit
                    int time = (int)((n_time_h.Value * 60 * 60) + (n_time_m.Value * 60) + n_time_s.Value);
                    modscript.addChild("setting").addAttribute("name", "S_TimeLimit")
                                                 .addAttribute("type", "integer")
                                                 .addAttribute("value", time.ToString());
                    //WarmUp Duration
                    time = (int)((n_warm_h.Value * 60 * 60) + (n_warm_m.Value * 60) + n_warm_s.Value);
                    modscript.addChild("setting").addAttribute("name", "S_WarmUpDuration")
                                                 .addAttribute("type", "integer")
                                                 .addAttribute("value", time.ToString());
                    //WarmUp Nb
                    modscript.addChild("setting").addAttribute("name", "S_WarmUpDuration")
                                                 .addAttribute("type", "integer")
                                                 .addAttribute("value", n_nbwarm.Value.ToString());
                    //ForceLapsNb
                    modscript.addChild("setting").addAttribute("name", "S_WarmUpDuration")
                                                 .addAttribute("type", "integer")
                                                 .addAttribute("value", n_forcelaps.Value.ToString());

                }
            }

            this.matchSettings.save();
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Methodes UI /////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void b_save_Click(object sender, EventArgs e)
        {
            Lama.mainConfig.save();
            saveMain();
            saveDedicated();
            saveMatchSettings();
            this.Close();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            l_mapsLocal.Items.Clear();
            DirectoryInfo dir = new DirectoryInfo(serverPath + @"UserData\" + e.Node.FullPath);
            foreach (FileInfo file in dir.EnumerateFiles())
            {
                l_mapsLocal.Items.Add(file.Name);
                if (!mapFiles.ContainsValue(file.FullName))
                {
                    try
                    {
                        mapFiles.Add(file.Name, file.FullName);
                    }
                    catch (Exception err) {
                      
                    }
                }
            }
        }

        private void b_add_Click(object sender, EventArgs e)
        {
            if (!l_mapsMatch.Items.Contains(l_mapsLocal.SelectedItem))
            {
                l_mapsMatch.Items.Add(l_mapsLocal.SelectedItem);
            }
            
        }

        private void flatButton1_Click(object sender, EventArgs e)
        {
            if(l_mapsMatch.SelectedIndex >= 0)
                l_mapsMatch.Items.RemoveAt(l_mapsMatch.SelectedIndex);
        }

        private void b_addAll_Click(object sender, EventArgs e)
        {
            foreach(var map in l_mapsLocal.Items)
            {
                if (!l_mapsMatch.Items.Contains(map))
                {
                    l_mapsMatch.Items.Add(map);
                }
            }
        }

        private void b_clearMapMatch_Click(object sender, EventArgs e)
        {
            l_mapsMatch.Items.Clear();
        }

        private void b_cancel_Click(object sender, EventArgs e)
        {
            this.config = null;
            this.matchSettings = null;
            this.dedicated_config = null;
            this.Close();
        }
    }
}
