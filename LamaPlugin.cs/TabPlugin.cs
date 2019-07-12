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
        public GetConfigValue getConfigValue { get; set; }
        public string Author { get; set; }
        public string Version { get; set; }
        public List<Requirement> Requirements { get; set; }
        public string PluginName { get; set; }
    }
}
