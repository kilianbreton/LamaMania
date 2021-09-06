using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LamaPlugin
{
    public class InterPluginArgs
    {
        private int handle;
        private string callName;
        private Dictionary<string, object> args = new Dictionary<string, object>();


        public InterPluginArgs(int handle, string callName, Dictionary<string, object> args)
        {
            this.handle = handle;
            this.callName = callName;
            this.args = args;
        }

        public string CallName { get => callName; set => callName = value; }
        public Dictionary<string, object> Args { get => args; set => args = value; }
        public int Handle { get => handle; set => handle = value; }
    }
}
