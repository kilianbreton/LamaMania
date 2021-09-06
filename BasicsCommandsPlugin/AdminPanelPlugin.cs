using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LamaPlugin;
using LamaPlugin.ManiaLink;
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
            base.Version = "0.1";
            base.PluginKey = "535f1d474116b9038aa33a42ed783484e6369fd310c203cc9ce77c762746f950b6b557e1ef14811077a7bd33a3b55f2dcba1778f7e4ea96f6a06a77f857bece1ddf0b13ba3d4fd4d04a334e1029a074302b18798a2af336108b642fa0f60ad107dcabdbe66de444dfddd9e03c26952e3d85313adaac6d1cfdd9d56da1dab633a";
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
           
                Callbacks.AddListener(GBXCallBacks.ManiaPlanet_PlayerManialinkPageAnswer, callback_ManiaLinkAnswer);            
                Callbacks.AddListener(GBXCallBacks.ManiaPlanet_PlayerConnect, callback_PlayerConnect);

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
                      //  asyncRequest(GBXMethods.SendDisplayManialinkPageToLogin, login, makePanelManiaLink().getXmlText(), 0, false);
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
            string action = (string)e.Response.Params[1];
            switch (action)
            {
                case "0":   //Close
                 //   asyncRequest(GBXMethods.SendHideManialinkPageToLogin);
                    break;

                case "Restart":   //Restart
                    asyncRequest(GBXMethods.RestartMap, checkError);
                    break;

                case "Prev":   //Previous
                   
                    break;
                case "Next":   //Next
                    asyncRequest(GBXMethods.NextMap, checkError);
                    break;
                case "Players":   //PlayerList

                    break;
                case "AddTime":   //AddTime

                    break;
              
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
                
        private ManialinkFile makePanelManiaLink()
        {
            ManialinkFile mlf = new ManialinkFile(false);

            MLFrame main = new MLFrame(0, 0);

            mlf.Nodes.Add(main);

            MLQuad mlqClose = new MLQuad(-10, 20, 1, 5, 5, "000", "Icons128x32_1", "Close", "CallVotePlugin?Action=0");
            MLQuad mlqRestart = new MLQuad(-5, 20, 1, 5, 5, "000", "Icons128x32_1", "RT_Laps", "CallVotePlugin?Action=Restart");
            MLQuad mlqPrev = new MLQuad(5, 20, 1, 5, 5, "000", "Icons64x64_1", "ArrowFastPrev", "CallVotePlugin?Action=Prev");
            MLQuad mlqNext = new MLQuad(10, 20, 1, 5, 5, "000", "Icons64x64_1", "ArrowFastNext", "CallVotePlugin?Action=Next");
            MLQuad mlqPlayers = new MLQuad(15, 20, 1, 5, 5, "000", "Icons128x128_1", "Buddies", "CallVotePlugin?Action=Players");
            MLQuad mlqAddTime = new MLQuad(20, 20, 1, 5, 5, "000", "Icons128x32_1", "RT_TimeAttack", "CallVotePlugin?Action=AddTime");
          
            main.Childs.Add(mlqClose);
            main.Childs.Add(mlqRestart);
            main.Childs.Add(mlqPrev);
            main.Childs.Add(mlqNext);
            main.Childs.Add(mlqPlayers);
       


            return mlf;
        }





        //==================================================================================================================
        //=[UNUSED]=========================================================================================================
        //==================================================================================================================
     
      
        public override void onDisconnect()
        {

        }


    }
}
