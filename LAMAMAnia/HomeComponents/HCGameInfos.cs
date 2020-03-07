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
            //Do checks
        }

        /// <summary>
        /// 
        /// </summary>
        public override void onPluginUpdate()
        {
            this.l_players.setText(Lama.nbPlayers + "/" + Lama.maxPlayers);

            base.onPluginUpdate();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="res"></param>
        protected override void onGbxAsyncResult(GbxCall res)
        {
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
                    Lama.nbPlayers = userList.Count;
                    setLabel(l_players, Lama.nbPlayers + "/" + Lama.maxPlayers);
                    break;

                case GetCurrentMapInfo:
                    var htcm = res.getHashTable();
                    setLabel(l_map, ManiaColors.getText((string)htcm["Name"]));
                    break;

                case GetServerOptions:
                    setLabel(l_players, Lama.nbPlayers + "/" + Lama.maxPlayers);
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="res"></param>
        public override void onGbxCallBack(GbxCallbackEventArgs res)
        {
            switch (res.Response.MethodName)
            {
                case "ManiaPlanet.BeginMap":   
                    asyncRequest(GetScriptName);
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

               
                        

                case "TrackMania.BeginChallenge":
                    asyncRequest(GetScriptName);
                    setLabelColor(l_map, Color.Green);

                    List<MapInfo> test = Lama.maps;


                    Hashtable ht = (Hashtable)res.Response.Params[0];
                    setLabel(l_map, ManiaColors.getText((string)ht["Name"]));
               //     Lama.previousMapId = (int)ht["UId"];
                    asyncRequest("GetCurrentMapIndex");
                    break;

                case GBXCallBacks.ManiaPlanet_PlayerConnect:
                    setLabel(l_players, Lama.nbPlayers + "/" + Lama.maxPlayers);

                    break;

            }
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

                asyncRequest(SetScriptName, gm);
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
            if (Lama.previousMapId != -1)
                asyncRequest(res =>
                {
                    if (!res.Error)
                        asyncRequest(NextMap, checkError);
                    else
                        checkError(res);
                }, 
                SetNextMapIndex, Lama.previousMapId);
        }
    }
}
