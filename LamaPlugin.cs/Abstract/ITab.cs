using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LamaPlugin
{
    public delegate object GetConfigValue(ITab sender, string inputName);

    public interface ITab : IBase
    {
        GetConfigValue getConfigValue { get; set; }
    }
}
