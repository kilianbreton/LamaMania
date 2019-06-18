using System;
using System.Collections.Generic;
using System.Text;
using NTK.IO.Xml;

namespace LamaPlugin
{
    public enum Game
    {
        TrackMania,
        ShootMania
    }
    public enum Lvl
    {
        SuperAdmin,
        Admin,
        User
    }
    public struct LamaConfig
    {
        public Dictionary<string, XmlDocument> configFiles;
        public bool dbConnected;
        public bool remote;
        public bool connected;
        public Game game;
        public bool InternetServer;
        public Lvl lvl;
        public string scriptName;

    }
}
