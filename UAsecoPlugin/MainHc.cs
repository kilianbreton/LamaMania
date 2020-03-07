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

namespace UAsecoPlugin
{
    public partial class MainHc : HomeComponentPlugin
    {
        public MainHc()
        {
            InitializeComponent();
            this.Author = "Kilian";
            this.PluginName = "MainHCTest";
            this.Version = "0";
     //       this.Requirements.Add(new Requirement(RequirementType.PLUGIN, "TestPlugin"));
            
            //If a control ovveride HomeCompenent, use this to add Mouse Events
            addMouseEvents(this.flatGroupBox1);
           
        }
     
        protected override void onGbxAsyncResult(GbxCall res)
        {
            switch (res.MethodName)
            {
                case "ManiaPlanet.ServerStart":
                    
                    break;
            }
        }

        public override void onGbxCallBack(GbxCallbackEventArgs res)
        {
          
        }

       
    }
}
