using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LamaPlugin;
using TMXmlRpcLib;
using NTK.IO.Xml;


namespace Records
{
    public enum UserLevel
    {
        MasterAdmin,
        Admin,
        Moderator,
        Guest,
        User
    }


    public class UserLevels : InGamePlugin
    {
        private Dictionary<string, UserLevel> userLevels = new Dictionary<string, UserLevel>();
        private List<Player> players = new List<Player>();
        private XmlDocument levelsConfig;


        public UserLevels()
        {
            base.PluginName = "UserLevels";
            base.PluginDescription = "Gère les nivexu utilisateurs (SuperAdmin,Admin,Guest..)";
            base.PluginFolder = "[NONE]";
            base.Version = "0.1";
            base.Author = "KBT";
            base.PluginKey = "363fcbfe31ab2c561e98b635b2782776c96669433ba3fe77ac959093dced4fffb983247eabffc33098e425e5e7c3d5e2c3d9d702b23fb16ecbe14d081c46223bcf6978626ea5b3bd4ccbd0bc7f763d5c4bc489ae115db047be25d3dcf1890aba7ad8112dd8c4659cb9fc0dcd68fc0a5229475efb2990b60deb56f783d6b4ccdc";

            base.Requirements.Add(new Requirement(RequirementContext.LOCAL));
            base.Requirements.Add(new Requirement(RequirementType.FILE, "levels.xml"));
        }


        public override bool onLoad(LamaConfig lamaConfig)
        {
            try
            {
                if (lamaConfig.configFiles.ContainsKey("levels.xml"))
                {
                    players = lamaConfig.players;
                    levelsConfig = lamaConfig.configFiles["levels.xml"];
                    addUserLevel("masterAdmins", UserLevel.MasterAdmin);
                    addUserLevel("admins", UserLevel.Admin);
                    addUserLevel("moderators", UserLevel.Moderator);
                    addUserLevel("guests", UserLevel.Guest);

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

        public override void onGbxAsyncResult(GbxCall res)
        {
            
        }

        public override void onGbxCallBack(object sender, GbxCallbackEventArgs args)
        {
            
        }

        public override void onDisconnect()
        {
            
        }
    }
}
