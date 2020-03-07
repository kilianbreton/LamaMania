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
using FlatUITheme;


namespace BasicsCommandsPlugin
{
    public partial class PluginList : HomeComponentPlugin
    {
        public PluginList()
        {
            InitializeComponent();
            addMouseEvents(this.flatGroupBox1);

            base.PluginName = "PluginList";
            base.Author = "KBT";
            base.Version = "0.1";

            base.Requirements.Add(new Requirement(RequirementContext.LOCAL));
        }

        public override void onLoad(LamaConfig cfg)
        {
            InterPluginResponse resp = sendInterPluginCall("PluginManager", "GetPluginList", null);
            TreeNode root = this.treeView1.Nodes.Add("Plugins");
            TreeNode inGame = root.Nodes.Add("InGame");
            TreeNode homeComp = root.Nodes.Add("HomeComponent");
            TreeNode tab = root.Nodes.Add("Tab");
           
            foreach (KeyValuePair<string,PluginType> kvp in (Dictionary<string,PluginType>)resp.Param["PluginList"])
            {
                switch (kvp.Value)
                {
                    case PluginType.Base:
                        break;
                    case PluginType.HomeComponent:
                        homeComp.Nodes.Add(kvp.Key);
                        break;
                    case PluginType.TabPlugin:
                        tab.Nodes.Add(kvp.Key);
                        break;
                    case PluginType.InGamePlugin:
                        inGame.Nodes.Add(kvp.Key);
                        break;
                }
            }

            base.onLoad(cfg);
        }



    }
}
