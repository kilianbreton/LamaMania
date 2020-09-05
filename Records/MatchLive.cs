using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LamaPlugin;
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

            this.Callbacks.Add("ManiaPlanet.BeginMatch", cb_BeginMatch);
            this.Callbacks.Add("ManiaPlanet.EndMatch", cb_EndMatch);
            this.Callbacks.Add("ManiaPlanet.BeginMap", cb_BeginMap);
            this.Callbacks.Add("ManiaPlanet.EndMap", cb_EndMap);
            this.Callbacks.Add("TrackMania.PlayerFinish", cb_PlayerFinish);
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

        public override void onGbxAsyncResult(GbxCall res)
        {
            
        }

        public override void onGbxCallBack(object sender, GbxCallbackEventArgs args)
        {
    
        }


    }
}
