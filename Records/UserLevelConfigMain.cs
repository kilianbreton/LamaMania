using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LamaPlugin;
using NTK.IO.Xml;

namespace BasicsCommandsPlugin
{
    public partial class UserLevelConfigMain : TabPlugin
    {

        private XmlDocument config;


        public UserLevelConfigMain()
        {
            InitializeComponent();

            base.PluginName = "UserLevelsConfigMain";
            base.PluginFolder = "[NONE]";
            base.Author = "KBT";
            base.Version = "0.1";

            base.Requirements = new List<Requirement>();
            base.Requirements.Add(new Requirement(RequirementContext.LOCAL));
            base.Requirements.Add(new Requirement(RequirementType.FILE, "levels.xml"));

            
        }

        public override bool onLoad(LamaConfig cfg)
        {
            if (cfg.configFiles.ContainsKey("levels.xml"))
            {
                this.config = cfg.configFiles["levels.xml"];

                foreach(XmlNode n in this.config[0]["masterAdmins"].Childs)
                {
                    if (!n.Value.Trim().Equals(""))
                    {
                        l_superAdmin.Items.Add(n.Value);
                    }
                }

                foreach (XmlNode n in this.config[0]["admins"].Childs)
                {
                    if (!n.Value.Trim().Equals(""))
                    {
                        l_admins.Items.Add(n.Value);
                    }
                }
                
                foreach (XmlNode n in this.config[0]["moderators"].Childs)
                {
                    if (!n.Value.Trim().Equals(""))
                    {
                        l_moderators.Items.Add(n.Value);
                    }
                }


                return true;
            }

            return false;
        }

        private void b_addSuperAdmin_Click(object sender, EventArgs e)
        {
            l_superAdmin.Items.Add(tb_superAdmin.Text);
        }

        private void b_addAdmin_Click(object sender, EventArgs e)
        {
            l_admins.Items.Add(tb_admins.Text);
        }

        private void b_addModerator_Click(object sender, EventArgs e)
        {
            l_moderators.Items.Add(tb_moderators.Text);
        }

        private void UserLevelConfigMain_Load(object sender, EventArgs e)
        {

        }

        private void b_save_Click(object sender, EventArgs e)
        {
            this.config[0].Childs.Clear();

            XmlNode master = this.config.addNode("masterAdmins");
            foreach(string s in l_superAdmin.Items)
            {
                master.addChild("player", s);
            }
            
            XmlNode admin = this.config.addNode("admins");
            foreach (string s in l_admins.Items)
            {
                admin.addChild("player", s);
            }


            XmlNode moderator = this.config.addNode("moderators");
            foreach (string s in l_moderators.Items)
            {
                moderator.addChild("player", s);
            }


            this.config.save(false);
            sendInterPluginCall("UserLevels", "ReadConfig", new Dictionary<string, object>());            
        }
    }
}
