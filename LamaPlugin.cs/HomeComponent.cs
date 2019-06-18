using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace LamaPlugin
{
    public abstract class HomeComponent : BasePlugin
    {
        public abstract UserControl getControl();

        public abstract bool canLoad();

    }
}
