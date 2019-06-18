/* ----------------------------------------------------------------------------------
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
using NTK.IO.Xml;
using NTK.IO;
using LamaLang;
using LamaPlugin;

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
         
            loadPlugins();
            load();
        }

        /// <summary>
        /// 
        /// </summary>
        public void load()
        {
            
            Lama.mainConfig = new XmlDocument(@"Config\Main.xml");
            var root = Lama.mainConfig[0];
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
                        switch (node.Value)
                        {
                            case "FR":
                             //   Lama.lang = new BaseFR();
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

        void start(int index)
        {
            //  Lama.loadForm.Show();
            //Open Server config
            XmlNode cfg = Lama.mainConfig[0]["servers"].getChildsByAttribute("id", index.ToString())[0];
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
                    this.Close();
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


                if (Lama.invisibleServer)
                {
                    Lama.serverProcess = new Process();
                    ProcessStartInfo startInfo = new ProcessStartInfo
                    {
                        WindowStyle = ProcessWindowStyle.Hidden,
                        FileName = path,
                        Arguments = cmd
                    };
                    Lama.serverProcess.Exited += new EventHandler(Process_Exited);
                    Lama.serverProcess.Disposed += new EventHandler(Process_Disposed);
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
                    
                    Lama.serverProcess.Exited += new EventHandler(Process_Exited);
                    Lama.serverProcess.Disposed += new EventHandler(Process_Disposed);
                    Lama.serverProcess.StartInfo = startInfo;
                    Lama.serverProcess.Start();
                }

                Lama.launched = true;

                //Open main form
                try
                {
                    var mainForm = new Main(config);
                    mainForm.Show();
                }
                catch (Exception)
                {
                  

                }
            }
        }

        private void Process_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Process_Disposed(object sender, EventArgs e)
        {
            Lama.launched = false;
        }

        private void Process_Exited(object sender, EventArgs e)
        {
            Lama.launched = false;
        }

        void loadLang()
        {

        }

        void loadPlugins()
        {
            try
            {
                DirectoryInfo pluginsDir = new DirectoryInfo(Path.GetDirectoryName(Application.ExecutablePath) + @"\Plugins\");
                foreach (FileInfo file in pluginsDir.GetFiles())
                {
                    if (file.Extension.Equals(".dll"))
                    {
                        try
                        {
                            //Todo : add method in DllLoader to multiload
                            DllLoader loader = new DllLoader(file.FullName);
                            Lama.inGamePlugins.AddRange(loader.getAllInstances<InGamePlugin>());
                            Lama.homeComponentPlugins.AddRange(loader.getAllInstances<HomeComponent>());
                            Lama.tabPlugins.AddRange(loader.getAllInstances<TabPlugin>());
                        }
                        catch (Exception er)
                        {
                            // Lama.log("ERROR", "[LoadPlugins][" + file.FullName + "]" + er.Message);
                        }
                    }
                }

            }
            catch (Exception e)
            {
                Lama.log("ERROR", "[LoadPlugins]" + e.Message);
            }
        }


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
                var cfg = Lama.mainConfig[0]["servers"].getChildsByAttribute("id", index.ToString())[0];
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
            {
                return;
            }
            int index = Lama.servers.getKeyFromValue(flatComboBox1.Text);
            XmlNode cfg = Lama.mainConfig[0].getChildsByAttribute("id", index.ToString())[0];

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
