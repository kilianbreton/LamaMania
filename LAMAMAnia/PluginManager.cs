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

namespace LamaMania
{
    /// <summary>
    /// Manage LamaPlugins
    /// </summary>
    public class PluginManager
    {
        private PMCache cache;
        private HCFile hcFile;

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
        }


        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Load dll ////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////



        /// <summary>
        /// Load plugins from dll
        /// </summary>
        public void loadPluginsObsolete()
        {
            Lama.log("NOTICE", "Load plugins");
            try
            {
                DirectoryInfo pluginsDir = new DirectoryInfo(Path.GetDirectoryName(Application.ExecutablePath) + @"\Plugins\");
                //Read dllignore
                List<string> dllignore = new List<string>(File.ReadAllLines(pluginsDir.FullName + "dllignore"));
                //Read dll
                foreach (FileInfo file in pluginsDir.GetFiles())
                {
                    if (file.Extension.Equals(".dll") && !dllignore.Contains(file.Name))
                    {
                        try
                        {
                            DllLoader loader = new DllLoader(file.FullName);
                            //Load instances in lists and count nb instances
                            int cpt = loader.getAllCountInstances(InGamePlugins)
                                    + loader.getAllCountInstances(HomeComponentPlugins)
                                    + loader.getAllCountInstances(TabPlugins);

                            if (cpt == 0) //0 Instances loaded
                            {   //Append dllIgnore
                                Lama.log("NOTICE", file.Name + " added in dllignore (0 instances loaded)");
                                StreamWriter sw = new StreamWriter(File.Open(pluginsDir.FullName + "dllignore", FileMode.Append));
                                sw.WriteLine(file.Name);
                                sw.Close();
                            }
                            else
                            {
                                Lama.log("NOTICE", "Loaded : " + file.Name);
                            }
                        }
                        catch (IOException) { }
                        catch (Exception er)
                        {
                            Lama.log("ERROR", "[LoadPlugins][" + file.FullName + "]" + er.Message + er.GetType().Name);
                            try
                            {   //Append dllIgnore
                                StreamWriter sw = new StreamWriter(File.Open(pluginsDir.FullName + "dllignore", FileMode.Append));
                                sw.WriteLine(file.Name);
                                sw.Close();
                            }
                            catch (Exception) { }
                        }
                    }
                }

            }
            catch (Exception e)
            {
                Lama.log("ERROR", "[LoadPlugins]" + e.Message);
            }

        }
   
        /// <summary>
        /// Load plugins from dll
        /// </summary>
        public void loadPlugins()
        {
            Lama.log("NOTICE", "Load plugins");
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
                                //BruteSearch
                                DllLoader loader = new DllLoader(file.FullName);

                                List<string> links = this.cache.getLinks(file.Name);
                                if (links.Count != 0 && !hashComputed)  //ReadLinks
                                {
                                    int insLoaded = 0;
                                    foreach (string link in links)
                                    {
                                        IBase p = loader.getClassInstance<IBase>(link);
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
                                  //      Lama.log("NOTICE", "    -" + link);
                                    }

                                    if (insLoaded != 0)
                                    {
                                        Lama.log("NOTICE", "Loaded FL : " + file.Name);
                                    }
                                    else
                                    {
                                        this.cache.addIgnore(file.Name);
                                        this.cache.removeAllLinks(file.Name);
                                        Lama.log("NOTICE", file.Name + " added in dllignore (0 instances loaded)");
                                    }

                                }
                                else//Search class
                                {
                                    //Load instances in lists and count nb instances
                                    List<InGamePlugin> inGame = loader.getAllInstances<InGamePlugin>();
                                    List<HomeComponentPlugin> hcs = loader.getAllInstances<HomeComponentPlugin>();
                                    List<TabPlugin> tabs = loader.getAllInstances<TabPlugin>();

                                    int cpt = inGame.Count + hcs.Count + tabs.Count;

                                    foreach (InGamePlugin p in inGame)
                                    {
                                        this.cache.addLink(file.Name, p.GetType().FullName);
                                    }

                                    foreach (HomeComponentPlugin p in hcs)
                                    {
                                        this.cache.addLink(file.Name, p.GetType().FullName);
                                    }

                                    foreach (TabPlugin p in tabs)
                                    {
                                        this.cache.addLink(file.Name, p.GetType().FullName);
                                    }



                                    if (cpt == 0) //0 Instances loaded
                                    {   //Append dllIgnore
                                        Lama.log("NOTICE", file.Name + " added in dllignore (0 instances loaded)");
                                        this.cache.addIgnore(file.Name);
                                    }
                                    else
                                    {
                                        Lama.log("NOTICE", "Loaded : " + file.Name);
                                    }


                                }



                            }
                            catch (IOException) { }
                            catch (Exception er)
                            {
                                Lama.log("ERROR", "[LoadPlugins][" + file.FullName + "]" + er.Message + er.GetType().Name);
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
        // Call load methods ///////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////


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
            foreach(XmlNode node in cfg.Childs)
            {
                InGamePlugin plug = (InGamePlugin)getPluginByName(node.Value,PluginType.InGamePlugin);
                if (plug != null)
                {
                    lst.Add(plug);
                    Lama.log("NOTICE", plug.PluginName + " Selected");
                }
                else
                {
                    Lama.log("WARNING", node.Value + " does not exist");
                }
            }
            InGamePlugins = lst;
        }


        private void selectHomeComponentPlugin(XmlNode cfg)
        {
            List<HomeComponentPlugin> lst = new List<HomeComponentPlugin>();
            foreach (XmlNode node in cfg.Childs)
            {
                HomeComponentPlugin plug = (HomeComponentPlugin)getPluginByName(node.Value,PluginType.HomeComponent);
                if (plug != null)
                {
                    lst.Add(plug);
                    Lama.log("NOTICE", plug.PluginName + " Selected");
                }
                else
                {
                    Lama.log("WARNING", node.Value + " does not exist");
                }
            }
            HomeComponentPlugins = lst;
        }



        /// <summary>
        /// Call onLoad on InGamePlugins
        /// </summary>
        /// <param name="client"></param>
        public void onLoadInGame(XmlRpcClient client)
        {
            Lama.log("NOTICE", "Init InGame Plugins ...");
            List<InGamePlugin> removeLST = new List<InGamePlugin>();
            foreach (InGamePlugin plug in InGamePlugins)
            {
                bool badRequirement = false;
                string brInfos = "";
              
                //Check all requirements=====================================================
                badRequirement = checkRequirements(plug, out brInfos, out LamaConfig conf2plug);
                conf2plug.connected = true;
                conf2plug.scriptName = "";
                conf2plug.remote = Lama.remote;

               
                if (badRequirement)
                {
                    Lama.log("ERROR", "Unable to init [" + plug.PluginName + "] Plugin, " + brInfos);
                    removeLST.Add(plug);
                }
                else
                {
                    Lama.log("NOTICE", "[" + plug.PluginName + "] Plugin loaded");
                    plug.setClient(client);
                    plug.Log = Lama.log;
                    plug.OnError = Lama.onError;
                    
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
        public void loadHomeComponent(XmlRpcClient client, Control mainHomeTab)
        {
            Lama.log("NOTICE", "Init HomeComponent Plugins ...");
            List<HomeComponentPlugin> removeLST = new List<HomeComponentPlugin>();
            foreach(HomeComponentPlugin plugin in HomeComponentPlugins)
            {
                try
                {
                    //Do check requirements
                    string brInfos;
                    bool badRequirement = checkRequirements(plugin, out brInfos, out LamaConfig cfg);
                    if (badRequirement)
                    {
                        Lama.log("ERROR", "Unable to init [" + plugin.PluginName + "] Plugin, " + brInfos);
                        removeLST.Add(plugin);
                    }
                    else
                    {
                        Lama.log("NOTICE", "[" + plugin.PluginName + "] Plugin loaded");
                        plugin.client = client;
                        plugin.Log = Lama.log;
                        plugin.OnError = Lama.onError;
                        plugin.GetLamaProperty = Lama.getLamaProperty;

                        cfg.connected = Lama.connected;
                        cfg.remote = Lama.remote;
                        cfg.lvl = Lvl.SuperAdmin;


                        plugin.onLoad(cfg);

                        //Search Location

                        if (this.hcFile.haveProto(plugin.PluginName))
                        {
                            HCFP proto = this.hcFile.getProto(plugin.PluginName);
                            plugin.Location = new Point(proto.x, proto.y);
                        }
                        else
                        {
                            plugin.Location = new Point(200, 400);
                        }

                        mainHomeTab.Controls.Add(plugin);
                    }
                }
                catch (Exception e)
                {
                    Lama.log("ERROR", "Unable to load plugin : " + e.Message);
                }
            }
            foreach(HomeComponentPlugin p in removeLST)
            {
                HomeComponentPlugins.Remove(p);
            }

        }

        /// <summary>
        /// load internal homeComponents in plugin list
        /// </summary>
        public void loadInternalHC()
        {
            HomeComponentPlugins.Add(new HomeComponents.HCGameInfos());
            HomeComponentPlugins.Add(new HomeComponents.HCStatus());
            HomeComponentPlugins.Add(new HomeComponents.HCServerInfos());
            HomeComponentPlugins.Add(new HomeComponents.HCNetworkStats());
            HomeComponentPlugins.Add(new HomeComponents.HCPlayerList());
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
                plug.onGbxCallBack(sender, args);
            }
            foreach (HomeComponentPlugin plug in HomeComponentPlugins)
            {
                plug.onGbxCallBack(args);
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
            if (Lama.pluginManager.TabPlugins != null)
            {
                list.Clear();
                foreach (TabPlugin plugin in Lama.pluginManager.TabPlugins)
                {
                    plugin.getConfigValue = getConfigDelegate;
                    Control ctrl = plugin;
                    TabPage tp = new TabPage(plugin.PluginName);
                    tp.Controls.Add(ctrl);
                    ctrl.Dock = DockStyle.Fill;
                    pages.Add(tp);

                }
            }
            //Load InGamePlugins List
            if (Lama.pluginManager.InGamePlugins != null)
            {
                list.Clear();
                foreach (BasePlugin plugin in Lama.pluginManager.InGamePlugins)
                {
                    list.Add(plugin.PluginName);
                }
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
        // Other ///////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////

        public void saveHomeComponentLocations()
        {
            this.hcFile.write(HomeComponentPlugins);
        }


        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Private /////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////


        bool checkRequirements(IBase plug, out string brInfos, out LamaConfig conf2Plug)
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
            if (!badRequirement && plug.PluginType == PluginType.InGamePlugin)
            {
                badRequirement = !useT<InGamePlugin>(plug).onLoad(conf2Plug);
                if (badRequirement)
                    brInfos = "onLoad method returned false";
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

     

        public class HCFile
        {
            string path;
            private List<HCFP> hcProtos = new List<HCFP>();

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

            public List<HCFP> HcProtos { get => hcProtos; set => hcProtos = value; }


            public bool haveProto(string name)
            {
                int cpt = 0;
                while(cpt < HcProtos.Count && name != HcProtos[cpt].name) { cpt++; }

                return (HcProtos.Count != 0 && name == HcProtos[cpt].name);
            }


            public HCFP getProto(string name)
            {
                int cpt = 0;
                while (cpt < HcProtos.Count && name != HcProtos[cpt].name) { cpt++; }

                if (name == HcProtos[cpt].name)
                    return hcProtos[cpt];
                else
                    return new HCFP();
            }

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
        
        public struct HCFP
        {
            public string name;
            public int x;
            public int y;
            public int width;
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
            StreamReader sr;
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


            public void ClearCache()
            {
                this.hashs.Clear();
                this.links.Clear();
                this.ignore.Clear();
            }


            public void removeLib(string libName)
            {
                removeHash(libName);
                removeIgnore(libName);
                removeAllLinks(libName);
            }

            public void addLink(string lib, string className)
            {
                if (!this.links.ContainsKey(lib))
                    this.links.Add(lib, new List<string>() { className });
                else
                    if(!this.links.ContainsKey(className))
                        this.links[lib].Add(className);
                
            }

            public void removeLink(string libName, string className)
            {
                if (this.links.ContainsKey(libName))
                {
                    if (this.links[libName].Contains(className))
                        this.links[libName].Remove(className);
                }
            }


            public void removeAllLinks(string libName)
            {
                if (this.links.ContainsKey(libName))
                    this.links.Remove(libName);
            }



            public void addHash(string libName, string hash)
            {
                if (!this.hashs.ContainsKey(libName))
                    this.hashs.Add(libName, hash);
                else
                    this.hashs[libName] = hash;
            }

            public void removeHash(string libName)
            {
                if (this.hashs.ContainsKey(libName))
                    this.hashs.Remove(libName);
            }

            public void addIgnore(string libName)
            {
                if (!this.ignore.Contains(libName))
                    this.ignore.Add(libName);
            }

            public void removeIgnore(string libName)
            {
                if (this.ignore.Contains(libName))
                    this.ignore.Remove(libName);
            }


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
