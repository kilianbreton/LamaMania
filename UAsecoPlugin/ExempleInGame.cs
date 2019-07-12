using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LamaPlugin;
using TMXmlRpcLib;
using NTK.IO.Xml;

namespace UAsecoPlugin
{
    public class ExempleInGame : InGamePlugin
    {
        XmlDocument config;

        public ExempleInGame()
        {
            this.PluginName = "Exemple";
            this.Author = "Kilian";
            this.Version = "0.1";
            this.Requirements.Add(new Requirement(RequirementType.FILE, "exemple.xml"));

        }
        
        public override void onGbxAsyncResult(GbxCall res)
        {
            if (res.Error)
            {
                switch (this.handles[res.Handle])
                {
                    case "GetBanList":
                        break;
                }
            }
            else //Error
            {
                string errStr = "[" + this.PluginName + "]" + res.ErrorCode + " : " + res.ErrorString;

                Log("ERROR", errStr); //Log file
                OnError(this, "Error", errStr); //Show error dialog
            }
        }

        public override void onGbxCallBack(object sender, GbxCallbackEventArgs args)
        {
            switch (args.Response.MethodName)
            {
                case "TrackMania.PlayerChat":
                    ArrayList chatInfos = args.Response.Params;

                    break;
            }
        }

        public override bool onLoad(LamaConfig lamaConfig)
        {
            bool ret = (lamaConfig.configFiles.ContainsKey("exemple.xml")); //&& lamaConfig.scriptName == "TimeAttack");
            if (ret)
            {
                config = lamaConfig.configFiles["exemple.xml"];
         /*       int param2 = 2;
                asyncRequest("MethodName", "param1", param2);
                asyncRequest("GetMethodName", checkError); //checkError is GbxCallCallBackHandler delegate
                asyncRequest("methodName", res =>{
                    //do something
                });
                asyncRequest(checkError, "MethodName", "param1", "param2");*/
            }
            return ret;
        }
    }
}
