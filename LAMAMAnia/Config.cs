using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTK.IO.Xml;
using LamaLang;

namespace LAMAMAnia
{
    public class Config
    {
        public static Dictionary<String, String> servers = new Dictionary<string, string>();
        public static XmlDocument mainConfig;
        public static bool invisibleServer = false;
        public static bool launched = false;
        public static bool remote = false;
        public static string remoteAdrs;
        public static int remotePort;
        public static BaseLang lang;
        public static bool connected = false;
    }
}
