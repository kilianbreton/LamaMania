using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LamaPlugin;
using LamaPlugin.ManiaLink;
using LamaPlugin.ManiaLink.Styles;
using TMXmlRpcLib;

namespace ManiaExchange
{
    public class IGManiaExchange : InGamePlugin
    {
        private Regex rx = new Regex("^/[a-zA-Z0-9_ ]");
        private List<Player> players;


        public IGManiaExchange()
        {
            base.PluginName = "IGManiaExchange";
            base.PluginDescription = "Widget and commands to manage maniaexchange maps";
            base.Author = "KBT";
            base.Requirements.Add(new Requirement(RequirementContext.LOCAL));

        }

       

        public override bool onLoad(LamaConfig lamaConfig)
        {
            Callbacks.AddListener(GBXCallBacks.ManiaPlanet_PlayerConnect, cbPlayerConnect);
            Callbacks.AddListener(GBXCallBacks.ManiaPlanet_PlayerChat, cbPlayerChat);

            return true;
        }

        private void cbPlayerChat(object sender, GbxCallbackEventArgs args)
        {
            try
            {
                var htPlayerChat = args.Response.Params;
                string msg = (string)htPlayerChat[2];
                string login = (string)htPlayerChat[1];

                Player playerSender = searchByLogin(login);



                InterPluginResponse r = sendInterPluginCall("UserLever", "GetUserLevel", new Dictionary<string, object>() {
                        {"login", login }
                    });
                if (r != null)
                {
                    string level = (string)r.Param[login];

                    if (rx.IsMatch(msg)) //Check is command (/....)------------------------
                    {
                        //Admin Commands////////////////////////////////////////////////////////////////
                        if (msg.ToLower().Contains("/mxadd ") && msg.Length > 7 && checkLevel(level, "ADMIN"))
                        { 
                            
                        }
                    }
                }
            }
            catch(Exception e)
            {

            }
        }

        private void cbPlayerConnect(object sender, GbxCallbackEventArgs args)
        {
            string login = (string)args.Response.Params[0];
            

            ManialinkFile mlf = new ManialinkFile(true);

            mlf.Nodes.Add(new MLFrame(80, 10, 1));
            mlf.Nodes[0].Childs.Add(new MLQuad(0, 0, 2, 50, 50, "F0A", "Bgs1InRace", QuadBgs1InRace.BgTitleGlow));

            asyncRequest(checkError, GBXMethods.SendDisplayManialinkPageToLogin, login, mlf.getXmlText());
        }

        public override void onDisconnect()
        {

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


        private bool checkLevel(string source, string check)
        {
            bool ret = false;
            switch (check.ToUpper())
            {
                case "GUEST":
                    ret = (source.ToUpper() == "GUEST");
                    break;
                case "USER":
                    ret = true;
                    break;
                case "MODERATOR":
                    switch (source.ToUpper())
                    {
                        case "MODERATOR":
                        case "ADMIN":
                        case "MASTERADMIN":
                            ret = true;
                            break;
                        default:
                            ret = false;
                            break;
                    }
                    break;
                case "ADMIN":
                    switch (source.ToUpper())
                    {
                        case "ADMIN":
                        case "MASTERADMIN":
                            ret = true;
                            break;
                        default:
                            ret = false;
                            break;
                    }
                    break;

                case "MASTERADMIN":
                    ret = (source.ToUpper() == "MASTERADMIN");
                    break;

            }
            return ret;
        }

    }
}
