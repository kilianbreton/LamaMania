﻿using System;
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
        }

     
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show((string)this.getConfigValue(this, "Admin"));
        }
    }
}
