using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LamaPlugin;
using TMXmlRpcLib;
using NTK.Database;
using NTK.IO.Xml;
using System.Data;

namespace CupRegisterPlugin
{
    public class CupRegisterPlugin : BasePlugin
    {
        private NTKDatabase db;

        public CupRegisterPlugin()
        {
            this.Author = "KilianBT";
            this.Name = "CupRegister";
            this.Version = "0.1";

            this.Requirements.Add(new Requirement(RequirementType.FILE, "CupRegister.xml"));
            this.Requirements.Add(new Requirement(RequirementType.DATABASE, "dbconfig.xml")); //You can set the dbconfig path or set blank to load default dbconfig file
            this.Requirements.Add(new Requirement(RequirementType.STATE, "Version>=3.3.0"));
        }

        public override bool onLoad(LamaConfig lamaConfig)
        {
            //Get file with Requirement:
            var config = lamaConfig.configFiles["CupRegister.xml"];
            var db = config[0]["database"];
            this.db = NTKDatabase.getInstance();
            if(this.db == null)
            {
                log("ERROR", "[" + Name + "]Database not instanced");
            }


            int maxPlayers = int.Parse(lamaConfig.configFiles["Main"][0]["MaxPlayers"].Value);
            asyncRequest("GetPlayerList", new object[] { maxPlayers, 1 });

            //If db == null : no-execute plugin
            return (db != null);
        }

        public override void onGbxAsyncResult(GbxCall res)
        {
            switch (this.handles[res.Handle])
            {
                case "GetPlayerList":
                    break;
            }
        }

        public override void onGbxCallBack(object sender, GbxCallbackEventArgs args)
        {
            switch (args.Response.MethodName)
            {
                case "":
                    break;
            }
        }

        /// <summary>
        /// Get the struc of db
        /// </summary>
        /// <returns></returns>
        DBStruct getDbs()
        {
            DBStruct dbs = new DBStruct("cupregister", "MyIsam");

            DBSTable cup = dbs.addTable("cup");
            cup.Columns.Add(new DBSColumn("id", DBSType.INT, 27, true, DBSIndex.INDEX, true));
            cup.Columns.Add(new DBSColumn("name", DBSType.VARCHAR, 25, false, true));
            cup.Columns.Add(new DBSColumn("date", DBSType.DATE, 25, false, true));
            cup.Columns.Add(new DBSColumn("type", DBSType.INT, 25, false, true));

            DBSTable type = dbs.addTable("type");
            type.Columns.Add(new DBSColumn("id", DBSType.INT, 27, true, DBSIndex.INDEX, true));
            type.Columns.Add(new DBSColumn("name", DBSType.VARCHAR, 25, false, true));
            

            DBSTable particip = dbs.addTable("particip");
            particip.Columns.Add(new DBSColumn("idparticip", DBSType.INT, 27, true, DBSIndex.INDEX, true));
            particip.Columns.Add(new DBSColumn("idplayer", DBSType.INT, 27, true, DBSIndex.INDEX, true));

            DBSTable player = dbs.addTable("player");
            particip.Columns.Add(new DBSColumn("id", DBSType.INT, 27, true, DBSIndex.INDEX, true));
            particip.Columns.Add(new DBSColumn("login", DBSType.VARCHAR, 50, false, true));
            particip.Columns.Add(new DBSColumn("name", DBSType.VARCHAR, 100, false, true));
            


            return dbs;
        }
      
        string makeXml(int Uid)
        {
            Dictionary<int, int> particip = new Dictionary<int, int>();
            XmlDocument xmld = new XmlDocument();
            var root = xmld.addNode("manialink").addAttribute("version", "3");

            

            var msr = new QueryResult(db.select("SELECT * FROM participation WHERE Uid = '" + Uid + "'"));
            while (msr.read())
            {
                particip.Add(msr.getInt("CupID"), msr.getInt("Particips"));
            }


            msr = new QueryResult(db.select("SELECT * FROM cups"));
            var frame = root.addChild("frame").addAttribute("pos", "10 10");
            while (msr.read())
            {
                var cup = frame.addChild("quad").addAttribute("size", "10 10")
                                                .addAttribute("bgcolor", "F00A");
                cup.addChild("label", "");                              
            }

            return xmld.print();
        }

        object getData(IDataReader dr, string name)
        {
            object ret = null;
            int cpt = 0;
            while(cpt < dr.FieldCount && ret == null)
            {
                if (dr.GetName(cpt).Equals(name))
                {
                    ret = dr.GetValue(cpt);
                }
                cpt++;
            }
            return ret;
        }

    }
}
