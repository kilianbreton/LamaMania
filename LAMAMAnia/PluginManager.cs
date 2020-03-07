using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;
using NTK.IO;
using NTK.IO.Xml;
using LamaPlugin;
using static LamaMania.StaticMethods;
using static LamaPlugin.StaticM;
using TMXmlRpcLib;
using System.Drawing;
using System.Security.Cryptography;
using System.Threading;
//using System.Threading.Tasks;


namespace LamaMania
{
    /// <summary>
    /// Manage LamaPlugins
    /// </summary>
    public class PluginManager
    {
        private PMCache cache;
        private HCFile hcFile;
        //Handle number -> sender (Plugin)
        private Dictionary<int, IBasePlugin> handles = new Dictionary<int, IBasePlugin>();
        private int lastHandle;

        private List<IBasePlugin> updateList = new List<IBasePlugin>();

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Constructors ////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Init plugins list
        /// </summary>
        public PluginManager(string path)
        {
            this.cache = new PMCache(@"Cache\PM.cache");
            this.hcFile = new HCFile(@"Config\Servers\" + Lama.serverIndex + @"\HomeComponents.hcf");
            this.HomeComponentPlugins = new List<HomeComponentPlugin>();
            this.InGamePlugins = new List<InGamePlugin>();
            this.TabPlugins = new List<TabPlugin>();
            this.lastHandle = 0;

            Thread t = new Thread(updateLoop);
            t.Start();

        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Load dll ////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        
        /// <summary>
        /// Load plugins from dll
        /// </summary>
        public void loadPlugins()
        {
            Lama.log("NOTICE", "[PluginManager] Load plugins");
            try
            {
                DirectoryInfo pluginsDir = new DirectoryInfo(Path.GetDirectoryName(Application.ExecutablePath) + @"\Plugins\");
                
                //Read dll
                foreach (FileInfo file in pluginsDir.GetFiles())
                {
                    bool hashComputed = false;
                    if (file.Extension.Equals(".dll"))
                    {
                        //Check if cache know lib
                        if (this.cache.haveLib(file.Name))
                        {
                            this.cache.computeHash(file.FullName, out string hash);
                            if (hash != this.cache.getHash(file.Name))
                            {
                                hashComputed = true;
                                //Remove all plugin informations
                                this.cache.addHash(file.Name, hash);
                                this.cache.removeIgnore(file.Name);
                                this.cache.removeAllLinks(file.Name);
                            }
                        }
                        else
                        {
                            this.cache.addLib(file.Name);
                        }


                        if (!this.cache.isIgnore(file.Name))
                        {
                            try
                            {
                                DllLoader loader = new DllLoader(file.FullName);
                                List<string> links = this.cache.getLinks(file.Name);
                                
                                //ReadLinks------------------------------------------------------------------------------------------------------------------------------
                                if (links.Count != 0 && !hashComputed)
                                {
                                    int insLoaded = 0;
                                    Lama.log("NOTICE", "Load " + file.Name + " ...");
                                    foreach (string link in links)
                                    {
                                        IBasePlugin p = loader.getClassInstance<IBasePlugin>(link);
                                        switch (p.PluginType)
                                        {
                                            case PluginType.Base:
                                                //Delete link ?
                                                break;
                                            case PluginType.HomeComponent:
                                                HomeComponentPlugins.Add((HomeComponentPlugin)p);
                                                insLoaded++;
                                                break;
                                            case PluginType.TabPlugin:
                                                TabPlugins.Add((TabPlugin)p);
                                                insLoaded++;
                                                break;
                                            case PluginType.InGamePlugin:
                                                InGamePlugins.Add((InGamePlugin)p);
                                                insLoaded++;
                                                break;
                                        }
                                        Lama.log("NOTICE", "-" + link);
                                    }

                                    if (insLoaded != 0)
                                    {
                                        Lama.log("NOTICE", "[PluginManager][LoadPlugins] Success !");
                                    }
                                    else
                                    {
                                        this.cache.addIgnore(file.Name);
                                        this.cache.removeAllLinks(file.Name);
                                        Lama.log("NOTICE", "[PluginManager][LoadPlugins] Error, added in dllignore (0 instances loaded)");
                                    }

                                }
                                else//Search class----------------------------------------------------------------------------------------------------------------------
                                {
                                    //Load instances in lists and count nb instances
                                   
                                    List<IBasePlugin> plugs = loader.getAllInstances<IBasePlugin>();
                                    int cpt = 0;
                                    foreach (IBasePlugin p in plugs)
                                    {
                                        this.cache.addLink(file.Name, p.GetType().FullName);
                                        bool ok = true;
                                        switch (p.PluginType)
                                        {
                                            case PluginType.Base:
                                                ok = false;
                                                break;
                                            case PluginType.HomeComponent:
                                                HomeComponentPlugins.Add((HomeComponentPlugin)p);
                                                break;
                                            case PluginType.TabPlugin:
                                                TabPlugins.Add((TabPlugin)p);
                                                break;
                                            case PluginType.InGamePlugin:
                                                InGamePlugins.Add((InGamePlugin)p);
                                                break;
                                        }
                                        if (ok)
                                            cpt++;
                                    }


                                
                                    if (cpt == 0) //0 Instances loaded
                                    {   //Append dllIgnore
                                        Lama.log("NOTICE", "[PluginManager][LoadPlugins] " + file.Name + " added in dllignore (0 instances loaded)");
                                        this.cache.addIgnore(file.Name);
                                    }
                                    else
                                    {
                                        Lama.log("NOTICE", "[PluginManager][LoadPlugins] Loaded : " + file.Name);
                                    }
                                }
                            }
                            catch (IOException) { }
                            catch (Exception er)
                            {
                                Lama.log("ERROR", "[PluginManager][LoadPlugins][" + file.Name + "]" + er.Message + er.GetType().Name);
                                this.cache.addIgnore(file.Name);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Lama.log("ERROR", "[LoadPlugins]" + e.Message);
            }


            this.cache.save();
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Select Plugins //////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Select plugins used by cfg
        /// </summary>
        /// <param name="cfg"></param>
        public void selectPluginsFrmCfg(XmlNode cfg)
        {
            selectHomeComponentPlugin(cfg);
            selectInGamePlugins(cfg);
        }

        /// <summary>
        /// Select plugins used by cfg
        /// </summary>
        /// <param name="cfg"></param>
        private void selectInGamePlugins(XmlNode cfg)
        {
            List<InGamePlugin> lst = new List<InGamePlugin>();
            foreach (XmlNode node in cfg.Childs)
            {
                InGamePlugin plug = (InGamePlugin)getPluginByName(node.Value, PluginType.InGamePlugin);
            


                if (plug != null)
                {
                    lst.Add(plug);
                    Lama.log("NOTICE", "[PluginManager] " + plug.PluginName + " Selected");
                }
                else
                {
                    //   Lama.log("WARNING", node.Value + " does not exist");
                }
            }
            InGamePlugins = lst;
        }

        /// <summary>
        /// Select plugins used by cfg
        /// </summary>
        /// <param name="cfg"></param>
        private void selectHomeComponentPlugin(XmlNode cfg)
        {
            List<HomeComponentPlugin> lst = new List<HomeComponentPlugin>();
            foreach (XmlNode node in cfg.Childs)
            {
                HomeComponentPlugin plug = (HomeComponentPlugin)getPluginByName(node.Value, PluginType.HomeComponent);
                
                if (plug != null)
                {
                    lst.Add(plug);
                    Lama.log("NOTICE", "[PluginManager] " + plug.PluginName + " Selected");
                }
                else
                {
                    //     Lama.log("WARNING", node.Value + " does not exist");
                }
            }
            HomeComponentPlugins = lst;
        }

                     
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Call load methods ///////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Call onLoad on InGamePlugins
        /// </summary>
        /// <param name="client"></param>
        public void onLoadInGame(XmlRpcClient client)
        {
            Lama.log("NOTICE", "[PluginManager] Init InGame Plugins ...");
            List<InGamePlugin> removeLST = new List<InGamePlugin>();
            foreach (InGamePlugin plug in InGamePlugins)
            {
                bool badRequirement = false;
                string brInfos = "";

                plug.setClient(client);
                
                //Check all requirements=====================================================
                badRequirement = checkRequirements(plug, out brInfos, out LamaConfig conf2plug);
                conf2plug.connected = true;
                conf2plug.scriptName = "";
                conf2plug.remote = Lama.remote;
                conf2plug.maps = Lama.maps;
                conf2plug.players = Lama.players;
                conf2plug.currentMapId = Lama.currentMapId;
                conf2plug.players = Lama.players;

                if (!badRequirement)
                    badRequirement = !plug.onLoad(conf2plug);

                if (badRequirement)
                {
                    Lama.log("ERROR", "[PluginManager][InGame] Unable to init [" + plug.PluginName + "] Plugin, " + brInfos);
                    removeLST.Add(plug);
                }
                else
                {

                    Lama.log("NOTICE", "[PluginManager][InGame][" + plug.PluginName + "] Plugin loaded");
                    plug.Log = Lama.log;
                    plug.OnError = Lama.onError;
                    plug.GetLamaProperty = Lama.getLamaProperty;
                    plug.setPluginManager(PMInterPluginCall);
                    updateList.Add(plug);
                }

            }
            foreach (InGamePlugin plug in removeLST)
            {
                InGamePlugins.Remove(plug);
            }
        }

        /// <summary>
        /// Load HomeComponent Plugins
        /// </summary>
        /// <param name="client"></param>
        /// <param name="mainHomeTab"></param>
        public void onLoadHomeComponent(XmlRpcClient client, Control mainHomeTab, bool needXmlRpc)
        {
            Lama.log("NOTICE", "[PluginManager] Init HomeComponent Plugins ...");
            List<HomeComponentPlugin> removeLST = new List<HomeComponentPlugin>();
            foreach(HomeComponentPlugin plugin in HomeComponentPlugins)
            {
                try
                {
                    if (useT<IHomeComponent>(plugin).NeedXmlRpcConnection == needXmlRpc)
                    {

                        //Do check requirements
                        string brInfos;
                        bool badRequirement = checkRequirements(plugin, out brInfos, out LamaConfig cfg);
                        if (badRequirement)
                        {
                            Lama.log("ERROR", "[PluginManager][HomeComponents] Unable to init [" + plugin.PluginName + "] Plugin, " + brInfos);
                            removeLST.Add(plugin);
                        }
                        else
                        {
                            Lama.log("NOTICE", "[PluginManager][HomeComponents][" + plugin.PluginName + "] Plugin loaded");
                            plugin.client = client;
                            plugin.Log = Lama.log;
                            plugin.OnError = Lama.onError;
                            plugin.GetLamaProperty = Lama.getLamaProperty;

                            cfg.connected = Lama.connected;
                            cfg.remote = Lama.remote;
                            cfg.lvl = Lvl.SuperAdmin;
                            cfg.players = Lama.players;

                            plugin.setPluginManager(PMInterPluginCall);
                            plugin.onLoad(cfg);

                            //Search Location
                            mainHomeTab.Controls.Add(plugin);
                            if (this.hcFile.haveProto(plugin.PluginName))
                            {
                                HCFP proto = this.hcFile.getProto(plugin.PluginName);
                                plugin.Location = new Point(proto.x, proto.y);

                            }
                            else
                            {
                                plugin.Location = new Point(200, 400);
                            }

                            updateList.Add(plugin);

                        }
                    }
                }
                catch (Exception e)
                {
                    Lama.log("ERROR", "[PluginManager][HomeComponents] Unable to load [" + plugin.PluginName + "]\tErr: " + e.Message);
                }
            }
            foreach(HomeComponentPlugin p in removeLST)
            {
                HomeComponentPlugins.Remove(p);
            }

        }
       
        /// <summary>
        /// Load MainTabPlugins
        /// </summary>
        /// <param name="client"></param>
        /// <param name="tabContainer"></param>
        /// <param name="needXmlRpc"></param>
        public void onLoadTabMain(XmlRpcClient client, TabControl tabContainer, bool needXmlRpc)
        {
            Lama.log("NOTICE", "[PluginManager] Init Tab Plugins ...");
            List<TabPlugin> removeLST = new List<TabPlugin>();
            foreach (TabPlugin plugin in TabPlugins)
            {
                try
                {
                    if (!plugin.ConfigServPlugin)
                    {

                        //Do check requirements
                        string brInfos;
                        bool badRequirement = checkRequirements(plugin, out brInfos, out LamaConfig cfg);
                        if (badRequirement)
                        {
                            Lama.log("ERROR", "[PluginManager][TabPlugin] Unable to init [" + plugin.PluginName + "] Plugin, " + brInfos);
                            removeLST.Add(plugin);
                        }
                        else
                        {
                            Lama.log("NOTICE", "[PluginManager][TabPlugin][" + plugin.PluginName + "] Plugin loaded");
                         
                            plugin.Log = Lama.log;
                            plugin.OnError = Lama.onError;
                            //plugin.GetLamaProperty = Lama.getLamaProperty;

                            cfg.connected = Lama.connected;
                            cfg.remote = Lama.remote;
                            cfg.lvl = Lvl.SuperAdmin;
                            cfg.players = Lama.players;

                            //plugin.setPluginManager(PMInterPluginCall);
                            plugin.onLoad(cfg);

                            //Search Location
                            TabPage tp = new TabPage(plugin.PluginName);
                            tp.Controls.Add(plugin);
                            plugin.Dock = DockStyle.Fill;
                            tabContainer.TabPages.Add(tp);

                            updateList.Add(plugin);


                        }
                    }
                }
                catch (Exception e)
                {
                    Lama.log("ERROR", "[PluginManager][TabPlugin] Unable to load [" + plugin.PluginName + "]\tErr: " + e.Message);
                }
            }
            foreach (TabPlugin p in removeLST)
            {
                TabPlugins.Remove(p);
            }

        }

        /// <summary>
        /// load internal homeComponents in plugin list
        /// </summary>
        public void loadInternalHC()
        {
            //TODO: Select from config
            HomeComponentPlugins.Add(new HomeComponents.HCGameInfos());
            HomeComponentPlugins.Add(new HomeComponents.HCStatus());
            HomeComponentPlugins.Add(new HomeComponents.HCServerInfos());
            HomeComponentPlugins.Add(new HomeComponents.HCNetworkStats());
            HomeComponentPlugins.Add(new HomeComponents.HCPlayerList());
        }


        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Call update methods /////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////

        private void updateLoop()
        {
            Thread.Sleep(5000);
            foreach(IBasePlugin p in updateList)
            {
                p.onPluginUpdate();
            }
        }




        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Call event methods //////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////


        /// <summary>
        /// Call onGbxCallBack on InGamePlugins
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void onGbxCallBack(object sender, GbxCallbackEventArgs args)
        {
            foreach (InGamePlugin plug in InGamePlugins)
            {
                plug.onGbxCallBack(sender, args,false);
            }
            foreach (HomeComponentPlugin plug in HomeComponentPlugins)
            {
                plug.onGbxCallBack(this, args);
            }
        }

        /// <summary>
        /// Call onGbxAsyncResult on InGamePlugins
        /// </summary>
        /// <param name="res"></param>
        public void onGbxAsyncResult(GbxCall res)
        {
            //Send to plugins --------------------------------------------------------------------------------
            foreach (InGamePlugin plug in InGamePlugins)
            {
                try
                {
                    plug.onGbxAsyncResult(res);
                }
                catch (Exception e)
                {
                    Lama.log("ERROR", "Plugins " + plug.PluginName + " throws Gbx Error :" + e.Message);
                }
            }
            //Send to plugins --------------------------------------------------------------------------------
            foreach (HomeComponentPlugin plug in HomeComponentPlugins)
            {
                try
                {
                 //   plug.onGbxAsyncResult(res);
                }
                catch (Exception e)
                {
                    Lama.log("ERROR", "Plugins " + plug.PluginName + " throws Gbx Error :" + e.Message);
                }
            }
        }
  
        /// <summary>
        /// Load Tab and InGameList in configserv
        /// </summary>
        /// <param name="pages"></param>
        /// <param name="list"></param>
        /// <param name="getConfigDelegate"></param>
        public void loadConfigServ(TabControl.TabPageCollection pages, CheckedListBox.ObjectCollection list, GetConfigValue getConfigDelegate)
        {
            Lama.log("NOTICE", "Load Plugins");
            //Load ConfigServPlugins
            if (TabPlugins != null)
            {
                list.Clear();
                foreach (TabPlugin plugin in TabPlugins)
                {
                    if (plugin.ConfigServPlugin)
                    {
                        plugin.getConfigValue = getConfigDelegate;
                        Control ctrl = plugin;
                        TabPage tp = new TabPage(plugin.PluginName);
                        tp.Controls.Add(ctrl);
                        ctrl.Dock = DockStyle.Fill;
                        pages.Add(tp);
                    }

                }
            }
          
            list.Clear();
            XmlNode pluginList = Lama.mainConfig[0]
                                 ["servers"]
                                 .getChildByAttribute("id", Lama.serverIndex.ToString())
                                 ["plugins"];
            foreach (IBasePlugin plugin in getAllPlugins())
            {
                bool isChecked = (pluginList.getChildsByValue(plugin.PluginName).Count == 1);
                int idx = list.Add(plugin.PluginName, isChecked);

            }
            
        }

        /// <summary>
        /// Call onDisconnect on plugins
        /// </summary>
        public void onDisconnect()
        {
            foreach(HomeComponentPlugin p in HomeComponentPlugins)
            {
                p.onDisconnect();
            }

            foreach(InGamePlugin p in InGamePlugins)
            {
                p.onDisconnect();
            }
        }



        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Inter Plugin Communication //////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        
        /// <summary>
        /// Send request to plugin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="targetName"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        InterPluginResponse PMInterPluginCall(IBasePlugin sender, string targetName, InterPluginArgs args)
        {
            if (targetName.ToUpper() == "PLUGINMANAGER")
            {
                switch (args.CallName)
                {
                    case "GetPluginList":
                        Dictionary<string, PluginType> plgs = new Dictionary<string, PluginType>();
                        List<IBasePlugin> l = getAllPlugins();
                        foreach(IBasePlugin p in l)
                        {
                            plgs.Add(p.PluginName, p.PluginType);
                        }
                        return new InterPluginResponse(args.CallName, new Dictionary<string, object>()
                        {
                            {"PluginList", plgs }
                        });


                    default:
                        return new InterPluginResponse(true, "Unknown call : " + args.CallName);
                }
            }
            else
            {
                IBasePlugin target = getPluginByName(targetName);
                if (target != null)
                {
                    return target.onInterPluginCall(sender, args);
                }
                else
                {
                    return new InterPluginResponse(true, "unknow plugin " + targetName);
                }
            }
        }
                            
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Other ///////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Get all plugins (IBasePlugin)
        /// </summary>
        /// <returns></returns>
        public List<IBasePlugin> getAllPlugins()
        {
            List<IBasePlugin> ret = new List<IBasePlugin>();
            ret.AddRange(this.HomeComponentPlugins);
            ret.AddRange(this.InGamePlugins);
            ret.AddRange(this.TabPlugins);
            return ret;
        }

        /// <summary>
        /// Save HomeComponent from EditHome menu
        /// </summary>
        public void saveHomeComponentLocations()
        {
            this.hcFile.write(HomeComponentPlugins);
        }


        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Private /////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Check plugin requirements and prepare LamaConfig
        /// </summary>
        /// <param name="plug"></param>
        /// <param name="brInfos"></param>
        /// <param name="conf2Plug"></param>
        /// <returns></returns>
        bool checkRequirements(IBasePlugin plug, out string brInfos, out LamaConfig conf2Plug)
        {
            brInfos = "";
            bool badRequirement = false;
            conf2Plug = new LamaConfig()
            {
                connected = true,
                scriptName = "",
                remote = Lama.remote,
                configFiles = new Dictionary<string, XmlDocument>()
            };
            foreach (Requirement r in plug.Requirements)
            {
                switch (r.Type)
                {
                    case RequirementType.PLUGIN:
                        if (getPluginByName(r.Value) == null)
                        {
                            badRequirement = true;
                            brInfos += "Requiredplugin '" + r.Value + "' does not exists";
                        }

                        break;

                    case RequirementType.FILE:
                        try
                        {
                            conf2Plug.configFiles.Add(r.Value, new XmlDocument(@"Config\Servers\" + Lama.serverIndex + @"\" + r.Value));
                        }
                        catch (Exception)
                        {
                            badRequirement = true;
                            brInfos += @"Unable to load Config\Servers\" + Lama.serverIndex + @"\" + r.Value + " ";
                        }
                        break;

                    case RequirementType.DATABASE:
                        conf2Plug.dbConnected = false;
                        break;
                }
            }
           

            return badRequirement;
        }


        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Getter & Setters ////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////

    
        /// <summary>
        /// 
        /// </summary>
        public List<InGamePlugin> InGamePlugins { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<TabPlugin> TabPlugins { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<HomeComponentPlugin> HomeComponentPlugins { get; set; }

     
 
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Classes /////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////

     
        /// <summary>
        /// HomeComponents settings file
        /// </summary>
        public class HCFile
        {
            string path;
            private List<HCFP> hcProtos = new List<HCFP>();
            /// <summary>
            /// 
            /// </summary>
            /// <param name="path"></param>
            public HCFile(string path)
            {
                this.path = path;
                try
                {
                    /*GZipStream gzs = new GZipStream(File.OpenRead(path),CompressionLevel.Fastest);
                    StreamReader sr = new StreamReader(gzs);

                    string text = sr.ReadToEnd();
                    IEnumerable<string> lines = text.Split('\n');
                    */
                    List<string> lines = new List<string>(File.ReadAllLines(path));
                    foreach(string line in lines)
                    {
                        string[] args = line.Split('\t');

                        string name = args[0];

                        int.TryParse(args[1], out int x);
                        int.TryParse(args[2], out int y);
                        int.TryParse(args[3], out int width);
                        int.TryParse(args[4], out int height);

                        HCFP proto = new HCFP()
                        {
                            name = name,
                            x = x,
                            y = y,
                            width = width,
                            height = height
                        };

                        this.hcProtos.Add(proto);
                    }


                }
                catch(Exception)  { }
            }
            /// <summary>
            /// 
            /// </summary>
            public List<HCFP> HcProtos { get => hcProtos; set => hcProtos = value; }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="name"></param>
            /// <returns></returns>
            public bool haveProto(string name)
            {
                int cpt = 0;
                while(cpt < HcProtos.Count && name != HcProtos[cpt].name) { cpt++; }


                return (cpt < HcProtos.Count && name == HcProtos[cpt].name);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="name"></param>
            /// <returns></returns>
            public HCFP getProto(string name)
            {
                int cpt = 0;
                while (cpt < HcProtos.Count && name != HcProtos[cpt].name) { cpt++; }

                if (name == HcProtos[cpt].name)
                    return hcProtos[cpt];
                else
                    return new HCFP();
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="plugins"></param>
            public void write(List<HomeComponentPlugin> plugins)
            {
                FileStream fs = File.Open(path, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);

                foreach(HomeComponentPlugin p in plugins)
                {
                    
                    sw.WriteLine(p.PluginName + "\t" + p.Location.X + "\t" + p.Location.Y + "\t" + p.Width + "\t" + p.Height);
                }

                sw.Close();
                fs.Close();
            }



        }
        
        /// <summary>
        /// HomeComponent prototype
        /// </summary>
        public struct HCFP
        {
            /// <summary>
            /// 
            /// </summary>
            public string name;
            /// <summary>
            /// 
            /// </summary>
            public int x;
            /// <summary>
            /// 
            /// </summary>
            public int y;
            /// <summary>
            /// 
            /// </summary>
            public int width;
            /// <summary>
            /// 
            /// </summary>
            public int height;
        }
            
        /// <summary>
        /// PluginManager Cache Class
        /// </summary>
        public class PMCache
        {
            string path;
            Dictionary<string, string> hashs = new Dictionary<string, string>();
            List<string> ignore = new List<string>();
            Dictionary<string, List<string>> links = new Dictionary<string, List<string>>();

            static StreamReader sr;
            static FileStream fs = null;

            /// <summary>
            /// Instanciation from path
            /// </summary>
            /// <param name="path"></param>
            public PMCache(string path)
            {
                this.path = path;
                if (fs == null)
                {
                    fs = File.Open(path, FileMode.OpenOrCreate);
                  //  GZipStream gzs = new GZipStream(fs, CompressionLevel.Fastest) ;
                    sr = new StreamReader(fs);
                    string text = sr.ReadToEnd();
                    int type = 0; //0 =none; 1=hash; 2=ingore; 3=links;


                    foreach (string s in text.Split('\n'))
                    {
                        string str = s;
                        if (s.Contains('\r'))
                        {
                            str = s.Substring(0, s.Length - 1);
                        }
                        switch (str)
                        {
                            case "#HS#":
                                type = 1;
                                break;
                            case "#IG#":
                                type = 2;
                                break;
                            case "#LK#":
                                type = 3;
                                break;
                            default:

                                switch (type)
                                {
                                    case 1:
                                        string[] lh = str.Split('\t');
                                        addLib(lh[0]);
                                        if (lh.Length == 2)
                                            addHash(lh[0], lh[1]);
                                       
                                        break;

                                    case 2:
                                        addIgnore(str);
                                        break;

                                    case 3:
                                        string[] lk = str.Split('\t');
                                        if (!this.ignore.Contains(lk[0]) && str != "")
                                        {
                                            if (!this.links.ContainsKey(lk[0]))
                                                this.links.Add(lk[0], new List<string>() { lk[1] });
                                            else
                                            {
                                                this.links[lk[0]].Add(lk[1]);
                                            }
                                        }
                                        break;
                                }

                                break;
                        }


                    }

                }
            }

            /// <summary>
            /// Test constructor
            /// </summary>
            public PMCache() { }

            /// <summary>
            /// Get links from lib name
            /// </summary>
            /// <param name="lib"></param>
            /// <returns></returns>
            public List<string> getLinks(string lib)
            {
                if (this.links.ContainsKey(lib))
                    return this.links[lib];
                else
                    return new List<string>();
            }

            /// <summary>
            /// Get lib hash
            /// </summary>
            /// <param name="lib"></param>
            /// <returns></returns>
            public string getHash(string lib)
            {
                if (this.hashs.ContainsKey(lib))
                    return this.hashs[lib];
                else
                    return "";
            }

            /// <summary>
            /// Get if lib is ignored
            /// </summary>
            /// <param name="lib"></param>
            /// <returns></returns>
            public bool isIgnore(string lib)
            {
                return (this.ignore.Contains(lib));
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="libName"></param>
            /// <returns></returns>
            public bool haveLib(string libName)
            {
                return this.hashs.ContainsKey(libName);
            }

            /// <summary>
            /// Compute lib hash
            /// </summary>
            /// <param name="path"></param>
            /// <param name="hash"></param>
            /// <returns></returns>
            public bool computeHash(string path, out string hash)
            {
                try
                {
                    using (var md5 = MD5.Create())
                    {
                        using (var stream = File.OpenRead(path))
                        {
                            hash = Encoding.Unicode.GetString(md5.ComputeHash(stream));
                            return true;
                        }
                    }
                }
                catch (Exception)
                {
                    hash = "";
                    return false;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="libName"></param>
            /// <param name="ignore"></param>
            /// <param name="classes"></param>
            public void addLib(string libName, bool ignore = false, params string[] classes)
            {
                //TODO: compute hash
                computeHash(libName, out string hash);
                addHash(libName, hash);
                if (ignore)
                    addIgnore(libName);
                else
                {
                    if(classes != null)
                    {
                        foreach(string s in classes)
                        {
                            addLink(libName, s);
                        }
                    }
                }

            }

            /// <summary>
            /// 
            /// </summary>
            public void ClearCache()
            {
                this.hashs.Clear();
                this.links.Clear();
                this.ignore.Clear();
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="libName"></param>
            public void removeLib(string libName)
            {
                removeHash(libName);
                removeIgnore(libName);
                removeAllLinks(libName);
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="lib"></param>
            /// <param name="className"></param>
            public void addLink(string lib, string className)
            {
                if (!this.links.ContainsKey(lib))
                    this.links.Add(lib, new List<string>() { className });
                else
                    if(!this.links.ContainsKey(className))
                        this.links[lib].Add(className);
                
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="libName"></param>
            /// <param name="className"></param>
            public void removeLink(string libName, string className)
            {
                if (this.links.ContainsKey(libName))
                {
                    if (this.links[libName].Contains(className))
                        this.links[libName].Remove(className);
                }
            }

            /// <summary>
            /// /
            /// </summary>
            /// <param name="libName"></param>
            public void removeAllLinks(string libName)
            {
                if (this.links.ContainsKey(libName))
                    this.links.Remove(libName);
            }


            /// <summary>
            /// 
            /// </summary>
            /// <param name="libName"></param>
            /// <param name="hash"></param>
            public void addHash(string libName, string hash)
            {
                if (!this.hashs.ContainsKey(libName))
                    this.hashs.Add(libName, hash);
                else
                    this.hashs[libName] = hash;
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="libName"></param>
            public void removeHash(string libName)
            {
                if (this.hashs.ContainsKey(libName))
                    this.hashs.Remove(libName);
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="libName"></param>
            public void addIgnore(string libName)
            {
                if (!this.ignore.Contains(libName))
                    this.ignore.Add(libName);
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="libName"></param>
            public void removeIgnore(string libName)
            {
                if (this.ignore.Contains(libName))
                    this.ignore.Remove(libName);
            }

            /// <summary>
            /// 
            /// </summary>
            public void save()
            {
                fs.Close();
                fs = File.Open(this.path, FileMode.Create);
           //     GZipStream gzs = new GZipStream(fs, CompressionLevel.Fastest);

                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine("#HS#");
                foreach(KeyValuePair<string,string> kvp in hashs)
                {
                    sw.WriteLine(kvp.Key + '\t' + kvp.Value);
                }

                sw.WriteLine("#IG#");
                foreach(string s in ignore)
                {
                    sw.WriteLine(s);
                }

                sw.WriteLine("#LK#");
                foreach(KeyValuePair<string,List<string>> kvp in links)
                {
                    foreach(string s in kvp.Value)
                    {
                        sw.WriteLine(kvp.Key + '\t' + s);
                    }
                }

                sw.Close();
                fs.Close();
                fs = null;
            }


        }

    }
}
