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
    public partial class HCServerInfos : HomeComponentPlugin
    {
        /// <summary>
        /// 
        /// </summary>
        public HCServerInfos()
        {
            InitializeComponent();
            addMouseEvents(this.gb_serverInfos);

            // Plugin Infos
            base.Author = "Kilian";
            base.PluginName = "HomeComponent - ServerInfos";
            base.PluginFolder = "[NONE]";

            base.NeedXmlRpcConnection = true;

            this.l_serverDescritpion.initName("Description : ");
            this.l_serverName.initName("Name : ");
            this.l_serverTitle.initName("Title : ");
            this.l_version.initName("Version : ");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cfg"></param>
        public override void onLoad(LamaConfig cfg)
        {
            asyncRequest(GetVersion, res => {
                setLabel(l_version, (string)res.getHashTable()["Version"]);
                setLabel(l_serverTitle, (string)res.getHashTable()["TitleId"]);
            });

            asyncRequest(GetServerOptions, res => {
                Hashtable ht = res.getHashTable();
                setLabel(l_serverName, ManiaColors.getText((string)ht["Name"]));
                setLabel(l_serverDescritpion, ManiaColors.getText((string)ht["Comment"]));
            });
        }
        /// <summary>
        /// 
        /// </summary>
        public override void onPluginUpdate()
        {
            asyncRequest(GetVersion, res => {
                setLabel(l_version, (string)res.getHashTable()["Version"]);
                setLabel(l_serverTitle, (string)res.getHashTable()["TitleId"]);
            });

            asyncRequest(GetServerOptions, res => {
                Hashtable ht = res.getHashTable();
                setLabel(l_serverName, ManiaColors.getText((string)ht["Name"]));
                setLabel(l_serverDescritpion, ManiaColors.getText((string)ht["Comment"]));
            });
            base.onPluginUpdate();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="res"></param>
        protected override void onGbxAsyncResult(GbxCall res)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="res"></param>
        public override void onGbxCallBack(GbxCallbackEventArgs res)
        {

        }



    }
}
