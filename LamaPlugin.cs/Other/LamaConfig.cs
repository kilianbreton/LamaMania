using System;
using System.Collections.Generic;
using System.Text;
using NTK.IO.Xml;
using NTK.Database;


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
        public List<Player> players;
        public List<MapInfo> maps;
        public string serverName;
        public string serverLogin;
        public string serverComment;
        public bool dbConnected;
        public NTKDatabase db;
        public bool remote;
        public bool connected;
        public Game game;
        public bool InternetServer;
        public Lvl lvl;
        public string scriptName;
        public int currentMapId;
        public Dictionary<string, LamaConfig> requiredPluginsConfig;
    }
}
