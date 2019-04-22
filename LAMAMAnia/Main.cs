using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMXmlRpcLib;
using NTK.IO.Xml;
using System.Collections;

namespace LAMAMAnia
{
    public partial class Main : Form
    {
        private XmlRpcClient client;
        private string adrs = "127.0.0.1";
        private int port = 5000;
        private string login;
        private string passwd;
        private ManiaColors chatColors;
        private Dictionary<int, String> handles = new Dictionary<int, string>();

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Constructeurs ///////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        public Main(XmlDocument config)
        {
            InitializeComponent();
            if (Config.lang != null)
                loadLang();

            this.chatColors = new ManiaColors(richTextBox1);

            if (Config.launched)
            {
                //Parse base config-----------------------------------------------------------------------------------
                var root = config.getNode(0);
                var auth = root.getChild("authorization_levels");
                foreach (XmlNode n in auth.getChildList())
                {
                    switch (n.getChildV("name"))
                    {
                        case "SuperAdmin":
                            this.login = "SuperAdmin";
                            this.passwd = n.getChildV("password");
                            break;
                    }
                }
                if (Config.remote)
                {
                    this.adrs = Config.remoteAdrs;
                    this.port = Config.remotePort;
                }
                else
                {
                    this.port = (int)root.getChild("system_config").getChildNV("xmlrpc_port");
                }
               
                //Launch XmlRpcClient---------------------------------------------------------------------------------
                int cpt = 0;

                while (cpt < 5 && !Config.connected)
                {
                    cpt++;
                    try
                    {
                        this.client = new XmlRpcClient(this.adrs, this.port);
                        var authAnsw = this.client.Request("Authenticate", new object[]
                        {
                            (object) this.login,
                            (object) this.passwd
                        });
                        if(authAnsw.Params[0].Equals((object)true)) //Auth success---------------------------------
                        {
                            this.client.EnableCallbacks(true);
                            this.client.EventGbxCallback += new GbxCallbackHandler(gbxCallBack);
                            this.client.EventOnDisconnectCallback += new OnDisconnectHandler(gbxDisconnect);
                            
                            Config.connected = true; //exit loop
                        }
                      
                    }
                    catch (Exception e)
                    {
                        System.Threading.Thread.Sleep(2000);
                    }
                }
                if (Config.connected)
                {
                    //Affichage
                    this.b_serverStarted.Enabled = false;
                    this.b_xmlrpcConnect.Enabled = false;
                    this.b_uasecoStop.Enabled = false;
                    this.b_usaecoStart.Enabled = false;

                    //Requêtes
                    asyncRequest("GetStatus", new object[] { });
                    asyncRequest("GetVersion", new object[] { });
                    asyncRequest("GetChatLines", new object[] { });
                    asyncRequest("GetServerName", new object[] { });
                    asyncRequest("GetServerComment", new object[] { });
                    asyncRequest("GetServerPassword", new object[] { });
                    asyncRequest("GetServerPasswordForSpectator", new object[] { });
                    asyncRequest("GetMaxPlayers", new object[] { });
                    asyncRequest("GetMaxSpectators", new object[] { });
                    asyncRequest("GetMapsDirectory", new object[] { });
                    asyncRequest("GetServerOptions", new object[] { });
                }
                else
                {
                    this.Close();
                }

            }//if


        }

        //Constructeur pour les test /!\ NE PAS UTILISER EN PRODUCTION /!\
        public Main()
        {
            InitializeComponent();
            var testColors = new ManiaColors(richTextBox1);
            testColors.write("$i$06f$oLAN $fffBTS $f03SIO");
            
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Methodes UI /////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //Chargement du module de langue
        void loadLang()
        {
            this.formSkin1.Text = Config.lang.getMainTitle();

            this.tabPage1.Text = Config.lang.getMTabMain();
            this.tabPage2.Text = Config.lang.getMtabChat();
            this.tabPage3.Text = Config.lang.getMTabUsers();
            this.tabPage4.Text = Config.lang.getMTabMaps();
            this.tabPage5.Text = Config.lang.getMTabMatchSettings();
            this.tabPage6.Text = Config.lang.getMTabPlugins();
            
            this.gb_status.Text = Config.lang.getMMStatusTitle();
            this.gb_players.Text = Config.lang.getMMPlayersTitle();
            this.gb_gameInfos.Text = Config.lang.getMMGameInfosTitle();

            this.l_gameMode.Text = Config.lang.getMMGameInfosGameMode() + " : ";
            this.l_map.Text = Config.lang.getMMGameInfosMap() + " : ";
            this.l_players.Text = Config.lang.getMMGameInfosPlayers() + " : ";
            this.l_server.Text = Config.lang.getMMStatusServer() + " : ";
            this.l_uaseco.Text = Config.lang.getMMSUaseco() + " : ";
            this.l_xmlrpc.Text = Config.lang.getMMStatusXmlRpc() + " : ";

            this.b_join.Text = Config.lang.getMMGameInfoJoin();
            this.b_makeNextGameMode.Text = Config.lang.getMMGameInfoMakeNext();
            this.b_nextMap.Text = Config.lang.getMMGameInfoNext();
            this.b_prevMap.Text = Config.lang.getMMGameInfosPrevious();
            this.b_restart.Text = Config.lang.getMMGameInfoRestart();
            this.b_stopRound.Text = Config.lang.getMMGameInfoStopRound();

            this.b_serverStarted.Text = Config.lang.getMMStatusServer();
          /*  this.b_serverStop.Text = Config.lang.;
            this.b_uasecoStop.Text = Config.lang.;
            this.b_usaecoStart.Text = Config.lang;
            this.b_xmlrpcClose.Text = Config.lang;
            this.b_xmlrpcConnect.Text = Config.lang;*/
         

        }
         
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

        void clearList(ListBox list)
        {
            if (list.InvokeRequired) //Permet de revenir au Thread de gestion des composants UI
            {
                list.Invoke(new Action<ListBox>(clearList));
            }
            else
            {
                list.Items.Clear();
            }
        }

        void clearRichText(RichTextBox rtb)
        {
            if (rtb.InvokeRequired) //Permet de revenir au Thread de gestion des composants UI
            {
                rtb.Invoke(new Action<RichTextBox>(clearRichText));
            }
            else
            {
                rtb.Clear();
            }
        }

        void enableControl(Control control, bool value)
        {
            if (control.InvokeRequired) //Permet de revenir au Thread de gestion des composants UI
            {
                control.Invoke(new Action<Button, bool>(enableControl), value);
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
                label.Invoke(new Action<Label,String>(setLabel), label, value);
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


        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Methodes GBX ////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void asyncRequest(String methodeName, object[] param)
        {
            this.handles.Add(this.client.AsyncRequest(methodeName, param, basicResult), methodeName);
        }

        void gbxCallBack(object sender, GbxCallbackEventArgs args)
        {
            writeConsole(args.Response.Xml, Color.Orange);
            switch (args.Response.MethodName)
            {   //Race & Map infos
                case "TrackMania.EndRace":
                    setLabelColor(l_map, Color.Orange);
                    break;

                case "TrackMania.EndChallenge":
                    setLabelColor(l_map,  Color.Red);
                    break;

                case "TrackMania.StatusChanged":
                    int statusCode = (int)args.Response.Params[0];
                    setLabel(this.l_server, Config.lang.getMMStatusServer() + " : " + getStatus(statusCode));
                    break;

                case "TrackMania.ChallengeListModified":
                    break;

                case "TrackMania.BeginChallenge":
                    setLabelColor(l_map, Color.Green);
                    var ht = (Hashtable)args.Response.Params[0];
                    setLabel(l_map, Config.lang.getMMGameInfosMap() + " : " + chatColors.getText((string)ht["Name"]));
                    break;

                case "TrackMania.BeginRace":
                    break;

                case "ManiaPlanet.PlayerChat":
                    var r = args.Response;

                    break;

            }
        }

        void gbxDisconnect(object sender)
        {
            writeConsole("---disconnected---", Color.Red);
        }

        void basicResult(GbxCall res)
        {
            try
            {
                switch (this.handles[res.Handle])
                {
                    case "GetStatus":
                        Hashtable ht = (Hashtable) res.Params[0];
                        setLabel(this.l_server, Config.lang.getMMStatusServer() + " : " + (string) ht["Name"]);
                        break;
                    case "GetChatLines":

                        break;
                    case "GetServerName":
                        setLabel(this.l_serverName, Config.lang.getMMServerInfosName() + " : " + chatColors.getText((string)res.Params[0]));
                        break;
                    case "GetServerComment":
                        setLabel(this.l_serverDescritpion, Config.lang.getMMServerInfosDescription() + " : " + chatColors.getText((string)res.Params[0]));
                        break;
                    case "GetServerPassword":

                        break;
                    case "GetServerPasswordForSpectator":

                        break;
                    case "GetMaxPlayers":

                        break;
                    case "GetMaxSpectators":

                        break;
                    case "GetMapsDirectory":

                        break;
                    case "GetServerOptions":

                        break;
                }
                this.handles.Remove(res.Handle);
            }
            catch (Exception e)
            {

            }
            writeConsole(res.Xml,Color.Red);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Autres Methodes /////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

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



        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Methodes Event UI ///////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////


        private void b_prevMap_Click(object sender, EventArgs e)
        {
            this.client.AsyncRequest("", new object[] { }, new GbxCallCallbackHandler(basicResult));
        }

        private void b_restart_Click(object sender, EventArgs e)
        {
            asyncRequest("RestartMap", new object[] { });
        }

        private void b_nextMap_Click(object sender, EventArgs e)
        {
            asyncRequest("NextMap", new object[] { });
        }

        private void b_stopRound_Click(object sender, EventArgs e)
        {
            asyncRequest("ForceEndRound", new object[] { });
        }

        private void b_makeNextGameMode_Click(object sender, EventArgs e)
        {

        }

        private void b_join_Click(object sender, EventArgs e)
        {

        }

        private void b_xmlrpcConnect_Click(object sender, EventArgs e)
        {

        }

        private void b_xmlrpcClose_Click(object sender, EventArgs e)
        {

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
    }
}
