using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LamaPlugin
{
    public abstract class TabPlugin : BasePlugin
    {
        public abstract Control getTab();

        public bool IsConfigServPlugin { protected set; get; }

    }
}
