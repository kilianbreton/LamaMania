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
using LamaMania.UserConstrols;
using static NTK.Other.NTKF;
using static LamaMania.StaticMethods;
using static LamaMania.GBXMethods;

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


        //Variable ingame
        private int maxPlayers;
        private int maxSpectators;
        private int nbPlayers;

        private List<SPlayerInfo> playerList = new List<SPlayerInfo>();
        private List<String> mapList;
        private int currentMapId = -1;
        private int previousMapId = -1;
        private string mapPath;
        private string serverPass;
        private string serverSpecPass;
        private string game;
        private SMGameMode smGameMode;
        private TMGameMode tmGameMode;
        private bool isTM = true;

        private Timer netStatsTimer;
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
            loadLang();

            this.dedicatedConfig = config;
            this.chatColors = new ManiaColors(richTextBox1);

            Lama.log("NOTICE", "Open Main Form");
               
            //Parse base config-----------------------------------------------------------------------------------
            XmlNode root = config[0];
            XmlNode auth = root["authorization_levels"];
            foreach (XmlNode node in auth.Childs)
            {
                switch (node["name"].Value)
                {
                    case "SuperAdmin":
                        this.login = "SuperAdmin";
                        this.passwd = node["password"].Value;
                        break;
                }
            }
            this.port = int.Parse(root["system_config"]["xmlrpc_port"].Value);

            commonConstructor();
        }

        /// <summary>
        /// Start main in remote mode
        /// </summary>
        public Main(string login, string pass)
        {
            InitializeComponent();
            loadLang();

            this.chatColors = new ManiaColors(richTextBox1);

            Lama.log("NOTICE", "Open Main Form");
            this.login = login;
            this.passwd = pass;
            this.adrs = Lama.remoteAdrs;
            this.port = Lama.remotePort;

            commonConstructor();
        }

        void commonConstructor()
        {
            //Launch XmlRpcClient---------------------------------------------------------------------------------
            Lama.log("NOTICE", "XmlRpcConnect");
            connectXmlRpc();
            Lama.loadForm.Close();

            if (Lama.connected)
            {
                Lama.log("NOTICE", "XmlRPC : Connected");

                //Affichage
                this.b_serverStarted.Enabled = false;
                this.b_xmlrpcConnect.Enabled = false;
                this.b_uasecoStop.Enabled = false;
                this.b_usaecoStart.Enabled = false;
                
                //Requêtes
                startupRequests();

                Lama.log("NOTICE", "Init inGamePlugins ...");
                //Init plugins
                if (!Lama.remote) {
                    List<InGamePlugin> removeLST = new List<InGamePlugin>();
                    foreach (InGamePlugin plug in Lama.inGamePlugins)
                    {
                        bool badRequirement = false;
                        string brInfos = "";
                        LamaConfig conf2plug = new LamaConfig()
                        {
                            connected = true,
                            scriptName = "",
                            remote = Lama.remote,
                            configFiles = new Dictionary<string, XmlDocument>()
                        };
                        foreach (Requirement r in plug.Requirements)
                        {
                            switch (r.Type)
                            {
                                case RequirementType.PLUGIN:
                                    if (getPluginByName(r.Value) == null)
                                    {
                                        badRequirement = true;
                                        brInfos = "Requiredplugin '" + r.Value + "does not exists";
                                    }

                                    break;

                                case RequirementType.FILE:
                                    try
                                    {
                                        conf2plug.configFiles.Add(r.Value, new XmlDocument(@"Config\Servers\" + Lama.serverIndex + @"\" + r.Value));
                                    }
                                    catch (Exception)
                                    {
                                        badRequirement = true;
                                        brInfos = @"Unable to load Config\Servers\" + Lama.serverIndex + @"\" + r.Value;
                                    }
                                    break;

                                case RequirementType.DATABASE:
                                    conf2plug.dbConnected = false;
                                    break;
                            }
                        }
                        if(!badRequirement)
                        {
                            badRequirement = !plug.onLoad(conf2plug);
                            brInfos = "onLoad method returned false";
                        }

                        if(badRequirement)
                        {
                            Lama.log("ERROR", "Unable to init [" + plug.PluginName + "] Plugin, " + brInfos);
                            removeLST.Add(plug);
                        }
                        else
                        {
                            Lama.log("NOTICE", "[" + plug.PluginName + "] Plugin loaded");
                        }

                    }
                    foreach(InGamePlugin plug in removeLST)
                    {
                        Lama.inGamePlugins.Remove(plug);
                    }
                }
                
            }
            else
            {
                if (Lama.launched)
                {
                    Lama.onError(this, "Unable to connect", "Unable to connect to " + this.adrs + ":" + this.port + "\nPlease check server and/or Lama configuration");
                    this.Close();
                }
                else
                {
                    Lama.onError(this, "Server exited", "Server exited \nPlease check server logs and configuration");
                    this.Close();
                }
            }
        }

        void startupRequests()
        {
            
            //Requêtes
            asyncRequest(GetStatus, res => {
                Hashtable ht = res.getHashTable();
                setLabel(this.l_server, "Status : " + (string)ht["Name"]);
            });
            asyncRequest(GetVersion, res => {
                setLabel(l_version, "Version : " + (string)res.getHashTable()["Version"]);
            });

            asyncRequest(GetChatLines);

            asyncRequest(GetServerOptions, getServerOptions);
            asyncRequest(GetCurrentGameInfo, getCurrentGameInfo);
            asyncRequest(GetModeScriptSettings, getModeScriptSettings);
            asyncRequest(GetScriptName);

            asyncRequest(GetCurrentMapInfo, res => {
                var htcm = res.getHashTable();
                setLabel(l_map, "Map : " + ManiaColors.getText((string)htcm["Name"]));
            });
            asyncRequest("GetMapsDirectory", res => {
                this.mapPath = (string)res.Params[0];
            });

            asyncRequest(GetPlayerList, this.maxPlayers + this.maxSpectators, 0);
            asyncRequest(GetGuestList, this.maxPlayers + this.maxSpectators, 0);
            asyncRequest(GetBanList, this.maxPlayers + this.maxSpectators, 0);
            asyncRequest(GetBlackList, this.maxPlayers + this.maxSpectators, 0);
            asyncRequest(GetMapList, 999, 0);

            this.netStatsTimer = new Timer();
            this.netStatsTimer.Tick += new EventHandler(netStatsTimer_Tick);
            this.netStatsTimer.Interval = 800;
            this.netStatsTimer.Start();
        }
        #endregion

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Methodes UI /////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

        #region "UI Methods"
        //Other UI Methods in StaticMethods
        void loadLang()
        {
            if (Lama.lang != null)
            {
              
                /*  this.b_serverStop.Text = Config.lang.;
                  this.b_uasecoStop.Text = Config.lang.;
                  this.b_usaecoStart.Text = Config.lang;
                  this.b_xmlrpcClose.Text = Config.lang;
                  this.b_xmlrpcConnect.Text = Config.lang;*/
            }

        }
    
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
        /// Write in Chat console
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

        #endregion

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Methodes GBX ////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

        #region "GBX Methods"
        void connectXmlRpc()
        {
            int cpt = 0;
            while (cpt < TRY_AUTH_NB && !Lama.connected && Lama.launched)
            {
                cpt++;
                try
                {
                    this.client = new XmlRpcClient(this.adrs, this.port);
                    GbxCall authAnsw = this.client.Request(Authenticate, this.login, this.passwd);
                    if (authAnsw.Params[0].Equals(true)) //Auth success---------------------------------
                    {
                        this.client.EnableCallbacks(true);
                        this.client.EventGbxCallback += new GbxCallbackHandler(gbxCallBack);
                        this.client.EventOnDisconnectCallback += new OnDisconnectHandler(gbxDisconnect);

                        Lama.connected = true; //exit loop
                    }
                }
                catch (Exception)
                {




                    System.Threading.Thread.Sleep(WAIT_AUTH_TIME);
                }
            }
        }

        //Requests====================================================================================
        void asyncRequest(String methodName, params object[] param)
        {
            if(param == null)
                param = new object[] { };
            this.handles.Add(this.client.AsyncRequest(methodName, param, asyncResult), methodName);
        }

        void asyncRequest(GbxCallCallbackHandler handler, String methodName, params object[] param)
        {
            if (param == null)
                param = new object[] { };
            this.client.AsyncRequest(methodName, param, handler);
        }

        void asyncRequest(String methodName, GbxCallCallbackHandler handler)
        {
            this.client.AsyncRequest(methodName, new object[] { }, handler);
        }

        //Main Async results==========================================================================
        void asyncResult(GbxCall res)
        {        
            //Manage result------------------------------------------------------------------------
            try
            {
                if (this.handles.ContainsKey(res.Handle) && !res.Error)
                {
                    switch (this.handles[res.Handle])
                    {

                        #region "Server Infos"
                        //////////////////////////////////////////////////////////////////////////////////////////////////////
                        // Server Infos /////////////////////////////////////////////////////////////////////////////////////
                        ////////////////////////////////////////////////////////////////////////////////////////////////////
                        case GetScriptName:
                            var htscript = res.getHashTable();
                            string script = (string)htscript["CurrentValue"];
                            if (script.Contains(".Script.txt"))
                            {
                                script = subsep(script, 0, ".");
                            }
                            setLabel(this.l_gameMode, "GameMode : " + script);

                            this.isTM = Enum.TryParse(script, out this.tmGameMode);
                            if (this.isTM)
                            {
                                foreach (TMGameMode suit in (TMGameMode[])Enum.GetValues(typeof(TMGameMode)))
                                {
                                    appendCombo(cb_serverGMScript, suit.ToString());
                                }
                            }
                            else
                            {
                                if(Enum.TryParse(script, out this.smGameMode))
                                {
                                    foreach (SMGameMode suit in (SMGameMode[])Enum.GetValues(typeof(SMGameMode)))
                                    {
                                        appendCombo(cb_serverGMScript,suit.ToString());
                                    }
                                }
                                else
                                {
                                    //Show select game dialog
                                }

                            }
                            break;
                        case GetMapList:
                            Hashtable maps = res.getHashTable();
                            clearDg(dg_map);
                            foreach (Hashtable map in maps)
                            {
                                addDgRow(dg_map, ManiaColors.getText((string)map["Name"]), map["Author"], map["Environnement"], map["LadderRanking"]);
                            }
                            break;
                        case GetCurrentMapIndex:
                            if (this.currentMapId != -1)
                                this.previousMapId = this.currentMapId;
                            this.currentMapId = (int)res.Params[0];
                            break;

                        case SetScriptName:
                            if ((bool)res.Params[0])
                            {
                                setLabel(this.l_gameMode, "GameMode: "+this.cb_serverGMScript.Text);
                            }

                            break;
                            #endregion

                        #region "Chat"
                        //////////////////////////////////////////////////////////////////////////////////////////////////////
                        // Chat /////////////////////////////////////////////////////////////////////////////////////////////
                        ////////////////////////////////////////////////////////////////////////////////////////////////////
                        case GetChatLines:

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
                                break;


                        #endregion

                        #region "Players List"
                        //////////////////////////////////////////////////////////////////////////////////////////////////////
                        // Players List /////////////////////////////////////////////////////////////////////////////////////
                        ////////////////////////////////////////////////////////////////////////////////////////////////////

                        case GetPlayerList:
                            ArrayList userList = (ArrayList)res.Params[0];
                            clearList(l_users);
                            clearDg(dg_users);
                            this.nbPlayers = userList.Count;
                            setLabel(l_players, "Players : " + this.nbPlayers + "/" + this.maxPlayers);
                            foreach (Hashtable user in userList)
                            {
                                this.playerList.Add(new SPlayerInfo {
                                    Login = (string)user["Login"],
                                    NickName = (string)user["NickName"],
                                    PlayerId = (int)user["PlayerId"],
                                    //...............
                                });
                                addDgRow(dg_users, user["PlayerId"], ManiaColors.getText((string)user["NickName"]), user["Login"], user["LadderRanking"]);
                                appendList(l_users, ManiaColors.getText((string)user["NickName"]));
                            }
                            break;
                        case SendDisplayManialinkPageToId:
                           
                            break;
                        case GetGuestList:
                            break;
                        case GetBlackList:
                            break;
                        case GetBanList:
                            break;
                        #endregion

                    }             
                }
                else
                {
                    if(res.Error)
                        Lama.log("ERROR", "Answer for handle n° " + res.Handle + " named '" + this.handles[res.Handle] + "' Returned Error : " + res.ErrorString);
                }
                //Send to plugins --------------------------------------------------------------------------------
                foreach (InGamePlugin plug in Lama.inGamePlugins)
                {
                    try
                    {
                        plug.onGbxAsyncResult(res);
                    }
                    catch (Exception e)
                    {
                        Lama.log("ERROR", "Plugins " + plug.PluginName +" throws Gbx Error :" + e.Message);
                    }
                }

                this.handles.Remove(res.Handle);
            }
            catch (Exception e)
            {
                Lama.log("ERROR", "Answer for handle n°"+res.Handle+ " throws a " + e.GetType().Name + "Exception : " + e.Message);
            }
        }

        //Specific AsyncResult
        void checkError(GbxCall res)
        {
            if(res.Error)
            {
                Lama.onError(this, "Error", "Error " + res.ErrorCode + " : " + res.ErrorString + "\n from request : " + res.MethodName);
            }
        }

        void getServerOptions(GbxCall res)
        {
            Hashtable ht = res.getHashTable();

            setLabel(l_serverName, "Name : " + ManiaColors.getText((string)ht["Name"]));
            setLabel(l_serverDescritpion, "Description : " + ManiaColors.getText((string)ht["Comment"]));
            this.maxPlayers = (int)ht["CurrentMaxPlayers"];
            this.maxSpectators = (int)ht["CurrentMaxSpectators"];

            //Fill ServerOptions Tab
            setTextBoxText(tb_ingameName, (string) ht["Name"]);
            setTextBoxText(tb_description, (string) ht["Comment"]);
            setTextBoxText(tb_playerPass, (string) ht["Password"]);
            setTextBoxText(tb_specPass, (string) ht["PasswordForSpectator"]);

            setNumeric(n_playersLimit, maxPlayers);
            setNumeric(n_specsLimit, maxSpectators);

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
            
        }

        void getCurrentGameInfo(GbxCall res)
        {
            Hashtable ht = res.getHashTable();

        }

        void getModeScriptSettings(GbxCall res)
        {
            Hashtable ht = res.getHashTable();

            foreach(string key in ht.Keys)
            {
                switch (getType(ht[key]))
                {
                    case 0://String
                        this.flowLayoutPanel1.Controls.Add(new StringScriptSetting(key, key, (string)ht[key]));
                        break;
                    case 1://Int
                        this.flowLayoutPanel1.Controls.Add(new NumericScriptSetting(key, key, (int)ht[key]));
                        break;
                    case 2://Bool
                        this.flowLayoutPanel1.Controls.Add(new BooleanScriptSetting(key, key, (bool)ht[key]));
                        break;
                    case 3://Double
                        this.flowLayoutPanel1.Controls.Add(new DoubleScriptSetting(key, key, (double)ht[key]));
                        break;
                    case -1://Unknown
                        Lama.log("ERROR", "Unable to get ScriptSetting type of : " + key + " : " + key.GetType());
                        break;
                }
            }
        }

        //CallBacks=============================================================================================
        void gbxCallBack(object sender, GbxCallbackEventArgs args)
        {
            switch (args.Response.MethodName)
            {   //Race & Map infos

                #region "Server"
                case "ManiaPlanet.ServerStart":

                    break;
                case "ManiaPlanet.ServerStop":

                    break;

                case "ManiaPlanet.StatusChanged":

                    break;
                case "ManiaPlanet.TunnelDataReceived":

                    break;
                case "ManiaPlanet.Echo":

                    break;
                case "ManiaPlanet.BillUpdated":
                  
                    break;

                #endregion

                #region "Scripts"
                case "ModeScriptCallback":

                    break;
                case "ModeScriptCallbackArray":

                    break;
                case "ScriptCloud.LoadData":

                    break;
                case "ScriptCloud.SaveData":

                    break;
                #endregion

                #region "ManiaPlanetMap"
                case "ManiaPlanet.BeginMap":
                    setLabelColor(l_map, Color.Green);
                    break;
                case "ManiaPlanet.BaginMatch":
                    setLabelColor(l_map, Color.Green);
                    break;
                case "ManiaPlanet.EndMap":
                    setLabelColor(l_map, Color.Red);
                    break;
                case "ManiaPlanet.EndMatch":
                    setLabelColor(l_map, Color.Orange);
                    break;

                #endregion

                #region "Race"

                case "TrackMania.EndRace":
                    setLabelColor(l_map, Color.Orange);
                    break;

                case "TrackMania.EndRound":

                    break;

                case "TrackMania.ChallengeListModified":

                    break;

                case "TrackMania.EndChallenge":
                    setLabelColor(l_map, Color.Red);
                    break;

                case "TrackMania.StatusChanged":
                    int statusCode = (int)args.Response.Params[0];
                    setLabel(this.l_server, "Status : " + getStatus(statusCode));
                    break;


                case "TrackMania.BeginChallenge":
               
                    setLabelColor(l_map, Color.Green);
                    var ht = (Hashtable)args.Response.Params[0];
                    setLabel(l_map, "GameInfo : " + ManiaColors.getText((string)ht["Name"]));
                    asyncRequest("GetCurrentMapIndex");
                    break;

                case "TrackMania.BeginRace":
                    break;

                #endregion

                #region "Player"
                case "TrackMania.PlayerConnect":
                    asyncRequest("GetPlayerList", this.maxPlayers + this.maxSpectators, 0);
                    break;
                case "TrackMania.PlayerDisconnect":
                    asyncRequest("GetPlayerList", this.maxPlayers + this.maxSpectators, 0);
                    break;
                case "ManiaPlanet.PlayerChat":
                case "TrackMania.PlayerChat":
                    var htPlayerChat = args.Response.Params;
                    chatColors.write(htPlayerChat[1] + "$fff : " + htPlayerChat[2] + "\n");
                    break;
                case "TrackMania.PlayerInoChanged":

                    break;
                case "TrackMania.PlayerAllies":

                    break;

                case "TrackMania.PlayerManialinkPageAnswer":

                    break;

                case "TrackMania.PlayerCheckpoint":

                    break;
                case "TrackMania.PlayerFinish":

                    break;
                case "TrackMania.PlayerIncoherence":

                    break;
                    #endregion

            }

            //Send to plugins----------------------------------------------------------------------
            foreach (InGamePlugin plug in Lama.inGamePlugins)
            {
                plug.onGbxCallBack(sender, args);
            }

        }

        void gbxDisconnect(object sender)
        {
            FlatButton but = (FlatButton)getControl(this.b_xmlrpcConnect);
            but.BaseColor = Color.Green;
            enableControl(but, true);
            but.Enabled = true;
            but = (FlatButton)getControl(this.b_serverStarted);
            but.BaseColor = Color.Green;
            enableControl(but, true);
            this.netStatsTimer.Stop();
        }

        #endregion

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Autres Methodes /////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

        #region "Other Methods"

        string getStatus(int code)
        {
            switch(code)
            {
                case 3:
                    return "Running - Synchronisation";
                case 4:
                    return "Running - Play";
                default:
                    return code.ToString() ;
            }
        }

        private void netStatsTimer_Tick(object sender, EventArgs a)
        {
            asyncRequest(GetNetworkStats, res => {
                var ht = res.getHashTable();
                setLabel(this.l_upTime, "UpTime : " + ht["UpTime"]);
                setLabel(this.l_nbConn, "Nb Connections : " + ht["NbrConnection"]);
                setLabel(this.l_upTime, "Connection Time Average : " + ht["MeanConnectionTime"]);
                setLabel(this.l_upTime, "Recive Net Rate : " + ht["RecvNetRate"]);
                setLabel(this.l_upTime, "Send Net Rate : " + ht["SendNetRate"]);
            });
        }

        #endregion

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Methodes Event UI ///////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

        #region "Event UI Methods"

        //Main Tab=================================================================================================
        private void b_prevMap_Click(object sender, EventArgs e)
        {
            if(this.previousMapId != -1)
                asyncRequest(res => {if (!res.Error) { asyncRequest(NextMap); }},
                    SetNextMapIndex, this.previousMapId);
        }

        private void b_restart_Click(object sender, EventArgs e)
        {
            asyncRequest(RestartMap, checkError);
        }

        private void b_nextMap_Click(object sender, EventArgs e)
        {
            asyncRequest(NextMap, checkError);
        }

        private void b_stopRound_Click(object sender, EventArgs e)
        {
            asyncRequest(ForceEndRound, checkError);
        }

        private void b_makeNextGameMode_Click(object sender, EventArgs e)
        {
            string gm = cb_serverGMScript.Text;
            if (gm != "")
            {
                if (!gm.Contains(".Script.txt"))
                    gm += ".Script.Txt";

                asyncRequest(SetScriptName, gm);
            }
        }

        private void b_join_Click(object sender, EventArgs e)
        {
            //Todo Generate Maniaplanet Link
            //maniaplanet://#join=btssiolan@TMStadium@nadeo
            
            string login = this.dedicatedConfig[0]["masterserver_account"]["login"].Value;
            string title = this.dedicatedConfig[0]["system_config"]["title"].Value;
            string port = this.dedicatedConfig[0]["system_config"]["server_port"].Value;
            string pass = this.dedicatedConfig[0]["server_options"]["password"].Value;

            string link = "maniaplanet://#join=" + login;
            if (pass != null && pass != "")
                link += ":" + pass;
            link += "@" + title + "@nadeo";


            System.Diagnostics.Process.Start(link);
        }

        private void b_xmlrpcConnect_Click(object sender, EventArgs e)
        {
            commonConstructor();
        }

        private void b_xmlrpcClose_Click(object sender, EventArgs e)
        {
            this.client.Dispose();
            this.client = null;
            //TODO: Manage Controls
        }

        private void b_serverStarted_Click(object sender, EventArgs e)
        {
           
        }

        private void b_serverStop_Click(object sender, EventArgs e)
        {

        }

        private void b_usaecoStart_Click(object sender, EventArgs e)
        {

        }

        private void b_uasecoStop_Click(object sender, EventArgs e)
        {

        }

        //Chat Tab===============================================================================================
        private void b_send_Click(object sender, EventArgs e)
        {
            asyncRequest(ChatSend, tb_chat.Text);
            tb_chat.Text = "";

        }
        //ServerOptions Tab===============================================================================================
        private void b_save_serverOptions_Click(object sender, EventArgs e)
        {
            //Method list
            //setServerOptions (struct)
            Dictionary<string, object> so = new Dictionary<string, object>();
            so.Add("Name", tb_ingameName.Text);
            so.Add("Comment", tb_description.Text);
            so.Add("Password", tb_playerPass.Text);
            so.Add("PasswordForSpectator", tb_specPass.Text);
            so.Add("NextMaxpPlayers", n_playersLimit.Value);
            so.Add("NextMaxSpectators", n_specsLimit.Value);
            so.Add("IsP2PUpload", ch_p2pUp.Checked);
            so.Add("IsP2PDownload", ch_p2pDown.Checked);
            int ladder = 0;
            if (this.ch_ladder.Checked)
                ladder = 1;

            so.Add("NextLadderMode", ladder);
            so.Add("NextVehicleNetQuality", "Low");
            double.TryParse(tb_voteRatio.Text, out double voteRatio);
            so.Add("NextCallVoteRatio", voteRatio);
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
            so.Add("KeepPlayerSlots", ch_keepPlayerSlot.Checked);
          
            Hashtable serverOptions = new Hashtable(so);

            asyncRequest(checkError, SetServerOptions, serverOptions);
        }

       
        //GameSettings Tab===============================================================================================
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

        private void button1_Click(object sender, EventArgs e)
        {
            b_send_Click(sender, e);
        }

        private void b_toGuests_Click(object sender, EventArgs e)
        {
            var rows = dg_users.SelectedRows;
            foreach (DataGridViewRow row in rows)
            {
                int uId = (int)row.Cells[0].Value;
                asyncRequest(checkError, AddGuestId, uId);
            }
            asyncRequest(GetGuestList);
        }

        private void b_toBans_Click(object sender, EventArgs e)
        {
            var rows = dg_users.SelectedRows;
            foreach (DataGridViewRow row in rows)
            {
                int uId = (int)row.Cells[0].Value;
                asyncRequest(checkError, BanId, uId, "BAN");
            }
            asyncRequest(GetBanList);
        }

        private void b_toBlacks_Click(object sender, EventArgs e)
        {
            var rows = dg_users.SelectedRows;
            foreach (DataGridViewRow row in rows)
            {
                int uId = (int)row.Cells[0].Value;
                asyncRequest(checkError, BlackListId, uId);
            }
            asyncRequest(GetBlackList);
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
            asyncRequest(GetPlayerList, this.maxPlayers + this.maxSpectators, 0);
        }

        #endregion
    }
}
