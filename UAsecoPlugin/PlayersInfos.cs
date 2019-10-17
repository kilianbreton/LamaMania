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
using NTK.Database;



namespace UAsecoPlugin
{
    public partial class PlayersInfos : HomeComponentPlugin
    {
        NTKDatabase db;
        XmlDocument config;

        string dbAdrs;
        string dbName;
        string dbLogin;
        string dbPass;


        public PlayersInfos()
        {
            InitializeComponent();
            addMouseEvents(this.flatGroupBox1);

            this.Author = "KilianBT";
            this.PluginName = "UAsecoPlayersInfos";
            this.Version = "1.0";

            this.Requirements.Add(new Requirement(RequirementType.FILE, "uaseco_main.xml"));
        }



        public override void onLoad(LamaConfig cfg)
        {
            if (cfg.configFiles.ContainsKey("uaseco_main.xml"))
            { 
                this.config = cfg.configFiles["uaseco_main.xml"];
                this.dbAdrs = this.config[0]["database"]["ip_adress"].Value;
                this.dbName = this.config[0]["database"]["name"].Value;
                this.dbLogin = this.config[0]["database"]["login"].Value;
                this.dbPass = this.config[0]["database"]["password"].Value;

                this.db = NTKD_MySql.getInstance(this.dbAdrs, this.dbLogin, this.dbPass, this.dbName);

                List<string> users = new List<string>();


                QueryResult r = new QueryResult(this.db.select("select * from uaseco_players"));
                while (r.read())
                {
                    users.Add(ManiaColors.getText(r.getString("Nickname")));
                    this.listBox1.Items.Add(ManiaColors.getText(r.getString("Nickname")));

                }
                

            }
            else
                throw new Exception("");



            base.onLoad(cfg);
        }





    }
}
