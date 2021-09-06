using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq.Expressions;

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


                Callbacks.AddListener(GBXCallBacks.ManiaPlanet_PlayerConnect, (sender, args) =>
                {
                    string login = (string)args.getHashTable()["login"];
                });
                Callbacks.AddListener(GBXCallBacks.ManiaPlanet_PlayerDisconnect, (sender, args) =>
                {
                    string login = (string)args.getHashTable()["login"];
                    
                });

                base.onLoad(cfg);
            }
            catch (Exception e)
            {
                Log("ERROR", "[" + this.PluginName + "]>" +e.Message);
            }
        }
        

    }
}
