﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LamaPlugin;
using TMXmlRpcLib;
using NTK.IO.Xml;
using System.Text.RegularExpressions;

namespace Records
{
    public enum UserLevel
    {
        MasterAdmin,
        Admin,
        Moderator,
        Guest,
        User,
        Custom
    }


    public class UserLevels : InGamePlugin
    {
        private Dictionary<string, UserLevel> userLevels = new Dictionary<string, UserLevel>();
        private List<Player> players = new List<Player>();
        private XmlDocument levelsConfig;
        private const string CONFIG_FILE = "levels.xml";
        private Regex rx = new Regex("^/[a-zA-Z0-9_ ]");

        public UserLevels()
        {
            base.PluginName = "UserLevels";
            base.PluginDescription = "Gère les nivexu utilisateurs (SuperAdmin,Admin,Guest..)";
            base.PluginFolder = "[NONE]";
            base.Version = "0.1";
            base.Author = "KBT";
           
            base.Requirements.Add(new Requirement(RequirementContext.LOCAL));
            base.Requirements.Add(new Requirement(RequirementType.FILE, CONFIG_FILE));
        }


        public override bool onLoad(LamaConfig lamaConfig)
        {
            try
            {
                if (lamaConfig.configFiles.ContainsKey(CONFIG_FILE))
                {
                    players = lamaConfig.players;
                    levelsConfig = lamaConfig.configFiles[CONFIG_FILE];
                    addUserLevel("masterAdmins", UserLevel.MasterAdmin);
                    addUserLevel("admins", UserLevel.Admin);
                    addUserLevel("moderators", UserLevel.Moderator);
                    addUserLevel("guests", UserLevel.Guest);


                    Callbacks.AddListener(GBXCallBacks.ManiaPlanet_PlayerChat, onPlayerChat);
                    return true;
                }
            }
            catch (Exception e)
            {
                if(Log != null)
                    Log("ERROR", "[UserLevels][OnLoad]>" + e.Message);
            }
            return false;
        }


        private void addUserLevel(string nodeName, UserLevel level)
        {
            if (this.levelsConfig[0].isChildExist(nodeName))
            {
                foreach (XmlNode n in levelsConfig[0][nodeName])
                {
                    if (!userLevels.ContainsKey(n.Value) && n.Value.Trim() != "")
                    {
                        userLevels.Add(n.Value, level);
                    }
                }
            }
        }


        private void onPlayerChat(object sender, GbxCallbackEventArgs args)
        {
            var htPlayerChat = args.Response.Params;
            string msg = (string)htPlayerChat[2];
            string login = (string)htPlayerChat[1];

            Player playerSender = searchByLogin(login);

            UserLevel lvl = UserLevel.User;
            if(this.userLevels.ContainsKey(login))
            {
                lvl = this.userLevels[login];
            }



            if (rx.IsMatch(msg)) //Check is command (/....)------------------------
            {
                //Admin Commands////////////////////////////////////////////////////////////////
                if (msg.ToLower().Equals("/levels")  && lvl == UserLevel.MasterAdmin)
                {
                    //test
                    string txt = "";

                    foreach (KeyValuePair<string, UserLevel> kvp in this.userLevels.OrderBy(kvp => kvp.Value))
                    {
                        txt += "$fff" + kvp.Key + " - ";
                        switch (kvp.Value)
                        {
                            case UserLevel.MasterAdmin:
                                txt += "$f00";
                                break;
                            case UserLevel.Admin:
                                txt += "$a33";
                                break;
                            case UserLevel.Moderator:
                                txt += "$aa2";
                                break;
                            case UserLevel.Guest:
                                txt += "$0f0";
                                break;
                            case UserLevel.User:
                                txt += "$55d";
                                break;
                        }
                        txt += kvp.Value.ToString() + "\n";
                    }

                    asyncRequest(checkError, GBXMethods.ChatSendServerMessageToLogin, txt, login);

                }
            }




        }

        private Player searchByLogin(string login)
        {
            Player ret = null;
            int cpt = 0;
            while (cpt < this.players.Count && this.players[cpt].Login != login) { cpt++; }

            if (cpt < this.players.Count && this.players[cpt].Login == login)
                ret = this.players[cpt];


            return ret;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public override InterPluginResponse onInterPluginCall(IBasePlugin sender, InterPluginArgs args)
        {
            InterPluginResponse response = null;
            switch (args.CallName)
            {
                //GET++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                case "GetCallList":
                    response = new InterPluginResponse(args.CallName, new Dictionary<string, object>
                    {
                        {"GetCallList","All" },
                        {"GetUserLevel","Admin" },
                        {"GetMasterAdmins","MasterAdmin" },
                        {"GetAdmins","Admin" },
                        {"GetModerators","Moderator" },
                        {"GetGuests","All" },
                        {"GetAll","MasterAdmin" },
                        {"AddUser","MasterAdmin" },
                        {"EditUser","MasterAdmin" },
                        {"RemoveUser","MasterAdmin" },
                        {"AddLevel","MasterAdmin" },
                        {"EditLevel","MasterAdmin" },
                        {"RemoveLevel","MasterAdmin" },
                        {"SaveFile","MasterAdmin" },
                        {"ReadConfig", "MasterAdmin" },
                    });
                    break;
                 
                    #region "GET"
                case "GetUserLevel":
                    if (args.Args.ContainsKey("login"))
                    {
                        string login = (string)args.Args["login"];
                        if(this.userLevels.ContainsKey(login))
                        {
                            response = new InterPluginResponse(args.CallName, new Dictionary<string, object>
                            {
                                { login, userLevels[login].ToString() }
                            });
                        }
                        else
                        {
                            response = new InterPluginResponse(true, "Unknown " + login + " player");
                        }
                    }
                    else
                    {
                        response = new InterPluginResponse(true, "Need 'login' arg");
                    }
                    break;

                case "GetMasterAdmins":
                    response = new InterPluginResponse(args.CallName, new Dictionary<string, object>()
                    {
                        {"MasterAdmins", getListByLvl(UserLevel.MasterAdmin) }
                    });
                    break;

                case "GetAdmins":
                    response = new InterPluginResponse(args.CallName, new Dictionary<string, object>()
                    {
                        {"Admins", getListByLvl(UserLevel.Admin) }
                    });
                    break;
                case "GetModerators":
                    response = new InterPluginResponse(args.CallName, new Dictionary<string, object>()
                    {
                        {"Moderators", getListByLvl(UserLevel.Moderator) }
                    });
                    break;
                case "GetGuests":
                    response = new InterPluginResponse(args.CallName, new Dictionary<string, object>()
                    {
                        {"Guests", getListByLvl(UserLevel.Guest) }
                    });
                    break;

                case "GetAll":
                    List<string> users = new List<string>();
                    foreach(KeyValuePair<string,UserLevel> kvp in userLevels)
                    {
                        users.Add(kvp.Key);
                    }
                    response = new InterPluginResponse(args.CallName, new Dictionary<string, object>()
                    {
                        {"All", users }
                    });
                    break;
                #endregion

                //SET++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++


                case "AddUser":
                    if (args.Args.ContainsKey("login") && args.Args.ContainsKey("level"))
                    {
                        string login = (string)args.Args["login"];
                        UserLevel lvl = parseUserLevel((string)args.Args["level"]);
                        if (!userLevels.ContainsKey(login))
                        {
                            userLevels.Add(login, lvl);
                            response = new InterPluginResponse(args.CallName, null);
                        }
                        else
                        {
                            response = new InterPluginResponse(true, "User already exist");
                        }
                    }
                    else
                    {
                        response = new InterPluginResponse(true, "Bad args");
                    }

                    break;

                case "EditUser":
                    if (args.Args.ContainsKey("login") && args.Args.ContainsKey("level"))
                    {
                        string login = (string)args.Args["login"];
                        UserLevel lvl = parseUserLevel((string)args.Args["level"]);
                        if (userLevels.ContainsKey(login))
                        {
                            userLevels[login] = lvl;
                            response = new InterPluginResponse(args.CallName, null);
                        }
                        else
                        {
                            response = new InterPluginResponse(true, "User does not exist");
                        }
                    }
                    else
                    {
                        response = new InterPluginResponse(true, "Bad args");
                    }
                    break;

                case "RemoveUser":
                    if (args.Args.ContainsKey("login"))
                    {
                        string login = (string)args.Args["login"];
                        
                        if (!userLevels.ContainsKey(login))
                        {
                            userLevels.Remove(login);
                            response = new InterPluginResponse(args.CallName, null);
                        }
                        else
                        {
                            response = new InterPluginResponse(true, "User already exist");
                        }
                    }
                    else
                    {
                        response = new InterPluginResponse(true, "Bad args");
                    }
                    break;

                case "AddLevel":
                    break;

                case "EditLevel":
                    break;

                case "RemoveLevel":
                    break;

                case "SaveFile":
                    this.levelsConfig.deleteNode(0);
                    XmlNode root = this.levelsConfig.addNode("levels");
                    XmlNode ma = root.addChild("masterAdmins");
                    XmlNode ad = root.addChild("admins");
                    XmlNode mo = root.addChild("moderators");
                    XmlNode gu = root.addChild("guests");
                    foreach (KeyValuePair<string, UserLevel> kvp in userLevels)
                    {
                        switch (kvp.Value)
                        {
                            case UserLevel.MasterAdmin:
                                ma.addChild("player", kvp.Key);
                                break;
                            case UserLevel.Admin:
                                ad.addChild("player", kvp.Key);
                                break;
                            case UserLevel.Moderator:
                                mo.addChild("player", kvp.Key);
                                break;
                            case UserLevel.Guest:
                                gu.addChild("player", kvp.Key);
                                break;
                            case UserLevel.User:
                                //ma.addChild("player", kvp.Key);
                                break;
                        }
                        
                    }

                    this.levelsConfig.save(false);

                    break;

                case "ReadConfig":
                    string cfgPath = this.levelsConfig.Path;
                    this.levelsConfig = new XmlDocument(cfgPath);
                 
                    addUserLevel("masterAdmins", UserLevel.MasterAdmin);
                    addUserLevel("admins", UserLevel.Admin);
                    addUserLevel("moderators", UserLevel.Moderator);
                    addUserLevel("guests", UserLevel.Guest);

                    break;

            }

            return response;
        }

        private UserLevel parseUserLevel(string lvl)
        {
            switch (lvl.ToUpper())
            {
                case "MASTERADMIN":
                    return UserLevel.MasterAdmin;
                case "ADMIN":
                    return UserLevel.Admin;
                case "MODERATOR":
                    return UserLevel.Moderator;
                case "GUEST":
                    return UserLevel.Guest;
                default:
                    throw new Exception("Unknown Level : " + lvl);
            }
        }

        private List<string> getListByLvl(UserLevel lvl)
        {
            List<string> logins = new List<string>();
            foreach (KeyValuePair<string, UserLevel> kvp in this.userLevels)
            {
                if (kvp.Value == lvl)
                {
                    logins.Add(kvp.Key);
                }
            }
            return logins;
        }

   


        public override void onDisconnect()
        {
            
        }
    }
}
