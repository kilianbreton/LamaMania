using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LamaPlugin;


namespace BasicsCommandsPlugin
{
    public class CallVote
    {
        private string cvType;
        private string cvTarget;
        private Dictionary<Player, bool> votes = new Dictionary<Player, bool>();


        public CallVote(string type, string target)
        {
            cvType = type;
            cvTarget = target;
        }

        public CallVote(string type)
        {
            cvType = type;
        }



        public void vote(Player p, bool vote)
        {
            if (votes.ContainsKey(p))
                votes[p] = vote;
            else
                votes.Add(p, vote);
        }


        public bool haveVote(Player p)
        {
            return (votes.ContainsKey(p));
        }


        public bool getVote(Player p)
        {
            bool ret = false;
            if(haveVote(p)){
                ret = votes[p];
            }


            return ret;
        }


        public string Type { get => cvType; set => cvType = value; }
        public string Target { get => cvTarget; set => cvTarget = value; }
        public Dictionary<Player, bool> Votes { get => votes; set => votes = value; }
    }
}
