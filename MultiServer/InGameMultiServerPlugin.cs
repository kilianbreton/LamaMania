using System;
using System.Threading;
using LamaPlugin;
using LamaPlugin.ManiaLink;
using LamaPlugin.Other;
using NTK.IO.Xml;
using TMXmlRpcLib;

namespace MultiServer
{
    public class InGameMultiServerPlugin : InGamePlugin
    {
        const string CONFIG_NAME = "IGMultiServer.xml";
        
        private XmlDocument config;
        private int gameTime;
        private bool alerts;
        private bool autoSwitch;
        private int nextServerId;

        private bool stopThread = false;
        private int currentTime = 0;

        public InGameMultiServerPlugin()
        {
            base.PluginName = "IGMultiServer";
            base.PluginDescription = "Manage multi server with planning";
            base.PluginFolder = "";
            base.Version = "0.0.0.1";
            base.Author = "KBT";
            base.PluginKey = "0b89fe9108f857092937dcdcd1039f392d6f484603a72fc08398ad4736c49931c8ed63c7461481b3df4510b74cf6a7da1fca65ace8d9e1cb5ab38a328baaa907339c4cc130dc0aa6aad82fdcd12f0704350964785bd055abf2c7d6bb3fea4fac9f673a9a96f785c0fdd2aaf534b6c347f5d1890bbbe5fbb6b51c7dbdbbe9a457";

            base.Requirements.Add(new Requirement(RequirementContext.LOCAL));
            base.Requirements.Add(new Requirement(RequirementType.FILE, CONFIG_NAME));
            
        }

        public override bool onLoad(LamaConfig lamaConfig)
        {
            try
            {
                this.config = lamaConfig.configFiles[CONFIG_NAME];
               
                //ReadConfig
                XmlNode root = this.config[0];
                this.gameTime = int.Parse(root["GameTime"].Value);
                this.alerts = parseBool(root["Alerts"].Value);
                this.autoSwitch = parseBool(root["Auto"].Value);
                this.nextServerId = int.Parse(root["NextServerId"].Value);

                Thread t = new Thread(task_loop);
                t.Start();

                return true;
            }
            catch(Exception e)
            {
                Log("ERROR", "[" + this.PluginName + "][OnLoad]>" + e.Message);
                return false;
            }
        }

        public void test()
        {

        }

        //Private======================================================
        private ManialinkFile makeNextServerButton()
        {

            
            return null;
        }
        private bool parseBool(string s)
        {
            bool ret;
            switch(s.ToLower())
            {
                case "true":
                case "1":
                    ret = true;
                    break;
                case "false":
                case "0":
                    ret = false;
                    break;
                default:
                    throw new InvalidCastException("'" + s + "' invalid bool");
            }
            return ret;
        }
        private void task_loop()
        {
            bool alert5m = false;
            bool alert2m = false;
            bool alert1m = false;
            bool alert30s = false;
            bool notime = false;

            while(!stopThread)
            {
                currentTime++;

                if(currentTime >= gameTime && !notime)
                {
                    notime = true;
                    //show nextServerButton
                    asyncRequest(checkError, GBXMethods.ChatSendServerMessage, "$o$f00>>NextServer : $fffTest");
                }
                if (currentTime >= gameTime - 30 && !alert30s)
                {
                    alert30s = true;
                    asyncRequest(checkError, GBXMethods.ChatSendServerMessage, "$o$f00>>$fff30 $f00second left");
                }
                if (currentTime >= gameTime - 60 && !alert1m)
                {
                    alert1m = true;
                    asyncRequest(checkError, GBXMethods.ChatSendServerMessage, "$o$f00>>$fff1 $f00minutes left");
                }
                if (currentTime >= gameTime - 120 && !alert2m)
                {
                    alert2m = true;
                    asyncRequest(checkError, GBXMethods.ChatSendServerMessage, "$o$f00>>$fff2 $f00minutes left");
                }
                if (currentTime >= gameTime - 300 && !alert5m)
                {
                    alert5m = true;
                    asyncRequest(checkError, GBXMethods.ChatSendServerMessage, "$o$f00>>$fff5 $f00minutes left");


                }

                Thread.Sleep(1000); //sleep 1s
            }
        }


        //Useless======================================================
     
        public override void onDisconnect() { }
    }
}
