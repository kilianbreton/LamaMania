using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LamaPlugin
{
    public class TabPlugin : UserControl, ITab
    {
        PluginType type = PluginType.TabPlugin;

        public GetConfigValue getConfigValue { get; set; }
        public string Author { get; set; }
        public string Version { get; set; }
        public List<Requirement> Requirements { get; set; }
        public string PluginName { get; set; }
        public string PluginFolder { get; set; }

        public PluginType PluginType { get => type; set => type = value; }
        public OnError OnError { get; set; }
        public Logger Log { get; set; }
    }
}
