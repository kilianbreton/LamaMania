using System;
using System.Collections.Generic;
using System.Text;
using NTK.IO.Xml;

namespace LamaPlugin
{
    public struct LamaConfig
    {
        public Dictionary<string, XmlDocument> configFiles;
        public bool remote;
        public bool connected;


    }
}
