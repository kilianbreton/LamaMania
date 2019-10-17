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
        public HCServerInfos()
        {
            InitializeComponent();
            addMouseEvents(this.gb_serverInfos);

            // Plugin Infos
            base.Author = "Kilian";
            base.PluginName = "HomeComponent - ServerInfos";
            base.PluginFolder = "[NONE]";
        }

        public override void onLoad(LamaConfig cfg)
        {
            asyncRequest(GetVersion, res => {
                setLabel(l_version, "Version : " + (string)res.getHashTable()["Version"]);
            });

            asyncRequest(GetServerOptions, res => {
                Hashtable ht = res.getHashTable();
                setLabel(l_serverName, "Name : " + ManiaColors.getText((string)ht["Name"]));
                setLabel(l_serverDescritpion, "Description : " + ManiaColors.getText((string)ht["Comment"]));
            });
        }

        protected override void onGbxAsyncResult(GbxCall res)
        {

        }

        public override void onGbxCallBack(GbxCallbackEventArgs res)
        {

        }



    }
}
