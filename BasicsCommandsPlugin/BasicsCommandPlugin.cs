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

        
        private List<String> adminLogins = new List<string>();
        private Regex rx = new Regex("^/[a-zA-Z0-9_ ]");

        private List<Player> players;

        public BasicsCommandPlugin()
        {
            this.Author = "KBT";
            this.PluginName = "Basic Commands";
            this.Version = "0.1";
            this.PluginKey = "0c2242ef0a0969855bd57e26851c709bf39f6c9fd43a68b899fa37c480e1e3941d0d792ca82987784c89421cd0bfe170ce145537163f3611af119f540fe967584e09773c5a64b076217591aed1fc3aa6d0bd3680e02c316139fd99b86c67516fe00d8b0dfe336737fe50b8e34bff6d39a0b679e1692ba103ab6b41958e598bb7";
            this.Requirements.Add(new Requirement(RequirementType.DATABASE, true));
            this.Requirements.Add(new Requirement(RequirementType.FILE, "locales.xml"));
            this.Requirements.Add(new Requirement(RequirementType.FILE, "admins.xml"));
            this.Requirements.Add(new Requirement(RequirementType.PLUGIN, "UserLevels"));
        }


        public override bool onLoad(LamaConfig lamaConfig)
        {
            bool ret = (lamaConfig.connected
                //    && lamaConfig.dbConnected
                    && lamaConfig.game == Game.TrackMania
                    && lamaConfig.configFiles.ContainsKey("locales.xml")
                    && lamaConfig.configFiles["locales.xml"] != null
                    && lamaConfig.configFiles.ContainsKey("admins.xml")
                    && lamaConfig.configFiles["admins.xml"] != null);
            if (ret)
            {
                this.players = lamaConfig.players;
           /*   try
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
                }*/
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
                    try
                    {
                        var htPlayerChat = args.Response.Params;
                        string msg = (string)htPlayerChat[2];
                        string login = (string)htPlayerChat[1];

                        Player playerSender = searchByLogin(login);



                        InterPluginResponse r = sendInterPluginCall("UserLever", "GetUserLevel", new Dictionary<string, object>() {
                        {"login", login }
                    });
                        string level = (string)r.Param[login];






                        if (rx.IsMatch(msg)) //Check is command (/....)------------------------
                        {
                            //Admin Commands////////////////////////////////////////////////////////////////
                            if (msg.ToLower().Contains("/admin ") && msg.Length > 7 && checkLevel(level, "ADMIN"))
                            {
                                msg = subsep(msg, "/admin ");
                                switch (msg)
                                {
                                    case "help":
                                        asyncRequest(checkError, GBXMethods.ChatSendServerMessageToLogin, login, "Admin commands :\n /Admin #command");
                                        break;
                                    case "savematchfile":
                                        break;

                                    default: //Commands with args or bad command
                                        if (msg.IndexOf("setgamemode ") == 0)
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
                                if (msg.ToLower().Contains("/mp "))
                                {
                                    // /mp login mon message
                                    try
                                    {
                                        msg = subsep(msg, "/mp ");
                                        string targetLogin = subsep(msg, 0, " ");
                                        msg = subsep(msg, login + " ");

                                        if (playerSender != null)
                                            msg = "[" + playerSender.NickName + "$z]>" + msg;
                                        else
                                            msg = "[" + targetLogin + "]>" + msg;

                                        asyncRequest(checkError, GBXMethods.ChatSendToLogin, targetLogin, msg);
                                        asyncRequest(checkError, GBXMethods.ChatSendToLogin, login, msg);   //Back to sender
                                    }
                                    catch (Exception e)
                                    {
                                        Log("ERROR", "[" + base.PluginName + "]>" + e.Message);
                                    }

                                }
                                //else if


                            }
                        }


                    }
                    catch(Exception err)
                    {
                        Log("ERROR", "[" + this.PluginName + "]>" + err.Message);
                    }
                    break;
            }
        }


        private Player searchByLogin(string login)
        {
            Player ret = null;
            int cpt = 0;
            while(cpt < this.players.Count && this.players[cpt].Login != login) { cpt++; }

            if (cpt < this.players.Count && this.players[cpt].Login == login)
                ret = this.players[cpt];

                       
            return ret;
        }


        private bool checkLevel(string source, string check)
        {
            bool ret = false;
            switch (check.ToUpper())
            {
                case "GUEST":
                    ret = (source.ToUpper() == "GUEST");
                    break;
                case "USER":
                    ret = true;
                    break;
                case "MODERATOR":
                    switch (source.ToUpper())
                    {
                        case "MODERATOR":
                        case "ADMIN":
                        case "MASTERADMIN":
                            ret = true;
                            break;
                        default:
                            ret = false;
                            break;
                    }
                    break;
                case "ADMIN":
                    switch (source.ToUpper())
                    {
                        case "ADMIN":
                        case "MASTERADMIN":
                            ret = true;
                            break;
                        default:
                            ret = false;
                            break;
                    }
                    break;
  
                case "MASTERADMIN":
                    ret = (source.ToUpper() == "MASTERADMIN");
                    break;
            
            }




            return ret;
        }



        public override void onDisconnect()
        {
          
        }
    }
}
