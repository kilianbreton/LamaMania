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
using TMXmlRpcLib;
using NTK.IO.Xml;
using NTK.IO;
using static NTK.Other.NTKF;
using LamaPlugin;
using FlatUITheme;
using LAMAMAnia.UserConstrols;

namespace LAMAMAnia
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
        private Log XmlRpclogger;

        //Variable ingame
        private int maxPlayers;
        private int maxSpectators;
        private int nbPlayers;
        
        private List<String> mapList;
        private int currentMapId = -1;
        private int previousMapId = -1;
        private string mapPath;
        private string serverPass;
        private string serverSpecPass;
        private string game;
        private GameMode gameMode;

        private Timer netStatsTimer;
        #endregion

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Constructeurs ///////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        #region "Constructors"
        /// <summary>
        /// Start main with dedicated_cfg
        /// </summary>
        /// <param name="config"></param>
        public Main(XmlDocument config)
        {
            InitializeComponent();
            loadLang();
            
            this.XmlRpclogger = new LogXMLRPC(@"Logs\XmlRpc.log");
            this.dedicatedConfig = config;
            this.chatColors = new ManiaColors(richTextBox1);

            Lama.log("NOTICE", "Open Main Form");
        
            if (Lama.launched)
            {

                //Parse base config-----------------------------------------------------------------------------------
                var root = config[0];
                var auth = root["authorization_levels"];
                foreach (XmlNode n in auth.getChildList())
                {
                    switch (n["name"].Value)
                    {
                        case "SuperAdmin":
                            this.login = "SuperAdmin";
                            this.passwd = n["password"].Value;
                            break;
                    }
                }
                this.port = int.Parse(root["system_config"]["xmlrpc_port"].Value);
                

                //Launch XmlRpcClient---------------------------------------------------------------------------------
                Lama.log("NOTICE", "XmlRpcConnect");
                connectXmlRpc();
                Lama.loadForm.Close();

                if (Lama.connected)
                {
                    Lama.log("NOTICE", "XmlRPC : Connected");
                    
                    //Affichage
                    this.b_serverStarted.Enabled = false;
                    this.b_serverStarted.BaseColor = Color.Gray;
                    this.b_xmlrpcConnect.Enabled = false;
                    this.b_xmlrpcConnect.BaseColor = Color.Gray;
                    this.b_uasecoStop.Enabled = false;
                    this.b_uasecoStop.BaseColor = Color.Gray;
                    this.b_usaecoStart.Enabled = false;
                    this.b_usaecoStart.BaseColor = Color.Gray;
               
                    startupRequests();
                }
                else
                {
                    
                    Lama.onError(this, "Unable to connect", "Unable to connect to " + this.adrs + ":" + this.port + "\nPlease check server and/or Lama configuration");
                    this.Close();
                }

            }//if

        }

        /// <summary>
        /// Start main in remote mode
        /// </summary>
        public Main(string login, string pass)
        {
            InitializeComponent();
            loadLang();

            this.XmlRpclogger = new LogXMLRPC(@"Logs\XmlRpc.log");
            this.chatColors = new ManiaColors(richTextBox1);

            Lama.log("NOTICE", "Open Main Form");
            this.login = login;
            this.passwd = pass;
        
            
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

                startupRequests();

            }
            else
            {

                Lama.onError(this, "Unable to connect", "Unable to connect to " + this.adrs + ":" + this.port + "\nPlease check server and/or Lama configuration");
                this.Close();
            }


        }
        #endregion
     
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Methodes UI /////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

        #region "UI Methods"
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
        /// Add row in DataGridView
        /// </summary>
        /// <param name="dg"></param>
        /// <param name="pars"></param>
        void addDgRow(DataGridView dg, params object[] pars)
        {
            if (dg.InvokeRequired)
            {
                dg.Invoke(new Action<DataGridView, object[]>(addDgRow), dg, pars);
            }
            else
            {
                dg.Rows.Add(pars);
            }
        }
        /// <summary>
        /// AddRow in listBox
        /// </summary>
        /// <param name="list"></param>
        /// <param name="value"></param>
        void appendList(ListBox list, String value)
        {
            if (list.InvokeRequired)
            {
                list.Invoke(new Action<ListBox, String>(appendList), list, value);
            }
            else
            {
                list.Items.Add(value);
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
        /// Clear listBox
        /// </summary>
        /// <param name="list"></param>
        void clearList(ListBox list)
        {
            if (list.InvokeRequired) //Permet de revenir au Thread de gestion des composants UI
            {
                list.Invoke(new Action<ListBox>(clearList),list);
            }
            else
            {
                list.Items.Clear();
            }
        }
        /// <summary>
        /// Clear DataGridView
        /// </summary>
        /// <param name="dg"></param>
        void clearDg(DataGridView dg)
        {
            if (dg.InvokeRequired) //Permet de revenir au Thread de gestion des composants UI
            {
                dg.Invoke(new Action<DataGridView>(clearDg),dg);
            }
            else
            {
                dg.Rows.Clear();
            }
        }
        /// <summary>
        /// Clear RichTextBox
        /// </summary>
        /// <param name="rtb"></param>
        void clearRichText(RichTextBox rtb)
        {
       
            if (rtb.InvokeRequired) //Permet de revenir au Thread de gestion des composants UI
            {
                rtb.Invoke(new Action<RichTextBox>(clearRichText),rtb);
            }
            else
            {
                rtb.Clear();
            }
        }
        /// <summary>
        /// Enable control
        /// </summary>
        /// <param name="control"></param>
        /// <param name="value"></param>
        void enableControl(Control control, bool value)
        {
            if (control.InvokeRequired) //Permet de revenir au Thread de gestion des composants UI
            {
                control.Invoke(new Action<Button, bool>(enableControl), control,value);
            }
            else
            {
                control.Enabled = value;
            }
        }

        void setLabel(Label label, String value)
        {
            if (label.InvokeRequired) //Permet de revenir au Thread de gestion des composants UI
            {
                label.Invoke(new Action<Label, String>(setLabel), label, value);
            }
            else
            {
                label.Text = value;
            }
        }

        void setLabelColor(Label label, Color color)
        {
            if (label.InvokeRequired) //Permet de revenir au Thread de gestion des composants UI
            {
                label.Invoke(new Action<Label, Color>(setLabelColor), label, color);
            }
            else
            {
                label.ForeColor = color;
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
        
        void setTextBoxText(FlatTextBox tb, string text)
        {
            tb = (FlatTextBox)getControl(tb);
            tb.Text = text;
        }

        void setNumeric(FlatNumeric n, int v)
        {
            n = (FlatNumeric)getControl(n);
            n.Value = v;
        }

        void setComboBox(FlatComboBox cb, string selectedValue)
        {
            cb = (FlatComboBox)getControl(cb);
            cb.SelectedText = selectedValue;
        }

        void setCheckBox(FlatCheckBox cb, bool value)
        {
            cb = (FlatCheckBox)getControl(cb);
            cb.Checked = value;
        }

        /// <summary>
        /// Get the control and Invoke if required
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        Control getControl(Control control)
        {
            if (control.InvokeRequired)
            {
                return (Control) control.Invoke(new Func<Control, Control>(getControl), control);
            }
            else
            {
                return control;
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
            while (cpt < TRY_AUTH_NB && !Lama.connected)
            {
                cpt++;
                try
                {
                    this.client = new XmlRpcClient(this.adrs, this.port);
                    var authAnsw = this.client.Request("Authenticate", new object[]
                    {
                            this.login,
                            this.passwd
                    });
                    if (authAnsw.Params[0].Equals(true)) //Auth success---------------------------------
                    {
                        this.client.EnableCallbacks(true);
                        this.client.EventGbxCallback += new GbxCallbackHandler(gbxCallBack);
                        this.client.EventOnDisconnectCallback += new OnDisconnectHandler(gbxDisconnect);

                        Lama.connected = true; //exit loop
                    }

                }
                catch (Exception e)
                {
                    System.Threading.Thread.Sleep(WAIT_AUTH_TIME);
                }
            }
        }

        //Requests
        void asyncRequest(String methodName, params object[] param)
        {
            if(param == null)
                param = new object[] { };
            this.handles.Add(this.client.AsyncRequest(methodName, param, asyncResult), methodName);
        }

        void asyncRequest(String methodName, object[] param, GbxCallCallbackHandler handler)
        {
            if (param == null)
                param = new object[] { };
            this.client.AsyncRequest(methodName, param, handler);
        }

        void asyncRequest(String methodName, GbxCallCallbackHandler handler)
        {
            this.client.AsyncRequest(methodName, new object[] { }, handler);
        }

        //CallBacks
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
                    setLabelColor(l_map,  Color.Red);
                    break;

                case "TrackMania.StatusChanged":
                    int statusCode = (int)args.Response.Params[0];
                    setLabel(this.l_server, "Status : " + getStatus(statusCode));
                    break;

               
                case "TrackMania.BeginChallenge":
                    SMapInfo mi;
                    setLabelColor(l_map, Color.Green);
                    var ht = (Hashtable)args.Response.Params[0];
                    setLabel(l_map, "GameInfo : " + chatColors.getText((string)ht["Name"]));
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
                    var htPlayerChat = (Hashtable)args.Response.Params[0];

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
         /* foreach (BasePlugin plug in Lama.plugins)
            {
                plug.onGbxCallBack(sender, args);
            }*/

        }

        void gbxDisconnect(object sender)
        {
            FlatButton but = (FlatButton)getControl(this.b_xmlrpcConnect);
            but.BaseColor = Color.Green;
            but.Enabled = true;
            but = (FlatButton)getControl(this.b_serverStarted);
            but.BaseColor = Color.Green;
            but.Enabled = true;
            this.netStatsTimer.Stop();
        }

        //Async results
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
                        case "GetGameMode":

                            break;
                        case "GetCurrentMapInfo":
                            var htcm = (Hashtable)res.Params[0];
                            setLabel(l_map, "Map : " + chatColors.getText((string)htcm["Name"]));

                            break;
                        case "GetMapsDirectory":
                            this.mapPath = (string)res.Params[0];
                            break;
                        case "GetStatus":
                            Hashtable ht = (Hashtable)res.Params[0];
                            setLabel(this.l_server, "Status : " + (string)ht["Name"]);
                            break;
                    
                        case "GetScriptName":
                            var htscript = (Hashtable)res.Params[0];
                            var script = (string)htscript["CurrentValue"];
                            if (script.Contains(".Script.txt"))
                            {
                                script = subsep(script, 0, ".");
                            }
                            setLabel(this.l_gameMode, "GameMode : " + script);
                            Enum.TryParse<GameMode>(script, out this.gameMode);


                            break;
                        case "GetMapList":
                            ArrayList maps = (ArrayList)res.Params[0];
                            foreach (Hashtable map in maps)
                            {
                                addDgRow(dg_map, chatColors.getText((string)map["Name"]), map["Author"], map["Environnement"], map["LadderRanking"]);
                            }
                            break;
                        case "GetCurrentMapIndex":
                            if (this.currentMapId != -1)
                                this.previousMapId = this.currentMapId;
                            this.currentMapId = (int)res.Params[0];
                            break;

                            #endregion

                        #region "Chat"
                            //////////////////////////////////////////////////////////////////////////////////////////////////////
                            // Chat /////////////////////////////////////////////////////////////////////////////////////////////
                            ////////////////////////////////////////////////////////////////////////////////////////////////////
                            case "GetChatLines":

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

                            case "ChatSend":
                                if (!res.Error)
                                {
                                    asyncRequest("GetChatLines", new object[] { });
                                }
                                break;

                            #endregion

                        #region "Players List"
                        //////////////////////////////////////////////////////////////////////////////////////////////////////
                        // Players List /////////////////////////////////////////////////////////////////////////////////////
                        ////////////////////////////////////////////////////////////////////////////////////////////////////

                        case "GetPlayerList":
                            ArrayList userList = (ArrayList)res.Params[0];
                            clearList(l_users);
                            this.nbPlayers = userList.Count;
                            setLabel(l_players, "Players : " + this.nbPlayers + "/" + this.maxPlayers);
                            foreach (Hashtable user in userList)
                            {
                                string xml = "<manialink version='3'>\n"
                                        + "< frame pos = '10 10'  index = '0' >\n"

                                        + " < quad size = '10 10' bgcolor = 'F00A' />\n"

                                        + "< quad pos = '-10 0'  index = '0' size = '10 10' bgcolor = '00FA' />\n"
                                        + " </frame>"
                                        + "</manialink>";

                                addDgRow(dg_users, user["PlayerId"], chatColors.getText((string)user["NickName"]), user["Login"], user["LadderRanking"]);
                                appendList(l_users, chatColors.getText((string)user["NickName"]));

                                // asyncRequest("SendDisplayManialinkPageToId", new object[] { user["PlayerId"], xml,0,false });
                            }
                            break;
                        case "SendDisplayManialinkPageToId":
                            var r = res;
                            break;
                        case "GetGuestList":
                            break;
                        case "GetBlackList":
                            break;
                        case "GetBanList":
                            break;
                        #endregion

                        #region "Set Returns"
                        case "SetModeScriptSettings":
                            if (res.Error)
                            {
                                Lama.onError(this, "Error", "Unable to set ModeScriptSettings : " + res.ErrorString);
                            }
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
                foreach (BasePlugin plug in Lama.plugins)
                {
                    try
                    {
                        plug.onGbxAsyncResult(res);
                    }
                    catch (Exception e)
                    {
                        Lama.log("ERROR", "Plugins " + plug.Name +" throws Gbx Error :" + e.Message);
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
        void getServerOptions(GbxCall res)
        {
            Hashtable ht = (Hashtable)res.Params[0];

            setLabel(l_serverName, "Name : " + chatColors.getText((string)ht["Name"]));
            setLabel(l_serverDescritpion, "Description : " + chatColors.getText((string)ht["Comment"]));
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
            Hashtable ht = (Hashtable)res.Params[0];



         
        }

        void getModeScriptSettings(GbxCall res)
        {
            Hashtable ht = (Hashtable)res.Params[0];

            foreach(string key in ht.Keys)
            {
                switch (Lama.getType(ht[key]))
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

        void getNetworkStats(GbxCall res)
        {
            var ht = res.getHashTable();
            setLabel(this.l_upTime, "UpTime : " + ht["UpTime"]);
            setLabel(this.l_nbConn, "Nb Connections : " + ht["NbrConnection"]);
            setLabel(this.l_upTime, "Connection Time Average : " + ht["MeanConnectionTime"]);
            setLabel(this.l_upTime, "Recive Net Rate : " + ht["RecvNetRate"]);
            setLabel(this.l_upTime, "Send Net Rate : " + ht["SendNetRate"]);
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

        void logRpc(string type, string msg)
        {
            this.XmlRpclogger.add(new LogLineXMLRPC(type, msg, DateTime.Now));
            this.XmlRpclogger.flush();
        }

        void startupRequests()
        {
            //Requêtes
            asyncRequest("GetStatus");
            asyncRequest("GetVersion");

            asyncRequest("GetChatLines");
            asyncRequest("GetCurrentMapInfo");

            asyncRequest("GetServerOptions", getServerOptions);
            asyncRequest("GetCurrentGameInfo", getCurrentGameInfo);
            asyncRequest("GetModeScriptSettings", getModeScriptSettings);
            asyncRequest("GetGameMode");
            asyncRequest("GetScriptName");

            asyncRequest("GetCurrentMapInfo");
            asyncRequest("GetMapsDirectory");

            asyncRequest("GetPlayerList", this.maxPlayers + this.maxSpectators, 0);
            asyncRequest("GetMapList", 999, 0);

            this.netStatsTimer = new Timer();
            this.netStatsTimer.Tick += new EventHandler(netStatsTimer_Tick);
            this.netStatsTimer.Interval = 800;
            this.netStatsTimer.Start();
        }

        private void netStatsTimer_Tick(object sender, EventArgs a)
        {
            asyncRequest("GetNetworkStats", getNetworkStats);
        }

        #endregion

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Methodes Event UI ///////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

        #region "Event UI Methods"
        protected override void WndProc(ref Message m)
        {
            const int RESIZE_HANDLE_SIZE = 10;

            switch (m.Msg)
            {
                case 0x0084/*NCHITTEST*/ :
                    base.WndProc(ref m);

                    if ((int)m.Result == 0x01/*HTCLIENT*/)
                    {
                        Point screenPoint = new Point(m.LParam.ToInt32());
                        Point clientPoint = this.PointToClient(screenPoint);
                        if (clientPoint.Y <= RESIZE_HANDLE_SIZE)
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)13/*HTTOPLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)12/*HTTOP*/ ;
                            else
                                m.Result = (IntPtr)14/*HTTOPRIGHT*/ ;
                        }
                        else if (clientPoint.Y <= (Size.Height - RESIZE_HANDLE_SIZE))
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)10/*HTLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)2/*HTCAPTION*/ ;
                            else
                                m.Result = (IntPtr)11/*HTRIGHT*/ ;
                        }
                        else
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)16/*HTBOTTOMLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)15/*HTBOTTOM*/ ;
                            else
                                m.Result = (IntPtr)17/*HTBOTTOMRIGHT*/ ;
                        }
                    }
                    return;
            }
            base.WndProc(ref m);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= 0x20000; // <--- use 0x20000
                return cp;
            }
        }

        private void formSkin1_Click(object sender, EventArgs e)
        {

        }

        //Main Tab=================================================================================================
        private void b_prevMap_Click(object sender, EventArgs e)
        {
            if(this.previousMapId != -1)
                asyncRequest("SetNextMapIndex", new object[] { this.previousMapId }, prevMapNext);
        }

        private void prevMapNext(GbxCall args)
        {
            if (!args.Error)
                asyncRequest("NextMap");
        }

        private void b_restart_Click(object sender, EventArgs e)
        {
            asyncRequest("RestartMap");
        }

        private void b_nextMap_Click(object sender, EventArgs e)
        {
            asyncRequest("NextMap");
        }

        private void b_stopRound_Click(object sender, EventArgs e)
        {
            asyncRequest("ForceEndRound");
        }

        private void b_makeNextGameMode_Click(object sender, EventArgs e)
        {

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
            connectXmlRpc();
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
            asyncRequest("ChatSend", tb_chat.Text);
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
            string ladder = "";
            if (this.ch_ladder.Checked)
                ladder = "forced";

            so.Add("NextLadderMode", ladder);
            so.Add("NextVehicleNetQuality", "Low");
            double.TryParse(tb_voteRatio.Text, out double voteRatio);
            so.Add("NextCallVoteRatio", voteRatio);
            so.Add("AllowMapDownload", ch_mapDown.Checked);
            so.Add("AutoSaveReplays", ch_autoSaveReplay.Checked);
            so.Add("RefereePassword", tb_refereePass.Text);
            so.Add("RefereeMode", cb_refereeValid.SelectedText);
            so.Add("AutoSaveValidationReplays", ch_autoSaveReplay.Checked);
            so.Add("HideServer", false);
            so.Add("UseChangingValidationSeed", true);
            so.Add("ClientInputsMaxLatency", 0);
            so.Add("DisableHorns", ch_horns.Checked);
            so.Add("DisableServiceAnnounces", false);
            so.Add("KeepPlayerSlots", ch_keepPlayerSlot.Checked);
          
            Hashtable serverOptions = new Hashtable(so);

            asyncRequest("setServerOptions", serverOptions);


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
            asyncRequest("SetModeScriptSettings", dic);
        }
        #endregion

    }
}
