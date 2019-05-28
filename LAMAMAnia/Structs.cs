﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMAMAnia
{
    public struct SMapInfo
    {
        public string Uid;
        public string Name;
        public string FileName;
        public string Author;
        public string Environnement;
        public string Mood;
        public int BronzeTime;
        public int SilverTime;
        public int GoldTime;
        public int AuthorTime;
        public int CopperPrice;
        public bool LapRace;
        public int NbLaps;
        public int NbCheckpopublic;
        public string MapType;
        public string MapStyle;
    }

    public struct SPlayerRanking
    {
        public string Login;
        public string NickName;
        public int PlayerId;
        public int Rank;
        public int BestTime;
        public int[] BestCheckpopublic;
        public int Score;
        public int NbrLapsFinished;
        public double LadderScore;
    }

    public struct SPlayerInfo
    {
        public string Login;
        public string NickName;
        public int PlayerId;
        public int TeamId;
        public int SpectatorStatus;
        public int LadderRanking;
        public int Flags;
    }
}
