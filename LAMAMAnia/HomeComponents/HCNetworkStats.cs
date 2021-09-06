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
            this.netStatsTimer.Interval = 2000;
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

                int time = int.Parse(ht["Uptime"].ToString());

                parseTime(time, out int h, out int m, out int s);
                string upTime = h.ToString() + ":" + m + ":" + s; 

                setLabel(this.l_upTime, "UpTime : " + upTime);
                setLabel(this.l_nbConn, "Nb Connections : " + ht["NbrConnection"].ToString());
                setLabel(this.l_conTimeAvg, "Connection Time Average : " + ht["MeanConnectionTime"].ToString());
                setLabel(this.l_recvRate, "Recive Net Rate : " + ht["RecvNetRate"].ToString());
                setLabel(this.l_sendRate, "Send Net Rate : " + ht["SendNetRate"].ToString());

              

            });
        }

        private void Gb_netStats_Click(object sender, EventArgs e)
        {

        }
    }
}
