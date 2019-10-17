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


namespace UAsecoPlugin
{
    public partial class MapRecords : HomeComponentPlugin
    {
        public MapRecords()
        {
            InitializeComponent();
         //   this.Requirements.Add(new Requirement(RequirementType.FILE, "uaseco_main.xml"));

            this.PluginName = "UAseco - Map Records";
            this.Version = "0.1";
            this.Author = "KBT";

            addMouseEvents(flatGroupBox1);
            label1.Text = "<span style='color: Green'>Fine</span><span style='color: Blue'>and</span><span style='color: Red'>you?</span>";

        }



        public override void onLoad(LamaConfig cfg)
        {


            base.onLoad(cfg);
        }
    }
}
