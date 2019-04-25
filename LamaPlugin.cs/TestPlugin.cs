using System;
using System.Collections.Generic;
using System.Text;
using TMXmlRpcLib;
using System.Collections;

namespace LamaPlugin
{
    public class TestPlugin : BasePlugin
    {
        public TestPlugin()
        {
            this.Plugin = "Test";
            this.Author = "Murdisto";
            this.Version = 0.1F;
        }

        public override void onLoad(List<Dictionary<string,string>> lamaConfig)
        {
            asyncRequest("GetPlayerList",new object[] { 32, 1 });
        }

        public override void onGbxAsyncResult(GbxCall res)
        {
            switch (handles[res.Handle])
            {
                case "GetPlayerList":
                    //Manage playerList
                    break;
            }
        }

        public override void onGbxCallBack(object sender, GbxCallbackEventArgs args)
        {
            switch (args.Response.MethodName)
            {

            }
        }


     
    }
}
