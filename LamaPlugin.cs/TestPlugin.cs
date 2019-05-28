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
            this.Name = "Test";
            this.Author = "Murdisto";
            this.Version = "0.1.1";
        }

        public override bool onLoad(LamaConfig lamaConfig)
        {
            asyncRequest("GetPlayerList",new object[] { 32, 1 });
            return true;
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
