using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LamaPlugin;
using LamaPlugin.ManiaLink;
using TMXmlRpcLib;

namespace Records
{
    public class MatchLive : InGamePlugin
    {
        public MatchLive()
        {
            this.PluginName = "MatchLive";
            this.PluginDescription = "Show current race times";
            this.Author = "KBT";
            this.Requirements.Add(new Requirement(RequirementContext.LOCAL));

            this.Callbacks.AddListener(GBXCallBacks.ManiaPlanet_BeginMatch, cb_BeginMatch);
            this.Callbacks.AddListener(GBXCallBacks.ManiaPlanet_EndMatch, cb_EndMatch);
            this.Callbacks.AddListener(GBXCallBacks.ManiaPlanet_BeginMap, cb_BeginMap);
            this.Callbacks.AddListener(GBXCallBacks.ManiaPlanet_EndMap, cb_EndMap);
            this.Callbacks.AddListener(GBXCallBacks.TrackMania_PlayerFinish, cb_PlayerFinish);
        }


        public override bool onLoad(LamaConfig lamaConfig)
        {
            return true;
        }



        /////////////////////////////////////////////////////////////////////////////////
        /// CallBakcs //////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// 
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>

        private void cb_PlayerFinish(object o, GbxCallbackEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void cb_EndMap(object o, GbxCallbackEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void cb_BeginMap(object o, GbxCallbackEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void cb_EndMatch(object o, GbxCallbackEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void cb_BeginMatch(object o, GbxCallbackEventArgs e)
        {
            throw new NotImplementedException();
        }


        /////////////////////////////////////////////////////////////////////////////////
        /// ManiaLink //////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////

        private ManialinkFile genML()
        {
            ManialinkFile ret = new ManialinkFile(false);


            return ret;
        }


        /////////////////////////////////////////////////////////////////////////////////
        /// UseLess ////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////

        public override void onDisconnect()
        {
            //DO nothing
        }

 

    }
}
