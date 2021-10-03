using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMXmlRpcLib;
using LamaPlugin;

namespace BasicsCommandsPlugin
{
    public class SayHello : InGamePlugin
    {
        private List<Player> players;


        public SayHello()
        {
            this.PluginName = "SayHello";
            this.PluginDescription = "Informe les joueurs lors d'une connexion/déconnexion d'un autre joueur.";
            this.Author = "KBT";
            this.PluginFolder = "[NONE]";
           
            this.Callbacks.AddListener(GBXCallBacks.ManiaPlanet_PlayerConnect, callBack_PlayerConnect);
            this.Callbacks.AddListener(GBXCallBacks.ManiaPlanet_PlayerDisconnect, callBack_PlayerDisconnect);


            this.Requirements.Add(new Requirement(RequirementType.PLUGIN, "UserLevels"));
        }

        private void callBack_PlayerDisconnect(object o, GbxCallbackEventArgs e)
        {
            string login = (string)e.Response.Params[0];

            Player p = getPlayerByLogin(login);
            if (p != null)
                login = p.NickName;

            asyncRequest(checkError, GBXMethods.ChatSendServerMessage, "$40fDisconnection $fff: $922" + login);
        }

        private void callBack_PlayerConnect(object o, GbxCallbackEventArgs e)
        {
            string login = (string)e.Response.Params[0];
            Player p = getPlayerByLogin(login);
            if (p != null)
                login = p.NickName;

            asyncRequest(checkError, GBXMethods.ChatSendServerMessageToLogin, "Hello " + login, login);
            asyncRequest(checkError, GBXMethods.ChatSendServerMessage, "$40fNew Player $fff: $922" + login);
            
        }

        public override bool onLoad(LamaConfig lamaConfig)
        {
            this.players = lamaConfig.players;

            return true;    
        }
       
     

        public override void onDisconnect(){ }

        
        Player getPlayerByLogin(string login)
        {
          
            Player ret = null;
            if (this.players != null)
            {
                int cpt = 0;

                if (this.players.Count > 0)
                {
                    while (cpt < this.players.Count && this.players[cpt].Login != login) { cpt++; }
                    if (this.players[cpt].Login == login)
                    {
                        ret = this.players[cpt];
                    }
                }
            }
            return ret;
        }
    }
}
