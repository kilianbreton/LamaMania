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
using NTK.IO;
using NTK.IO.Xml;
using RestSharp;
using static LamaMania.Program;
using LamaPlugin;
using System.IO;

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


            //Read config
            this.config = Program.lama.mainConfig;
            this.tb_cachePath.Text = this.config[0]["cachePath"].Value;
            this.tb_ressourcePath.Text = this.config[0]["ressourcesPath"].Value;
            this.tb_logPath.Text = this.config[0]["logPath"].Value;

            //Locales
            foreach(string str in lama.localesManager.availableLanguages())
            {
                cb_lang.Items.Add(str);
            }

            //External tools
            XmlNode exTools = config[0]["externalTools"];

            foreach(XmlNode n in exTools)
            {
                ExternalTool et = new ExternalTool(n.getAttibuteV("path"),n.getAttibuteV("alias"));
                et.Remove += onRemoveETool;
                this.flowLayoutPanel1.Controls.Add(et);
            }


            //Plugins treeView
            List<IBasePlugin> plugins = new List<IBasePlugin>();
            plugins.AddRange(lama.pluginManager.InGamePlugins);
            plugins.AddRange(lama.pluginManager.TabPlugins);
            plugins.AddRange(lama.pluginManager.HomeComponentPlugins);
            
            //dump
            foreach(IBasePlugin p in plugins)
            {
                rtb_pluginsDump.AppendText(p.ToStringExt());
                rtb_pluginsDump.AppendText("--------------\n");
            }

            foreach (DllLoader dll in lama.pluginManager.getLibs())
            {
                IEnumerable<IBasePlugin> lst = plugins.Where(p => p.LamaLibName == dll.getName());
                TreeNode r = tv_plugins.Nodes.Add(dll.getName());
                foreach(IBasePlugin p in lst)
                {
                    r.Nodes.Add(p.PluginName);
                }



            }






            //Call API
            RestClient client = new RestClient("http://lamamania.yoxclan.fr/Api");

            RestRequest request = new RestRequest("librarys.php", DataFormat.Json);

            IRestResponse response = client.Get(request);

            JsonArray pluginsList = (JsonArray)SimpleJson.DeserializeObject(response.Content);

            foreach(JsonObject obj in pluginsList)
            {
                if(obj.TryGetValue("name", out object pluginName))
                {
                  //  MessageBox.Show((string)pluginName);
                }
             
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

        private void tog_devmode_CheckedChanged(object sender)
        {
            if(tog_devmode.Checked)
            {
                MessageBox.Show("Attention le DevMode est un mode d'utilisation pour les développeurs et créateurs, il ne convient pas à une utilisation normale du programme", "WARNING", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
        }

        private void b_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void flatButton1_Click(object sender, EventArgs e)
        {
            lama.pluginManager.unloadLib("Records");

            /*DllLoader loader = new DllLoader(Path.GetDirectoryName(Application.ExecutablePath) + @"\Plugins\Records.dll");
            lama.pluginManager.loadLibPlugins(loader, "Records");*/
        }
    }
}
