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

                    Callbacks.AddListener(GBXCallBacks.ManiaPlanet_BeginMap, updateStatus);
                    Callbacks.AddListener(GBXCallBacks.ManiaPlanet_EndMap, updateStatus);
                    Callbacks.AddListener(GBXCallBacks.ManiaPlanet_EndMatch, updateStatus);
                    Callbacks.AddListener(GBXCallBacks.ManiaPlanet_BeginMatch, updateStatus);

                   


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



        public void updateStatus(object sender, GbxCallbackEventArgs args)
        {
            int statusCode = (int)args.Response.Params[0];
            setLabel(this.l_server, "Status : " + getStatus(statusCode));
        }

        /// <summary>
        /// Called when server disconnect
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

      

        private void B_serverStop_Click(object sender, EventArgs e)
        {
            if (Program.lama.remote)
            {
                asyncRequest(GBXMethods.StopServer, checkEror);
            }
            else
            {
                Process[] ps = Process.GetProcessesByName("ManiaPlanetServer");
                foreach (Process p in ps)
                {
                    if (p.MainWindowTitle.Contains(Program.lama.serverPath + Program.lama.serverIndex))
                        p.Kill();
                }
            }
        }

        private void checkEror(GbxCall res)
        {
            if(res.Error)
                Log("ERROR", res.ErrorString);
        }
    }
}
