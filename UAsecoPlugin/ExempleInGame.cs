using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LamaPlugin;
using TMXmlRpcLib;
using NTK.IO.Xml;
using static NTK.Other.NTKF;
using System.Text.RegularExpressions;
using static LamaPlugin.GBXMethods;

namespace UAsecoPlugin
{
    public class ExempleInGame : InGamePlugin
    {
        XmlDocument config;
        private List<String> adminLogins = new List<string>();
        private Regex rx = new Regex("^/[a-zA-Z0-9_ ]");

        public ExempleInGame()
        {
            this.PluginName = "Exemple";
            this.Author = "Kilian";
            this.Version = "0.1";
            this.Requirements.Add(new Requirement(RequirementType.FILE, "exemple.xml"));
            this.Requirements.Add(new Requirement(RequirementType.ExternalTool, "php"));

            adminLogins.Add("kamphare");
        }

        public override void onDisconnect()
        {
           
        }

     /*

        public override void onGbxCallBack(object sender, GbxCallbackEventArgs args)
        {
            switch (args.Response.MethodName)
            {
                case "ManiaPlanet.PlayerChat":
                case "TrackMania.PlayerChat":
                    var htPlayerChat = args.Response.Params;
                    string msg = (string)htPlayerChat[2];
                    string login = (string)htPlayerChat[1];

                    if (rx.IsMatch(msg)) //Check is command (/....)------------------------
                    {
                        //Admin Commands////////////////////////////////////////////////////////////////
                        if (msg.Contains("/admin ") && msg.Length > 7 && adminLogins.Contains(login))
                        {
                            msg = subsep(msg, "/admin ");
                            switch (msg)
                            {
                                case "help":
                                    break;
                                case "savematchfile":
                                    break;

                                default: //Commands with args or bad command
                                    if (msg.IndexOf("setgamemode ") == 0)
                                    {
                                        string gameMode = subsep(msg, "mode ");
                                        asyncRequest(SetScriptName, gameMode + ".Script.txt");
                                    }
                                    else if (msg.IndexOf("restart") == 0)
                                    {
                                        asyncRequest(RestartMap);
                                    }
                                    else if (msg.IndexOf("warn ") == 0)
                                    {

                                    }
                                    else if (msg.IndexOf("kick ") == 0)
                                    {

                                    }
                                    else if (msg.IndexOf("ban ") == 0)
                                    {

                                    }
                                    else if (msg.IndexOf("black ") == 0)
                                    {

                                    }
                                    else if (msg.IndexOf("guest ") == 0)
                                    {

                                    }

                                    break;
                            }
                        }
                        else //User Commands//////////////////////////////////////////////////////////
                        {

                        }
                    }
                    break;
            }
        }*/

        public override bool onLoad(LamaConfig lamaConfig)
        {
            bool ret = (lamaConfig.configFiles.ContainsKey("exemple.xml")); //&& lamaConfig.scriptName == "TimeAttack");
            if (ret)
            {
                try
                {
                    config = lamaConfig.configFiles["exemple.xml"];
                    List<XmlNode> lst = config[0]["Admins"].Childs;
                    foreach (XmlNode n in lst)
                    {
                        this.adminLogins.Add(n.Value);
                    }
                }
                catch(Exception e)
                {
                    Log("ERROR", e.Message);
                    ret = false;
                }

            }
            return ret;
        }
    }
}
