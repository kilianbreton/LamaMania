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

        public HCGameInfos()
        {
            InitializeComponent();
            initGameModeCombo("TimeAttack");
            addMouseEvents(this.gb_gameInfos);
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

        protected override void onGbxAsyncResult(GbxCall res)
        {
            switch (handles[res.Handle])
            {
                case GetScriptName:
                    var htscript = res.getHashTable();
                    string script = (string)htscript["CurrentValue"];
                    if (script.ToLower().Contains(".script.txt"))
                    {
                        script = subsep(script, 0, ".");
                    }
                    setLabel(this.l_gameMode, "GameMode : " + script);
                    initGameModeCombo(script);
                    break;
            
            }
        }

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
                    var ht = (Hashtable)res.Response.Params[0];
                    setLabel(l_map, "Map : " + ManiaColors.getText((string)ht["Name"]));
                    asyncRequest("GetCurrentMapIndex");
                    break;



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
        }

        private void checkError(GbxCall res)
        {
            if(res.Error)
                Lama.onError(this, res.MethodName, "GBX Error " + res.ErrorString);
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
                        asyncRequest(NextMap);
                }, 
                SetNextMapIndex, Lama.previousMapId);
        }
    }
}
