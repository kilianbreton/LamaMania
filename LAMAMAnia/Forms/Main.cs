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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using TMXmlRpcLib;
using NTK.IO.Xml;
using NTK.IO;
using LamaPlugin;
using FlatUITheme;
using GBXMapParser;
using LamaMania.UserConstrols;
using static NTK.Other.NTKF;
using static LamaMania.StaticMethods;
using static LamaPlugin.GBXMethods;


namespace LamaMania
{
    /// <summary>
    /// Main form controller
    /// </summary>
    public partial class Main : Form
    {
        #region "Attributes"
        private const int TRY_AUTH_NB = 5;
        private const int WAIT_AUTH_TIME = 1500;

        private XmlDocument dedicatedConfig;
        private XmlRpcClient client;
        private string adrs = "127.0.0.1";
        private int port = 5000;
        private string login;
        private string passwd;
        private ManiaColors chatColors;
        private Dictionary<int, String> handles = new Dictionary<int, string>();


        private Dictionary<string, string> mapFiles = new Dictionary<string, string>();
        private string mapPath;

        private List<string> chatSends = new List<string>();
        private int curIndexChatSends = -1;

        private Dictionary<string, string> scriptSettingsTitles;

        private CallbacksManager callbacks = new CallbacksManager();


        #endregion

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Constructeurs ///////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        #region "Constructors"

        /// <summary>
        /// Test UI constructor
        /// </summary>
        public Main()
        {
            InitializeComponent();
        }
            
        /// <summary>
        /// Start main with dedicated_cfg
        /// </summary>
        /// <param name="config"></param>
        public Main(XmlDocument config)
        {
            InitializeComponent();
           

            this.dedicatedConfig = config;
            this.chatColors = new ManiaColors(richTextBox1);

            Program.lama.log("NOTICE", "Open Main Form");
               
            //Parse base config-----------------------------------------------------------------------------------
            XmlNode root = config[0];
            XmlNode auth = root["authorization_levels"];

            int ncpt = 0;
            while(ncpt < auth.Childs.Count && auth[ncpt]["name"].Value != "SuperAdmin"){ ncpt++; }
            if(ncpt < auth.Childs.Count && auth[ncpt]["name"].Value == "SuperAdmin")
            {
                this.login = "SuperAdmin";
                this.passwd = auth[ncpt]["password"].Value;
            }


            this.port = int.Parse(root["system_config"]["xmlrpc_port"].Value);

           // commonConstructor();
        }
        
        /// <summary>
        /// Start main in remote mode
        /// </summary>
        public Main(string login, string pass)
        {
            InitializeComponent();

            this.chatColors = new ManiaColors(richTextBox1);

            Program.lama.log("NOTICE", "Open Main Form");
            this.login = login;
            this.passwd = pass;
            this.adrs = Program.lama.remoteAdrs;
            this.port = Program.lama.remotePort;

         //   commonConstructor();
        }

        /// <summary>
        /// Init and connect to server
        /// </summary>
        /// <returns></returns>
        public async Task commonConstructor()
        {
            Program.lama.log("NOTICE", "XmlRpcConnect");

            await Task.Run(() => { 
                connectXmlRpc();
                if (!Program.lama.remote)
                {
                    Program.lama.pluginManager.onLoadInGame(this.client);
                }
            });

            Program.lama.pluginManager.onLoadHomeComponent(this.client, this.tp_main.getControl<Control>(), false);
            Program.lama.pluginManager.onLoadTabMain(this.client, this.flatTabControl1, false);

            if (Program.lama.connected)
            {
                Program.lama.log("NOTICE", "XmlRPC : Connected");

                //Affichage
                if (!Program.lama.remote)
                {
                    Program.lama.pluginManager.onLoadHomeComponent(this.client, this.tp_main.getControl<Control>(), true);
 
                }

                //Requests
                Program.lama.log("NOTICE", "Send startup requests");
                startupRequests();
                //Init plugins
               
            }
            else
            {
                if (Program.lama.launched)
                {
                    Program.lama.onError(this, "Unable to connect", "Unable to connect to " + this.adrs + ":" + this.port + "\nPlease check server and/or Lama configuration");
                    this.Close();
                }
                else
                {
                    Program.lama.onError(this, "Server exited", "Server exited \nPlease check server logs and configuration");
                    this.Close();
                }
            }
            
        }

        void startupRequests()
        {
            //Chat
            asyncRequest(GetChatLines, getChatLines);

            //Options & GameInfos
            asyncRequest(GetServerOptions, getServerOptions);
            asyncRequest(GetCurrentGameInfo, getCurrentGameInfo);
            
            //Script
            asyncRequest(GetModeScriptSettings, getModeScriptSettings);
            asyncRequest(GetScriptName, getScriptName);

            //Map
            //asyncRequest(GetCurrentMapInfo, getCurr); //Catched by HCGameInfos
            asyncRequest(GetMapsDirectory, getMapDirectory);
            asyncRequest(getMapList, GetMapList, 999, 0);

            //Users lists
            asyncRequest(getPlayerList, GetPlayerList, Program.lama.maxPlayers + Program.lama.maxSpectators, 0);
           /* asyncRequest(getGuestList, GetGuestList, Program.lama.maxPlayers + Program.lama.maxSpectators, 0);
            asyncRequest(GetBanList, Program.lama.maxPlayers + Program.lama.maxSpectators, 0);
            asyncRequest(GetBlackList, Program.lama.maxPlayers + Program.lama.maxSpectators, 0);*/
            
            //Send chat msg
            asyncRequest(checkError, GBXMethods.ChatSendServerMessage, "$o$12d LamaMania V 0.0.1 ....");



            //Callbacks=========================================================================================
            
            GbxCallbackHandler cb_beginMatch = (sender, args) => {
                asyncRequest(GBXMethods.GetCurrentMapIndex, res =>
                {
                    Program.lama.previousMapId = Program.lama.currentMapId;
                    Program.lama.currentMapId = (int)res.Params[0];
                });
            };
            callbacks.AddListener(GBXCallBacks.ManiaPlanet_BeginMap, cb_beginMatch);
            callbacks.AddListener(GBXCallBacks.ManiaPlanet_BeginMatch, cb_beginMatch);
            callbacks.AddListener("TrackMania.BeginRace", cb_beginMatch);
            callbacks.AddListener("TrackMania.BeginChallenge", cb_beginMatch);

            GbxCallbackHandler cb_players = (sender, args) =>
            {
                asyncRequest(getPlayerList, GetPlayerList, Program.lama.maxPlayers + Program.lama.maxSpectators, 0);
            };
            callbacks.AddListener(GBXCallBacks.ManiaPlanet_PlayerConnect, cb_players);
            callbacks.AddListener(GBXCallBacks.ManiaPlanet_PlayerChat, cb_PlayerChat);
        }
      
        #endregion

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Methodes UI /////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

        #region "UI Methods"
       
       
    
        /// <summary>
        /// Clear chat console
        /// </summary>
        void clearConsole()
        {
            if (richTextBox1.InvokeRequired) //Permet de revenir au Thread de gestion des composants UI
            {
                richTextBox1.Invoke(new Action(clearConsole));
            }
            else
            {
                richTextBox1.Clear();
            }
        }
        
        /// <summary>
        /// Write in Chat console [Only for tests, use ManiaColor to write in chat console]
        /// </summary>
        /// <param name="text"></param>
        /// <param name="color"></param>
        void writeConsole(String text, Color color)
        {
            if (richTextBox1.InvokeRequired) //Permet de revenir au Thread de gestion des composants UI
            {
                richTextBox1.Invoke(new Action<String, Color>(writeConsole), text, color);
            }
            else
            {
                richTextBox1.SelectionColor = color;
                if (!string.IsNullOrWhiteSpace(richTextBox1.Text))
                {
                    richTextBox1.AppendText("\r\n" + text);
                }
                else
                {
                    richTextBox1.AppendText(text);
                }
                richTextBox1.ScrollToCaret();
            }
        }
        
        void showOverlayMessage(string title, string text, string type)
        {

        }
     

        #endregion

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Methodes GBX ////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

        #region "GBX Methods"
        void connectXmlRpc()
        {
            int cpt = 0;
            while (cpt++ < TRY_AUTH_NB && !Program.lama.connected && ((!Program.lama.remote && Program.lama.launched) || Program.lama.remote))
            {
                try
                {
                    this.client = new XmlRpcClient(this.adrs, this.port);
                    GbxCall authAnsw = this.client.Request(Authenticate, this.login, this.passwd);
                    if (authAnsw.Params[0].Equals(true)) //Auth success---------------------------------
                    {
                        this.client.EnableCallbacks(true);
                        this.client.EventGbxCallback += new GbxCallbackHandler(gbxCallBack);
                        this.client.EventOnDisconnectCallback += new OnDisconnectHandler(gbxDisconnect);

                        Program.lama.connected = true; //exit loop
                    }
                }
                catch (Exception)
                {
                    System.Threading.Thread.Sleep(WAIT_AUTH_TIME);
                }
            }
        }

        //Requests====================================================================================
  

        void asyncRequest(GbxCallCallbackHandler handler, String methodName, params object[] param)
        {
            if (Program.lama.connected)
            {
                if (param == null)
                    param = new object[] { };
                this.client.AsyncRequest(methodName, param, handler);
            }
        }

        void asyncRequest(String methodName, GbxCallCallbackHandler handler)
        {
            if(Program.lama.connected)
                this.client.AsyncRequest(methodName, new object[] { }, handler);
        }

        //Main Async results==========================================================================
       
        void getMapList(GbxCall res)
        {
            ArrayList maps = res.getArrayList();
            clearDg(dg_map);
            foreach (Hashtable map in maps)
            {
                addDgRow(dg_map, ManiaColors.getText((string)map["Name"]), map["Author"], map["Environnement"], map["LadderRanking"], map["FileName"]);
                //  Program.lama.maps.Add(

                MapInfo m = new MapInfo((string)map["Uid"],
                                        (string)map["Name"],
                                        (string)map["FileName"],
                                        (string)map["Author"],
                                        (string)map["Environnement"]);
                //m.NbCheckpoints = (int)map[""];

            }
        }


        void getCurrentMapIndex(GbxCall res)
        {
            if (Program.lama.currentMapId != -1)
                Program.lama.previousMapId = Program.lama.currentMapId;
            Program.lama.currentMapId = (int)res.Params[0];
        }
        
        void getScriptName(GbxCall res)
        {
            var htscript = res.getHashTable();
            string script = (string)htscript["CurrentValue"];
            if (script.ToLower().Contains(".script.txt"))
            {
                script = subsep(script, 0, ".");
            }
        }

        void getChatLines(GbxCall res)
        {
            clearConsole();
            var al = (ArrayList)res.Params[0];
            foreach (object o in al)
            {
                string als = (string)o;
                if (als.Contains("$>") && als.Contains("$<"))
                {
                    als = delseps(als, "[", "<");
                    als = als.Replace("$>]", "$000 :$fff");
                }
                chatColors.write(als + "\n");
            }
        }

        void getPlayerList(GbxCall res)
        {
            ArrayList userList = (ArrayList)res.Params[0];
            clearDg(dg_users);
            Program.lama.nbPlayers = userList.Count;
            //s setLabel(l_players, "Players : " + Program.lama.nbPlayers + "/" + Program.lama.maxPlayers);
            foreach (Hashtable user in userList)
            {
                Program.lama.players.Add(new Player((string)user["Login"], (string)user["NickName"], (int)user["PlayerId"]));
                addDgRow(dg_users, user["PlayerId"], ManiaColors.getText((string)user["NickName"]), user["Login"], user["LadderRanking"]);
            }
 
        }


        

        //Specific AsyncResult handler
        void checkError(GbxCall res)
        {
            if(res.Error)
            {
                Program.lama.onError(this, "Error", "Error " + res.ErrorCode + " : " + res.ErrorString + "\n from request : " + res.MethodName);
            }
        }

        void getServerOptions(GbxCall res)
        {
            Hashtable ht = res.getHashTable();

            Program.lama.maxPlayers = (int)ht["CurrentMaxPlayers"];
            Program.lama.maxSpectators = (int)ht["CurrentMaxSpectators"];
            Program.lama.serverName = (string)ht["Name"];
            Program.lama.serverComment = (string)ht["Comment"];

            //Fill ServerOptions Tab
            tb_ingameName.Text = "";
            setTextBoxText(tb_ingameName, (string) ht["Name"]);
            setTextBoxText(tb_description, (string) ht["Comment"]);
            setTextBoxText(tb_playerPass, (string) ht["Password"]);
            setTextBoxText(tb_specPass, (string) ht["PasswordForSpectator"]);

            setNumeric(n_playersLimit, Program.lama.maxPlayers);
            setNumeric(n_specsLimit, Program.lama.maxSpectators);

            setTextBoxText(tb_refereePass, (string) ht["RefereePassword"]);
            //TODO comboboxReferee

            setNumeric(n_voteTimeout, (int)ht["NextCallVoteTimeOut"]);

            setTextBoxText(tb_voteRatio, (string) ht["NextCallVoteRatio"]);

            int lm = (int)ht["NextLadderMode"];

            setCheckBox(ch_ladder, (lm == 1));
            setCheckBox(ch_p2pUp, (bool) ht["IsP2PUpload"]);
            setCheckBox(ch_p2pDown, (bool)ht["IsP2PDownload"]);
            setCheckBox(ch_autoSaveReplay, false);
            setCheckBox(ch_saveValReplay, false);
            setCheckBox(ch_keepPlayerSlot, false);
            setCheckBox(ch_mapDown, false);
            setCheckBox(ch_horns, false);

          //  Program.lama.pluginManager.onGbxAsyncResult(res);
        }

        void getCurrentGameInfo(GbxCall res)
        {
            Hashtable ht = res.getHashTable();

        }

        void getModeScriptSettings(GbxCall res)
        {
            Hashtable ht = res.getHashTable();
            int cpt = 0;
            IScriptSetting tmp;
            foreach(string key in ht.Keys)
            {
                string name = key;
                if (Program.lama.scriptSettingsLocales.ContainsKey(key))
                {
                    name = Program.lama.scriptSettingsLocales[key];
                }
                switch (getType(ht[key]))
                {
                    case 0://String
                        tmp = new StringScriptSetting(key, name, (string)ht[key]);
                        break;
                    case 1://Int
                        tmp = new NumericScriptSetting(key, name, (int)ht[key]);
                        break;
                    case 2://Bool
                        tmp = new BooleanScriptSetting(key, name, (bool)ht[key]);
                        break;
                    case 3://Double
                        tmp = new DoubleScriptSetting(key, name, (double)ht[key]);
                        break;
                    case -1://Unknown
                    default:
                        Program.lama.log("ERROR", "Unable to get ScriptSetting type of : " + key + " : " + key.GetType());
                        tmp = null;
                        break;
                }
                if(tmp != null)
                {
                    if(cpt % 3 == 0)
                        tmp.setColor(Color.Gray);
                    this.flowLayoutPanel1.Controls.Add(tmp.GetControl());
                    cpt++;
                }
                
            }
        }

      

        void getMapDirectory(GbxCall res)
        {
            this.mapPath = (string)res.Params[0];

            //Init map section
            Program.lama.log("NOTICE", "Init map section");
            if (Program.lama.remote)
            {
                this.l_mapsLocal.Enabled = false;
            }
            else //Local
            {
                if (this.mapPath != null)
                {
                    DirectoryInfo dir = new DirectoryInfo(this.mapPath);
                    makeTreeview(dir, this.treeView1.Nodes.Add("Maps"));
                }
            }
        }

        void cb_PlayerChat(object sender, GbxCallbackEventArgs args)
        {
            var htPlayerChat = args.Response.Params;

            if ((int)htPlayerChat[0] == 0) //server
                                           //chatColors.write(Program.lama.serverName + "$fff : " + htPlayerChat[2] + "\n");
                chatColors.write(htPlayerChat[2] + "\n");
            else
            {
                Player p = Program.lama.getPlayerByLogin((string)htPlayerChat[1]);
                if (p != null)
                    chatColors.write(p.NickName + "$fff : " + htPlayerChat[2] + "\n");
                else
                    chatColors.write(htPlayerChat[1] + "$fff : " + htPlayerChat[2] + "\n");
            }
            
        }

        //CallBacks=============================================================================================
        void gbxCallBack(object sender, GbxCallbackEventArgs args)
        {
            //send to callBacks manager
            callbacks.onGbxCallBack(sender, args);
            //Send to plugins
            Program.lama.pluginManager.onGbxCallBack(sender, args);
        }

        void gbxDisconnect(object sender)
        {
            Program.lama.connected = false;
        }

        #endregion

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Methodes Event UI ///////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

        #region "Event UI Methods"
        //++++++++++++
        //+ Main Tab +>================================================================================================
        //++++++++++++

     

        //Chat Tab======================================================================================================
        private void b_send_Click(object sender, EventArgs e)
        {
            string text = tb_chat.Text;
            chatSends.Add(text);
            curIndexChatSends = chatSends.Count - 1;


            switch(text.ToUpper())
            {
                case "PLUGIN LIST":
                    writeConsole("Home Components------------------------------", Color.DodgerBlue);
                    foreach(IBasePlugin p in Program.lama.pluginManager.HomeComponentPlugins)
                    {
                        writeConsole("- " + p.PluginName + "\t" + p.Version, Color.DodgerBlue);
                    }
                    writeConsole("InGame Plugins-------------------------------", Color.DodgerBlue);
                    foreach (IBasePlugin p in Program.lama.pluginManager.InGamePlugins)
                    {
                        writeConsole("- " + p.PluginName + "\t" + p.Version, Color.DodgerBlue);
                    }
                    writeConsole("Tab Plugin-----------------------------------", Color.DodgerBlue);
                    foreach (IBasePlugin p in Program.lama.pluginManager.TabPlugins)
                    {
                        writeConsole("- " + p.PluginName + "\t" + p.Version, Color.DodgerBlue);
                    }
                    break;

                case "LAMAPLUGIN VERSION":
                    writeConsole("LamaPlugin V0.1", Color.DodgerBlue);
                    break;

                case "LAMAMANIA VERSION":
                    writeConsole("LamaMania V0.3", Color.DodgerBlue);
                    break;

                case "HELP":
                    writeConsole("LAMAPLUGIN VERSION",Color.DodgerBlue);
                    writeConsole("LAMAMANIA VERSION",Color.DodgerBlue);
                    writeConsole("PLUGIN LIST",Color.DodgerBlue);
                    writeConsole("PLUGIN #NAME INFOS",Color.DodgerBlue);
                    writeConsole("VIEW LOG",Color.DodgerBlue);

                    break;
                default:
                    asyncRequest(checkError, ChatSend, tb_chat.Text);

                    break;
            }
       

            tb_chat.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            b_send_Click(sender, e);
        }

        //ServerOptions Tab=============================================================================================
        private void b_save_serverOptions_Click(object sender, EventArgs e)
        {
            //Method list
            //setServerOptions (struct)
            Dictionary<string, object> so = new Dictionary<string, object>();
            so.Add("Name", tb_ingameName.Text);
            so.Add("Comment", tb_description.Text);
            so.Add("Password", tb_playerPass.Text);
            so.Add("PasswordForSpectator", tb_specPass.Text);
          
            so.Add("IsP2PUpload", ch_p2pUp.Checked);
            so.Add("IsP2PDownload", ch_p2pDown.Checked);
            int ladder = 0;
            if (this.ch_ladder.Checked)
                ladder = 1;
            so.Add("NextLadderMode", ladder);
            //so.Add("NextVehicleNetQuality", "Low");

            so.Add("NextVehicleNetQuality", 1);
            so.Add("NextMaxpPlayers", n_playersLimit.Value);
            so.Add("NextMaxSpectators", n_specsLimit.Value);
            double.TryParse(tb_voteRatio.Text, out double voteRatio);
            so.Add("NextCallVoteRatio", voteRatio);
            so.Add("NextCallVoteTimeOut", n_voteTimeout.Value);

            /*
               double.TryParse(tb_voteRatio.Text, out double voteRatio);
               //so.Add("NextCallVoteRatio", voteRatio);
               so.Add("CallVoteRatio", voteRatio);
               so.Add("NextCallVoteTimeOut", n_voteTimeout.Value);
               so.Add("AllowMapDownload", ch_mapDown.Checked);
               so.Add("AutoSaveReplays", ch_autoSaveReplay.Checked);
               so.Add("RefereePassword", tb_refereePass.Text);
               so.Add("RefereeMode", cb_refereeValid.SelectedIndex);
               so.Add("AutoSaveValidationReplays", ch_autoSaveReplay.Checked);
               so.Add("HideServer", false);
               so.Add("UseChangingValidationSeed", true);
               so.Add("ClientInputsMaxLatency", 0);
               so.Add("DisableHorns", ch_horns.Checked);
               so.Add("DisableServiceAnnounces", false);
               so.Add("KeepPlayerSlots", ch_keepPlayerSlot.Checked);*/

            Hashtable serverOptions = new Hashtable(so);

            

            asyncRequest(checkError, SetServerOptions, serverOptions);
        }

        //GameSettings Tab==============================================================================================
        private void b_gameSettingsSave_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            foreach (IScriptSetting setting in flowLayoutPanel1.Controls)
            {
                //Control value
                object value = setting.SettingValue;
                if (value == null)
                {
                    switch (setting.getValueType)
                    {
                        case "String":
                            value = "";
                            break;
                        case "Boolean":
                            value = false;
                            break;
                        case "Numeric":
                            value = 0;
                            break;
                    }
                }
                //Add value
                dic.Add(setting.SettingName, value);
            }
            Hashtable ht = new Hashtable(dic);
            asyncRequest(checkError, SetModeScriptSettings, dic);
        }

        //Users Tab=====================================================================================================
        private void b_toGuests_Click(object sender, EventArgs e)
        {
            var rows = dg_users.SelectedRows;
            foreach (DataGridViewRow row in rows)
            {
                int uId = (int)row.Cells[0].Value;
                asyncRequest(checkError, AddGuestId, uId);
            }
          //  asyncRequest(GetGuestList);
        }

        private void b_toBans_Click(object sender, EventArgs e)
        {
            var rows = dg_users.SelectedRows;
            foreach (DataGridViewRow row in rows)
            {
                int uId = (int)row.Cells[0].Value;
                asyncRequest(checkError, BanId, uId, "BAN");
            }
           // asyncRequest(GetBanList);
        }

        private void b_toBlacks_Click(object sender, EventArgs e)
        {
            var rows = dg_users.SelectedRows;
            foreach (DataGridViewRow row in rows)
            {
                int uId = (int)row.Cells[0].Value;
                asyncRequest(checkError, BlackListId, uId);
            }
        //    asyncRequest(GetBlackList);
        }

        private void b_kick_Click(object sender, EventArgs e)
        {
            var rows = dg_users.SelectedRows;
            foreach (DataGridViewRow row in rows)
            {
                int uId = (int)row.Cells[0].Value;
                asyncRequest(checkError, KickId, uId, "KICK");
            }
        }

        private void b_ForceRed_Click(object sender, EventArgs e)
        {
            forceTeam(1);
        }

        private void b_ForceBlue_Click(object sender, EventArgs e)
        {
            forceTeam(0);
        }

        void forceTeam(int team)
        {
            var rows = dg_users.SelectedRows;
            foreach (DataGridViewRow row in rows)
            {
                int uId = (int)row.Cells[0].Value;
                asyncRequest(checkError, ForcePlayerTeamId, uId, team);
            }
            asyncRequest(getPlayerList, GetPlayerList, Program.lama.maxPlayers + Program.lama.maxSpectators, 0);
        }

        //Maps Tab======================================================================================================
        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                l_mapsLocal.Items.Clear();
                DirectoryInfo dir = new DirectoryInfo(@"Servers\" + Program.lama.serverIndex + @"\UserData\" + e.Node.FullPath);
                foreach (FileInfo file in dir.EnumerateFiles())
                {
                    l_mapsLocal.Items.Add(file.Name);
                    if (!mapFiles.ContainsValue(file.FullName))
                    {
                        try
                        {
                            mapFiles.Add(file.Name, subsep(file.FullName, @"\Maps\"));
                        }
                        catch (Exception err)
                        {
                            Program.lama.log("ERROR", "[Main][TreeViewAfterSelect] PathParse error : " + err.Message);
                        }
                    }
                }
            }
            catch (Exception err)
            {
                Program.lama.log("ERROR", "[Main][TreeViewAfterSelect] Load error : " + err.Message);
            }
        }

     
        private void EditHomeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.lama.inEditMode)
            {
                Program.lama.pluginManager.saveHomeComponentLocations();
            }

            Program.lama.inEditMode = !Program.lama.inEditMode;
        }


        private void L_mapsLocal_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string name = l_mapsLocal.Items[l_mapsLocal.SelectedIndex].ToString();
                MapInformation mi = MapParser.ReadFile("Servers\\" + Program.lama.serverIndex + "\\UserData\\Maps\\" + mapFiles[name]);
                MemoryStream mStream = new MemoryStream();

                mStream.Write(mi.Thumbnail, 0, Convert.ToInt32(mi.Thumbnail.Length));

                Bitmap bm = new Bitmap(mStream, false);
                bm.RotateFlip(RotateFlipType.Rotate180FlipX);

                this.pictureBox1.Image = bm;
            }
            catch (Exception er)
            {
                this.pictureBox1.Image = null;
                Program.lama.log("ERROR", "[ConfigServ][MapSelect]>" + er.Message);
            }
        }

        private void Tb_chat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (curIndexChatSends != -1 && curIndexChatSends < chatSends.Count)
                {
                    tb_chat.Text = chatSends[curIndexChatSends];
                    curIndexChatSends--;
                }
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (curIndexChatSends != -1 && curIndexChatSends < chatSends.Count)
                {
                    tb_chat.Text = chatSends[curIndexChatSends];
                    curIndexChatSends++;
                }
            }

        }

        private void B_add_Click(object sender, EventArgs e)
        {
            string mapName = l_mapsLocal.SelectedItem.ToString();
            string path = makeTreePath(treeView1.SelectedNode);


            asyncRequest(checkError, GBXMethods.AddMap, path + "\\" + mapName);

        }

        string makeTreePath(TreeNode n)
        {
            string ret = n.Text;
            foreach (TreeNode node in n.Nodes)
            {
                if (n.IsSelected)
                {
                    ret += "\\" + makeTreePath(n);
                }
            }

            return ret;
        }

        private void dg_map_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string name = (string)dg_map.Rows[e.RowIndex].Cells[3].Value;
                MapInformation mi = MapParser.ReadFile("Servers\\" + Program.lama.serverIndex + "\\UserData\\Maps\\" + name);
                MemoryStream mStream = new MemoryStream();

                mStream.Write(mi.Thumbnail, 0, Convert.ToInt32(mi.Thumbnail.Length));

                Bitmap bm = new Bitmap(mStream, false);
                bm.RotateFlip(RotateFlipType.Rotate180FlipX);

                this.pictureBox1.Image = bm;
            }
            catch (Exception er)
            {
                this.pictureBox1.Image = null;
                Program.lama.log("ERROR", "[ConfigServ][MapSelect]>" + er.Message);
            }
        }
        #endregion


    }
}
