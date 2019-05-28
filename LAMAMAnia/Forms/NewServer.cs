using NTK.IO.Xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAMAMAnia
{
    /// <summary>
    /// NewServer Form
    /// </summary>
    public partial class NewServer : Form
    {
        private HomeLauncher hl;
        
        /// <summary>
        /// Init NewServer
        /// </summary>
        /// <param name="hl">The homeLauncher Form to reload</param>
        public NewServer(HomeLauncher hl)
        {
            InitializeComponent();
            this.hl = hl;
        }

        private void tog_remote_CheckedChanged(object sender)
        {
            tb_ip.Enabled = tog_remote.Checked;
            tb_port.Enabled = tog_remote.Checked;
            tb_login.Enabled = tog_remote.Checked;
        }

        private void b_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void b_create_Click(object sender, EventArgs e)
        {
            if (tog_remote.Checked)
            {
                var index = Lama.mainConfig[0]["servers"].count();
                var configPath = @"Config\Servers\" + index + ".xml";
                //MakeConfig------------------------------------------------------------------
                var config = new XmlDocument(configPath);
                var root = config.addNode("server_config");

                root.addChild("matchSettings");
                root.addChild("remote").addAttribute("value", "true")
                                       .addChild("ip", tb_ip.Text);

                root["remote"].addChild("port", tb_port.Text);
                root["remote"].addChild("login", tb_login.Text);

                root.addChild("plugins");
                config.save();

                //Actualize main Config
                Lama.mainConfig[0]["servers"].addChild("server")
                                             .addAttribute("id", index.ToString())
                                             .Value = tb_name.Text;

                Lama.mainConfig.save();
                Lama.mainConfig = new XmlDocument(@"Config\Main.xml");
                this.hl.load();
                this.Close();
            }
            else
            {
                ConfigServ cs = new ConfigServ(tb_name.Text);
                cs.Show();
                this.Close();
            }
        }
    }
}
