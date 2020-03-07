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




        public PlayersInfos()
        {
            InitializeComponent();
            addMouseEvents(this.flatGroupBox1);

            this.Author = "KBT";
            this.PluginName = "UAsecoPlayersInfos";
            this.Version = "1.0";

            this.Requirements.Add(new Requirement(RequirementType.FILE, "uaseco_main.xml"));
            this.Requirements.Add(new Requirement(RequirementContext.LOCAL));
        }



        public override void onLoad(LamaConfig cfg)
        {
         //   throw new Exception();
            if (cfg.configFiles.ContainsKey("uaseco_main.xml") && cfg.dbConnected && cfg.db != null)
            { 
                this.config = cfg.configFiles["uaseco_main.xml"];


                this.db = cfg.db;

                List<string> users = new List<string>();


         /*       QueryResult r = new QueryResult(this.db.select("select * from uaseco_players"));
                while (r.read())
                {
                    users.Add(ManiaColors.getText(r.getString("Nickname")));
                    this.listBox1.Items.Add(ManiaColors.getText(r.getString("Nickname")));

                }*/

                //InterPlugin call
                InterPluginResponse response = sendInterPluginCall("UserLevels", "GetAll", null);

                foreach (string s in (List<string>)response.Param["All"])
                {
                    this.listBox1.Items.Add(s);
                }
            }
            else
                throw new Exception("");



            base.onLoad(cfg);
        }





    }
}
