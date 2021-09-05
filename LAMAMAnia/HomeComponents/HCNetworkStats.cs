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

namespace LamaMania.HomeComponents
{
    /// <summary>
    /// 
    /// </summary>
    public partial class HCNetworkStats : HomeComponentPlugin
    {
        private Timer netStatsTimer;
        /// <summary>
        /// 
        /// </summary>
        public HCNetworkStats()
        {
            InitializeComponent();
            addMouseEvents(this.gb_netStats);

            this.Author = "Kilian";
            this.PluginName = "HomeComponent - Network Stats";
            this.PluginFolder = "[NONE]";

            this.NeedXmlRpcConnection = true;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="cfg"></param>
        public override void onLoad(LamaConfig cfg)
        {
            //Network infos
            this.netStatsTimer = new Timer();
            this.netStatsTimer.Tick += new EventHandler(netStatsTimer_Tick);
            this.netStatsTimer.Interval = 1500;
            this.netStatsTimer.Start();
        }
      
        /// <summary>
        /// 
        /// </summary>
        public override void onDisconnect()
        {
            this.netStatsTimer.Stop();
            base.onDisconnect();
        }





        void netStatsTimer_Tick(object sender, EventArgs a)
        {
            asyncRequest(GetNetworkStats, res => {
                var ht = res.getHashTable();
                setLabel(this.l_upTime, "UpTime : " + ht["UpTime"]);
                setLabel(this.l_nbConn, "Nb Connections : " + ht["NbrConnection"]);
                setLabel(this.l_upTime, "Connection Time Average : " + ht["MeanConnectionTime"]);
                setLabel(this.l_upTime, "Recive Net Rate : " + ht["RecvNetRate"]);
                setLabel(this.l_upTime, "Send Net Rate : " + ht["SendNetRate"]);
            });
        }

        private void Gb_netStats_Click(object sender, EventArgs e)
        {

        }
    }
}
