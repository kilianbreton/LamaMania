using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LamaPlugin;
using LamaPlugin.Other;
using TMXmlRpcLib;
using static LamaPlugin.StaticM;
using NTK.IO.Xml;
using System.Text.RegularExpressions;

namespace BasicsCommandsPlugin
{
    public class CallVotePlugin : InGamePlugin
    {
        private const string CONFIG_NAME = "CallVoteConfig.xml";

        private Regex rx = new Regex("^/[a-zA-Z0-9_ ]");
        private List<Player> players = new List<Player>();
        private List<CallVote> callVotes = new List<CallVote>();
        private int callVotesIndex = -1;
        private CallVote currentCallVote = null;

        
        private XmlDocument config;

       

        public CallVotePlugin()
        {
            base.PluginName = "CallVote";
            base.Author = "KBT";
            base.PluginFolder = "[NONE]";


            base.Requirements.Add(new Requirement(RequirementType.FILE, CONFIG_NAME));
            base.Requirements.Add(new Requirement(RequirementContext.LOCAL));
            base.Requirements.Add(new Requirement(RequirementType.PLUGIN, "UserLevels"));
        }



        public override bool onLoad(LamaConfig lamaConfig)
        {
            if (lamaConfig.configFiles.ContainsKey(CONFIG_NAME)) 
            {
                try
                {
                    this.players = lamaConfig.players;
                    this.config = lamaConfig.configFiles[CONFIG_NAME];

                    
                    Callbacks.Add(GBXCallBacks.ManiaPlanet_PlayerManialinkPageAnswer, callback_ManiaLinkAnswer);
                    Callbacks.Add(GBXCallBacks.ManiaPlanet_PlayerChat, callback_PlayerChat);
                    Callbacks.Add("TrackManaia_PlayerChat", callback_PlayerChat);
                    Callbacks.Add(GBXCallBacks.ManiaPlanet_EndMatch, callback_EndMatch);
                    
                    //asyncRequest(checkError, GBXMethods.S)    TODO: Unable maniaplanet CallVote system.
                    return true;
                }
                catch (Exception e)
                {
                    Log("ERROR", "[" + base.PluginName + "]>" + e.Message);
                }
            }
            return false;
        }

        private void callback_ManiaLinkAnswer(object o, GbxCallbackEventArgs e)
        {
            string action = (string)e.Response.getHashTable()["Action"];
            switch (action)
            {
                case "0":   //Close

                    break;

                case "1":   //Yes

                    break;

                case "2":   //No

                    break;
            }


        }

        private void callback_PlayerChat(object o, GbxCallbackEventArgs e)
        {
            try
            {
                var htPlayerChat = e.Response.Params;
                string msg = (string)htPlayerChat[2];
                string login = (string)htPlayerChat[1];

                Player playerSender = searchByLogin(login);



                InterPluginResponse r = sendInterPluginCall("UserLever", "GetUserLevel", new Dictionary<string, object>() {
                        {"login", login }
                    });
                string level = (string)r.Param[login];






                if (rx.IsMatch(msg)) //Check is command (/....)------------------------
                {
                    // /CallVote SkipMap


                }
            }
            catch(Exception err)
            {
                Log("ERROR", "[" + this.PluginName + "]>" + err.Message);
            }
        }

        private Player searchByLogin(string login)
        {
            Player ret = null;
            int cpt = 0;
            while (cpt < this.players.Count && this.players[cpt].Login != login) { cpt++; }

            if (cpt < this.players.Count && this.players[cpt].Login == login)
                ret = this.players[cpt];


            return ret;
        }


        private void callback_EndMatch(object o, GbxCallbackEventArgs e)
        {
            
        }



        public override InterPluginResponse onInterPluginCall(IBasePlugin sender, InterPluginArgs args)
        {
            InterPluginResponse response = null;
            switch (args.CallName)
            {
                case "GetCallList":
                    response = new InterPluginResponse(args.CallName, new Dictionary<string, object>
                    {
                        {"GetCallList","All" },
                        {"GetCallVoteList","All" },
                        {"GetCurrentVote","All" },
                        {"CallVote","All" },
                        {"VoteYes","All" },
                        {"VoteNo","Call" },
                        {"ForceVote","Admin" },
                        {"CancelVote","Admin" },
                      
                    });

                    break;

                case "GetCallVoteList":
                    response = new InterPluginResponse(args.CallName, new Dictionary<string, object>
                    {
                        {"SkipMap","All" },
                        {"RestartMap","All" },
                        {"SetNextMap","All" },
                        {"SetPrevToNext","All" },
                        {"EditTime","All" },
                        {"Kick","All" },
                        {"Warn","All" },
                        {"Ban","Moderator" },

                    });
                    break;

                case "CallVote":

                    addCallVote(sender.PluginName, (string)args.Args["CallVoteName"], (string)args.Args["CallVoteArgs"]);


                    break;


            }




            return response;
        }




        private bool voteCallVote(string senderLogin, bool value)
        {




            return false;
        }


        private int addCallVote(string senderLogin, string callVoteName, string args)
        {
            if(currentCallVote == null)
            {
                currentCallVote = new CallVote(callVoteName, args);
                callVotes.Add(currentCallVote);
                callVotesIndex = callVotes.Count;

                asyncRequest(checkError, 
                            GBXMethods.SendDisplayManialinkPage,
                            0, 
                            true);



                return callVotesIndex;
            }
           
            return -1;
        }




        private ManialinkFile makeCallVoteManiaLink(CallVote cv, Player p)
        {
            ManialinkFile mlf = new ManialinkFile(false);

            MLFrame main = new MLFrame(0, 0);

            mlf.Nodes.Add(main);

            MLQuad mlqClose = new MLQuad(0, 0, 1, 20, 20, "000", "Icons64x64_1", "Close", "CallVotePlugin?Action=0");
            if (!cv.haveVote(p))
            {
                MLQuad mlqYes = new MLQuad(0, 0, 1, 20, 20, "000", "Icons64x64_1", "Close", "CallVotePlugin?Action=0");
                MLQuad mlqNo = new MLQuad(0, 0, 1, 20, 20, "000", "Icons64x64_1", "Close", "CallVotePlugin?Action=0");
                main.Childs.Add(mlqClose);
                main.Childs.Add(mlqYes);
                main.Childs.Add(mlqNo);
            }
            else
            {
                string text = "";
                MLLabel mllabel = new MLLabel(text, 5, 5);
                main.Childs.Add(mlqClose);
                main.Childs.Add(mllabel);
            }

         


            return mlf;
        }


                                    


        //==================================================================================================================
        //=[UNUSED]=========================================================================================================
        //==================================================================================================================
        public override void onGbxAsyncResult(GbxCall res)
        {
            
        }
        public override void onGbxCallBack(object sender, GbxCallbackEventArgs args)
        {
            
        }
        public override void onDisconnect()
        {
            
        }
    }
}
