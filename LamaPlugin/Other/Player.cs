using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LamaPlugin
{
    public class Player
    {
        string login;
        string nickName;
        int playerId;
        int teamId;
        int spectatorStatus;
        int ladderRanking;
        int flags;
        int rank;
        int bestTime;
        int[] bestCheckpoints;
        int score;
        int nbrLapsFinished;
        double ladderScore;

        List<int> live_checkPoints;

        public Player(string login, string nickName, int playerId)
        {
            this.login = login;
            this.nickName = nickName;
            PlayerId = playerId;
        }

        public Player(string login, string nickName, int playerId, int teamId, int spectatorStatus, int ladderRanking)
        {
            this.login = login;
            this.nickName = nickName;
            PlayerId = playerId;
            TeamId = teamId;
            SpectatorStatus = spectatorStatus;
            LadderRanking = ladderRanking;
        }

        public string Login { get => login; set => login = value; }
        public string NickName { get => nickName; set => nickName = value; }
        public int PlayerId { get => playerId; set => playerId = value; }
        public int TeamId { get => teamId; set => teamId = value; }
        public int SpectatorStatus { get => spectatorStatus; set => spectatorStatus = value; }
        public int LadderRanking { get => ladderRanking; set => ladderRanking = value; }
        public int Flags { get => flags; set => flags = value; }
        public int Rank { get => rank; set => rank = value; }
        public int BestTime { get => bestTime; set => bestTime = value; }
        public int[] BestCheckpoints { get => bestCheckpoints; set => bestCheckpoints = value; }
        public int Score { get => score; set => score = value; }
        public int NbrLapsFinished1 { get => nbrLapsFinished; set => nbrLapsFinished = value; }
        public double LadderScore { get => ladderScore; set => ladderScore = value; }
        public List<int> Live_checkPoints { get => live_checkPoints; set => live_checkPoints = value; }
    }
}
