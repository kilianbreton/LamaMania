using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LamaMania
{
    /// <summary>
    /// 
    /// </summary>
    public enum GameMode
    {
        OTHER = 0,
        TIMEATTACK,
        ROUNDS,
        CUP,
        CHASE,
        LAPS,

        MATCH,
        TEAM,
        BATTLE,
        COMBO,
        ELITE,
        JOUST,
        MELEE,
        ROYAL_FUN,
        ROYAL_PRO,
        SIEGE,
        WARLORDS,
    }

    public enum TMGameMode
    {
        Chase,
        Cup,
        Laps,
        ModeMatchMaking,
        Rounds,
        Team,
        TeamAttack,
        TimeAttack      
    }

    public enum SMGameMode
    {
        Melee,
        ModMatchMaking,
        Realm,
        SiegeV1,
        TimeAttack

    }
    
}
