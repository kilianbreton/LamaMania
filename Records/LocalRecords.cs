using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMXmlRpcLib;
using NTK.IO.Xml;
using NTK.Database;
using LamaPlugin;
using System.Collections;
using static LamaPlugin.StaticM;
using System.Data;

namespace Records
{

    public class LocalRecords : InGamePlugin
    {
        private XmlDocument config;
        private NTKDatabase db;
        private List<Player> players = new List<Player>();
        private List<MapInfo> maps = new List<MapInfo>();
        private int currentMapId = 0;

        public LocalRecords()
        {
            this.Author = "KBT";
            this.PluginName = "LocalRecords";
            this.PluginFolder = "[NONE]";
            this.Version = "0.1";

            this.Requirements.Add(new Requirement(RequirementType.DATABASE, true));
            this.Requirements.Add(new Requirement(RequirementContext.LOCAL));
        }



        public override bool onLoad(LamaConfig lamaConfig)
        {

            if (lamaConfig.dbConnected && lamaConfig.db != null)
            {
                try
                {
                    this.maps = lamaConfig.maps;
                    this.players = lamaConfig.players;
                    this.currentMapId = lamaConfig.currentMapId;
                    this.db = lamaConfig.db;
               
                    List<string> users = new List<string>();

                 //   players = new List<Player>();
                   // maps = new List<MapInfo>();
                    //Get Map List--------------------------------------------------------------------------
                    asyncRequest(res =>
                    {
                        ArrayList lst = res.getArrayList();
                        foreach (Hashtable map in lst)
                        {
                            this.maps.Add(new MapInfo((string)map["Uid"], (string)map["Name"], "", (string)map["Author"], (string)map["Environnement"]));
                        }

                    }, GBXMethods.GetMapList, 9999, 0);

                    //Get Player List-----------------------------------------------------------------------
                    asyncRequest(getPlayerList, GBXMethods.GetPlayerList, 999, 0);

                    //Init CallBacks-----------------------------------------------------------------------
                    Callbacks.Add("TrackMania.PlayerCheckpoint", callBack_PlayerCheckpoint);
                    Callbacks.Add("TrackMania.PlayerFinish", callBack_PlayerFinish);

                    Callbacks.Add("ManiaPlanet.PlayerConnect", (o,e) => { asyncRequest(getPlayerList, GBXMethods.GetPlayerList, 999, 0); });
                    Callbacks.Add("TrackMania.PlayerConnect", (o,e) => { asyncRequest(getPlayerList, GBXMethods.GetPlayerList, 999, 0); });

                   
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
      
        public override void onDisconnect()
        {

        }

   

        private void callBack_PlayerCheckpoint(object sender, GbxCallbackEventArgs args)
        {
            ArrayList param = args.Response.Params;
            int checkPointIndex = (int)param[4];
            int uid = (int)param[0];
            int timeOrScore = (int)param[2];

            if (isPlayerExist(uid))
            {
                Player p = getPlayer(uid);
                if (p.Live_checkPoints == null)
                    p.Live_checkPoints = new List<int>();

                if (p.Live_checkPoints.Count == checkPointIndex)
                {
                    p.Live_checkPoints.Add(timeOrScore);
                }
            }
        }

        private void callBack_PlayerFinish(object o, GbxCallbackEventArgs args)
        {
            ArrayList param = args.Response.Params;
            int uid = (int)param[0];
            int timeOrScore = (int)param[2];

            if (isPlayerExist(uid))
            {
                Player p = getPlayer(uid);
                if (p.Live_checkPoints == null)
                    p.Live_checkPoints = new List<int>();
                //    if ((p.Live_checkPoints.Count == maps[currentMapId].NbCheckpoints && p.Live_checkPoints.Count != 0))
                if(timeOrScore != 0)
                {
                    p.Live_checkPoints.Add(timeOrScore);
                    saveRecord(p);
                    asyncRequest(checkError, GBXMethods.ChatSendServerMessageToId, "$o$0f0New record : " + timeOrScore, p.PlayerId);
                }
            }
        }


        private void getPlayerList(GbxCall res)
        {
            this.players.Clear();
            ArrayList lst = res.getArrayList();
            //Login, NickName, PlayerId, TeamId, SpectatorStatus, LadderRanking, and Flags.
            foreach (Hashtable player in lst)
            {
                Player p = new Player((string)player["Login"], (string)player["NickName"], (int)player["PlayerId"]);
                this.players.Add(p);
                // asyncRequest(checkError, GBXMethods.SendDisplayManialinkPageToId, p.PlayerId1, makeManialink(p), 0, false);

                asyncRequest(checkError, GBXMethods.SendDisplayManialinkPage, makeManialink(p), 0, false);
                Log("NOTICE", "[LocalRecords] Send manialink");
            }
        }


        /*#################################################################################################
         # Private DB Methods #############################################################################
         ##################################################################################################*/

        bool saveRecord(Player player)
        {
            int playerId = checkPlayerDb(player);
            if (playerId != -1)
            {
                string cps = "";
                foreach (int cp in player.Live_checkPoints)
                {
                    cps += cp + ", ";
                }
                string query = "INSERT INTO records VALUES (" + currentMapId + ", " + playerId + ", '" + cps + "')";
                //  db.insert("UPDATE SET mapid =" + currentMapId + " , playerid = " + player.PlayerId1 + ", checkpoints = '" + cps + "'");
                db.insert(query);

                player.Live_checkPoints.Clear();
                return true;
            }
            else
            {
                return false;
            }
        }

        string makeManialink(Player player)
        {
            int playerId = checkPlayerDb(player);
            
            QueryResult r = new QueryResult(db.select("SELECT * FROM `records` WHERE playerId = " + playerId));
            List<string> records = new List<string>();
            while (r.read())
            {
                string[] checkpoints = r.getString("checkpoints").Trim().Split(',');
                int time = int.Parse(checkpoints[checkpoints.Length-2]);
                parseTime(time, out int h, out int m, out int s);
                records.Add(h + ":" + m + ":" + s);
            }


            ManialinkFile mlf = new ManialinkFile(false);
            mlf.Nodes.Add(new MLFrame(80, 10, 1));
            mlf.Nodes[0].Childs.Add(new MLQuad(0, 0, 2, 50, 50, "F00A"));

            int y = -10;
            foreach (string s in records)
            {
                mlf.Nodes[0].Childs.Add(new MLLabel(s, 80, y, 3));
                y -= 10;
            }


            return mlf.getXmlText();
        }


        int checkPlayerDb(Player player)
        {
            IDataReader idr = db.select("SELECT id FROM players WHERE login=`" + player.Login + "`");
            if (idr != null)
            {
                QueryResult r = new QueryResult(idr);
                if (r.read())   //Si il y a un résultat
                {
                    return r.getInt("id");
                }
                else
                {
                    db.insert("INSERT INTO players VALUES (`" + player.Login + "`, `" + player.NickName + "`)");
                    QueryResult r2 = new QueryResult(db.select("SELECT id FROM players WHERE login=`" + player.Login + "`"));
                    if (r2.read())   //Si il y a un résultat
                    {
                        return r2.getInt("id");
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            else
            {
                return -1;
            }
        }


        /*#################################################################################################
          # Private Search Methods ########################################################################
          #################################################################################################*/


     

        bool isPlayerExist(int uid)
        {
            int cpt = 0;
            while (cpt < players.Count && players[cpt].PlayerId != uid) { cpt++; }
            return (cpt < players.Count && players[cpt].PlayerId == uid);
        }
        bool isPlayerExist(string nickName)
        {
            int cpt = 0;
            while (cpt < players.Count && players[cpt].NickName != nickName) { cpt++; }
            return (cpt < players.Count && players[cpt].NickName == nickName);
        }

        Player getPlayer(int uid)
        {
            int cpt = 0;
            while (cpt < players.Count && players[cpt].PlayerId != uid) { cpt++; }
            if (cpt < players.Count && players[cpt].PlayerId == uid)
                return players[cpt];
            else
                return null;

        }

        public override void onGbxCallBack(object sender, GbxCallbackEventArgs args)
        {
            throw new NotImplementedException();
        }

        public override void onGbxAsyncResult(GbxCall res)
        {
            throw new NotImplementedException();
        }
    }
}
