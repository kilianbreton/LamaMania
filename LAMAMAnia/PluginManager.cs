using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using NTK.IO;
using NTK.IO.Xml;
using LamaPlugin;
using static LamaMania.StaticMethods;
using static LamaPlugin.StaticM;
using TMXmlRpcLib;
using System.Drawing;

namespace LamaMania
{
    /// <summary>
    /// Manage LamaPlugins
    /// </summary>
    public class PluginManager
    {
        /// <summary>
        /// Init plugins list
        /// </summary>
        public PluginManager()
        {
            this.HomeComponentPlugins = new List<HomeComponentPlugin>();
            this.InGamePlugins = new List<InGamePlugin>();
            this.TabPlugins = new List<TabPlugin>();
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

                            if (cpt == 0)
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
        /// Select plugins used by cfg
        /// </summary>
        /// <param name="cfg"></param>
        public void selectInGamePlugins(XmlNode cfg)
        {
            List<InGamePlugin> lst = new List<InGamePlugin>();
            foreach(XmlNode node in cfg.Childs)
            {
                InGamePlugin plug = getPluginByName(node.Value);
                if (plug != null)
                    lst.Add(plug);
            }
            InGamePlugins = lst;
        }

        /// <summary>
        /// Call onLoad on InGamePlugins
        /// </summary>
        /// <param name="client"></param>
        public void onLoadInGame(XmlRpcClient client)
        {
            List<InGamePlugin> removeLST = new List<InGamePlugin>();
            foreach (InGamePlugin plug in InGamePlugins)
            {
                bool badRequirement = false;
                string brInfos = "";
                LamaConfig conf2plug = new LamaConfig()
                {
                    connected = true,
                    scriptName = "",
                    remote = Lama.remote,
                    configFiles = new Dictionary<string, XmlDocument>()
                };
                //Check all requirements=====================================================
                badRequirement = checkRequirements(plug, out brInfos);
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
            List<HomeComponentPlugin> removeLST = new List<HomeComponentPlugin>();
            foreach(HomeComponentPlugin plugin in HomeComponentPlugins)
            {
               
                //Do check requirements
                string brInfos;
                bool badRequirement = checkRequirements(plugin, out brInfos);
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
                    //tests
                    plugin.Location = new Point(200, 400);
                    mainHomeTab.Controls.Add(plugin);
                }      
            }
            foreach(HomeComponentPlugin p in removeLST)
            {
                HomeComponentPlugins.Remove(p);
            }

        }

        public void loadInternalHC()
        {
            HomeComponentPlugins.Add(new HomeComponents.HCGameInfos());

           
            
        }

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
                    plugin.getITabInterface().getConfigValue = getConfigDelegate;
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


        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Private /////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////

        bool checkRequirements(IBase plug, out string brInfos)
        {
            brInfos = "";
            bool badRequirement = false;
            LamaConfig conf2plug = new LamaConfig()
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
                            brInfos += "Requiredplugin '" + r.Value + "does not exists\n";
                        }

                        break;

                    case RequirementType.FILE:
                        try
                        {
                            conf2plug.configFiles.Add(r.Value, new XmlDocument(@"Config\Servers\" + Lama.serverIndex + @"\" + r.Value));
                        }
                        catch (Exception)
                        {
                            badRequirement = true;
                            brInfos += @"Unable to load Config\Servers\" + Lama.serverIndex + @"\" + r.Value + "\n";
                        }
                        break;

                    case RequirementType.DATABASE:
                        conf2plug.dbConnected = false;
                        break;
                }
            }
            if (!badRequirement && plug.PluginType == PluginType.InGamePlugin)
            {
                badRequirement = !useT<InGamePlugin>(plug).onLoad(conf2plug);
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

    }
}
