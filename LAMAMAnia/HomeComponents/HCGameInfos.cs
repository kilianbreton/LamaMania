using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LamaPlugin;
using static LamaMania.StaticMethods;
using static LamaPlugin.GBXMethods;
using static NTK.Other.NTKF;
using TMXmlRpcLib;
using FlatUITheme;
using System.Collections;

namespace LamaMania.HomeComponents
{
    public partial class HCGameInfos : HomeComponentPlugin
    {
        private SMGameMode smGameMode;
        private TMGameMode tmGameMode;
        private bool isTM = true;
      
        /// <summary>
        /// 
        /// </summary>
        public HCGameInfos()
        {
            InitializeComponent();

            initGameModeCombo("TimeAttack");
            addMouseEvents(this.gb_gameInfos);

            //Plugin Infos
            base.Author = "KBT";
            base.PluginName = "HomeComponent - GameInfos";
            base.PluginFolder = "[NONE]";

            base.NeedXmlRpcConnection = true;


            //init labelNames
            this.l_map.initName("Map : ");
            this.l_gameMode.initName("GameMode : ");
            this.l_players.initName("Players : ");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cfg"></param>
        public override void onLoad(LamaConfig cfg)
        {
            Callbacks.AddListener(GBXCallBacks.ManiaPlanet_BeginMap, (s, a) => 
            {
                asyncRequest(GetScriptName, onGetScriptName);
                asyncRequest(GetCurrentMapInfo, (res) => {
                    var htcm = res.getHashTable();
                    setLabel(l_map, ManiaColors.getText((string)htcm["Name"]));
                });
                setLabelColor(l_map, Color.Green);
            });
            Callbacks.AddListener(GBXCallBacks.ManiaPlanet_BeginMatch, (s, a) =>
            {
                onBeginChallenge(s, a);
                asyncRequest(GetCurrentMapInfo, (res) => {
                    var htcm = res.getHashTable();
                    setLabel(l_map, ManiaColors.getText((string)htcm["Name"]));
                });
                setLabelColor(l_map, Color.Green);
            });
            Callbacks.AddListener(GBXCallBacks.ManiaPlanet_EndMap, (s, a) =>
            {
                setLabelColor(l_map, Color.Red); 
            });
            Callbacks.AddListener(GBXCallBacks.ManiaPlanet_EndMatch, (s, a) =>
            {
                setLabelColor(l_map, Color.Orange);
            });
            Callbacks.AddListener("TrackMania.EndRace", (s, a) =>
            {
                setLabelColor(l_map, Color.Orange);
            });
            Callbacks.AddListener("TrackMania.EndChallenge", (s, a) =>
            {
                setLabelColor(l_map, Color.Red);
            });

            Callbacks.AddListener("TrackMania.BeginChallenge", onBeginChallenge);
            Callbacks.AddListener("TrackMania.BeginRace", onBeginChallenge);
           
            Callbacks.AddListener(GBXCallBacks.ManiaPlanet_PlayerConnect, (s, a) =>
            {
                setLabel(l_players, Program.lama.nbPlayers + "/" + Program.lama.maxPlayers);
            });
        }

        void onBeginChallenge(object sender, GbxCallbackEventArgs args)
        {
            asyncRequest(GetScriptName, onGetScriptName);
            setLabelColor(l_map, Color.Green);

            List<MapInfo> test = Program.lama.maps;

            Hashtable ht = (Hashtable)args.Response.Params[0];
            setLabel(l_map, ManiaColors.getText((string)ht["Name"]));
            //Program.lama.previousMapId = (int)ht["UId"];
            asyncRequest(GBXMethods.GetCurrentMapIndex, onGetCurrentMapIndex);
        }


        /// <summary>
        /// 
        /// </summary>
        public override void onPluginUpdate()
        {
            this.l_players.setText(Program.lama.nbPlayers + "/" + Program.lama.maxPlayers);
            base.onPluginUpdate();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="res"></param>
     /*   protected override void onGbxAsyncResult(GbxCall res)
        {

            var htcm = res.getHashTable();
                    setLabel(l_map, ManiaColors.getText((string)htcm["Name"]));

            switch (handles[res.Handle])
            {
                case GetScriptName:
                    Hashtable htscript = res.getHashTable();
                    string script = (string)htscript["CurrentValue"];
                    if (script.ToLower().Contains(".script.txt"))
                    {
                        script = subsep(script, 0, ".");
                    }
                    setLabel(this.l_gameMode, script);
                    initGameModeCombo(script);
                    break;

                case GetPlayerList:
                    ArrayList userList = (ArrayList)res.Params[0];
                    Program.lama.nbPlayers = userList.Count;
                    setLabel(l_players, Program.lama.nbPlayers + "/" + Program.lama.maxPlayers);
                    break;

                case GetCurrentMapInfo:
                    var htcm = res.getHashTable();
                    setLabel(l_map, ManiaColors.getText((string)htcm["Name"]));
                    break;

                case GetServerOptions:
                    setLabel(l_players, Program.lama.nbPlayers + "/" + Program.lama.maxPlayers);
                    break;
            }
        }*/



        private void onGetScriptName(GbxCall res)
        {
            Hashtable htscript = res.getHashTable();
            string script = (string)htscript["CurrentValue"];
            if (script.ToLower().Contains(".script.txt"))
            {
                script = subsep(script, 0, ".");
            }
            setLabel(this.l_gameMode, script);
            initGameModeCombo(script);
        }

        private void onGetCurrentMapIndex(GbxCall res)
        {
         
        }
    

  

        private void B_makeNextGameMode_Click(object sender, EventArgs e)
        {
            string gameMode = cb_serverGMScript.Text;
            string gm = "";
            if (gameMode != "")
            {
                if (!gameMode.Contains(".Script.txt"))
                    gm = gameMode + ".Script.Txt";
                else
                {
                    gm = gameMode;
                }

                asyncRequest(SetScriptName, onGetScriptName);
            }
        }

        void initGameModeCombo(string script)
        {
            FlatComboBox cbGM = (FlatComboBox)getControl(cb_serverGMScript);
            if (cbGM.Items.Count == 0)
            {
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
                    if (Enum.TryParse(script, out this.smGameMode))
                    {
                        foreach (SMGameMode suit in (SMGameMode[])Enum.GetValues(typeof(SMGameMode)))
                        {
                            appendCombo(cb_serverGMScript, suit.ToString());
                        }
                    }
                    else
                    {
                        //Show select game dialog
                    }

                }
            }
        }

        private void B_nextMap_Click(object sender, EventArgs e)
        {
            asyncRequest(checkError, GBXMethods.ChatSendServerMessage, "$f00Server $n$z>> $fffForce next map");
            asyncRequest(NextMap, checkError);
            asyncRequest(GetScriptName, res => {
                Hashtable ht = res.getHashTable();
                setLabel(l_gameMode, subsep((string)ht["NextValue"], 0, ".Script"));
            });
        } 

       
        private void checkError(GbxCall res)
        {
            if(res.Error)
                OnError(this, res.MethodName, "GBX Error " + res.ErrorString);
        }

        private void B_restart_Click(object sender, EventArgs e)
        {
            asyncRequest(RestartMap, checkError);
        }

        private void B_prevMap_Click(object sender, EventArgs e)
        {
            if (Program.lama.previousMapId != -1)
                asyncRequest(res =>
                {
                    if (!res.Error)
                        asyncRequest(NextMap, checkError);
                    else
                        checkError(res);
                },
                SetNextMapIndex, Program.lama.previousMapId);
            else
                Program.lama.log("WARN", "No previous map ID !");
        }
    }
}
