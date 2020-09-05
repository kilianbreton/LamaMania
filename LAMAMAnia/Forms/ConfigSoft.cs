using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LamaMania.UserConstrols;
using NTK.IO.Xml;

namespace LamaMania
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ConfigSoft : Form
    {

        private XmlDocument config;

        /// <summary>
        /// 
        /// </summary>
        public ConfigSoft()
        {
            InitializeComponent();

            this.config = Program.lama.mainConfig;
            XmlNode exTools = config[0]["externalTools"];

            foreach(XmlNode n in exTools)
            {
                ExternalTool et = new ExternalTool(n.getAttibuteV("path"),n.getAttibuteV("alias"));
                et.Remove += onRemoveETool;
                this.flowLayoutPanel1.Controls.Add(et);
            }





        }

        private void B_exTool_add_Click(object sender, EventArgs e)
        {
            ExternalTool et = new ExternalTool();
            et.Remove += onRemoveETool;

            this.flowLayoutPanel1.Controls.Add(et);
        }


        void onRemoveETool(object tool)
        {
            ExternalTool et = (ExternalTool)tool;

            this.flowLayoutPanel1.Controls.Remove(et);
        }

        private void B_save_Click(object sender, EventArgs e)
        {

            XmlNode ets = config[0]["externalTools"];
            ets.deleteAllChildLike("externalTool");

            foreach(Control c in this.flowLayoutPanel1.Controls)
            {
                ExternalTool et = (ExternalTool)c;
                XmlNode n = new XmlNode("externalTool")
                    .addAttribute("alias", et.Alias)
                    .addAttribute("path", et.Path);

                n.AutoClose = true;

                ets.addChild(n);
            }


            this.config.save(false);

        }
    }
}
