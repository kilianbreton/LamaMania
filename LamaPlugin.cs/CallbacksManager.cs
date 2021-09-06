using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMXmlRpcLib;
using LamaPlugin.Other;

namespace LamaPlugin
{
    public class CallbacksManager
    {
        private Dictionary<string, GbxCallbackHandler> callbacks = new Dictionary<string, GbxCallbackHandler>();

        public CallbacksManager()
        {

        }

        public void AddListener(string name, GbxCallbackHandler handler)
        {
            switch(name)
            {
                case GBXCallBacks.ManiaPlanet_BeginMap:
                case GBXCallBacks.ManiaPlanet_BeginMatch:
                case GBXCallBacks.ManiaPlanet_BillUpdated:
                case GBXCallBacks.ManiaPlanet_Echo:
                case GBXCallBacks.ManiaPlanet_EndMap:
                case GBXCallBacks.ManiaPlanet_EndMatch:
                case GBXCallBacks.ManiaPlanet_MapListModified:
                case GBXCallBacks.ManiaPlanet_ModeScriptCallback:
                case GBXCallBacks.ManiaPlanet_ModeScriptCallbackArray:
                case GBXCallBacks.ManiaPlanet_PlayerAlliesChanged:
                case GBXCallBacks.ManiaPlanet_PlayerChat:
                case GBXCallBacks.ManiaPlanet_PlayerConnect:
                case GBXCallBacks.ManiaPlanet_PlayerDisconnect:
                case GBXCallBacks.ManiaPlanet_PlayerInfoChanged:
                case GBXCallBacks.ManiaPlanet_PlayerManialinkPageAnswer:
                case GBXCallBacks.ManiaPlanet_ServerStart:
                case GBXCallBacks.ManiaPlanet_ServerStop:
                case GBXCallBacks.ManiaPlanet_StatusChanged:
                case GBXCallBacks.ManiaPlanet_TunnelDataReceived:
                case GBXCallBacks.ManiaPlanet_VoteUpdated:
                    string cbt = "TrackMania." + name.Split('.')[1];
                    callbacks.Add(name, handler);
                    callbacks.Add(cbt, handler);
                    break;
              
                default:
                    callbacks.Add(name, handler);
                    break;
                
            }
            

        }

        public bool ContainListener(string name)
        {

            return callbacks.ContainsKey(name);
        }

        public void onGbxCallBack(object sender, GbxCallbackEventArgs args)
        {
            if (callbacks.ContainsKey(args.Response.MethodName))
            {
                callbacks[args.Response.MethodName](sender, args);
            }
        }


    }
}
