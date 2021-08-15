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
            this.PluginKey = "22373843d50a7e68490b866e19d67dba4414e0eef49e1ccaba3f86a24bd841ac8fce0886a349fb57ada10003d15b573443391ddf803731ce9d8301e2b4b5ec19fca7975bd08651e058d6e283d23dfc10c3cc86b17a772a8b43f34847be27bd36d10eb97d849f0fb8d60ba99ce1e38cc9b64c4dd1d57e609317d491361095ccb4";

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
