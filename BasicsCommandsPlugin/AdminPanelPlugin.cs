using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LamaPlugin;
using NTK.IO.Xml;
using TMXmlRpcLib;

namespace BasicsCommandsPlugin
{
    public class AdminPanelPlugin : InGamePlugin
    {

        private const string CONFIG_NAME = "PluginPanelConfig.xml";

        private Regex rx = new Regex("^/[a-zA-Z0-9_ ]");
        private List<Player> players = new List<Player>();
        private List<CallVote> callVotes = new List<CallVote>();
        private int callVotesIndex = -1;
        private CallVote currentCallVote = null;


        private XmlDocument config;



        public AdminPanelPlugin()
        {
            base.PluginName = "AdminPanel";
            base.Author = "KBT";
            base.PluginFolder = "[NONE]";

            base.Requirements = new List<Requirement>();
            base.Requirements.Add(new Requirement(RequirementType.FILE, CONFIG_NAME));
            base.Requirements.Add(new Requirement(RequirementContext.LOCAL));
            base.Requirements.Add(new Requirement(RequirementType.PLUGIN, "UserLevels"));
        }

        public override bool onLoad(LamaConfig lamaConfig)
        {
        
            try
            {
                this.players = lamaConfig.players;
           
                Callbacks.Add(GBXCallBacks.ManiaPlanet_PlayerManialinkPageAnswer, callback_ManiaLinkAnswer);
                Callbacks.Add(GBXCallBacks.ManiaPlanet_PlayerConnect, callback_PlayerConnect);
                Callbacks.Add("TrackMania.PlayerConnect", callback_PlayerConnect);


                //asyncRequest(checkError, GBXMethods.S)    TODO: Unable maniaplanet CallVote system.
                return true;
            }
            catch (Exception e)
            {
                Log("ERROR", "[" + base.PluginName + "]>" + e.Message);
            }
          
            return false;
        }

        private void callback_PlayerConnect(object o, GbxCallbackEventArgs e)
        {
            try
            {
                var htPlayerChat = e.Response.Params;
           //     string msg = (string)htPlayerChat[2];
                string login = (string)htPlayerChat[0];

                Player playerSender = searchByLogin(login);


                InterPluginResponse r = sendInterPluginCall("UserLevels", "GetUserLevel", new Dictionary<string, object>() {
                        {"login", login }
                    });
                string level = (string)r.Param[login];
                switch (level.ToUpper())
                {
                    case "ADMIN":
                    case "MASTERADMIN":
                        asyncRequest(GBXMethods.SendDisplayManialinkPageToLogin, login, makeCallVoteManiaLink().getXmlText(), 0, false);
                        break;
                    default:
                        
                        break;
                }



            }
            catch (Exception err)
            {
                Log("ERROR", "[" + this.PluginName + "]>" + err.Message);
            }
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
            catch (Exception err)
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



        private ManialinkFile makeCallVoteManiaLink()
        {
            ManialinkFile mlf = new ManialinkFile(false);

            MLFrame main = new MLFrame(0, 0);

            mlf.Nodes.Add(main);

            MLQuad mlqClose = new MLQuad(0, 0, 1, 20, 20, "000", "Icons64x64_1", "Close", "CallVotePlugin?Action=0");
            MLQuad mlqYes = new MLQuad(0, 0, 1, 20, 20, "000", "Icons64x64_1", "Close", "CallVotePlugin?Action=0");
            MLQuad mlqNo = new MLQuad(0, 0, 1, 20, 20, "000", "Icons64x64_1", "Close", "CallVotePlugin?Action=0");
            main.Childs.Add(mlqClose);
            main.Childs.Add(mlqYes);
            main.Childs.Add(mlqNo);
          



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
