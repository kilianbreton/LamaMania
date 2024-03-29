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

#define debug
//#define visualDebug

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
using NTK.Database;
using LamaPlugin;
using static LamaMania.StaticMethods;
using static LamaMania.Program;
using LamaMania.Other;

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
        /// 

        private string servType;
        private RegisteryManager registryManager;
        /// <summary>
        /// Home Launcher constructor
        /// </summary>
        public HomeLauncher()
        {
            InitializeComponent();

            registryManager = new RegisteryManager();
            if( !registryManager.RootKeyExist)
            {
               // FirstStart fs = new FirstStart();
               // fs.Show();
            }


#if debug
            lama.lamaLogger = new LamaLog(@"Logs\Lama.log",true);
#else
            Lama.lamaLogger = new LamaLog(@"Logs\Lama.log",false);
#endif
            lama.log("NOTICE", "Program start================================================================================");

            lama.localesManager = new LocalesManager("LamaMania", Path.GetDirectoryName(Application.ExecutablePath) + @"\", Path.GetDirectoryName(Application.ExecutablePath) + @"\Plugins\","FR", lama.log);
      //    lama.localesManager.saveAppForm(this);

            lama.pluginManager = new PluginManager(@"Config\Servers\" + lama.serverIndex, Path.GetDirectoryName(Application.ExecutablePath) +"\\", lama);
            lama.pluginManager.loadPlugins();
            lama.pluginManager.loadInternalHC(new HomeComponents.HCGameInfos(),
                                              new HomeComponents.HCNetworkStats(),
                                              new HomeComponents.HCPlayerList(),
                                              new HomeComponents.HCServerInfos(),
                                              new HomeComponents.HCStatus());

            load();
        }

        /// <summary>
        /// 
        /// </summary>
        public void load()
        {
            lama.log("NOTICE", "Read main config");
            lama.mainConfig = new XmlDocument(@"Config\Main.xml");
            serversManager = new ServersManager(Application.StartupPath + @"\Servers\", lama.mainConfig[0]["servers"]);

            XmlNode root = lama.mainConfig[0];
            while (root.read())
            {
                var node = root.getNode();
                switch (node.Name)
                {
                    case "startMode":
                        if (!node.Value.ToUpper().Equals("SELECT"))
                        {
                            if(!int.TryParse(node.Value, out lama.startMode))
                            {
                                lama.startMode = -1;
                                lama.log("WARNING", "StartMode : '" + node.Value + "' Unknown");
                            }
                        }
                        break;
                    case "servers":
                        lama.log("NOTICE", "Read server list");
                       // lama.servers.Clear();
                        flatComboBox1.Items.Clear();
                        foreach (XmlNode n in node.Childs)
                        {
                           //lama.servers.Add(int.Parse(n.getAttibuteV("id")), n["name"].Value);
                            flatComboBox1.Items.Add(n["name"].Value);
                        }
                        break;
                }
            }

            if (lama.startMode >= 0)
            {
                start(lama.startMode);
            }
        }

      

        void loadScriptSettings(string locale)
        {
            XmlDocument script = new XmlDocument(@"Config\locales\" + locale + @"\ScriptSettings.xml");
            foreach(XmlNode n in script[0].Childs)
            {
                lama.scriptSettingsLocales.Add(n.Name, n.Value);
            }
            
        }

        void start(int index)
        {
            //Open Server config
            lama.serverIndex = index;
            XmlNode cfg = lama.mainConfig[0]["servers"].getChildByAttribute("id", index.ToString());
            if (cfg["remote"].getAttibuteV("value").ToUpper().Equals("TRUE"))
            {
                lama.remote = true;
                lama.remoteAdrs = cfg["remote"]["ip"].Value;
                lama.remotePort = (int)cfg["remote"]["port"].LValue;
                string login = cfg["remote"]["login"].Value;

               // servType = cfg.getAttibuteV("type");

                var askLogs = new AskLogins(login);
                var result = askLogs.getDialogResult();
                if (result.Res)
                {
                    lama.launched = true;
#if visualDebug
                    Main main = new Main();
#else
                    Main main = new Main(result.Login, result.Pass);
                    main.commonConstructor();
#endif
                    this.Hide();
                    main.Show();
                    
                }

            }
            else
            {
                servType = cfg.getAttibuteV("type");
                if (cfg.isChildExist("database") && (cfg["database"].haveAttribute("value") && cfg["database"].getAttibuteV("value").ToUpper() == "TRUE") || !cfg["database"].haveAttribute("value"))
                {
                    lama.pluginManager.initDatabase(cfg["database"]);
                }
                var config = new XmlDocument(@"Servers\" + index + @"\UserData\Config\dedicated_cfg.txt");

                string path;
                string cmd;

                if (servType == "TM3")
                {
                    path = @"Servers\" + index + @"\TrackmaniaServer.exe";
                    cmd = "";
                }
                else
                {
                    path = @"Servers\" + index + @"\ManiaPlanetServer.exe";
                    cmd = "/Title=" + config[0]["system_config"]["title"].Value;
                }

              
               
                cmd += " /dedicated_cfg=dedicated_cfg.txt";
                cmd += " /game_settings=" + cfg["matchSettings"].Value;
                if(cfg["internetServer"].Value.ToUpper() == "TRUE")
                {
                    //cmd += " /lan";
                }



                cmd += " /validation=" + config[0]["masterserver_account"]["validation_key"].Value;
                cmd += " /login=" + config[0]["masterserver_account"]["login"].Value;
                cmd += " /password=" + config[0]["masterserver_account"]["password"].Value;
                
                //Open database connection
                if(cfg["database"].haveAttribute("value") && cfg["database"].getAttibuteV("value").ToUpper().Equals("TRUE"))
                {
                    string ip = cfg["database"]["ip"].Value;
                    string login = cfg["database"]["login"].Value;
                    string passwd = cfg["database"]["passwd"].Value;
                    string baseName = cfg["database"]["baseName"].Value;
                    lama.database = NTKD_MySql.overrideInstance(ip, login, passwd, baseName);
                }
                
                //Select plugin list
               // if (cfg["plugins"].haveAttribute("value") && cfg["plugins"].getAttibuteV("value").ToUpper().Equals("TRUE"))
                //{
                    lama.pluginManager.selectPluginsFrmCfg(cfg["plugins"]);
                //}
#if visualDebug

                Main main = new Main();
                main.Show();
#else
                if (lama.invisibleServer)
                {
                    lama.serverProcess = new Process();
                    ProcessStartInfo startInfo = new ProcessStartInfo
                    {
                        WindowStyle = ProcessWindowStyle.Hidden,
                        FileName = path,
                        Arguments = cmd
                    };
                    lama.serverProcess.Exited += new EventHandler(lama.Process_Exited);
                    lama.serverProcess.Disposed += new EventHandler(lama.Process_Disposed);
                    
                    lama.serverProcess.ErrorDataReceived += Process_ErrorDataReceived;
                    lama.serverProcess.StartInfo = startInfo;
                    lama.serverProcess.Start();
                }
                else
                {
                    
                    lama.serverProcess = new Process();
                    ProcessStartInfo startInfo = new ProcessStartInfo
                    {
                        WindowStyle = ProcessWindowStyle.Normal,
                        FileName = path,
                        Arguments = cmd,
                    };

                    lama.serverProcess.EnableRaisingEvents = true;
                    lama.serverProcess.Exited += new EventHandler(lama.Process_Exited);
                    lama.serverProcess.Disposed += new EventHandler(lama.Process_Disposed);
                    lama.serverProcess.StartInfo = startInfo;
                    lama.serverProcessExited = false;
                    lama.serverProcess.Start();
                    lama.serverProcess.OutputDataReceived += new DataReceivedEventHandler(lama.Process_DataReceived);

                    
                }

                lama.launched = true;

                //Open main form
                try
                {
                 
                    var mainForm = new Main(config);
                  //  Thread t = new Thread(mainForm.Show);
                    mainForm.Show();
                    mainForm.commonConstructor();
                   // t.Start();
                }
                catch (Exception)
                {
                  

                }
#endif
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
                try
                {
                    XmlNode cfg = serversManager.getCfg(flatComboBox1.Text);
                    int.TryParse(cfg.getAttibuteV("id"), out lama.serverIndex);

                    if (cfg["remote"].getAttribute("value").Value.ToUpper().Equals("TRUE"))
                    {
                        var conf = new NewServer(this, cfg);
                        conf.Show();
                    }
                    else
                    {
                        var conf = new ConfigServ(lama.serverIndex, flatComboBox1.Text);
                        conf.Show();
                    }
                }
                catch (Exception er)
                {
                    lama.onError(this, "Serveur introuvable", er.Message);
                }
            }
        }
        
        //Remove
        private void flatButton3_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure ?", "Are you sure to remove"+ flatComboBox1.SelectedText, MessageBoxButtons.YesNo);
            if(res == DialogResult.No)
                return;

     
            int index = serversManager.getIdByName(flatComboBox1.Text);

            XmlNode cfg = lama.mainConfig[0]["servers"].getChildByAttribute("id", index.ToString());

            try
            {
                if (cfg["remote"].getAttibuteV("value").ToUpper().Equals("FALSE"))
                {
                    Directory.Delete(Application.StartupPath + @"\Servers\" + index + @"\", true);
                }

            }
            catch (Exception dirEx){
                lama.onException(this, dirEx);
            }

            //Update Main Config

            serversManager.removeById(index);
            lama.mainConfig.save();

            flatComboBox1.Items.Clear();
            flatComboBox1.Items.AddRange(serversManager.getServersList()); 

        }
        
        //Start
        private void flatButton1_Click(object sender, EventArgs e)
        {
            try
            {
                int index = serversManager.getIdByName(flatComboBox1.Text);

                start(index);
            }
            catch (Exception)
            {
                lama.onError(this, "Error", "Undefined server : " + flatComboBox1.Text);
            }
        }

        private void FlatButton5_Click(object sender, EventArgs e)
        {
            ConfigSoft cfgs = new ConfigSoft();
            cfgs.Show();
        }

        private void B_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void b_logs_Click(object sender, EventArgs e)
        {
            try
            {
                int index = serversManager.getIdByName(flatComboBox1.Text);

                string logsPath = Application.StartupPath + @"\Servers\" + index + @"\Logs\";

                DirectoryInfo di = new DirectoryInfo(logsPath);

                DateTime lastAccess = di.EnumerateFiles("ConsoleLog*").Max(file => file.LastAccessTime);
                List<FileInfo> lastLog = new List<FileInfo>(di.EnumerateFiles("ConsoleLog*").Where(file => file.LastAccessTime == lastAccess));
               

                if(lastLog.Count == 1)
                {
                    LogViewer lv = new LogViewer(lastLog[0].FullName);
                    lv.Show();
                }

            }
            catch (Exception)
            {
                lama.onError(this, "Error", "Undefined server : " + flatComboBox1.Text);
            }
        }
    }
}
