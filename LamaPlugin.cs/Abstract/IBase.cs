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

        List<Requirement> Requirements { get; set; }
    }
}
