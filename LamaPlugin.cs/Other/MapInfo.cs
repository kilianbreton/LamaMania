using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LamaPlugin
{
    public class MapInfo
    {
        string uid;
        string name;
        string fileName;
        string author;
        string environnement;
        string mood;
        int bronzeTime;
        int silverTime;
        int goldTime;
        int authorTime;
        int copperPrice;
        bool lapRace;
        int nbLaps;
        int nbCheckpoints;
        string mapType;
        string mapStyle;

        public MapInfo(string uid, string name, string fileName, string author, string environnement)
        {
            Uid = uid;
            Name = name;
            FileName = fileName;
            Author = author;
            Environnement = environnement;
        }

        public string Uid { get => uid; set => uid = value; }
        public string Name { get => name; set => name = value; }
        public string FileName { get => fileName; set => fileName = value; }
        public string Author { get => author; set => author = value; }
        public string Environnement { get => environnement; set => environnement = value; }
        public string Mood { get => mood; set => mood = value; }
        public int BronzeTime { get => bronzeTime; set => bronzeTime = value; }
        public int SilverTime { get => silverTime; set => silverTime = value; }
        public int GoldTime { get => goldTime; set => goldTime = value; }
        public int AuthorTime { get => authorTime; set => authorTime = value; }
        public int CopperPrice { get => copperPrice; set => copperPrice = value; }
        public bool LapRace { get => lapRace; set => lapRace = value; }
        public int NbLaps { get => nbLaps; set => nbLaps = value; }
        public int NbCheckpoints { get => nbCheckpoints; set => nbCheckpoints = value; }
        public string MapType { get => mapType; set => mapType = value; }
        public string MapStyle { get => mapStyle; set => mapStyle = value; }
    }
}
