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
using TMXmlRpcLib;

using static LamaPlugin.GBXMethods;
using static LamaMania.StaticMethods;
using System.Collections;

namespace LamaMania.HomeComponents
{
    public partial class HCPlayerList : HomeComponentPlugin
    {
        /// <summary>
        /// 
        /// </summary>
        public HCPlayerList()
        {
            InitializeComponent();
            addMouseEvents(this.gb_players);

            this.Author = "Kilian";
            this.PluginName = "HomeComponent - Player List";
            this.PluginFolder = "[NONE]";

            this.NeedXmlRpcConnection = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cfg"></param>
        public override void onLoad(LamaConfig cfg)
        {
            try
            {
                List<Player> players = (List<Player>)base.GetLamaProperty(LamaProperty.PLAYERS);
                foreach (Player p in players)
                {
                    this.l_users.Items.Add(p.NickName);
                }


                base.onLoad(cfg);
            }
            catch (Exception e)
            {

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="res"></param>
        protected override void onGbxAsyncResult(GbxCall res)
        {
            if (!res.Error)
            {
                if (GBXMethods.commonHandles.ContainsKey(res.Handle))
                {
                    switch (GBXMethods.commonHandles[res.Handle])
                    {
                        case GetPlayerList:
                            ArrayList userList = (ArrayList)res.Params[0];
                            clearList(l_users);
                            Lama.nbPlayers = userList.Count;
                            //s setLabel(l_players, "Players : " + Lama.nbPlayers + "/" + Lama.maxPlayers);
                            foreach (Hashtable user in userList)
                            {
                                appendList(l_users, ManiaColors.getText((string)user["NickName"]));
                            }
                            break;

                    }
                }


            }
            else
            {
                Log("ERROR", "[" + PluginName + "]>" + res.ErrorCode + " : " + res.ErrorString);
            }




        }

    }
}
