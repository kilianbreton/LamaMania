﻿/* ----------------------------------------------------------------------------------
 * Project : LamaMania
 * Launch Authenticate Manage & Access ManiaPlanet Servers
 * Inspired by ServerMania by Cyrlaur
 * 
 * ----------------------------------------------------------------------------------
 * Author:	    Breton Kilian
 * Copyright:	April 2019 by Breton Kilian
 * ----------------------------------------------------------------------------------
 *
 * LICENSE: This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.If not, see<http://www.gnu.org/licenses/>.
 *
 * ----------------------------------------------------------------------------------*/

using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using NTK.IO.Xml;
using NTK.IO;
using LamaLang;
using LamaPlugin;
using static LamaMania.StaticMethods;

namespace LamaMania
{
    /// <summary>
    /// Launcher
    /// </summary>
    public partial class HomeLauncher : Form
    {
        /// <summary>
        /// Chargement du formulaire
        /// </summary>
        public HomeLauncher()
        {
            InitializeComponent();
            
            Lama.lamaLogger = new LamaLog(@"Logs\Lama.log");
            Lama.pluginManager = new PluginManager();
            Lama.pluginManager.loadPlugins();
            load();
        }

        /// <summary>
        /// 
        /// </summary>
        public void load()
        {
            Lama.log("NOTICE", "Read main config");
            Lama.mainConfig = new XmlDocument(@"Config\Main.xml");
            XmlNode root = Lama.mainConfig[0];
            while (root.read())
            {
                var node = root.getNode();
                switch (node.Name)
                {
                    case "startMode":
                        if (!node.Value.ToUpper().Equals("SELECT"))
                        {
                            Lama.startMode = int.Parse(node.Value);
                        }
                        break;

                    case "lang":
                        loadScriptSettings(node.Value);
                        switch (node.Value)
                        {
                            case "FR":
                                
                                break;
                            case "EN":
                                //   Lama.lang = new BaseEN();
                                break;
                            default:
                                //TODO: Manage dll
                                List<BaseLang> lstLang = new List<BaseLang>();
                                DirectoryInfo pluginsDir = new DirectoryInfo(Path.GetDirectoryName(Application.ExecutablePath) + @"\Plugins\");
                                foreach (FileInfo file in pluginsDir.GetFiles())
                                {
                                    DllLoader loader = new DllLoader(file.FullName);
                                    lstLang.AddRange(loader.getAllInstances<BaseLang>());
                                }
                                break;
                        }

                        if (Lama.lang != null)
                            loadLang();

                        break;

                    case "servers":
                        Lama.log("NOTICE", "Read server list");
                        Lama.servers.Clear();
                        flatComboBox1.Items.Clear();
                        foreach (XmlNode n in node.Childs)
                        {
                            Lama.servers.Add(int.Parse(n.getAttibuteV("id")), n["name"].Value);
                            flatComboBox1.Items.Add(n["name"].Value);
                        }
                        break;
                }
            }

            if (Lama.startMode >= 0)
            {
                start(Lama.startMode);
            }
        }

        void loadLang()
        {

        }

        void loadScriptSettings(string locale)
        {
            XmlDocument script = new XmlDocument(@"Config\locales\" + locale + @"\ScriptSettings.xml");
            foreach(XmlNode n in script[0].Childs)
            {
                Lama.scriptSettingsLocales.Add(n.Name, n.Value);
            }
            
        }

        void start(int index)
        {
          /*  Thread tLoad = new Thread(Lama.loadForm.Show);
            tLoad.Start();*/
            //  Lama.loadForm.Show();
            //Open Server config
            Lama.serverIndex = index;
            XmlNode cfg = Lama.mainConfig[0]["servers"].getChildByAttribute("id", index.ToString());
            if (cfg["remote"].getAttibuteV("value").ToUpper().Equals("TRUE"))
            {
                Lama.remoteAdrs = cfg["remote"]["ip"].Value;
                Lama.remotePort = (int)cfg["remote"]["port"].LValue;
                string login = cfg["remote"]["login"].Value;
                var askLogs = new AskLogins(login);
                var result = askLogs.getDialogResult();
                if (result.Res)
                {
                    Lama.launched = true;
                    Main main = new Main(result.Login, result.Pass);
                    main.Show();
                    this.Hide();
                }

            }
            else
            {
                var config = new XmlDocument(@"Servers\" + index + @"\UserData\Config\dedicated_cfg.txt");

                string path = @"Servers\" + index + @"\ManiaPlanetServer.exe";

                string cmd = "/Title=" + config[0]["system_config"]["title"].Value;
                cmd += " /dedicated_cfg=dedicated_cfg.txt";
                cmd += " /game_settings=" + cfg["matchSettings"].Value;
                if(cfg["internetServer"].Value.ToUpper() == "TRUE")
                {
                    cmd += " /lan";
                }
                //Select plugin list
                if (cfg["plugins"].getAttibuteV("value").ToUpper().Equals("TRUE"))
                {
                    Lama.pluginManager.selectInGamePlugins(cfg["plugins"]);
                }

                if (Lama.invisibleServer)
                {
                    Lama.serverProcess = new Process();
                    ProcessStartInfo startInfo = new ProcessStartInfo
                    {
                        WindowStyle = ProcessWindowStyle.Hidden,
                        FileName = path,
                        Arguments = cmd
                    };
                    Lama.serverProcess.Exited += new EventHandler(Lama.Process_Exited);
                    Lama.serverProcess.Disposed += new EventHandler(Lama.Process_Disposed);
                    
                    Lama.serverProcess.ErrorDataReceived += Process_ErrorDataReceived;
                    Lama.serverProcess.StartInfo = startInfo;
                    Lama.serverProcess.Start();
                }
                else
                {
                    
                    Lama.serverProcess = new Process();
                    ProcessStartInfo startInfo = new ProcessStartInfo
                    {
                        WindowStyle = ProcessWindowStyle.Normal,
                        FileName = path,
                        Arguments = cmd,
                    };
                    Lama.serverProcess.EnableRaisingEvents = true;
                    Lama.serverProcess.Exited += new EventHandler(Lama.Process_Exited);
                    Lama.serverProcess.Disposed += new EventHandler(Lama.Process_Disposed);
                    Lama.serverProcess.StartInfo = startInfo;
                    Lama.serverProcessExited = false;
                    Lama.serverProcess.Start();
                    Lama.serverProcess.OutputDataReceived += new DataReceivedEventHandler(Lama.Process_DataReceived);

                    
                }

                Lama.launched = true;

                //Open main form
                try
                {
                    
                    var mainForm = new Main(config);
                  //  Thread t = new Thread(mainForm.Show);
                    mainForm.Show();
                   // t.Start();
                }
                catch (Exception)
                {
                  

                }
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Autres Methodes /////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void Process_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            throw new NotImplementedException();
        }

     

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Methodes Event UI ///////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //New
        private void flatButton4_Click(object sender, EventArgs e)
        {
            var newServ = new NewServer(this);
            newServ.Show();
        }
        //Edit
        private void flatButton2_Click(object sender, EventArgs e)
        {
            if (flatComboBox1.SelectedIndex != -1)
            {
                int index = flatComboBox1.SelectedIndex;
                XmlNode cfg = Lama.mainConfig[0]["servers"].getChildByAttribute("id", index.ToString());
                if (cfg["remote"].getAttribute("value").Value.ToUpper().Equals("TRUE"))
                {
                    var conf = new NewServer(this, cfg);
                    conf.Show();
                }
                else
                {
                    var conf = new ConfigServ(index);
                    conf.Show();
                }
            }
        }
        //Remove
        private void flatButton3_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure ?", "Are you sure to remove"+ flatComboBox1.SelectedText, MessageBoxButtons.YesNo);
            if(res == DialogResult.No)
                return;
            
            int index = Lama.servers.getKeyFromValue(flatComboBox1.Text);
            XmlNode cfg = Lama.mainConfig[0]["servers"].getChildByAttribute("id", index.ToString());

            try
            {
                if (cfg["remote"].getAttibuteV("value").ToUpper().Equals("FALSE"))
                {
                    Directory.Delete(Application.StartupPath + @"\Servers\" + index + @"\", true);
                }

            }
            catch (Exception dirEx){
                Lama.onException(this, dirEx);
            }
         
            //Update Main Config
            int total = Lama.mainConfig[0]["servers"].removeChildsByAttribute("server", "id", index.ToString());


            if (total != 1)
            {
                Lama.onError(this, "Error", "Unable to delete server from main config, nodes affected = ");
            }
            else
            {
                Lama.mainConfig.save();
                load();
            }

        }
        //Start
        private void flatButton1_Click(object sender, EventArgs e)
        {
            try
            {
                int index = Lama.servers.getKeyFromValue(flatComboBox1.Text);
                start(index);
            }
            catch (Exception)
            {
                Lama.onError(this, "Error", "Undefined server : " + flatComboBox1.Text);
            }
        }            
    }
}
