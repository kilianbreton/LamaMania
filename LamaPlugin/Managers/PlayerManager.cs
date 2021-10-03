using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMXmlRpcLib;

namespace LamaPlugin
{
    public class PlayerManager : IManager
    {
        private List<Player> players = new List<Player>();
        private CallbacksManager Callbacks = new CallbacksManager();
        
        public PlayerManager()
        {
            Callbacks.AddListener(GBXCallBacks.ManiaPlanet_PlayerConnect, (sender, args) =>
            {

            });
            
            Callbacks.AddListener(GBXCallBacks.ManiaPlanet_PlayerDisconnect, (sender, args) =>
            {

            });
        }

        //==============================================================================================================
        //=[Properties]=================================================================================================
        //==============================================================================================================

        public List<Player> Players { get => players; set => players = value; }

        public void onGbxCallBack(object sender, GbxCallbackEventArgs args)
        {
            Callbacks.onGbxCallBack(sender, args);
        }
    }
}
