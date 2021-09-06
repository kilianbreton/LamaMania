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
using static LamaMania.StaticMethods;
using static LamaMania.Program;

using LamaPlugin;
using GBXMapParser;
using LamaMania.UserConstrols;

namespace LamaMania
{
    /// <summary>
    /// Server configuration
    /// </summary>
    public partial class ConfigServ : Form
    {
        private XmlNode serverConfig; //View on server config in main Lama config
        private XmlDocument dedicated_config;
        private string serverPath;
        private string mapPath;
        private XmlDocument matchSettings;
        private Dictionary<string, string> mapFiles = new Dictionary<string, string>();
        private int index;
        private string title; //Save title for check change
        private string serverType;

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Constructeurs ///////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
      
        /// <summary>
        /// New Local Server, called by NewServer
        /// </summary>
        public ConfigServ(int index, string serverPath, string mapPath, XmlNode serverConfig)
        {
            InitializeComponent();


            this.index = index;
            this.serverPath = serverPath;
            this.mapPath = mapPath;
            this.serverConfig = serverConfig;
         
            
            loadDedicated();
            loadScriptList();
            loadMain();
            loadMaps();

            lama.mainConfig.save();
        }

        /// <summary>
        /// Edit Local Server
        /// </summary>
        /// <param name="index"></param>
        /// <param name="name"></param>
        public ConfigServ(int index, string name)
        {
            InitializeComponent();
            lama.log("NOTICE", "ConfigServ in Edit mode");
            this.serverPath = @"Servers\" + index + @"\";
            this.mapPath = this.serverPath + @"UserData\Maps\";
            this.index = index;
            //     this.serverConfig = lama.mainConfig[0]["servers"].getChildByAttribute("id", this.index.ToString());

            foreach (XmlNode n in Program.lama.mainConfig[0]["servers"].Childs)
            {
                if (n["name"].Value == name)
                {
                    this.serverConfig = n;
                    break;
                }
            }
            this.tb_name.Text = this.serverConfig["name"].Value;
            this.serverType = this.serverConfig.getAttibuteV("type");

            //this.flp_matchSettings.Controls.Add(new UserConstrols.DoubleMatchSetting("test", "testtitle", 0.2d));

            lama.pluginManager.loadConfigServ(flatTabControl1.TabPages, checkedListBox1.Items, this.getConfigValue);
            
            loadDedicated();
            loadScriptList();
            loadMain();
            loadMaps();
            initMatchSettings();
        }

      
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Methodes ////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        void loadLang()
        {
     //       NodeLang cs = lama.lang["ConfigServ"];

        //    NodeLang general = cs["General"];
       //     this.ch_horns.Text = general["horns"].Value;


        }

        void initMatchSettings()
        {
            XmlDocument xmld = new XmlDocument("Ressources\\Config\\MatchSettings.xml");
            XmlNode root = xmld[0];
            foreach(XmlNode n in root["All"].Childs)
            {
                loadOneMatchSetting(n);
            }

            if(tb_title.Text.ToUpper().IndexOf("SM") == 0)
            {
                XmlNode smAll = root["ShootMania"]["All"];
                foreach (XmlNode n in smAll.Childs)
                {
                    loadOneMatchSetting(n);
                }

                if(tb_title.Text.Contains("SMStorm"))
                {
                    string mode = tb_title.Text.Substring(7, tb_title.Text.Length - 7);
                    List<XmlNode> tl = (from n in root["ShootMania"].Childs where n.Name.Contains(mode) select n).ToList();
                    foreach(XmlNode spmode in tl) //Pour chaque sous-mode
                    {
                        foreach(XmlNode node in spmode)
                        {
                            loadOneMatchSetting(node);
                        }
                    }
                }
            }
            else
            {
                if (tb_title.Text.ToUpper().IndexOf("TM") == 0)
                {

                }
                else
                {
                    MessageBox.Show("Le titre ne coresspond à aucun jeu");
                }
            }
        }

        void loadOneMatchSetting(XmlNode n)
        {
            double val = 0;
            string baseVal = n.getAttibuteV("defVal");
            if (double.TryParse(baseVal, out val))
            {
                DoubleMatchSetting d = new DoubleMatchSetting(n.getAttibuteV("name"), n.getAttibuteV("name"), val);
                this.flp_matchSettings.Controls.Add(d);
            }
            else
            {
                if (baseVal.ToUpper() == "TRUE" || baseVal.ToUpper() == "FALSE")
                {
                    BoolMatchSetting b = new BoolMatchSetting(n.getAttibuteV("name"), n.getAttibuteV("name"), (baseVal.ToUpper() == "TRUE"));
                    this.flp_matchSettings.Controls.Add(b);
                }
                else
                {
                    StringMatchSetting s = new StringMatchSetting(n.getAttibuteV("name"), n.getAttibuteV("name"), baseVal);
                    this.flp_matchSettings.Controls.Add(s);
                }
            }
        }



        void loadMain()
        {
            lama.log("NOTICE", "Load Main config");
            
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

            //Database
            XmlNode db = this.serverConfig["database"];
            tb_db_ip.Text = db["ip"].Value;
            tb_db_login.Text = db["login"].Value;
            tb_db_passwd.Text = db["passwd"].Value;
            tb_db_base.Text = db["baseName"].Value;

        }

        void loadDedicated()
        {
            lama.log("NOTICE", "Load Dedicated config");
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
            if (this.serverType != "TM3")
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
            if(this.serverType != "TM3")
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


            //Color empty required fields
            Tb_serverLogin_TextChanged(this, null);
            Tb_ServerPass_TextChanged(this, null);
            Tb_validKey_TextChanged(this, null);

        }

        void loadScriptList()
        {
            lama.log("NOTICE", "Load script list");
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
            lama.log("NOTICE", "Load matchSettings");
            this.matchSettings = new XmlDocument(path, true, true);
            //Mode Script-------------------------------------------------
            try
            {
                cb_gameMode.Text = subsep(this.matchSettings["playlist"]["gameinfos"]["script_name"].Value, 0, ".Script");
            }
            catch (Exception e)
            {
                lama.log("ERROR", "Unable to load script name from matchSettings ! :\n" + e.Message);
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
      /*      foreach(XmlNode setting in root["mode_script_settings"].getChildList("setting"))
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
            }*/

        }

        void loadMaps()
        {
            lama.log("NOTICE", "Load maps folder");
            makeTreeview(new DirectoryInfo(mapPath), treeView1.Nodes.Add("Maps"));
        }
       
        //Save -----------------------------------------------------------------------------------------------------------

        void saveMain()
        {
            lama.log("NOTICE", "Save Main config");
            this.serverConfig["matchSettings"].Value = tb_matchFile.Text;
            this.serverConfig["name"].Value = tb_name.Text;
            this.serverConfig["internetServer"].Value = ch_internetServer.Checked.ToString();

            //Save Plugin List
            XmlNode pluginList = this.serverConfig["plugins"];
            pluginList.Childs.Clear();

            foreach (string pl in checkedListBox1.CheckedItems)
            {
                pluginList.addChild("plugin", pl);
            }

            this.serverConfig["database"]["ip"].Value = tb_db_ip.Text;
            this.serverConfig["database"]["login"].Value = tb_db_login.Text;
            this.serverConfig["database"]["passwd"].Value = tb_db_passwd.Text;
            this.serverConfig["database"]["baseName"].Value = tb_db_base.Text;
                                   
            lama.mainConfig.save(false);
        }

        void saveDedicated()
        {
            lama.log("NOTICE", "Save Dedicated");
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
                lama.log("ERROR", "[ConfigServ]Unable to save dedicated : " + er.Message);
                lama.onError(this, "Error", "Unable to save dedicated\n" + er.Message + "\n" + er.StackTrace);
            }
        }

        void saveMatchSettings()
        {
            lama.log("NOTICE", "Save matchSettings");
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
         /*   int time = (int)((n_time_h.Value * 60 * 60) + (n_time_m.Value * 60) + n_time_s.Value);
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
*/
            if (!root.isChildExist("gameinfos"))
            {
                root.addChild("gameinfos");
            }

            XmlNode gameInfos = root["gameinfos"];
            gameInfos["script_name"].Value = cb_gameMode.Text + ".Script.txt";

            this.matchSettings.save();
        }

        //Used by plugins
        object getConfigValue(ITab sender, string inputName)
        {
            object value = null;
            switch (inputName)
            {
                case "Name":
                    value = tb_name.Text;
                    break;
                case "Title":
                    value = tb_title.Text;
                    break;
                case "InGameName":
                    value = tb_ingameName.Text;
                    break;
                case "Description":
                    value = tb_description.Text;
                    break;
                case "PlayerPassword":
                    value = tb_playerPass.Text;
                    break;
                case "SpecPassword":
                    value = tb_specPass.Text;
                    break;
                case "PlayersLimit":
                    value = n_playersLimit.Value;
                    break;
                case "SpecLimit":
                    value = n_specsLimit.Value;
                    break;
                case "ServerLogin":
                    value = tb_serverLogin.Text;
                    break;
                case "ServerPassword":
                    value = tb_ServerPass.Text;
                    break;
                case "ValidationKey":
                    value = tb_validKey.Text;
                    break;
                case "SuperAdmin":
                    value = tb_superPass.Text;
                    break;
                case "Admin":
                    value = tb_adminPass.Text;
                    break;
            }
            return value;
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
            try { 
                l_mapsLocal.Items.Clear();
                DirectoryInfo dir = new DirectoryInfo(serverPath + @"UserData\" + e.Node.FullPath);
                foreach (FileInfo file in dir.EnumerateFiles())
                {
                    l_mapsLocal.Items.Add(file.Name);
                    if (!mapFiles.ContainsKey(file.Name))
                    {
                        try
                        {
                            //mapFiles.Add(file.Name, subsep(file.FullName, @"\Maps\"));
                            mapFiles.Add(file.Name, file.FullName);
                        }
                        catch (Exception err) {
                            lama.log("ERROR", "[ConfigServ][TreeViewAfterSelect] PathParse error : " + err.Message);
                        }
                    }
                }
            }
            catch (Exception err)
            {
                lama.log("ERROR", "[ConfigServ][TreeViewAfterSelect] Load error : " + err.Message);
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
                    lama.onException(this, er);
                }
            }
            else
            {
                lama.onError(this, "Error", "The file : " + file + " already exists !");
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
                loadScriptList();
            }
        }

        private void l_mapsMatch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                mapSelected(l_mapsMatch.Items[l_mapsMatch.SelectedIndex].ToString());
            }
            catch(Exception ex)
            {
                Program.lama.log("ERROR", "[ConfigServ.L_mapsMatchSelectedChanged]"+ex.Message);
            }
        }

        private void l_mapsLocal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(l_mapsLocal.SelectedIndex >= 0)
                mapSelected(l_mapsLocal.Items[l_mapsLocal.SelectedIndex].ToString());
        }

        void mapSelected(string name)
        {
            try
            {
                MapInformation mi = MapParser.ReadFile(mapFiles[name]);
                MemoryStream mStream = new MemoryStream();

                mStream.Write(mi.Thumbnail, 0, Convert.ToInt32(mi.Thumbnail.Length));

                Bitmap bm = new Bitmap(mStream, false);
                bm.RotateFlip(RotateFlipType.Rotate180FlipX);

                this.pictureBox1.Image = bm;
            }
            catch (Exception er)
            {

                lama.log("ERROR", "[ConfigServ][MapSelect]>" + er.Message);
            }
        }

        private void Tb_serverLogin_TextChanged(object sender, EventArgs e)
        {
            if (tb_serverLogin.Text == "")
                flatLabel3.ForeColor = Color.Red;
            else
                flatLabel3.ForeColor = Color.White;
        }

        private void Tb_ServerPass_TextChanged(object sender, EventArgs e)
        {
            if (tb_ServerPass.Text == "")
                flatLabel4.ForeColor = Color.Red;
            else
                flatLabel4.ForeColor = Color.White;
        }

        private void Tb_validKey_TextChanged(object sender, EventArgs e)
        {
            if (tb_validKey.Text == "")
                flatLabel5.ForeColor = Color.Red;
            else
                flatLabel5.ForeColor = Color.White;
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string pn = (string) checkedListBox1.SelectedItem;
            IBasePlugin p = getPluginByName(pn);
            this.richTextBox1.Text = p.PluginDescription;



        }
    }
}