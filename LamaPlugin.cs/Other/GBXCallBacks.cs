using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LamaPlugin
{
    public class GBXCallBacks
    {
        /// <summary>
        /// Params : SMapInfo Map
        /// </summary>
        public const string ManiaPlanet_BeginMap = "ManiaPlanet.BeginMap";
        /// <summary>
        /// Params :
        /// </summary>
        public const string ManiaPlanet_BeginMatch = "ManiaPlanet.BeginMatch";
        /// <summary>
        /// Params : int BillId  int State  string StateName  int TransactionId
        /// </summary>
        public const string ManiaPlanet_BillUpdated = "ManiaPlanet.BillUpdated";
        /// <summary>
        /// Params : string Internal  string Public
        /// </summary>
        public const string ManiaPlanet_Echo = "ManiaPlanet.Echo";
        /// <summary>
        /// Params : SMapInfo Map
        /// </summary>
        public const string ManiaPlanet_EndMap = "ManiaPlanet.EndMap";
        /// <summary>
        /// Params : SPlayerRanking Rankings[]  int WinnerTeam
        /// </summary>
        public const string ManiaPlanet_EndMatch = "ManiaPlanet.EndMatch";
        /// <summary>
        /// Params : int CurMapIndex  int NextMapIndex  bool IsListModified
        /// </summary>
        public const string ManiaPlanet_MapListModified = "ManiaPlanet.MapListModified";
        /// <summary>
        /// Params : string Param1  string Param2
        /// </summary>
        public const string ManiaPlanet_ModeScriptCallback = "ManiaPlanet.ModeScriptCallback";
        /// <summary>
        /// Params : string Param1  string Params[]
        /// </summary>
        public const string ManiaPlanet_ModeScriptCallbackArray = "ManiaPlanet.ModeScriptCallbackArray";
        /// <summary>
        /// Params : string Login
        /// </summary>
        public const string ManiaPlanet_PlayerAlliesChanged = "ManiaPlanet.PlayerAlliesChanged";
        /// <summary>
        /// Params : int PlayerUid  string Login  string Text  bool IsRegistredCmd
        /// </summary>
        public const string ManiaPlanet_PlayerChat = "ManiaPlanet.PlayerChat";
        /// <summary>
        /// Params : string Login  bool IsSpectator
        /// </summary>
        public const string ManiaPlanet_PlayerConnect = "ManiaPlanet.PlayerConnect";
        /// <summary>
        /// Params : string Login  string DisconnectionReason
        /// </summary>
        public const string ManiaPlanet_PlayerDisconnect = "ManiaPlanet.PlayerDisconnect";
        /// <summary>
        /// Params : SPlayerInfo PlayerInfo
        /// </summary>
        public const string ManiaPlanet_PlayerInfoChanged = "ManiaPlanet.PlayerInfoChanged";
        /// <summary>
        /// Params : int PlayerUid  string Login  string Answer  SEntryVal Entries[]
        /// </summary>
        public const string ManiaPlanet_PlayerManialinkPageAnswer = "ManiaPlanet.PlayerManialinkPageAnswer";
        /// <summary>
        /// Params :
        /// </summary>
        public const string ManiaPlanet_ServerStart = "ManiaPlanet.ServerStart";
        /// <summary>
        /// Params :
        /// </summary>
        public const string ManiaPlanet_ServerStop = "ManiaPlanet.ServerStop";
        /// <summary>
        /// Params : int StatusCode  string StatusName
        /// </summary>
        public const string ManiaPlanet_StatusChanged = "ManiaPlanet.StatusChanged";
        /// <summary>
        /// Params : int PlayerUid  string Login  base64 Data
        /// </summary>
        public const string ManiaPlanet_TunnelDataReceived = "ManiaPlanet.TunnelDataReceived";
        /// <summary>
        /// Params : string StateName  string Login  string CmdName  string CmdParam
        /// </summary>
        public const string ManiaPlanet_VoteUpdated = "ManiaPlanet.VoteUpdated";
        /// <summary>
        /// Params : string Type  string Id
        /// </summary>
        public const string ScriptCloud_LoadData = "ScriptCloud.LoadData";
        /// <summary>
        /// Params : string Type  string Id
        /// </summary>
        public const string ScriptCloud_SaveData = "ScriptCloud.SaveData";
        /// <summary>
        /// Params : int PlayerUid  string Login  int TimeOrScore  int CurLap  int CheckpointIndex
        /// </summary>
        public const string TrackMania_PlayerCheckpoint = "TrackMania.PlayerCheckpoint";
        /// <summary>
        /// Params : int PlayerUid  string Login  int TimeOrScore
        /// </summary>
        public const string TrackMania_PlayerFinish = "TrackMania.PlayerFinish";
        /// <summary>
        /// Params : int PlayerUid  string Login
        /// </summary>
        public const string TrackMania_PlayerIncoherence = "TrackMania.PlayerIncoherence";



    }
}