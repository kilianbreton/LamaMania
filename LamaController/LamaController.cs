using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTK.IO.Xml;
using static NTK.Other.NTKF;
using NTK.IO;
using NTK;
using TMXmlRpcLib;
using System.IO;
using System.Net;
using LamaPlugin;
using XmlRpcEncrypted;
using NTK.Service;
using CGE.OUT;
using static LamaController.Program;
using static LamaPlugin.StaticM;
using static LamaPlugin.GBXMethods;
using System.Collections;

namespace LamaController
{
    public enum Game
    {
        TM,
        SM
    }

    public class LamaController
    {
        private const int TRY_AUTH_NB = 5;
        private const int WAIT_AUTH_TIME = 1500;

        DataGrid dg;

        private Dictionary<int, String> handles = new Dictionary<int, string>();


        //Network
        NTKServer ntkServer;
        XmlRpcClient client;

        XmlNode mainConfig;
        XmlNode pluginsConfig;
        XmlNode logsConfig;
        MainLogger mainLogger;
        NTKLogger ntkLogger;

        List<InGamePlugin> plugins = new List<InGamePlugin>();
        string ip;
        int port;
        string login;
        string pass;
      /*  Game game;
        bool connected;*/
        bool remoteXmlRpc = true;
        private string mapPath;

        public LamaController(XmlDocument config)
        {
            Console.WriteLine("LamaController V0.1");
            Console.WriteLine("GNU");
            Console.WriteLine();

            lama = new Lama();

            lama.lamaLogger = new LamaLog(@"Logs\Lama.log",true,true);
            lama.launched = true;
            lama.remote = false;


            Console.WriteLine("Analyse des plugins ...");
            lama.pluginManager = new PluginManager(@"Config\Plugins\", "", lama);
            lama.pluginManager.loadPlugins();

            Console.WriteLine("Lecture de la configuration ...");
            lama.mainConfig = new XmlDocument(@"Config\Main.xml");
            XmlNode root = lama.mainConfig["config"];
            XmlNode server = root["server"];

            this.ip = server["ip"].Value;
            this.port = (int)server["port"].LValue;
            
            this.login = server["login"].Value;
            this.pass = server["password"].Value;

            lama.pluginManager.selectPluginsFrmCfg(root["plugins"]);

            lama.log("NOTICE", "Connect to server");
            connectXmlRpc();

            if(lama.connected)
                lama.pluginManager.onLoadInGame(this.client);
            

        /*    ConsoleKeyInfo k = Console.ReadKey();
            while (k.Key != ConsoleKey.Q)
            {
                Console.ReadKey();
            }*/
        }



        void startupRequests()
        {
            //Options & GameInfos
            asyncRequest(GetServerOptions, getServerOptions);
            asyncRequest(GetCurrentGameInfo, getCurrentGameInfo);

            //Script
            asyncRequest(GetModeScriptSettings, getModeScriptSettings);
            asyncRequest(GetScriptName);

            //Map
            asyncRequest(GetCurrentMapInfo); //Catched by HCGameInfos
       

            //Users lists
            asyncRequest(GetPlayerList, lama.maxPlayers + lama.maxSpectators, 0);
            asyncRequest(GetGuestList, lama.maxPlayers + lama.maxSpectators, 0);
            asyncRequest(GetBanList, lama.maxPlayers + lama.maxSpectators, 0);
            asyncRequest(GetBlackList, lama.maxPlayers + lama.maxSpectators, 0);
            asyncRequest(getMapList, GetMapList, 999, 0);
            asyncRequest(checkError, ChatSendServerMessage, "$o$12d LamaMania V 0.0.1 ....");
            
        }

        void connectXmlRpc()
        {
            int cpt = 0;
            while (cpt++ < TRY_AUTH_NB && !lama.connected && ((!lama.remote && lama.launched) || lama.remote))
            {
                try
                {
                    this.client = new XmlRpcClient(this.ip, this.port);
                    GbxCall authAnsw = this.client.Request(GBXMethods.Authenticate, this.login, this.pass);
                    if (authAnsw.Params[0].Equals(true)) //Auth success---------------------------------
                    {
                        this.client.EnableCallbacks(true);
                        this.client.EventGbxCallback += new GbxCallbackHandler(gbxCallBack);
                        this.client.EventOnDisconnectCallback += new OnDisconnectHandler(gbxDisconnect);

                        lama.connected = true; //exit loop
                        lama.log("SUCCESS", "Success");
                    }
                }
                catch (Exception err)
                {
                    System.Threading.Thread.Sleep(WAIT_AUTH_TIME);
                    lama.log("ERROR", "Error :" + err.Message);
                }
            }
        }




        void getServerOptions(GbxCall res)
        {
            Hashtable ht = res.getHashTable();

            lama.maxPlayers = (int)ht["CurrentMaxPlayers"];
            lama.maxSpectators = (int)ht["CurrentMaxSpectators"];
            lama.serverName = (string)ht["Name"];
            lama.serverComment = (string)ht["Comment"];

            //Fill ServerOptions Tab
           /* tb_ingameName.Text = "";
            setTextBoxText(tb_ingameName, (string)ht["Name"]);
            setTextBoxText(tb_description, (string)ht["Comment"]);
            setTextBoxText(tb_playerPass, (string)ht["Password"]);
            setTextBoxText(tb_specPass, (string)ht["PasswordForSpectator"]);

            setNumeric(n_playersLimit, Program.lama.maxPlayers);
            setNumeric(n_specsLimit, Program.lama.maxSpectators);

            setTextBoxText(tb_refereePass, (string)ht["RefereePassword"]);
            //TODO comboboxReferee

            setNumeric(n_voteTimeout, (int)ht["NextCallVoteTimeOut"]);

            setTextBoxText(tb_voteRatio, (string)ht["NextCallVoteRatio"]);

            int lm = (int)ht["NextLadderMode"];

            setCheckBox(ch_ladder, (lm == 1));
            setCheckBox(ch_p2pUp, (bool)ht["IsP2PUpload"]);
            setCheckBox(ch_p2pDown, (bool)ht["IsP2PDownload"]);
            setCheckBox(ch_autoSaveReplay, false);
            setCheckBox(ch_saveValReplay, false);
            setCheckBox(ch_keepPlayerSlot, false);
            setCheckBox(ch_mapDown, false);
            setCheckBox(ch_horns, false);
            */
            Program.lama.pluginManager.onGbxAsyncResult(res);
        }

        void getCurrentGameInfo(GbxCall res)
        {
            Hashtable ht = res.getHashTable();

        }

        void getModeScriptSettings(GbxCall res)
        {
            Hashtable ht = res.getHashTable();
            int cpt = 0;
           
            foreach (string key in ht.Keys)
            {
                string name = key;
                if (Program.lama.scriptSettingsLocales.ContainsKey(key))
                {
                    name = Program.lama.scriptSettingsLocales[key];
                }
                

            }
        }

        void getMapList(GbxCall res)
        {

            ArrayList lst = res.Params;
            foreach (Hashtable map in lst)
            {
                MapInfo m = new MapInfo((string)map["Uid"],
                                        (string)map["Name"],
                                        (string)map["FileName"],
                                        (string)map["Author"],
                                        (string)map["Environnement"]);
            }




        }


        void getMapDirectory(GbxCall res)
        {
            this.mapPath = (string)res.Params[0];

            //Init map section
            Program.lama.log("NOTICE", "Init map section");
            if (Program.lama.remote)
            {
           
            }
            else //Local
            {
             
            }
        }




        private void gbxDisconnect(object o)
        {
            lama.pluginManager.onDisconnect();
        }

        private void gbxCallBack(object o, GbxCallbackEventArgs e)
        {
            lama.pluginManager.onGbxCallBack(o, e);
        }

        private void asyncResult(GbxCall res)
        {
            lama.pluginManager.onGbxAsyncResult(res);
        }


        void asyncRequest(String methodName, params object[] param)
        {
            if (lama.connected)
            {
                if (param == null)
                    param = new object[] { };

                int handle = this.client.AsyncRequest(methodName, param, asyncResult);
                this.handles.Add(handle, methodName);
                GBXMethods.commonHandles.Add(handle, methodName);
            }
        }

        void asyncRequest(GbxCallCallbackHandler handler, String methodName, params object[] param)
        {
            if (lama.connected)
            {
                if (param == null)
                    param = new object[] { };
                this.client.AsyncRequest(methodName, param, handler);
            }
        }

        void asyncRequest(String methodName, GbxCallCallbackHandler handler)
        {
            if (lama.connected)
                this.client.AsyncRequest(methodName, new object[] { }, handler);
        }




        void checkError(GbxCall res)
        {
            if (res.Error)
            {
                lama.log("ERROR", "Error " + res.ErrorCode + " : " + res.ErrorString + "\n from request : " + res.MethodName);
            }
        }
    }
}
