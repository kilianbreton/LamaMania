﻿/* ----------------------------------------------------------------------------------
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
using static LamaMania.StaticMethods;
using LamaLang;
using LamaPlugin;

namespace LamaMania
{
    /// <summary>
    /// Server configuration
    /// </summary>
    public partial class ConfigServ : Form
    {
        private XmlNode serverConfig; //View to server config in main Lama config
        private XmlDocument dedicated_config;
        private string serverPath;
        private string mapPath;
        private XmlDocument matchSettings;
        private Dictionary<string, string> mapFiles = new Dictionary<string, string>();
        private int index;
        private string title; //Save title for change check

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Constructeurs ///////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
      
        /// <summary>
        /// New Local Server called by NewServer
        /// </summary>
        public ConfigServ(string name)
        {
            InitializeComponent();
            this.index = Lama.mainConfig[0]["servers"].count();
            this.serverPath = @"Servers\" + index + @"\";

            loadLang();

            //Make server-----------------------------------------------------------------
            Directory.CreateDirectory(this.serverPath);
            DirectoryInfo mps = new DirectoryInfo(@"Ressources\mps\");
            copyDirectory(mps, this.serverPath);
            this.mapPath = serverPath + @"UserData\Maps\";

            //MakeConfig------------------------------------------------------------------
            this.serverConfig = Lama.mainConfig[0]["servers"].addChild("server").addAttribute("id", index.ToString());
            XmlNode root = this.serverConfig;
            root.addChild("name", name);
            root.addChild("internetServer", "true");
            root.addChild("matchSettings");

            XmlNode remote = root.addChild("remote").addAttribute("value", "false");
            remote.addChild("ip", "");
            remote.addChild("port","");
            remote.addChild("login","");

            root.addChild("plugins");
            Lama.mainConfig.save(false);

            loadPlugins();
            loadDedicated();
            loadScript();
            loadMain();
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
            this.mapPath = serverPath + @"UserData\Maps\";
            this.index = index;
            this.serverConfig = Lama.mainConfig[0]["servers"].getChildsByAttribute("id", this.index.ToString())[0];
            if (Lama.lang != null)
                loadLang();

            this.tb_name.Text = this.serverConfig["name"].Value;

            loadPlugins();
            loadDedicated();
            loadScript();
            loadMain();
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
            tb_matchFile.Text = this.serverConfig["matchSettings"].Value;
            ch_internetServer.Checked = (this.serverConfig["internetServer"].Value.ToUpper().Equals("TRUE"));
            if(tb_matchFile.Text.Trim(' ') != "")
            {
                loadMatchSettings(this.serverPath + @"\UserData\Maps\" + tb_matchFile.Text);
            }
            else
            {
                this.matchSettings = new XmlDocument(this.serverPath + @"\UserData\Maps\MatchSettings\Default.txt");
            }
            //manage Plugins checked
        }

        void loadPlugins()
        {
            //Load ConfigServPlugins
            if (Lama.tabPlugins != null)
            {
                checkedListBox1.Items.Clear();
                foreach (TabPlugin plugin in Lama.tabPlugins)
                {
                    if (plugin.IsConfigServPlugin)
                    {
                        Control ctrl = plugin.getTab();
                        TabPage tp = new TabPage(plugin.Name);
                        tp.Controls.Add(ctrl);
                        ctrl.Dock = DockStyle.Fill;
                        flatTabControl1.TabPages.Add(tp);
                    }
                }
            }
            //Load InGamePlugins List
            if (Lama.inGamePlugins != null)
            {
                checkedListBox1.Items.Clear();
                foreach (BasePlugin plugin in Lama.inGamePlugins)
                {
                    checkedListBox1.Items.Add(plugin.Name);
                }
            }
        }

        void loadDedicated()
        {
            this.dedicated_config = new XmlDocument(serverPath + @"UserData\Config\dedicated_cfg.txt", true, true);
            
            XmlNode root = this.dedicated_config[0];  //dedicated

            //Authorisations --------------------------------------------------------------------------
            XmlNode auth = root["authorization_levels"];
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
            XmlNode master = root["masterserver_account"];
            tb_serverLogin.Text = master["login"].Value;
            tb_ServerPass.Text = master["password"].Value;
            tb_validKey.Text = master["validation_key"].Value;

            //Server Options --------------------------------------------------------------------------
            XmlNode servOptions = root["server_options"];
            tb_ingameName.Text = servOptions["name"].Value;
            tb_description.Text = servOptions["comment"].Value;
            cb_hiddenServer.SelectedIndex = (int)servOptions["hide_server"].LValue;
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
            XmlNode systemConfig = root["system_config"];

            n_UpRate.Value = systemConfig["connection_uploadrate"].LValue;
            n_DownRate.Value = systemConfig["connection_downloadrate"].LValue;
            n_paThreadCount.Value = systemConfig["packetassembly_threadcount"].LValue;
            n_p2pCacheSize.Value = systemConfig["p2p_cache_size"].LValue;

            tb_ServerPort.Text = systemConfig["server_port"].Value;
            tb_p2pPort.Text = systemConfig["server_p2p_port"].Value;
            tb_XmlRpcPort.Text = systemConfig["xmlrpc_port"].Value;
            tb_proxy.Text = systemConfig["proxy_url"].Value;

            ch_xmlRpcRemote.Checked = systemConfig["xmlrpc_allowremote"].BValue;
            ch_proxy.Checked = systemConfig["use_proxy"].BValue;
            ch_allowSpecRelay.Checked = systemConfig["allow_spectator_relays"].BValue;

            tb_title.Text = systemConfig["title"].Value;
            this.title = tb_title.Text;
        }

        /// <summary>
        /// Load scripts list
        /// </summary>
        void loadScript()
        {
            cb_gameMode.Items.Clear();
            string scriptLocation = this.serverPath + @"GameData\Scripts\Modes\";
            if (tb_title.Text.Length > 3)
            {
                if (tb_title.Text.Contains("SM"))
                {
                    scriptLocation += @"ShootMania\";
                }
                else if (tb_title.Text.Contains("TM"))
                {
                    scriptLocation += @"TrackMania\";
                }
                else
                {
                    LamaDialog d = new LamaDialog("Select game", "Unknow title : " + tb_title.Text + "\n Please select game :", FlatUITheme.FlatAlertBox._Kind.Info, LamaSpecialButtons.GameSlect);
                    DialogResult r = d.ShowDialog();
                    if(r == DialogResult.OK)
                    {
                        scriptLocation += @"TrackMania\";
                    }
                    else
                    {
                        scriptLocation += @"ShootMania\";
                    }
                }
            }
            IEnumerable<string> lst = Directory.EnumerateFiles(scriptLocation);
            foreach (string file in lst)
            {
                cb_gameMode.Items.Add(subsep(file, scriptLocation, ".Script"));
            }
        }

        void loadMatchSettings(string path)
        {
            this.matchSettings = new XmlDocument(path, true, true);
            //Mode Script-------------------------------------------------
            try
            {
                cb_gameMode.Text = subsep(this.matchSettings["playlist"]["gameinfos"]["script_name"].Value, 0, ".Script");
            }
            catch (Exception e)
            {
                Lama.log("ERROR", "Unable to load script name from matchSettings ! :\n" + e.Message);
            }

            //Map Playlist------------------------------------------------
            this.mapFiles.Clear();
            this.l_mapsMatch.Items.Clear();
            XmlNode root = this.matchSettings["playlist"];

            foreach(XmlNode map in root.getChildList("map"))
            {
                string mpath = this.mapPath + map["file"].Value;
                l_mapsMatch.Items.Add(Path.GetFileName(mpath));
                mapFiles.Add(Path.GetFileName(mpath), Path.GetFullPath(mpath));
            }
            //Script Settings-----------------------------------------------
            foreach(XmlNode setting in root["mode_script_settings"].getChildList("setting"))
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
            makeTreeview(new DirectoryInfo(mapPath), treeView1.Nodes.Add("Maps"));
        }
       
        //Save -----------------------------------------------------------------------------------------------------------

        void saveMain()
        {
            this.serverConfig["matchSettings"].Value = tb_matchFile.Text;
            this.serverConfig["name"].Value = tb_name.Text;
            this.serverConfig["internetServer"].Value = ch_internetServer.Checked.ToString();

            //Save Plugin List
            Lama.mainConfig.save(false);
        }

        void saveDedicated()
        {
            try
            {
                XmlNode root = this.dedicated_config[0];  //dedicated

                //Authorisations --------------------------------------------------------------------------
                XmlNode auth = root["authorization_levels"];
                foreach (XmlNode lvl in auth.getChildList("level"))
                {
                    switch (lvl["name"].Value)
                    {
                        case "SuperAdmin":
                            lvl["password"].Value = tb_superPass.Text;
                            break;

                        case "Admin":
                            lvl["password"].Value = tb_adminPass.Text;
                            break;

                        case "User":
                            lvl["password"].Value = tb_userPass.Text;
                            break;
                    }
                }

                //Master Account --------------------------------------------------------------------------
                XmlNode master = root["masterserver_account"];
                master["login"].Value = tb_serverLogin.Text;
                master["password"].Value = tb_ServerPass.Text;
                master["validation_key"].Value = tb_validKey.Text;


                //Server Options --------------------------------------------------------------------------
                XmlNode servOptions = root["server_options"];
                servOptions["name"].Value = tb_ingameName.Text;
                servOptions["comment"].Value = tb_description.Text;
                servOptions["hide_server"].Value = cb_hiddenServer.SelectedIndex.ToString();
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
                XmlNode systemConfig = root["system_config"];

                systemConfig["connection_uploadrate"].Value = n_UpRate.Value.ToString();
                systemConfig["connection_downloadrate"].Value = n_DownRate.Value.ToString();
                systemConfig["packetassembly_threadcount"].Value = n_paThreadCount.Value.ToString();

                systemConfig["allow_spectator_relays"].Value = ch_allowSpecRelay.Checked.ToString();

                systemConfig["p2p_cache_size"].Value = n_p2pCacheSize.Value.ToString();
                
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
            XmlNode root = this.matchSettings[0];
            root.deleteAllChildLike("map");
            foreach(string map in l_mapsMatch.Items)
            {
                string path = mapFiles[map];
                path = subsep(path, "\\Maps\\");
                root.addChild("map").addChild("file", path);
            }

            if (!root.isChildExist("mode_script_settings"))
            {
                root.addChild("mode_script_settings");
            }
            XmlNode modscript = root["mode_script_settings"];
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

            if (!root.isChildExist("gameinfos"))
            {
                root.addChild("gameinfos");
            }

            XmlNode gameInfos = root["gameinfos"];
            gameInfos["script_name"].Value = cb_gameMode.Text + ".Script.txt";

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
                    try
                    {
                        mapFiles.Add(file.Name, subsep(file.FullName, @"\Maps\"));
                    }
                    catch (Exception) {
                      
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
            foreach(string map in l_mapsLocal.Items)
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
            this.serverConfig = null;
            this.matchSettings = null;
            this.dedicated_config = null;
            this.Close();
        }

        private void b_newMatch_Click(object sender, EventArgs e)
        {
            string file = tb_matchFile.Text;
            string path = mapPath + @"MatchSettings\" + file;
            if (!File.Exists(path))
            {
                try
                {
                    File.Create(path).Close();
                    this.matchSettings = new XmlDocument(path);
                }
                catch(Exception er)
                {
                    Lama.onException(this, er);
                }
            }
            else
            {
                Lama.onError(this, "Error", "The file : " + file + " already exists !");
            }
        }

        private void b_browseMatch_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                InitialDirectory = this.mapPath + @"MatchSettings\"
            };
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                tb_matchFile.Text = ofd.FileName;
                loadMatchSettings(ofd.FileName);
            }

        }

        private void flatTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(flatTabControl1.SelectedTab == tp_match && this.title != tb_title.Text)
            {
                this.title = tb_title.Text;
                loadScript();
            }
        }
    }
}