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
using NTK.IO.Xml;
using NTK.IO;
using LamaLang;
using LamaPlugin;

namespace LAMAMAnia
{
    public partial class HomeLauncher : Form
    {
        /// <summary>
        /// Chargement du formulaire
        /// </summary>
        public HomeLauncher()
        {
            InitializeComponent();

            Lama.lamaLogger = new LamaLog(@"Logs\Lama.log");
            Lama.log("NOTICE", "Init");
            loadPlugins();
            load();
        }


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
                        foreach (XmlNode n in node.getChildList())
                        {
                            Lama.servers.Add(int.Parse(n.getAttibuteV("id")), n.Value);
                            flatComboBox1.Items.Add(n.Value);
                        }
                        break;
                }
            }

            if (Lama.startMode >= 0)
            {
                start(Lama.startMode);
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

                var conf = new ConfigServ(index);
                conf.Show();
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
            int index = Lama.getKeyFromValue(Lama.servers, flatComboBox1.SelectedText);
            string configPath = @"Config\Servers\" + index + ".xml";
            try
            {
                XmlDocument cfg = new XmlDocument(configPath);
                if (cfg[0]["remote"].getAttibuteV("value").ToUpper().Equals("FALSE"))
                {
                    Directory.Delete(@"Servers\" + index);
                }
                cfg = null;
            }
            catch (Exception er)
            {

            }
            try
            {
                File.Delete(configPath);
            }
            catch(Exception er)
            {

            }
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
                int index = Lama.getKeyFromValue(Lama.servers, flatComboBox1.SelectedText);
                start(index);
            }
            catch (Exception)
            {
                Lama.onError(this, "Error", "Undefined server : " + flatComboBox1.Text);
            }
        }

        void start(int index)
        {
            //  Lama.loadForm.Show();
            //Open Server config
            XmlDocument cfg = new XmlDocument(@"Config\Servers\" + index + ".xml");
            if (cfg[0]["remote"].getAttibuteV("value").ToUpper().Equals("TRUE"))
            {
                Lama.remoteAdrs = cfg[0]["remote"]["ip"].Value;
                Lama.remotePort = (int)cfg[0]["remote"]["port"].LValue;
                string login = cfg[0]["remote"]["login"].Value;
                var askLogs = new AskLogins(login);
                askLogs.Show();
            }
            else
            {

                string path = @"Servers\" + index + @"\ManiaPlanetServer.exe";
                string cmd = "/Title=TMStadium /lan /dedicated_cfg=dedicated_cfg.txt /game_settings=MatchSettings/MatchSetting_kamphare_2019_04_01_15_44.txt";
                if (Lama.invisibleServer)
                {
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo.FileName = path;
                    startInfo.Arguments = cmd;
                    process.StartInfo = startInfo;
                    process.Start();
                }
                else
                {
                    System.Diagnostics.Process.Start(path, cmd);
                }

                Lama.launched = true;
                var config = new XmlDocument(@"Servers\" + index + @"\UserData\Config\dedicated_cfg.txt");

                //Open main form
                try
                {
                    var mainForm = new Main(config);
                    mainForm.Show();
                }
                catch (Exception e)
                {
                    Lama.loadForm.Hide();
                    Lama.onException(this, e);

                }
            }
        }


        void loadLang()
        {
         
        }

        void loadPlugins()
        {
            try
            {
                DirectoryInfo pluginsDir = new DirectoryInfo(Path.GetDirectoryName(Application.ExecutablePath) + @"\Plugins\");
                foreach(FileInfo file in pluginsDir.GetFiles())
                {
                    if (file.Extension.Equals(".dll"))
                    {
                        try
                        {
                            DllLoader loader = new DllLoader(file.FullName);
                            Lama.plugins.AddRange(loader.getAllInstances<BasePlugin>());
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

    }
}
