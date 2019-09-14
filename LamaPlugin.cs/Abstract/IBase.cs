using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LamaPlugin
{
    public interface IBase
    {
        string Author { get; set; }
        string PluginName { get; set; }
        string Version { get; set; }
        string PluginFolder { get; set; }

        PluginType PluginType { get; set; }

        List<Requirement> Requirements { get; set; }

        OnError OnError { get; set; }
        Logger Log { get; set; }
    }
}
