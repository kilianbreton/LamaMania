using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LamaPlugin;
using TMXmlRpcLib;
using NTK.IO.Xml;
using static NTK.Other.NTKF;
using System.Text.RegularExpressions;

namespace BasicsCommandsPlugin
{
    public class BasicsCommandPlugin : InGamePlugin
    {
        //Msg const
        private const string WELCOME_MESSAGE = "Welcome on #S server, type /help to show commands !";
        private const string HEAD_USER = "User commands :";
        private const string HEAD_ADMIN = "Admin commands :";
        private const string HEAD_SUPERADMIN = "SuperAdmin commands :";

        private XmlDocument locales;
        private List<String> adminLogins = new List<string>();
        private Regex rx = new Regex("^/[a-zA-Z0-9_ ]");

        public BasicsCommandPlugin()
        {
            this.Author = "Breton Kilian";
            this.Name = "Basics Commands";
            this.Version = "0.1";
            this.Requirements.Add(new Requirement(RequirementType.DATABASE, "MySql://cmdPlug:root>mdp"));
            this.Requirements.Add(new Requirement(RequirementType.FILE, "locales.xml"));
            this.Requirements.Add(new Requirement(RequirementType.FILE, "admins.xml"));
        }


        public override bool onLoad(LamaConfig lamaConfig)
        {
            bool ret = (lamaConfig.connected
                    && lamaConfig.dbConnected
                    && lamaConfig.game == Game.TrackMania
                    && lamaConfig.configFiles.ContainsKey("locales.xml")
                    && lamaConfig.configFiles["locales.xml"] != null
                    && lamaConfig.configFiles.ContainsKey("admins.xml")
                    && lamaConfig.configFiles["admins.xml"] != null);
            if (ret)
            {
                try
                {
                    this.locales = lamaConfig.configFiles["locales.xml"];
                    XmlDocument admins = lamaConfig.configFiles["admins.xml"];
                    foreach (XmlNode node in admins[0]["logins"].getChildList("login"))
                    {
                        adminLogins.Add(node.Value);
                    }
                }
                catch (Exception)
                {
                    ret = false;
                }
            }

            return ret;
        }

        public override void onGbxAsyncResult(GbxCall res)
        {
            if (this.handles.ContainsKey(res.Handle))
            {
                switch (this.handles[res.Handle])
                {
                    case "":
                        break;
                }
            }
        }

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
                                    if(msg.IndexOf("setgamemode ") == 0)
                                    {

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
        }

    
    }
}
