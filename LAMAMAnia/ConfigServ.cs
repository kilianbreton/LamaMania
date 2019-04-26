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
        //Name ex : 01, 02, 03 ...

        private XmlDocument config;
        private XmlDocument dedicated_config;
        private string serverPath;
        private string configPath;
        private XmlDocument matchSettings;
        private Dictionary<string, string> mapFiles = new Dictionary<string, string>();


        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Constructeurs ///////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// New server
        /// </summary>
        public ConfigServ()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Edit server
        /// </summary>
        /// <param name="index"></param>
        public ConfigServ(string index)
        {
            InitializeComponent();
            this.serverPath = @"Servers\" + index + @"\";
            this.configPath = @"Config\Servers\" + index + ".xml";

            if (Config.lang != null)
                loadLang();

            loadPlugins();
            loadMain();
            loadDedicated();
            loadMaps();
           
        }
        
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Methodes ////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////


        void loadLang()
        {
        }

        void loadMain()
        {
            this.config = new XmlDocument(configPath);
            tb_matchFile.Text = this.config.getNode(0).getChildV("matchSettings");
            if(tb_matchFile.Text != "")
            {
                loadMatchSettings(this.serverPath + @"\UserData\Maps\MatchSettings\" + tb_matchFile.Text);
            }
            //manage Plugins checked
        }

        void loadPlugins()
        {
            //Load Plugins List
            if (Config.plugins != null)
            {
                foreach (BasePlugin plugin in Config.plugins)
                {
                    checkedListBox1.Items.Clear();
                    checkedListBox1.Items.Add(plugin.getPlugin);
                }
            }
        }

        void loadDedicated()
        {
            this.dedicated_config = new XmlDocument(serverPath + @"UserData\Config\dedicated_cfg.txt");
            var root = this.dedicated_config.getNode(0);  //dedicated

            //Authorisations --------------------------------------------------------------------------
            var auth = root.getChild("authorization_levels");
            foreach (XmlNode n in auth.getChildList("level"))
            {
                switch (n.getChildV("name"))
                {
                    case "SuperAdmin":
                        tb_superPass.Text = n.getChildV("password");
                        break;

                    case "Admin":
                        tb_adminPass.Text = n.getChildV("password");
                        break;

                    case "User":
                        tb_userPass.Text = n.getChildV("password");
                        break;
                }
            }

            //Master Account --------------------------------------------------------------------------
            var master = root.getChild("masterserver_account");
            tb_serverLogin.Text = master.getChildV("login");
            tb_ServerPass.Text = master.getChildV("password");
            tb_validKey.Text = master.getChildV("validation_key");

            //Server Options --------------------------------------------------------------------------
            var servOptions = root.getChild("server_options");
            tb_ingameName.Text = servOptions.getChildV("name");
            tb_description.Text = servOptions.getChildV("comment");
            tb_playerPass.Text = servOptions.getChildV("password");
            tb_specPass.Text = servOptions.getChildV("password_spectator");
            tb_refereePass.Text = servOptions.getChildV("referee_password");
            tb_voteRatio.Text = servOptions.getChildV("callvote_ratio");

            n_voteTimeout.Value = servOptions.getChildNV("callvote_timeout");
            n_playersLimit.Value = servOptions.getChildNV("max_players");
            n_specsLimit.Value = servOptions.getChildNV("max_spectators");
            n_maxLat.Value = servOptions.getChildNV("clientinputs_maxlatency");

            ch_keepPlayerSlot.Checked = servOptions.getChildBV("keep_player_slots");
            ch_ladder.Checked = (servOptions.getChildV("ladder_mode").Equals("forced"));
            ch_p2pUp.Checked = servOptions.getChildBV("enable_p2p_upload");
            ch_p2pDown.Checked = servOptions.getChildBV("enable_p2p_download");
            ch_mapDown.Checked = servOptions.getChildBV("allow_map_download");
            ch_autoSaveReplay.Checked = servOptions.getChildBV("autosave_replays");
            ch_saveValReplay.Checked = servOptions.getChildBV("autosave_validation_replays");

            cb_refereeValid.SelectedIndex = (int)servOptions.getChildNV("referee_validation_mode");
            ch_horns.Checked = servOptions.getChildBV("disable_horns");

            //System Config --------------------------------------------------------------------------
            var systemConfig = root.getChild("system_config");

            n_UpRate.Value = systemConfig.getChildNV("connection_uploadrate");
            n_DownRate.Value = systemConfig.getChildNV("connection_downloadrate");

            tb_ServerPort.Text = systemConfig.getChildV("server_port");
            tb_p2pPort.Text = systemConfig.getChildV("server_p2p_port");
            tb_XmlRpcPort.Text = systemConfig.getChildV("xmlrpc_port");
            tb_proxy.Text = systemConfig.getChildV("proxy_url");

            ch_xmlRpcRemote.Checked = systemConfig.getChildBV("xmlrpc_allowremote");
            ch_proxy.Checked = systemConfig.getChildBV("use_proxy");


            tb_title.Text = systemConfig.getChildV("title");
        }

        void loadMatchSettings(string path)
        {
            this.matchSettings = new XmlDocument(path);
            var root = this.matchSettings.getNode(0);

            foreach(XmlNode map in root.getChildList("map"))
            {
                l_mapsMatch.Items.Add(Path.GetFileName(map.getChildV("file")));
            }
            foreach(XmlNode setting in root.getChild("mode_script_settings").getChildList("setting"))
            {
                switch (setting.getAttibuteV("name"))
                {
                    case "S_TimeLimit":
                        int time = int.Parse(setting.getAttibuteV("value"));

                        int h, m, s;
                        parseTime(time, out h, out m, out s);

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
                        parseTime(timew, out hw, out mw, out sw);

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

        void parseTime(int time, out int h, out int m, out int s)
        {
            h = 0;
            m = 0;
            s = 0;
            while (time > 60)
            {
                time = time - 60;
                if(++m == 60)
                {
                    m = 0;
                    h++;
                }
            }
            s = time;
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
            this.config.getNode(0).getChild("matchSettings").setValue(tb_matchFile.Text);
            //Save Plugin List
            this.config.save();
        }

        void saveDedicated()
        {
            try
            {
                var root = this.dedicated_config.getNode(0);  //dedicated

                //Authorisations --------------------------------------------------------------------------
                var auth = root.getChild("authorization_levels");
                foreach (XmlNode n in auth.getChildList("level"))
                {
                    switch (n.getChildV("name"))
                    {
                        case "SuperAdmin":
                            n.getChild("password").setValue(tb_superPass.Text);
                            break;

                        case "Admin":
                            n.getChild("password").setValue(tb_adminPass.Text);
                            break;

                        case "User":
                            n.getChild("password").setValue(tb_userPass.Text);
                            break;
                    }
                }

                //Master Account --------------------------------------------------------------------------
                var master = root.getChild("masterserver_account");
                master.getChild("login").setValue(tb_serverLogin.Text);
                master.getChild("password").setValue(tb_ServerPass.Text);
                master.getChild("validation_key").setValue(tb_validKey.Text);


                //Server Options --------------------------------------------------------------------------
                var servOptions = root.getChild("server_options");
                servOptions.getChild("name").setValue(tb_ingameName.Text);
                servOptions.getChild("comment").setValue(tb_description.Text);
                servOptions.getChild("password").setValue(tb_playerPass.Text);
                servOptions.getChild("password_spectator").setValue(tb_specPass.Text);
                servOptions.getChild("referee_password").setValue(tb_refereePass.Text);
                servOptions.getChild("callvote_ratio").setValue(tb_voteRatio.Text);

                servOptions.getChild("callvote_timeout").setValue(n_voteTimeout.Value.ToString());
                servOptions.getChild("max_players").setValue(n_playersLimit.Value.ToString());
                servOptions.getChild("max_spectators").setValue(n_specsLimit.Value.ToString());
                servOptions.getChild("clientinputs_maxlatency").setValue(n_maxLat.Value.ToString());

                servOptions.getChild("keep_player_slots").setValue(ch_keepPlayerSlot.Checked.ToString());

                if (ch_ladder.Checked)
                    servOptions.getChild("ladder_mode").setValue("forced");
                else
                    servOptions.getChild("ladder_mode").setValue("incative");

                servOptions.getChild("enable_p2p_upload").setValue(ch_p2pUp.Checked.ToString());
                servOptions.getChild("enable_p2p_download").setValue(ch_p2pDown.Checked.ToString());
                servOptions.getChild("allow_map_download").setValue(ch_mapDown.Checked.ToString());
                servOptions.getChild("autosave_replays").setValue(ch_autoSaveReplay.Checked.ToString());
                servOptions.getChild("autosave_validation_replays").setValue(ch_saveValReplay.Checked.ToString());

                servOptions.getChild("referee_validation_mode").setValue(cb_refereeValid.SelectedIndex.ToString());
                servOptions.getChild("disable_horns").setValue(ch_horns.Checked.ToString());


                //System Config --------------------------------------------------------------------------
                var systemConfig = root.getChild("system_config");

                systemConfig.getChild("connection_uploadrate").setValue(n_UpRate.Value.ToString());
                systemConfig.getChild("connection_downloadrate").setValue(n_DownRate.Value.ToString());

                systemConfig.getChild("server_port").setValue(tb_ServerPort.Text);
                systemConfig.getChild("server_p2p_port").setValue(tb_p2pPort.Text);
                systemConfig.getChild("xmlrpc_port").setValue(tb_XmlRpcPort.Text);
                systemConfig.getChild("proxy_url").setValue(tb_proxy.Text);

                systemConfig.getChild("xmlrpc_allowremote").setValue(ch_xmlRpcRemote.Checked.ToString());
                systemConfig.getChild("use_proxy").setValue(ch_proxy.Checked.ToString());


                systemConfig.getChild("title").setValue(tb_title.Text);
                this.dedicated_config.save();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.ToString());

            }
        }

        void saveMatchSettings()
        {
            var root = this.matchSettings.getNode(0);
            root.deleteAllChildLike("map");
            foreach(string map in l_mapsMatch.Items)
            {
                string path = mapFiles[map];
                path = subsep(path, "Maps\\");
                root.addChild("map").addChild("file", path);

                

                if (root.isChildExist("mode_script_settings"))
                {
                    var modscript = root.getChild("mode_cript_settings");
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
                    mapFiles.Add(file.Name, file.FullName);
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

      
    }
}
