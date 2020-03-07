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
using static LamaMania.StaticMethods;
using static LamaPlugin.GBXMethods;
using FlatUITheme;
using System.Collections;
using System.Diagnostics;

namespace LamaMania.HomeComponents
{
    public partial class HCStatus : HomeComponentPlugin
    {
        /// <summary>
        /// 
        /// </summary>
        public HCStatus()
        {
            InitializeComponent();
            addMouseEvents(this.gb_status);

            //Plugin Infos
            base.Author = "Kilian";
            base.PluginName = "HomeComponent - Status";
            base.PluginFolder = "[NONE]";

            base.NeedXmlRpcConnection = false;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cfg"></param>
        public override void onLoad(LamaConfig cfg)
        {
            if (cfg.connected)
            {
                if (cfg.connected)
                {
                    //Infos
                    asyncRequest(GetStatus, res =>
                    {
                        Hashtable ht = res.getHashTable();
                        setLabel(this.l_server, "Status : " + (string)ht["Name"]);
                    });
                }

                this.b_serverStarted.Enabled = false;
                this.b_serverStarted.BaseColor = Color.Gray;

                this.b_xmlrpcConnect.Enabled = false;
                this.b_xmlrpcConnect.BaseColor = Color.Gray;

                this.b_uasecoStop.Enabled = false;
                this.b_uasecoStop.BaseColor = Color.Gray;

                this.b_usaecoStart.Enabled = false;
                this.b_usaecoStart.BaseColor = Color.Gray;

            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override void onDisconnect()
        {
            FlatButton but = (FlatButton)getControl(this.b_xmlrpcConnect);
            but.BaseColor = Color.Green;
            enableControl(but, true);
            but.Enabled = true;
            but = (FlatButton)getControl(this.b_serverStarted);
            but.BaseColor = Color.Green;
            enableControl(but, true);
          
        }

        /// <summary>
        /// Global async results out
        /// </summary>
        /// <param name="res"></param>
        protected override void onGbxAsyncResult(GbxCall res)
        {
            if (this.handles.ContainsKey(res.Handle) && !res.Error)
            {
                switch (this.handles[res.Handle])
                {
                    //Catch asyncResults
                }
            }
            else if (res.Error)
            {
                Log("ERROR", res.ErrorCode + " : " + res.ErrorString);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="res"></param>
        public override void onGbxCallBack(GbxCallbackEventArgs res)
        {
            switch (res.Response.MethodName)
            {
                case "TrackMania.StatusChanged":
                    int statusCode = (int)res.Response.Params[0];
                    setLabel(this.l_server, "Status : " + getStatus(statusCode));
                    break;
            }
        }

        private void B_serverStop_Click(object sender, EventArgs e)
        {
            if (Lama.remote)
            {

            }
            else
            {
                Process[] ps = Process.GetProcessesByName("ManiaPlanetServer");
                foreach (Process p in ps)
                {
                    if (p.MainWindowTitle.Contains(Lama.serverPath + Lama.serverIndex))
                        p.Kill();
                }

            }
        }
    }
}
