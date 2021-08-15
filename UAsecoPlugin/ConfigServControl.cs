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
    public partial class ConfigServControl : TabPlugin
    {
        public ConfigServControl()
        {
            InitializeComponent();
            this.PluginName = "UAseco";
            this.Author = "Kilian";
            this.Version = "0.0.0.1";
            this.ConfigServPlugin = true;
            this.PluginKey = "224bf699148708f7897ea51930c798bc3b1519206b6edc67719285d59481b9b05b7798b96a70493f12ad7df0e005e9bf9377f14659fcf6a6b837cbafbcbb27240b67999594709d2633af3a00d6be1801c7102ae513ddbd634aeda06d84947b5cd73f7c583b2c3bd5799deec07423379c16ebba158e4c3d6dbaccd49a83ad9c9b";
        }

     
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show((string)getConfigValue(this, "Admin"));
        }
    }
}
