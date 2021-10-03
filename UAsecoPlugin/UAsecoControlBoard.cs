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
using NTK.Database;
using NTK.IO.Xml;


namespace UAsecoPlugin
{
    public partial class UAsecoControlBoard : TabPlugin
    {
        private NTKDatabase db;
        private XmlDocument config;


        public UAsecoControlBoard()
        {
            InitializeComponent();

            this.Author = "KBT";
            this.PluginName = "UAsecoControlBoard";
            this.ConfigServPlugin = false;
           
            this.Requirements.Add(new Requirement(RequirementType.FILE, "uaseco_main.xml"));

        }


        public override bool onLoad(LamaConfig cfg)
        {
            if (cfg.configFiles.ContainsKey("uaseco_main.xml") && cfg.dbConnected && cfg.db != null)
            {
                this.config = cfg.configFiles["uaseco_main.xml"];

                this.db = cfg.db;

                QueryResult qr = new QueryResult(this.db.select("select * from uaseco_players"));
                while (qr.read())
                {
                    this.listBox1.Items.Add(qr.getString("Nickname"));
                }

            }

            return base.onLoad(cfg);
        }


    }
}
