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
        private PMInterPluginCall pmInterCall;

        public TabPlugin()
        {
            this.Requirements = new List<Requirement>();
        }

        public void setPluginManager(PMInterPluginCall pmipc)
        {
            this.pmInterCall = pmipc;
        }


        PluginType type = PluginType.TabPlugin;

        public bool ConfigServPlugin { get; set; }

        public GetConfigValue getConfigValue { get; set; }
        public string Author { get; set; }
        public string Version { get; set; }
        public List<Requirement> Requirements { get; set; }
        public string PluginName { get; set; }
        public string PluginFolder { get; set; }

        public PluginType PluginType { get => type; set => type = value; }
        public OnError OnError { get; set; }
        public Logger Log { get; set; }
        public string PluginDescription { get; set; }

        public InterPluginResponse onInterPluginCall(IBasePlugin sender, InterPluginArgs args)
        {
            return null;
        }

        public string aliasCall(string arg)
        {
            return "";
        }


        public virtual void onPluginUpdate()
        {

        }

        public virtual bool onLoad(LamaConfig cfg)
        {
          
            return true;
        }


        protected InterPluginResponse sendInterPluginCall(string target, string callName, Dictionary<string, object> args)
        {
            if (pmInterCall != null)
                return this.pmInterCall(this, target, new InterPluginArgs(0, callName, args));
            else
                return null;
        }



    }
}
