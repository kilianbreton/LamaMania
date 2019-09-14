using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTK.IO.Xml;

namespace LamaPlugin
{
    public delegate void OnError(object sender, string title, string text);
    public delegate void Logger(string type, string text);
    public delegate void MakeXml(object sender, string fileName, XmlDocument doc = null);


    public abstract class BasePlugin : IBase
    {
        private List<Requirement> requirements = new List<Requirement>();
        private string author = "";
        private string name = "";
        private string version = "";
        private OnError onError;
        private Logger log;
        private MakeXml makeXml;
        private string pluginFolder;
        private PluginType type = PluginType.Base;

        public BasePlugin() { }

        ///////////////////////////////////////////////////////////////////////////////////////////////////
        // GETTERS ///////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////

        public List<Requirement> Requirements { get => requirements; set => requirements = value; }
        public string Author { get => author;  set => author = value; }
        public string PluginName { get => name; set => name = value; }
        public string Version { get => version; set => version = value; }

        public OnError OnError { get => onError; set => onError = value; }
        public Logger Log { get => log; set => log = value; }
        public MakeXml MakeXml { get => makeXml; set => makeXml = value; }
        public string PluginFolder { get => pluginFolder; set => pluginFolder = value; }
        public PluginType PluginType { get => type; set => type = value; }
    }
}
