using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LamaPlugin
{
    public class OverlayPlugin : UserControl, IBasePlugin
    {

        public OverlayPlugin()
        {

        }

        public virtual void onShow()
        {

        }

        public virtual void onUnload()
        {

        }

        public InterPluginResponse onInterPluginCall(IBasePlugin sender, InterPluginArgs args)
        {
            return null;
        }

        public void onPluginUpdate()
        {

        }

        public string aliasCall(string arg)
        {
            return "";
        }

        public string Author { get; set; }
        public string PluginName { get; set; }
        public string Version { get; set; }
        public string PluginFolder { get; set; }
        public PluginType PluginType { get; set; }
        public List<Requirement> Requirements { get; set; }
        public OnError OnError { get; set; }
        public Logger Log { get; set; }
        public string PluginDescription { get; set; }

        public string LamaLibName { get; set; }
    }
}
