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

        public HomeLauncher()
        {
            InitializeComponent();

            loadPlugins();

            Config.mainConfig = new XmlDocument(@"Config\Main.xml");
            var root = Config.mainConfig.getNode(0);
            while (root.read())
            {
                var node = root.getNode();
                switch (node.getName())
                {
                    case "startMode":

                        break;

                    case "lang":
                        switch (node.getValue())
                        {
                            case "FR":
                                break;

                            case "EN":
                                Config.lang = new BaseEN();
                                break;
                            default:
                                //TODO: Manage dll
                                break;
                        }

                        if (Config.lang != null)
                            loadLang();
                        
                        break;

                    case "servers":
                        foreach(XmlNode n in node.getChildList())
                        {
                            Config.servers.Add(n.getAttibuteV("id"), n.getValue());
                            flatComboBox1.Items.Add(n.getValue());
                        }
                        break;
                }
            }

        }
        //New
        private void flatButton4_Click(object sender, EventArgs e)
        {
            var conf = new ConfigServ();
            conf.Show();
        }
        //Edit
        private void flatButton2_Click(object sender, EventArgs e)
        {
            string index = flatComboBox1.SelectedIndex.ToString();
            
            var conf = new ConfigServ(index);
            conf.Show();
        }
        //Start
        private void flatButton1_Click(object sender, EventArgs e)
        {
            string path = @"Servers\" + flatComboBox1.SelectedIndex + @"\ManiaPlanetServer.exe";
            string cmd = "/Title=TMStadium /dedicated_cfg=dedicated_cfg.txt /game_settings=MatchSettings/MatchSetting_kamphare_2019_04_01_15_44.txt";
            if (Config.invisibleServer)
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
             //   System.Diagnostics.Process.Start(path, cmd);
            }
            
            Config.launched = true;
            var config = new XmlDocument(@"Servers\" + flatComboBox1.SelectedIndex + @"\UserData\Config\dedicated_cfg.txt");
            try
            {
                var mainForm = new Main(config);
                mainForm.Show();
            }
            catch (Exception)
            {

            }
        }

        void loadLang()
        {
            this.formSkin1.Text = Config.lang.getHLTitle();
            this.flatButton1.Text = Config.lang.getHLStart();
            this.flatButton2.Text = Config.lang.getHLEdit();
            this.flatButton3.Text = Config.lang.getHLRemove();

        }

        void loadPlugins()
        {
            try
            {
                DllLoader loader = new DllLoader(@"Plugins\");
                Config.plugins = loader.getAllInstances<BasePlugin>();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

    }
}
