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
            this.PluginKey = "bffc8b09fff22aa24b9328a5d161e04f09b719782739cb58ab6b58dc851066b9e983d0b1f2016311b3f24cbba72652bcf2afdb14b826c2d011fa00219bd1baf0395818248f29cf23c117ec0d1dec94d405d71fad45cec4915c05d65296d8956642ba5811a44abae2c6f7f5593e99260a53659ff99148933101724e923e944362";
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

 

    }
}
