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

namespace ManiaExchange
{
    public partial class TabManiaExchange : TabPlugin
    {
        private ManiaExchange mx;
        public TabManiaExchange()
        {
            InitializeComponent();
            this.PluginName = "TabManiaExchange";
            this.PluginDescription = "Manage MX maps";
            this.Version = "0.1";
            this.ConfigServPlugin = true;
            
        }

        public override bool onLoad(LamaConfig cfg)
        {
            try
            {
                this.mx = new ManiaExchange(cfg.game, Log);
                this.mx.getMapList();

                return true;
            }
            catch(Exception e)
            {
                Log("ERROR", "[" + this.PluginName + "]>" + e.Message);
            }


            return false;
        }



    }
}
