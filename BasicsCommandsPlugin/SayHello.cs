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
            this.PluginKey = "6897964d6c0739edf42f71c8e24a06edc2e07f75e1edda06634524a82d9787181a80f6aae234757a90f7de43754bc5218b89ced248bf0724073fdf1f8f79cfa883c6df96872b2dfbe3d4e78dcf2be10176bac8bade3d10fefbc0ef0a994fa681c7eab963274b1123e86ad8dc6f5313f337096ac62697ee0c4b7d1bae714aca80";

            this.Callbacks.Add(GBXCallBacks.ManiaPlanet_PlayerConnect, callBack_PlayerConnect);
            this.Callbacks.Add("TrackMania.PlayerConnect", callBack_PlayerConnect);
         
            this.Callbacks.Add(GBXCallBacks.ManiaPlanet_PlayerDisconnect, callBack_PlayerDisconnect);
            this.Callbacks.Add("TrackMania.PlayerDisconnect", callBack_PlayerDisconnect);

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
       
        public override void onGbxAsyncResult(GbxCall res) { }

        public override void onGbxCallBack(object sender, GbxCallbackEventArgs args){}

        public override void onDisconnect(){ }

        
        Player getPlayerByLogin(string login)
        {
            Player ret = null;
            int cpt = 0;

            if (this.players.Count > 0)
            {
                while (cpt < this.players.Count && this.players[cpt].Login != login) { cpt++; }
                if (this.players[cpt].Login == login)
                {
                    ret = this.players[cpt];
                }
            }
            return ret;
        }
    }
}
