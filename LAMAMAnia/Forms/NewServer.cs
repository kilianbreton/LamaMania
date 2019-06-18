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

namespace LamaMania
{
    /// <summary>
    /// NewServer Form
    /// </summary>
    public partial class NewServer : Form
    {
        private HomeLauncher hl;
        private XmlNode cfg;

        /// <summary>
        /// New Server
        /// </summary>
        /// <param name="hl">The homeLauncher Form to reload</param>
        public NewServer(HomeLauncher hl)
        {
            InitializeComponent();
            this.hl = hl;
            formSkin1.Text = "New Server";
        }

        /// <summary>
        /// Edit remote server
        /// </summary>
        /// <param name="hl"></param>
        /// <param name="cfg"></param>
        public NewServer(HomeLauncher hl, XmlNode cfg)
        {
            InitializeComponent();
            formSkin1.Text = "Edit server";
            this.hl = hl;
            this.cfg = cfg;
            tb_name.Text = cfg["name"].Value;
            tb_ip.Text = cfg["remote"]["ip"].Value;
            tb_port.Text = cfg["remote"]["port"].Value;
            tb_login.Text = cfg["remote"]["login"].Value;
            b_create.Text = "Save";
            tog_remote.Checked = true;
            tog_remote.Enabled = false;
            tb_name.Enabled = true;
            tb_ip.Enabled = true;
            tb_port.Enabled = true;
            tb_login.Enabled = true;
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
            if (cfg == null) //Creation mode
            {
                if (tog_remote.Checked)
                {
                    var index = Lama.mainConfig[0]["servers"].count();
                    var configPath = @"Config\Servers\" + index + ".xml";
                    //MakeConfig------------------------------------------------------------------
                    //Actualize main Config
                    var root = Lama.mainConfig[0]["servers"].addChild("server")
                                                 .addAttribute("id", index.ToString());
                    root.addChild("name", tb_name.Text);
                    root.addChild("internetServer", "true");
                    root.addChild("matchSettings");
                    root.addChild("remote").addAttribute("value", "true")
                                           .addChild("ip", tb_ip.Text);

                    root["remote"].addChild("port", tb_port.Text);
                    root["remote"].addChild("login", tb_login.Text);

                    root.addChild("plugins");
                    Lama.mainConfig.save();

                    this.hl.load();
                    this.Close();
                }
                else
                {
                    ConfigServ cs = new ConfigServ(tb_name.Text);
                    cs.Show();
                    this.hl.load();
                    this.Close();
                }
            }
            else //Remote Edit mode
            {
                cfg["name"].Value = tb_name.Text;
                cfg["remote"]["ip"].Value = tb_ip.Text;
                cfg["remote"]["port"].Value = tb_port.Text;
                cfg["remote"]["login"].Value = tb_login.Text;
                Lama.mainConfig.save();
                hl.load();
                this.Close();
            }
        }
    }
}
