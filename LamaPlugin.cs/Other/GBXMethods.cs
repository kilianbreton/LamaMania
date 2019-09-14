using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LamaPlugin
{
    /// <summary>
    /// GbxMethods
    /// </summary>
    public static class GBXMethods
    {
        /// <summary>
        /// Return an array of all available XML-RPC methods on this server.
        /// </summary>
        /// <example>
        /// system.listMethods ()
        /// </example>
        /// <returns>
        /// array
        /// </returns>
        public const String systemlistMethods = "system.listMethods";
        /// <summary>
        /// Given the name of a method, return an array of legal signatures. Each signature is an array of strings.  The first item of each signature is the return type, and any others items are parameter types.
        /// </summary>
        /// <example>
        /// system.methodSignature (string)
        /// </example>
        /// <returns>
        /// array
        /// </returns>
        public const String systemmethodSignature = "system.methodSignature";
        /// <summary>
        /// Given the name of a method, return a help string.
        /// </summary>
        /// <example>
        /// system.methodHelp (string)
        /// </example>
        /// <returns>
        /// string
        /// </returns>
        public const String systemmethodHelp = "system.methodHelp";
        /// <summary>
        /// Process an array of calls, and return an array of results.  Calls should be structs of the form {'methodName': string, 'params': array}. Each result will either be a single-item array containing the result value, or a struct of the form {'faultCode': int, 'faultString': string}.  This is useful when you need to make lots of small calls without lots of round trips.
        /// </summary>
        /// <example>
        /// system.multicall (array)
        /// </example>
        /// <returns>
        /// array
        /// </returns>
        public const String systemmulticall = "system.multicall";
        /// <summary>
        /// Allow user authentication by specifying a login and a password, to gain access to the set of functionalities corresponding to this authorization level.
        /// </summary>
        /// <example>
        /// Authenticate (string,string)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String Authenticate = "Authenticate";
        /// <summary>
        /// Change the password for the specified login/user. Only available to SuperAdmin.
        /// </summary>
        /// <example>
        /// ChangeAuthPassword (string,string)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String ChangeAuthPassword = "ChangeAuthPassword";
        /// <summary>
        /// Allow the GameServer to call you back.
        /// </summary>
        /// <example>
        /// EnableCallbacks (boolean)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String EnableCallbacks = "EnableCallbacks";
        /// <summary>
        /// Define the wanted api.
        /// </summary>
        /// <example>
        /// SetApiVersion (string)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SetApiVersion = "SetApiVersion";
        /// <summary>
        ///
        /// </summary>
        /// <example>
        /// GetVersion ()
        /// </example>
        /// <returns>
        /// struct
        /// </returns>
        public const String GetVersion = "GetVersion";
        /// <summary>
        /// Returns the current status of the server.
        /// </summary>
        /// <example>
        /// GetStatus ()
        /// </example>
        /// <returns>
        /// struct
        /// </returns>
        public const String GetStatus = "GetStatus";
        /// <summary>
        /// Quit the application. Only available to SuperAdmin.
        /// </summary>
        /// <example>
        /// QuitGame ()
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String QuitGame = "QuitGame";
        /// <summary>
        /// Call a vote for a cmd. The command is a XML string corresponding to an XmlRpc request. Only available to Admin.
        /// </summary>
        /// <example>
        /// CallVote (string)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String CallVote = "CallVote";
        /// <summary>
        /// Extended call vote. Same as CallVote, but you can additionally supply specific parameters for this vote: a ratio, a time out and who is voting. Special timeout values: a ratio of '-1' means default; a timeout of '0' means default, '1' means indefinite; Voters values: '0' means only active players, '1' means any player, '2' is for everybody, pure spectators included. Only available to Admin.
        /// </summary>
        /// <example>
        /// CallVoteEx (string,double,int,int)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String CallVoteEx = "CallVoteEx";
        /// <summary>
        /// Used internally by game.
        /// </summary>
        /// <example>
        /// InternalCallVote ()
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String InternalCallVote = "InternalCallVote";
        /// <summary>
        /// Cancel the current vote. Only available to Admin.
        /// </summary>
        /// <example>
        /// CancelVote ()
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String CancelVote = "CancelVote";
        /// <summary>
        /// Returns the vote currently in progress. The returned structure is { CallerLogin, CmdName, CmdParam }.
        /// </summary>
        /// <example>
        /// GetCurrentCallVote ()
        /// </example>
        /// <returns>
        /// struct
        /// </returns>
        public const String GetCurrentCallVote = "GetCurrentCallVote";
        /// <summary>
        /// Set a new timeout for waiting for votes. A zero value disables callvote. Only available to Admin. Requires a map restart to be taken into account.
        /// </summary>
        /// <example>
        /// SetCallVoteTimeOut (int)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SetCallVoteTimeOut = "SetCallVoteTimeOut";
        /// <summary>
        /// Get the current and next timeout for waiting for votes. The struct returned contains two fields 'CurrentValue' and 'NextValue'.
        /// </summary>
        /// <example>
        /// GetCallVoteTimeOut ()
        /// </example>
        /// <returns>
        /// struct
        /// </returns>
        public const String GetCallVoteTimeOut = "GetCallVoteTimeOut";
        /// <summary>
        /// Set a new default ratio for passing a vote. Must lie between 0 and 1. Only available to Admin.
        /// </summary>
        /// <example>
        /// SetCallVoteRatio (double)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SetCallVoteRatio = "SetCallVoteRatio";
        /// <summary>
        /// Get the current default ratio for passing a vote. This value lies between 0 and 1.
        /// </summary>
        /// <example>
        /// GetCallVoteRatio ()
        /// </example>
        /// <returns>
        /// double
        /// </returns>
        public const String GetCallVoteRatio = "GetCallVoteRatio";
        /// <summary>
        ///
        /// </summary>
        /// <example>
        /// SetCallVoteRatios (array)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SetCallVoteRatios = "SetCallVoteRatios";
        /// <summary>
        /// Get the current ratios for passing votes.
        /// </summary>
        /// <example>
        /// GetCallVoteRatios ()
        /// </example>
        /// <returns>
        /// array
        /// </returns>
        public const String GetCallVoteRatios = "GetCallVoteRatios";
        /// <summary>
        ///
        /// </summary>
        /// <example>
        /// SetCallVoteRatiosEx (boolean,array)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SetCallVoteRatiosEx = "SetCallVoteRatiosEx";
        /// <summary>
        /// Get the current ratios for passing votes, extended version with parameters matching.
        /// </summary>
        /// <example>
        /// GetCallVoteRatiosEx ()
        /// </example>
        /// <returns>
        /// array
        /// </returns>
        public const String GetCallVoteRatiosEx = "GetCallVoteRatiosEx";
        /// <summary>
        /// Send a text message to all clients without the server login. Only available to Admin.
        /// </summary>
        /// <example>
        /// ChatSendServerMessage (string)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String ChatSendServerMessage = "ChatSendServerMessage";
        /// <summary>
        ///
        /// </summary>
        /// <example>
        /// ChatSendServerMessageToLanguage (array,string)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String ChatSendServerMessageToLanguage = "ChatSendServerMessageToLanguage";
        /// <summary>
        /// Send a text message without the server login to the client with the specified PlayerId. Only available to Admin.
        /// </summary>
        /// <example>
        /// ChatSendServerMessageToId (string,int)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String ChatSendServerMessageToId = "ChatSendServerMessageToId";
        /// <summary>
        /// Send a text message without the server login to the client with the specified login. Login can be a single login or a list of comma-separated logins. Only available to Admin.
        /// </summary>
        /// <example>
        /// ChatSendServerMessageToLogin (string,string)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String ChatSendServerMessageToLogin = "ChatSendServerMessageToLogin";
        /// <summary>
        /// Send a text message to all clients. Only available to Admin.
        /// </summary>
        /// <example>
        /// ChatSend (string)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String ChatSend = "ChatSend";
        /// <summary>
        ///
        /// </summary>
        /// <example>
        /// ChatSendToLanguage (array,string)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String ChatSendToLanguage = "ChatSendToLanguage";
        /// <summary>
        /// Send a text message to the client with the specified login. Login can be a single login or a list of comma-separated logins. Only available to Admin.
        /// </summary>
        /// <example>
        /// ChatSendToLogin (string,string)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String ChatSendToLogin = "ChatSendToLogin";
        /// <summary>
        /// Send a text message to the client with the specified PlayerId. Only available to Admin.
        /// </summary>
        /// <example>
        /// ChatSendToId (string,int)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String ChatSendToId = "ChatSendToId";
        /// <summary>
        /// Returns the last chat lines. Maximum of 40 lines. Only available to Admin.
        /// </summary>
        /// <example>
        /// GetChatLines ()
        /// </example>
        /// <returns>
        /// array
        /// </returns>
        public const String GetChatLines = "GetChatLines";
        /// <summary>
        /// The chat messages are no longer dispatched to the players, they only go to the rpc callback and the controller has to manually forward them. The second (optional) parameter allows all messages from the server to be automatically forwarded. Only available to Admin.
        /// </summary>
        /// <example>
        /// ChatEnableManualRouting (boolean,boolean)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String ChatEnableManualRouting = "ChatEnableManualRouting";
        /// <summary>
        /// (Text, SenderLogin, DestLogin) Send a text message to the specified DestLogin (or everybody if empty) on behalf of SenderLogin. DestLogin can be a single login or a list of comma-separated logins. Only available if manual routing is enabled. Only available to Admin.
        /// </summary>
        /// <example>
        /// ChatForwardToLogin (string,string,string)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String ChatForwardToLogin = "ChatForwardToLogin";
        /// <summary>
        /// Display a notice on all clients. The parameters are the text message to display, and the login of the avatar to display next to it (or '' for no avatar), and an optional 'variant' in [0 = normal, 1 = Sad, 2 = Happy]. Only available to Admin.
        /// </summary>
        /// <example>
        /// SendNotice (string,string,int)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SendNotice = "SendNotice";
        /// <summary>
        /// Display a notice on the client with the specified UId. The parameters are the Uid of the client to whom the notice is sent, the text message to display, and the UId of the avatar to display next to it (or '255' for no avatar), and an optional 'variant' in [0 = normal, 1 = Sad, 2 = Happy]. Only available to Admin.
        /// </summary>
        /// <example>
        /// SendNoticeToId (int,string,int,int)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SendNoticeToId = "SendNoticeToId";
        /// <summary>
        /// Display a notice on the client with the specified login. The parameters are the login of the client to whom the notice is sent, the text message to display, and the login of the avatar to display next to it (or '' for no avatar), and an optional 'variant' in [0 = normal, 1 = Sad, 2 = Happy]. Login can be a single login or a list of comma-separated logins.  Only available to Admin.
        /// </summary>
        /// <example>
        /// SendNoticeToLogin (string,string,string,int)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SendNoticeToLogin = "SendNoticeToLogin";
        /// <summary>
        /// Display a manialink page on all clients. The parameters are the xml description of the page to display, a timeout to autohide it (0 = permanent), and a boolean to indicate whether the page must be hidden as soon as the user clicks on a page option. Only available to Admin.
        /// </summary>
        /// <example>
        /// SendDisplayManialinkPage (string,int,boolean)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SendDisplayManialinkPage = "SendDisplayManialinkPage";
        /// <summary>
        /// Display a manialink page on the client with the specified UId. The first parameter is the UId of the player, the other are identical to 'SendDisplayManialinkPage'. Only available to Admin.
        /// </summary>
        /// <example>
        /// SendDisplayManialinkPageToId (int,string,int,boolean)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SendDisplayManialinkPageToId = "SendDisplayManialinkPageToId";
        /// <summary>
        /// Display a manialink page on the client with the specified login. The first parameter is the login of the player, the other are identical to 'SendDisplayManialinkPage'. Login can be a single login or a list of comma-separated logins. Only available to Admin.
        /// </summary>
        /// <example>
        /// SendDisplayManialinkPageToLogin (string,string,int,boolean)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SendDisplayManialinkPageToLogin = "SendDisplayManialinkPageToLogin";
        /// <summary>
        /// Hide the displayed manialink page on all clients. Only available to Admin.
        /// </summary>
        /// <example>
        /// SendHideManialinkPage ()
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SendHideManialinkPage = "SendHideManialinkPage";
        /// <summary>
        /// Hide the displayed manialink page on the client with the specified UId. Only available to Admin.
        /// </summary>
        /// <example>
        /// SendHideManialinkPageToId (int)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SendHideManialinkPageToId = "SendHideManialinkPageToId";
        /// <summary>
        /// Hide the displayed manialink page on the client with the specified login. Login can be a single login or a list of comma-separated logins. Only available to Admin.
        /// </summary>
        /// <example>
        /// SendHideManialinkPageToLogin (string)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SendHideManialinkPageToLogin = "SendHideManialinkPageToLogin";
        /// <summary>
        ///
        /// </summary>
        /// <example>
        /// GetManialinkPageAnswers ()
        /// </example>
        /// <returns>
        /// array
        /// </returns>
        public const String GetManialinkPageAnswers = "GetManialinkPageAnswers";
        /// <summary>
        /// Opens a link in the client with the specified UId. The parameters are the Uid of the client to whom the link to open is sent, the link url, and the 'LinkType' (0 in the external browser, 1 in the internal manialink browser). Only available to Admin.
        /// </summary>
        /// <example>
        /// SendOpenLinkToId (int,string,int)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SendOpenLinkToId = "SendOpenLinkToId";
        /// <summary>
        /// Opens a link in the client with the specified login. The parameters are the login of the client to whom the link to open is sent, the link url, and the 'LinkType' (0 in the external browser, 1 in the internal manialink browser). Login can be a single login or a list of comma-separated logins.  Only available to Admin.
        /// </summary>
        /// <example>
        /// SendOpenLinkToLogin (string,string,int)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SendOpenLinkToLogin = "SendOpenLinkToLogin";
        /// <summary>
        /// Kick the player with the specified login, with an optional message. Only available to Admin.
        /// </summary>
        /// <example>
        /// Kick (string,string)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String Kick = "Kick";
        /// <summary>
        /// Kick the player with the specified PlayerId, with an optional message. Only available to Admin.
        /// </summary>
        /// <example>
        /// KickId (int,string)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String KickId = "KickId";
        /// <summary>
        /// Ban the player with the specified login, with an optional message. Only available to Admin.
        /// </summary>
        /// <example>
        /// Ban (string,string)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String Ban = "Ban";
        /// <summary>
        /// Ban the player with the specified login, with a message. Add it to the black list, and optionally save the new list. Only available to Admin.
        /// </summary>
        /// <example>
        /// BanAndBlackList (string,string,boolean)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String BanAndBlackList = "BanAndBlackList";
        /// <summary>
        /// Ban the player with the specified PlayerId, with an optional message. Only available to Admin.
        /// </summary>
        /// <example>
        /// BanId (int,string)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String BanId = "BanId";
        /// <summary>
        /// Unban the player with the specified login. Only available to Admin.
        /// </summary>
        /// <example>
        /// UnBan (string)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String UnBan = "UnBan";
        /// <summary>
        /// Clean the ban list of the server. Only available to Admin.
        /// </summary>
        /// <example>
        /// CleanBanList ()
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String CleanBanList = "CleanBanList";
        /// <summary>
        ///
        /// </summary>
        /// <example>
        /// GetBanList (int,int)
        /// </example>
        /// <returns>
        /// array
        /// </returns>
        public const String GetBanList = "GetBanList";
        /// <summary>
        /// Blacklist the player with the specified login. Only available to SuperAdmin.
        /// </summary>
        /// <example>
        /// BlackList (string)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String BlackList = "BlackList";
        /// <summary>
        /// Blacklist the player with the specified PlayerId. Only available to SuperAdmin.
        /// </summary>
        /// <example>
        /// BlackListId (int)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String BlackListId = "BlackListId";
        /// <summary>
        /// UnBlackList the player with the specified login. Only available to SuperAdmin.
        /// </summary>
        /// <example>
        /// UnBlackList (string)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String UnBlackList = "UnBlackList";
        /// <summary>
        /// Clean the blacklist of the server. Only available to SuperAdmin.
        /// </summary>
        /// <example>
        /// CleanBlackList ()
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String CleanBlackList = "CleanBlackList";
        /// <summary>
        ///
        /// </summary>
        /// <example>
        /// GetBlackList (int,int)
        /// </example>
        /// <returns>
        /// array
        /// </returns>
        public const String GetBlackList = "GetBlackList";
        /// <summary>
        /// Load the black list file with the specified file name. Only available to Admin.
        /// </summary>
        /// <example>
        /// LoadBlackList (string)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String LoadBlackList = "LoadBlackList";
        /// <summary>
        /// Save the black list in the file with specified file name. Only available to Admin.
        /// </summary>
        /// <example>
        /// SaveBlackList (string)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SaveBlackList = "SaveBlackList";
        /// <summary>
        /// Add the player with the specified login on the guest list. Only available to Admin.
        /// </summary>
        /// <example>
        /// AddGuest (string)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String AddGuest = "AddGuest";
        /// <summary>
        /// Add the player with the specified PlayerId on the guest list. Only available to Admin.
        /// </summary>
        /// <example>
        /// AddGuestId (int)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String AddGuestId = "AddGuestId";
        /// <summary>
        /// Remove the player with the specified login from the guest list. Only available to Admin.
        /// </summary>
        /// <example>
        /// RemoveGuest (string)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String RemoveGuest = "RemoveGuest";
        /// <summary>
        /// Remove the player with the specified PlayerId from the guest list. Only available to Admin.
        /// </summary>
        /// <example>
        /// RemoveGuestId (int)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String RemoveGuestId = "RemoveGuestId";
        /// <summary>
        /// Clean the guest list of the server. Only available to Admin.
        /// </summary>
        /// <example>
        /// CleanGuestList ()
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String CleanGuestList = "CleanGuestList";
        /// <summary>
        ///
        /// </summary>
        /// <example>
        /// GetGuestList (int,int)
        /// </example>
        /// <returns>
        /// array
        /// </returns>
        public const String GetGuestList = "GetGuestList";
        /// <summary>
        /// Load the guest list file with the specified file name. Only available to Admin.
        /// </summary>
        /// <example>
        /// LoadGuestList (string)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String LoadGuestList = "LoadGuestList";
        /// <summary>
        /// Save the guest list in the file with specified file name. Only available to Admin.
        /// </summary>
        /// <example>
        /// SaveGuestList (string)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SaveGuestList = "SaveGuestList";
        /// <summary>
        ///
        /// </summary>
        /// <example>
        /// SetBuddyNotification (string,boolean)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SetBuddyNotification = "SetBuddyNotification";
        /// <summary>
        ///
        /// </summary>
        /// <example>
        /// GetBuddyNotification (string)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String GetBuddyNotification = "GetBuddyNotification";
        /// <summary>
        /// Write the data to the specified file. The filename is relative to the Maps path. Only available to Admin.
        /// </summary>
        /// <example>
        /// WriteFile (string,base64)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String WriteFile = "WriteFile";
        /// <summary>
        /// Send the data to the specified player. Only available to Admin.
        /// </summary>
        /// <example>
        /// TunnelSendDataToId (int,base64)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String TunnelSendDataToId = "TunnelSendDataToId";
        /// <summary>
        /// Send the data to the specified player. Login can be a single login or a list of comma-separated logins. Only available to Admin.
        /// </summary>
        /// <example>
        /// TunnelSendDataToLogin (string,base64)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String TunnelSendDataToLogin = "TunnelSendDataToLogin";
        /// <summary>
        /// Just log the parameters and invoke a callback. Can be used to talk to other xmlrpc clients connected, or to make custom votes. If used in a callvote, the first parameter will be used as the vote message on the clients. Only available to Admin.
        /// </summary>
        /// <example>
        /// Echo (string,string)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String Echo = "Echo";
        /// <summary>
        /// Ignore the player with the specified login. Only available to Admin.
        /// </summary>
        /// <example>
        /// Ignore (string)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String Ignore = "Ignore";
        /// <summary>
        /// Ignore the player with the specified PlayerId. Only available to Admin.
        /// </summary>
        /// <example>
        /// IgnoreId (int)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String IgnoreId = "IgnoreId";
        /// <summary>
        /// Unignore the player with the specified login. Only available to Admin.
        /// </summary>
        /// <example>
        /// UnIgnore (string)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String UnIgnore = "UnIgnore";
        /// <summary>
        /// Unignore the player with the specified PlayerId. Only available to Admin.
        /// </summary>
        /// <example>
        /// UnIgnoreId (int)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String UnIgnoreId = "UnIgnoreId";
        /// <summary>
        /// Clean the ignore list of the server. Only available to Admin.
        /// </summary>
        /// <example>
        /// CleanIgnoreList ()
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String CleanIgnoreList = "CleanIgnoreList";
        /// <summary>
        ///
        /// </summary>
        /// <example>
        /// GetIgnoreList (int,int)
        /// </example>
        /// <returns>
        /// array
        /// </returns>
        public const String GetIgnoreList = "GetIgnoreList";
        /// <summary>
        ///
        /// </summary>
        /// <example>
        /// Pay (string,int,string)
        /// </example>
        /// <returns>
        /// int
        /// </returns>
        public const String Pay = "Pay";
        /// <summary>
        ///
        /// </summary>
        /// <example>
        /// SendBill (string,int,string,string)
        /// </example>
        /// <returns>
        /// int
        /// </returns>
        public const String SendBill = "SendBill";
        /// <summary>
        ///
        /// </summary>
        /// <example>
        /// GetBillState (int)
        /// </example>
        /// <returns>
        /// struct
        /// </returns>
        public const String GetBillState = "GetBillState";
        /// <summary>
        /// Returns the current number of planets on the server account.
        /// </summary>
        /// <example>
        /// GetServerPlanets ()
        /// </example>
        /// <returns>
        /// int
        /// </returns>
        public const String GetServerPlanets = "GetServerPlanets";
        /// <summary>
        /// Get some system infos, including connection rates (in kbps).
        /// </summary>
        /// <example>
        /// GetSystemInfo ()
        /// </example>
        /// <returns>
        /// struct
        /// </returns>
        public const String GetSystemInfo = "GetSystemInfo";
        /// <summary>
        /// Set the download and upload rates (in kbps).
        /// </summary>
        /// <example>
        /// SetConnectionRates (int,int)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SetConnectionRates = "SetConnectionRates";
        /// <summary>
        /// Returns the list of tags and associated values set on this server. Only available to Admin.
        /// </summary>
        /// <example>
        /// GetServerTags ()
        /// </example>
        /// <returns>
        /// array
        /// </returns>
        public const String GetServerTags = "GetServerTags";
        /// <summary>
        ///
        /// </summary>
        /// <example>
        /// SetServerTag (string,string)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SetServerTag = "SetServerTag";
        /// <summary>
        /// Unset the tag with the specified name on the server. Only available to Admin.
        /// </summary>
        /// <example>
        /// UnsetServerTag (string)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String UnsetServerTag = "UnsetServerTag";
        /// <summary>
        /// Reset all tags on the server. Only available to Admin.
        /// </summary>
        /// <example>
        /// ResetServerTags ()
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String ResetServerTags = "ResetServerTags";
        /// <summary>
        /// Set a new server name in utf8 format. Only available to Admin.
        /// </summary>
        /// <example>
        /// SetServerName (string)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SetServerName = "SetServerName";
        /// <summary>
        /// Get the server name in utf8 format.
        /// </summary>
        /// <example>
        /// GetServerName ()
        /// </example>
        /// <returns>
        /// string
        /// </returns>
        public const String GetServerName = "GetServerName";
        /// <summary>
        /// Set a new server comment in utf8 format. Only available to Admin.
        /// </summary>
        /// <example>
        /// SetServerComment (string)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SetServerComment = "SetServerComment";
        /// <summary>
        /// Get the server comment in utf8 format.
        /// </summary>
        /// <example>
        /// GetServerComment ()
        /// </example>
        /// <returns>
        /// string
        /// </returns>
        public const String GetServerComment = "GetServerComment";
        /// <summary>
        /// Set whether the server should be hidden from the public server list (0 = visible, 1 = always hidden, 2 = hidden from nations). Only available to Admin.
        /// </summary>
        /// <example>
        /// SetHideServer (int)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SetHideServer = "SetHideServer";
        /// <summary>
        /// Get whether the server wants to be hidden from the public server list.
        /// </summary>
        /// <example>
        /// GetHideServer ()
        /// </example>
        /// <returns>
        /// int
        /// </returns>
        public const String GetHideServer = "GetHideServer";
        /// <summary>
        /// Returns true if this is a relay server.
        /// </summary>
        /// <example>
        /// IsRelayServer ()
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String IsRelayServer = "IsRelayServer";
        /// <summary>
        /// Set a new password for the server. Only available to Admin.
        /// </summary>
        /// <example>
        /// SetServerPassword (string)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SetServerPassword = "SetServerPassword";
        /// <summary>
        /// Get the server password if called as Admin or Super Admin, else returns if a password is needed or not.
        /// </summary>
        /// <example>
        /// GetServerPassword ()
        /// </example>
        /// <returns>
        /// string
        /// </returns>
        public const String GetServerPassword = "GetServerPassword";
        /// <summary>
        /// Set a new password for the spectator mode. Only available to Admin.
        /// </summary>
        /// <example>
        /// SetServerPasswordForSpectator (string)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SetServerPasswordForSpectator = "SetServerPasswordForSpectator";
        /// <summary>
        /// Get the password for spectator mode if called as Admin or Super Admin, else returns if a password is needed or not.
        /// </summary>
        /// <example>
        /// GetServerPasswordForSpectator ()
        /// </example>
        /// <returns>
        /// string
        /// </returns>
        public const String GetServerPasswordForSpectator = "GetServerPasswordForSpectator";
        /// <summary>
        /// Set a new maximum number of players. Only available to Admin. Requires a map restart to be taken into account.
        /// </summary>
        /// <example>
        /// SetMaxPlayers (int)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SetMaxPlayers = "SetMaxPlayers";
        /// <summary>
        ///
        /// </summary>
        /// <example>
        /// GetMaxPlayers ()
        /// </example>
        /// <returns>
        /// struct
        /// </returns>
        public const String GetMaxPlayers = "GetMaxPlayers";
        /// <summary>
        /// Set a new maximum number of Spectators. Only available to Admin. Requires a map restart to be taken into account.
        /// </summary>
        /// <example>
        /// SetMaxSpectators (int)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SetMaxSpectators = "SetMaxSpectators";
        /// <summary>
        ///
        /// </summary>
        /// <example>
        /// GetMaxSpectators ()
        /// </example>
        /// <returns>
        /// struct
        /// </returns>
        public const String GetMaxSpectators = "GetMaxSpectators";
        /// <summary>
        /// Declare if the server is a lobby, the number and maximum number of players currently managed by it, and the average level of the players. Only available to Admin.
        /// </summary>
        /// <example>
        /// SetLobbyInfo (boolean,int,int,double)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SetLobbyInfo = "SetLobbyInfo";
        /// <summary>
        ///
        /// </summary>
        /// <example>
        /// GetLobbyInfo ()
        /// </example>
        /// <returns>
        /// struct
        /// </returns>
        public const String GetLobbyInfo = "GetLobbyInfo";
        /// <summary>
        ///
        /// </summary>
        /// <example>
        /// CustomizeQuitDialog (string,string,boolean,int)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String CustomizeQuitDialog = "CustomizeQuitDialog";
        /// <summary>
        ///
        /// </summary>
        /// <example>
        /// SendToServerAfterMatchEnd (string)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SendToServerAfterMatchEnd = "SendToServerAfterMatchEnd";
        /// <summary>
        /// Set whether, when a player is switching to spectator, the server should still consider him a player and keep his player slot, or not. Only available to Admin.
        /// </summary>
        /// <example>
        /// KeepPlayerSlots (boolean)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String KeepPlayerSlots = "KeepPlayerSlots";
        /// <summary>
        /// Get whether the server keeps player slots when switching to spectator.
        /// </summary>
        /// <example>
        /// IsKeepingPlayerSlots ()
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String IsKeepingPlayerSlots = "IsKeepingPlayerSlots";
        /// <summary>
        /// Enable or disable peer-to-peer upload from server. Only available to Admin.
        /// </summary>
        /// <example>
        /// EnableP2PUpload (boolean)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String EnableP2PUpload = "EnableP2PUpload";
        /// <summary>
        /// Returns if the peer-to-peer upload from server is enabled.
        /// </summary>
        /// <example>
        /// IsP2PUpload ()
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String IsP2PUpload = "IsP2PUpload";
        /// <summary>
        /// Enable or disable peer-to-peer download for server. Only available to Admin.
        /// </summary>
        /// <example>
        /// EnableP2PDownload (boolean)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String EnableP2PDownload = "EnableP2PDownload";
        /// <summary>
        /// Returns if the peer-to-peer download for server is enabled.
        /// </summary>
        /// <example>
        /// IsP2PDownload ()
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String IsP2PDownload = "IsP2PDownload";
        /// <summary>
        /// Allow clients to download maps from the server. Only available to Admin.
        /// </summary>
        /// <example>
        /// AllowMapDownload (boolean)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String AllowMapDownload = "AllowMapDownload";
        /// <summary>
        /// Returns if clients can download maps from the server.
        /// </summary>
        /// <example>
        /// IsMapDownloadAllowed ()
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String IsMapDownloadAllowed = "IsMapDownloadAllowed";
        /// <summary>
        /// Returns the path of the game datas directory. Only available to Admin.
        /// </summary>
        /// <example>
        /// GameDataDirectory ()
        /// </example>
        /// <returns>
        /// string
        /// </returns>
        public const String GameDataDirectory = "GameDataDirectory";
        /// <summary>
        /// Returns the path of the maps directory. Only available to Admin.
        /// </summary>
        /// <example>
        /// GetMapsDirectory ()
        /// </example>
        /// <returns>
        /// string
        /// </returns>
        public const String GetMapsDirectory = "GetMapsDirectory";
        /// <summary>
        /// Returns the path of the skins directory. Only available to Admin.
        /// </summary>
        /// <example>
        /// GetSkinsDirectory ()
        /// </example>
        /// <returns>
        /// string
        /// </returns>
        public const String GetSkinsDirectory = "GetSkinsDirectory";
        /// <summary>
        /// Set Team names and colors (deprecated). Only available to Admin.
        /// </summary>
        /// <example>
        /// SetTeamInfo (string,double,string,string,double,string,string,double,string)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SetTeamInfo = "SetTeamInfo";
        /// <summary>
        ///
        /// </summary>
        /// <example>
        /// GetTeamInfo (int)
        /// </example>
        /// <returns>
        /// struct
        /// </returns>
        public const String GetTeamInfo = "GetTeamInfo";
        /// <summary>
        /// Set the clublinks to use for the two clans. Only available to Admin.
        /// </summary>
        /// <example>
        /// SetForcedClubLinks (string,string)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SetForcedClubLinks = "SetForcedClubLinks";
        /// <summary>
        /// Get the forced clublinks.
        /// </summary>
        /// <example>
        /// GetForcedClubLinks ()
        /// </example>
        /// <returns>
        /// struct
        /// </returns>
        public const String GetForcedClubLinks = "GetForcedClubLinks";
        /// <summary>
        /// (debug tool) Connect a fake player to the server and returns the login. Only available to Admin.
        /// </summary>
        /// <example>
        /// ConnectFakePlayer ()
        /// </example>
        /// <returns>
        /// string
        /// </returns>
        public const String ConnectFakePlayer = "ConnectFakePlayer";
        /// <summary>
        /// (debug tool) Disconnect a fake player, or all the fake players if login is '*'. Only available to Admin.
        /// </summary>
        /// <example>
        /// DisconnectFakePlayer (string)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String DisconnectFakePlayer = "DisconnectFakePlayer";
        /// <summary>
        /// Returns the token infos for a player. The returned structure is { TokenCost, CanPayToken }.
        /// </summary>
        /// <example>
        /// GetDemoTokenInfosForPlayer (string)
        /// </example>
        /// <returns>
        /// struct
        /// </returns>
        public const String GetDemoTokenInfosForPlayer = "GetDemoTokenInfosForPlayer";
        /// <summary>
        /// Disable player horns. Only available to Admin.
        /// </summary>
        /// <example>
        /// DisableHorns (boolean)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String DisableHorns = "DisableHorns";
        /// <summary>
        /// Returns whether the horns are disabled.
        /// </summary>
        /// <example>
        /// AreHornsDisabled ()
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String AreHornsDisabled = "AreHornsDisabled";
        /// <summary>
        /// Disable the automatic mesages when a player connects/disconnects from the server. Only available to Admin.
        /// </summary>
        /// <example>
        /// DisableServiceAnnounces (boolean)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String DisableServiceAnnounces = "DisableServiceAnnounces";
        /// <summary>
        /// Returns whether the automatic mesages are disabled.
        /// </summary>
        /// <example>
        /// AreServiceAnnouncesDisabled ()
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String AreServiceAnnouncesDisabled = "AreServiceAnnouncesDisabled";
        /// <summary>
        /// Enable the autosaving of all replays (vizualisable replays with all players, but not validable) on the server. Only available to SuperAdmin.
        /// </summary>
        /// <example>
        /// AutoSaveReplays (boolean)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String AutoSaveReplays = "AutoSaveReplays";
        /// <summary>
        /// Enable the autosaving on the server of validation replays, every time a player makes a new time. Only available to SuperAdmin.
        /// </summary>
        /// <example>
        /// AutoSaveValidationReplays (boolean)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String AutoSaveValidationReplays = "AutoSaveValidationReplays";
        /// <summary>
        /// Returns if autosaving of all replays is enabled on the server.
        /// </summary>
        /// <example>
        /// IsAutoSaveReplaysEnabled ()
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String IsAutoSaveReplaysEnabled = "IsAutoSaveReplaysEnabled";
        /// <summary>
        /// Returns if autosaving of validation replays is enabled on the server.
        /// </summary>
        /// <example>
        /// IsAutoSaveValidationReplaysEnabled ()
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String IsAutoSaveValidationReplaysEnabled = "IsAutoSaveValidationReplaysEnabled";
        /// <summary>
        /// Saves the current replay (vizualisable replays with all players, but not validable). Pass a filename, or '' for an automatic filename. Only available to Admin.
        /// </summary>
        /// <example>
        /// SaveCurrentReplay (string)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SaveCurrentReplay = "SaveCurrentReplay";
        /// <summary>
        /// Saves a replay with the ghost of all the players' best race. First parameter is the login of the player (or '' for all players), Second parameter is the filename, or '' for an automatic filename. Only available to Admin.
        /// </summary>
        /// <example>
        /// SaveBestGhostsReplay (string,string)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SaveBestGhostsReplay = "SaveBestGhostsReplay";
        /// <summary>
        /// Returns a replay containing the data needed to validate the current best time of the player. The parameter is the login of the player.
        /// </summary>
        /// <example>
        /// GetValidationReplay (string)
        /// </example>
        /// <returns>
        /// base64
        /// </returns>
        public const String GetValidationReplay = "GetValidationReplay";
        /// <summary>
        /// Set a new ladder mode between ladder disabled (0) and forced (1). Only available to Admin. Requires a map restart to be taken into account.
        /// </summary>
        /// <example>
        /// SetLadderMode (int)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SetLadderMode = "SetLadderMode";
        /// <summary>
        ///
        /// </summary>
        /// <example>
        /// GetLadderMode ()
        /// </example>
        /// <returns>
        /// struct
        /// </returns>
        public const String GetLadderMode = "GetLadderMode";
        /// <summary>
        ///
        /// </summary>
        /// <example>
        /// GetLadderServerLimits ()
        /// </example>
        /// <returns>
        /// struct
        /// </returns>
        public const String GetLadderServerLimits = "GetLadderServerLimits";
        /// <summary>
        /// Set the network vehicle quality to Fast (0) or High (1). Only available to Admin. Requires a map restart to be taken into account.
        /// </summary>
        /// <example>
        /// SetVehicleNetQuality (int)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SetVehicleNetQuality = "SetVehicleNetQuality";
        /// <summary>
        ///
        /// </summary>
        /// <example>
        /// GetVehicleNetQuality ()
        /// </example>
        /// <returns>
        /// struct
        /// </returns>
        public const String GetVehicleNetQuality = "GetVehicleNetQuality";
        /// <summary>
        ///
        /// </summary>
        /// <example>
        /// SetServerOptions (struct)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SetServerOptions = "SetServerOptions";
        /// <summary>
        ///
        /// </summary>
        /// <example>
        /// GetServerOptions ()
        /// </example>
        /// <returns>
        /// struct
        /// </returns>
        public const String GetServerOptions = "GetServerOptions";
        /// <summary>
        /// Set whether the players can choose their side or if the teams are forced by the server (using ForcePlayerTeam()). Only available to Admin.
        /// </summary>
        /// <example>
        /// SetForcedTeams (boolean)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SetForcedTeams = "SetForcedTeams";
        /// <summary>
        /// Returns whether the players can choose their side or if the teams are forced by the server.
        /// </summary>
        /// <example>
        /// GetForcedTeams ()
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String GetForcedTeams = "GetForcedTeams";
        /// <summary>
        ///
        /// </summary>
        /// <example>
        /// SetForcedMods (boolean,array)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SetForcedMods = "SetForcedMods";
        /// <summary>
        /// Get the mods settings.
        /// </summary>
        /// <example>
        /// GetForcedMods ()
        /// </example>
        /// <returns>
        /// struct
        /// </returns>
        public const String GetForcedMods = "GetForcedMods";
        /// <summary>
        ///
        /// </summary>
        /// <example>
        /// SetForcedMusic (boolean,string)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SetForcedMusic = "SetForcedMusic";
        /// <summary>
        /// Get the music setting.
        /// </summary>
        /// <example>
        /// GetForcedMusic ()
        /// </example>
        /// <returns>
        /// struct
        /// </returns>
        public const String GetForcedMusic = "GetForcedMusic";
        /// <summary>
        ///
        /// </summary>
        /// <example>
        /// SetForcedSkins (array)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SetForcedSkins = "SetForcedSkins";
        /// <summary>
        /// Get the current forced skins.
        /// </summary>
        /// <example>
        /// GetForcedSkins ()
        /// </example>
        /// <returns>
        /// array
        /// </returns>
        public const String GetForcedSkins = "GetForcedSkins";
        /// <summary>
        /// Returns the last error message for an internet connection. Only available to Admin.
        /// </summary>
        /// <example>
        /// GetLastConnectionErrorMessage ()
        /// </example>
        /// <returns>
        /// string
        /// </returns>
        public const String GetLastConnectionErrorMessage = "GetLastConnectionErrorMessage";
        /// <summary>
        /// Set a new password for the referee mode. Only available to Admin.
        /// </summary>
        /// <example>
        /// SetRefereePassword (string)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SetRefereePassword = "SetRefereePassword";
        /// <summary>
        /// Get the password for referee mode if called as Admin or Super Admin, else returns if a password is needed or not.
        /// </summary>
        /// <example>
        /// GetRefereePassword ()
        /// </example>
        /// <returns>
        /// string
        /// </returns>
        public const String GetRefereePassword = "GetRefereePassword";
        /// <summary>
        /// Set the referee validation mode. 0 = validate the top3 players, 1 = validate all players. Only available to Admin.
        /// </summary>
        /// <example>
        /// SetRefereeMode (int)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SetRefereeMode = "SetRefereeMode";
        /// <summary>
        /// Get the referee validation mode.
        /// </summary>
        /// <example>
        /// GetRefereeMode ()
        /// </example>
        /// <returns>
        /// int
        /// </returns>
        public const String GetRefereeMode = "GetRefereeMode";
        /// <summary>
        /// Set whether the game should use a variable validation seed or not. Only available to Admin. Requires a map restart to be taken into account.
        /// </summary>
        /// <example>
        /// SetUseChangingValidationSeed (boolean)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SetUseChangingValidationSeed = "SetUseChangingValidationSeed";
        /// <summary>
        ///
        /// </summary>
        /// <example>
        /// GetUseChangingValidationSeed ()
        /// </example>
        /// <returns>
        /// struct
        /// </returns>
        public const String GetUseChangingValidationSeed = "GetUseChangingValidationSeed";
        /// <summary>
        /// Set the maximum time the server must wait for inputs from the clients before dropping data, or '0' for auto-adaptation. Only used by ShootMania. Only available to Admin.
        /// </summary>
        /// <example>
        /// SetClientInputsMaxLatency (int)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SetClientInputsMaxLatency = "SetClientInputsMaxLatency";
        /// <summary>
        /// Get the current ClientInputsMaxLatency. Only used by ShootMania.
        /// </summary>
        /// <example>
        /// GetClientInputsMaxLatency ()
        /// </example>
        /// <returns>
        /// int
        /// </returns>
        public const String GetClientInputsMaxLatency = "GetClientInputsMaxLatency";
        /// <summary>
        /// Sets whether the server is in warm-up phase or not. Only available to Admin.
        /// </summary>
        /// <example>
        /// SetWarmUp (boolean)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SetWarmUp = "SetWarmUp";
        /// <summary>
        /// Returns whether the server is in warm-up phase.
        /// </summary>
        /// <example>
        /// GetWarmUp ()
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String GetWarmUp = "GetWarmUp";
        /// <summary>
        /// Get the current mode script.
        /// </summary>
        /// <example>
        /// GetModeScriptText ()
        /// </example>
        /// <returns>
        /// string
        /// </returns>
        public const String GetModeScriptText = "GetModeScriptText";
        /// <summary>
        /// Set the mode script and restart. Only available to Admin.
        /// </summary>
        /// <example>
        /// SetModeScriptText (string)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SetModeScriptText = "SetModeScriptText";
        /// <summary>
        /// Returns the description of the current mode script, as a structure containing: Name, CompatibleTypes, Description, Version and the settings available.
        /// </summary>
        /// <example>
        /// GetModeScriptInfo ()
        /// </example>
        /// <returns>
        /// struct
        /// </returns>
        public const String GetModeScriptInfo = "GetModeScriptInfo";
        /// <summary>
        /// Returns the current settings of the mode script.
        /// </summary>
        /// <example>
        /// GetModeScriptSettings ()
        /// </example>
        /// <returns>
        /// struct
        /// </returns>
        public const String GetModeScriptSettings = "GetModeScriptSettings";
        /// <summary>
        /// Change the settings of the mode script. Only available to Admin.
        /// </summary>
        /// <example>
        /// SetModeScriptSettings (struct)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SetModeScriptSettings = "SetModeScriptSettings";
        /// <summary>
        /// Send commands to the mode script. Only available to Admin.
        /// </summary>
        /// <example>
        /// SendModeScriptCommands (struct)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SendModeScriptCommands = "SendModeScriptCommands";
        /// <summary>
        /// Change the settings and send commands to the mode script. Only available to Admin.
        /// </summary>
        /// <example>
        /// SetModeScriptSettingsAndCommands (struct,struct)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SetModeScriptSettingsAndCommands = "SetModeScriptSettingsAndCommands";
        /// <summary>
        /// Returns the current xml-rpc variables of the mode script.
        /// </summary>
        /// <example>
        /// GetModeScriptVariables ()
        /// </example>
        /// <returns>
        /// struct
        /// </returns>
        public const String GetModeScriptVariables = "GetModeScriptVariables";
        /// <summary>
        /// Set the xml-rpc variables of the mode script. Only available to Admin.
        /// </summary>
        /// <example>
        /// SetModeScriptVariables (struct)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SetModeScriptVariables = "SetModeScriptVariables";
        /// <summary>
        /// Send an event to the mode script. Only available to Admin.
        /// </summary>
        /// <example>
        /// TriggerModeScriptEvent (string,string)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String TriggerModeScriptEvent = "TriggerModeScriptEvent";
        /// <summary>
        /// Send an event to the mode script. Only available to Admin.
        /// </summary>
        /// <example>
        /// TriggerModeScriptEventArray (string,array)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String TriggerModeScriptEventArray = "TriggerModeScriptEventArray";
        /// <summary>
        ///
        /// </summary>
        /// <example>
        /// SetServerPlugin (boolean,string,struct)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SetServerPlugin = "SetServerPlugin";
        /// <summary>
        /// Get the ServerPlugin current settings.
        /// </summary>
        /// <example>
        /// GetServerPlugin ()
        /// </example>
        /// <returns>
        /// struct
        /// </returns>
        public const String GetServerPlugin = "GetServerPlugin";
        /// <summary>
        /// Returns the current xml-rpc variables of the server script.
        /// </summary>
        /// <example>
        /// GetServerPluginVariables ()
        /// </example>
        /// <returns>
        /// struct
        /// </returns>
        public const String GetServerPluginVariables = "GetServerPluginVariables";
        /// <summary>
        /// Set the xml-rpc variables of the server script. Only available to Admin.
        /// </summary>
        /// <example>
        /// SetServerPluginVariables (struct)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SetServerPluginVariables = "SetServerPluginVariables";
        /// <summary>
        /// Send an event to the server script. Only available to Admin.
        /// </summary>
        /// <example>
        /// TriggerServerPluginEvent (string,string)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String TriggerServerPluginEvent = "TriggerServerPluginEvent";
        /// <summary>
        /// Send an event to the server script. Only available to Admin.
        /// </summary>
        /// <example>
        /// TriggerServerPluginEventArray (string,array)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String TriggerServerPluginEventArray = "TriggerServerPluginEventArray";
        /// <summary>
        /// Get the script cloud variables of given object. Only available to Admin.
        /// </summary>
        /// <example>
        /// GetScriptCloudVariables (string,string)
        /// </example>
        /// <returns>
        /// struct
        /// </returns>
        public const String GetScriptCloudVariables = "GetScriptCloudVariables";
        /// <summary>
        /// Set the script cloud variables of given object. Only available to Admin.
        /// </summary>
        /// <example>
        /// SetScriptCloudVariables (string,string,struct)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SetScriptCloudVariables = "SetScriptCloudVariables";
        /// <summary>
        ///
        /// </summary>
        /// <example>
        /// RestartMap ()
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String RestartMap = "RestartMap";
        /// <summary>
        ///
        /// </summary>
        /// <example>
        /// NextMap ()
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String NextMap = "NextMap";
        /// <summary>
        /// Attempt to balance teams. Only available to Admin.
        /// </summary>
        /// <example>
        /// AutoTeamBalance ()
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String AutoTeamBalance = "AutoTeamBalance";
        /// <summary>
        /// Stop the server. Only available to SuperAdmin.
        /// </summary>
        /// <example>
        /// StopServer ()
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String StopServer = "StopServer";
        /// <summary>
        /// In Rounds or Laps mode, force the end of round without waiting for all players to giveup/finish. Only available to Admin.
        /// </summary>
        /// <example>
        /// ForceEndRound ()
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String ForceEndRound = "ForceEndRound";
        /// <summary>
        ///
        /// </summary>
        /// <example>
        /// SetGameInfos (struct)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SetGameInfos = "SetGameInfos";
        /// <summary>
        ///
        /// </summary>
        /// <example>
        /// GetCurrentGameInfo ()
        /// </example>
        /// <returns>
        /// struct
        /// </returns>
        public const String GetCurrentGameInfo = "GetCurrentGameInfo";
        /// <summary>
        ///
        /// </summary>
        /// <example>
        /// GetNextGameInfo ()
        /// </example>
        /// <returns>
        /// struct
        /// </returns>
        public const String GetNextGameInfo = "GetNextGameInfo";
        /// <summary>
        ///
        /// </summary>
        /// <example>
        /// GetGameInfos ()
        /// </example>
        /// <returns>
        /// struct
        /// </returns>
        public const String GetGameInfos = "GetGameInfos";
        /// <summary>
        /// Set a new game mode between Script (0), Rounds (1), TimeAttack (2), Team (3), Laps (4), Cup (5) and Stunts (6). Only available to Admin. Requires a map restart to be taken into account.
        /// </summary>
        /// <example>
        /// SetGameMode (int)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SetGameMode = "SetGameMode";
        /// <summary>
        /// Get the current game mode.
        /// </summary>
        /// <example>
        /// GetGameMode ()
        /// </example>
        /// <returns>
        /// int
        /// </returns>
        public const String GetGameMode = "GetGameMode";
        /// <summary>
        /// Set a new chat time value in milliseconds (actually 'chat time' is the duration of the end race podium, 0 means no podium displayed.). Only available to Admin.
        /// </summary>
        /// <example>
        /// SetChatTime (int)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SetChatTime = "SetChatTime";
        /// <summary>
        ///
        /// </summary>
        /// <example>
        /// GetChatTime ()
        /// </example>
        /// <returns>
        /// struct
        /// </returns>
        public const String GetChatTime = "GetChatTime";
        /// <summary>
        /// Set a new finish timeout (for rounds/laps mode) value in milliseconds. 0 means default. 1 means adaptative to the duration of the map. Only available to Admin. Requires a map restart to be taken into account.
        /// </summary>
        /// <example>
        /// SetFinishTimeout (int)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SetFinishTimeout = "SetFinishTimeout";
        /// <summary>
        ///
        /// </summary>
        /// <example>
        /// GetFinishTimeout ()
        /// </example>
        /// <returns>
        /// struct
        /// </returns>
        public const String GetFinishTimeout = "GetFinishTimeout";
        /// <summary>
        /// Set whether to enable the automatic warm-up phase in all modes. 0 = no, otherwise it's the duration of the phase, expressed in number of rounds (in rounds/team mode), or in number of times the gold medal time (other modes). Only available to Admin. Requires a map restart to be taken into account.
        /// </summary>
        /// <example>
        /// SetAllWarmUpDuration (int)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SetAllWarmUpDuration = "SetAllWarmUpDuration";
        /// <summary>
        ///
        /// </summary>
        /// <example>
        /// GetAllWarmUpDuration ()
        /// </example>
        /// <returns>
        /// struct
        /// </returns>
        public const String GetAllWarmUpDuration = "GetAllWarmUpDuration";
        /// <summary>
        /// Set whether to disallow players to respawn. Only available to Admin. Requires a map restart to be taken into account.
        /// </summary>
        /// <example>
        /// SetDisableRespawn (boolean)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SetDisableRespawn = "SetDisableRespawn";
        /// <summary>
        ///
        /// </summary>
        /// <example>
        /// GetDisableRespawn ()
        /// </example>
        /// <returns>
        /// struct
        /// </returns>
        public const String GetDisableRespawn = "GetDisableRespawn";
        /// <summary>
        /// Set whether to override the players preferences and always display all opponents (0=no override, 1=show all, other value=minimum number of opponents). Only available to Admin. Requires a map restart to be taken into account.
        /// </summary>
        /// <example>
        /// SetForceShowAllOpponents (int)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SetForceShowAllOpponents = "SetForceShowAllOpponents";
        /// <summary>
        ///
        /// </summary>
        /// <example>
        /// GetForceShowAllOpponents ()
        /// </example>
        /// <returns>
        /// struct
        /// </returns>
        public const String GetForceShowAllOpponents = "GetForceShowAllOpponents";
        /// <summary>
        /// Set a new mode script name for script mode. Only available to Admin. Requires a map restart to be taken into account.
        /// </summary>
        /// <example>
        /// SetScriptName (string)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SetScriptName = "SetScriptName";
        /// <summary>
        ///
        /// </summary>
        /// <example>
        /// GetScriptName ()
        /// </example>
        /// <returns>
        /// struct
        /// </returns>
        public const String GetScriptName = "GetScriptName";
        /// <summary>
        /// Set a new time limit for time attack mode. Only available to Admin. Requires a map restart to be taken into account.
        /// </summary>
        /// <example>
        /// SetTimeAttackLimit (int)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SetTimeAttackLimit = "SetTimeAttackLimit";
        /// <summary>
        ///
        /// </summary>
        /// <example>
        /// GetTimeAttackLimit ()
        /// </example>
        /// <returns>
        /// struct
        /// </returns>
        public const String GetTimeAttackLimit = "GetTimeAttackLimit";
        /// <summary>
        /// Set a new synchronized start period for time attack mode. Only available to Admin. Requires a map restart to be taken into account.
        /// </summary>
        /// <example>
        /// SetTimeAttackSynchStartPeriod (int)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SetTimeAttackSynchStartPeriod = "SetTimeAttackSynchStartPeriod";
        /// <summary>
        ///
        /// </summary>
        /// <example>
        /// GetTimeAttackSynchStartPeriod ()
        /// </example>
        /// <returns>
        /// struct
        /// </returns>
        public const String GetTimeAttackSynchStartPeriod = "GetTimeAttackSynchStartPeriod";
        /// <summary>
        /// Set a new time limit for laps mode. Only available to Admin. Requires a map restart to be taken into account.
        /// </summary>
        /// <example>
        /// SetLapsTimeLimit (int)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SetLapsTimeLimit = "SetLapsTimeLimit";
        /// <summary>
        ///
        /// </summary>
        /// <example>
        /// GetLapsTimeLimit ()
        /// </example>
        /// <returns>
        /// struct
        /// </returns>
        public const String GetLapsTimeLimit = "GetLapsTimeLimit";
        /// <summary>
        /// Set a new number of laps for laps mode. Only available to Admin. Requires a map restart to be taken into account.
        /// </summary>
        /// <example>
        /// SetNbLaps (int)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SetNbLaps = "SetNbLaps";
        /// <summary>
        ///
        /// </summary>
        /// <example>
        /// GetNbLaps ()
        /// </example>
        /// <returns>
        /// struct
        /// </returns>
        public const String GetNbLaps = "GetNbLaps";
        /// <summary>
        /// Set a new number of laps for rounds mode (0 = default, use the number of laps from the maps, otherwise forces the number of rounds for multilaps maps). Only available to Admin. Requires a map restart to be taken into account.
        /// </summary>
        /// <example>
        /// SetRoundForcedLaps (int)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SetRoundForcedLaps = "SetRoundForcedLaps";
        /// <summary>
        ///
        /// </summary>
        /// <example>
        /// GetRoundForcedLaps ()
        /// </example>
        /// <returns>
        /// struct
        /// </returns>
        public const String GetRoundForcedLaps = "GetRoundForcedLaps";
        /// <summary>
        /// Set a new points limit for rounds mode (value set depends on UseNewRulesRound). Only available to Admin. Requires a map restart to be taken into account.
        /// </summary>
        /// <example>
        /// SetRoundPointsLimit (int)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SetRoundPointsLimit = "SetRoundPointsLimit";
        /// <summary>
        ///
        /// </summary>
        /// <example>
        /// GetRoundPointsLimit ()
        /// </example>
        /// <returns>
        /// struct
        /// </returns>
        public const String GetRoundPointsLimit = "GetRoundPointsLimit";
        /// <summary>
        ///
        /// </summary>
        /// <example>
        /// SetRoundCustomPoints (array,boolean)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SetRoundCustomPoints = "SetRoundCustomPoints";
        /// <summary>
        /// Gets the points used for the scores in rounds mode.
        /// </summary>
        /// <example>
        /// GetRoundCustomPoints ()
        /// </example>
        /// <returns>
        /// array
        /// </returns>
        public const String GetRoundCustomPoints = "GetRoundCustomPoints";
        /// <summary>
        /// Set if new rules are used for rounds mode. Only available to Admin. Requires a map restart to be taken into account.
        /// </summary>
        /// <example>
        /// SetUseNewRulesRound (boolean)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SetUseNewRulesRound = "SetUseNewRulesRound";
        /// <summary>
        ///
        /// </summary>
        /// <example>
        /// GetUseNewRulesRound ()
        /// </example>
        /// <returns>
        /// struct
        /// </returns>
        public const String GetUseNewRulesRound = "GetUseNewRulesRound";
        /// <summary>
        /// Set a new points limit for team mode (value set depends on UseNewRulesTeam). Only available to Admin. Requires a map restart to be taken into account.
        /// </summary>
        /// <example>
        /// SetTeamPointsLimit (int)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SetTeamPointsLimit = "SetTeamPointsLimit";
        /// <summary>
        ///
        /// </summary>
        /// <example>
        /// GetTeamPointsLimit ()
        /// </example>
        /// <returns>
        /// struct
        /// </returns>
        public const String GetTeamPointsLimit = "GetTeamPointsLimit";
        /// <summary>
        /// Set a new number of maximum points per round for team mode. Only available to Admin. Requires a map restart to be taken into account.
        /// </summary>
        /// <example>
        /// SetMaxPointsTeam (int)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SetMaxPointsTeam = "SetMaxPointsTeam";
        /// <summary>
        ///
        /// </summary>
        /// <example>
        /// GetMaxPointsTeam ()
        /// </example>
        /// <returns>
        /// struct
        /// </returns>
        public const String GetMaxPointsTeam = "GetMaxPointsTeam";
        /// <summary>
        /// Set if new rules are used for team mode. Only available to Admin. Requires a map restart to be taken into account.
        /// </summary>
        /// <example>
        /// SetUseNewRulesTeam (boolean)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SetUseNewRulesTeam = "SetUseNewRulesTeam";
        /// <summary>
        ///
        /// </summary>
        /// <example>
        /// GetUseNewRulesTeam ()
        /// </example>
        /// <returns>
        /// struct
        /// </returns>
        public const String GetUseNewRulesTeam = "GetUseNewRulesTeam";
        /// <summary>
        /// Set the points needed for victory in Cup mode. Only available to Admin. Requires a map restart to be taken into account.
        /// </summary>
        /// <example>
        /// SetCupPointsLimit (int)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SetCupPointsLimit = "SetCupPointsLimit";
        /// <summary>
        ///
        /// </summary>
        /// <example>
        /// GetCupPointsLimit ()
        /// </example>
        /// <returns>
        /// struct
        /// </returns>
        public const String GetCupPointsLimit = "GetCupPointsLimit";
        /// <summary>
        /// Sets the number of rounds before going to next map in Cup mode. Only available to Admin. Requires a map restart to be taken into account.
        /// </summary>
        /// <example>
        /// SetCupRoundsPerMap (int)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SetCupRoundsPerMap = "SetCupRoundsPerMap";
        /// <summary>
        ///
        /// </summary>
        /// <example>
        /// GetCupRoundsPerMap ()
        /// </example>
        /// <returns>
        /// struct
        /// </returns>
        public const String GetCupRoundsPerMap = "GetCupRoundsPerMap";
        /// <summary>
        /// Set whether to enable the automatic warm-up phase in Cup mode. 0 = no, otherwise it's the duration of the phase, expressed in number of rounds. Only available to Admin. Requires a map restart to be taken into account.
        /// </summary>
        /// <example>
        /// SetCupWarmUpDuration (int)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SetCupWarmUpDuration = "SetCupWarmUpDuration";
        /// <summary>
        ///
        /// </summary>
        /// <example>
        /// GetCupWarmUpDuration ()
        /// </example>
        /// <returns>
        /// struct
        /// </returns>
        public const String GetCupWarmUpDuration = "GetCupWarmUpDuration";
        /// <summary>
        /// Set the number of winners to determine before the match is considered over. Only available to Admin. Requires a map restart to be taken into account.
        /// </summary>
        /// <example>
        /// SetCupNbWinners (int)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SetCupNbWinners = "SetCupNbWinners";
        /// <summary>
        ///
        /// </summary>
        /// <example>
        /// GetCupNbWinners ()
        /// </example>
        /// <returns>
        /// struct
        /// </returns>
        public const String GetCupNbWinners = "GetCupNbWinners";
        /// <summary>
        /// Returns the current map index in the selection, or -1 if the map is no longer in the selection.
        /// </summary>
        /// <example>
        /// GetCurrentMapIndex ()
        /// </example>
        /// <returns>
        /// int
        /// </returns>
        public const String GetCurrentMapIndex = "GetCurrentMapIndex";
        /// <summary>
        /// Returns the map index in the selection that will be played next (unless the current one is restarted...)
        /// </summary>
        /// <example>
        /// GetNextMapIndex ()
        /// </example>
        /// <returns>
        /// int
        /// </returns>
        public const String GetNextMapIndex = "GetNextMapIndex";
        /// <summary>
        /// Sets the map index in the selection that will be played next (unless the current one is restarted...)
        /// </summary>
        /// <example>
        /// SetNextMapIndex (int)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SetNextMapIndex = "SetNextMapIndex";
        /// <summary>
        /// Sets the map in the selection that will be played next (unless the current one is restarted...)
        /// </summary>
        /// <example>
        /// SetNextMapIdent (string)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SetNextMapIdent = "SetNextMapIdent";
        /// <summary>
        /// Immediately jumps to the map designated by the index in the selection.
        /// </summary>
        /// <example>
        /// JumpToMapIndex (int)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String JumpToMapIndex = "JumpToMapIndex";
        /// <summary>
        /// Immediately jumps to the map designated by its identifier (it must be in the selection).
        /// </summary>
        /// <example>
        /// JumpToMapIdent (string)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String JumpToMapIdent = "JumpToMapIdent";
        /// <summary>
        ///
        /// </summary>
        /// <example>
        /// GetCurrentMapInfo ()
        /// </example>
        /// <returns>
        /// struct
        /// </returns>
        public const String GetCurrentMapInfo = "GetCurrentMapInfo";
        /// <summary>
        ///
        /// </summary>
        /// <example>
        /// GetNextMapInfo ()
        /// </example>
        /// <returns>
        /// struct
        /// </returns>
        public const String GetNextMapInfo = "GetNextMapInfo";
        /// <summary>
        ///
        /// </summary>
        /// <example>
        /// GetMapInfo (string)
        /// </example>
        /// <returns>
        /// struct
        /// </returns>
        public const String GetMapInfo = "GetMapInfo";
        /// <summary>
        /// Returns a boolean if the map with the specified filename matches the current server settings.
        /// </summary>
        /// <example>
        /// CheckMapForCurrentServerParams (string)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String CheckMapForCurrentServerParams = "CheckMapForCurrentServerParams";
        /// <summary>
        ///
        /// </summary>
        /// <example>
        /// GetMapList (int,int)
        /// </example>
        /// <returns>
        /// array
        /// </returns>
        public const String GetMapList = "GetMapList";
        /// <summary>
        /// Add the map with the specified filename at the end of the current selection. Only available to Admin.
        /// </summary>
        /// <example>
        /// AddMap (string)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String AddMap = "AddMap";
        /// <summary>
        /// Add the list of maps with the specified filenames at the end of the current selection. The list of maps to add is an array of strings. Only available to Admin.
        /// </summary>
        /// <example>
        /// AddMapList (array)
        /// </example>
        /// <returns>
        /// int
        /// </returns>
        public const String AddMapList = "AddMapList";
        /// <summary>
        /// Remove the map with the specified filename from the current selection. Only available to Admin.
        /// </summary>
        /// <example>
        /// RemoveMap (string)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String RemoveMap = "RemoveMap";
        /// <summary>
        /// Remove the list of maps with the specified filenames from the current selection. The list of maps to remove is an array of strings. Only available to Admin.
        /// </summary>
        /// <example>
        /// RemoveMapList (array)
        /// </example>
        /// <returns>
        /// int
        /// </returns>
        public const String RemoveMapList = "RemoveMapList";
        /// <summary>
        /// Insert the map with the specified filename after the current map. Only available to Admin.
        /// </summary>
        /// <example>
        /// InsertMap (string)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String InsertMap = "InsertMap";
        /// <summary>
        /// Insert the list of maps with the specified filenames after the current map. The list of maps to insert is an array of strings. Only available to Admin.
        /// </summary>
        /// <example>
        /// InsertMapList (array)
        /// </example>
        /// <returns>
        /// int
        /// </returns>
        public const String InsertMapList = "InsertMapList";
        /// <summary>
        /// Set as next map the one with the specified filename, if it is present in the selection. Only available to Admin.
        /// </summary>
        /// <example>
        /// ChooseNextMap (string)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String ChooseNextMap = "ChooseNextMap";
        /// <summary>
        /// Set as next maps the list of maps with the specified filenames, if they are present in the selection. The list of maps to choose is an array of strings. Only available to Admin.
        /// </summary>
        /// <example>
        /// ChooseNextMapList (array)
        /// </example>
        /// <returns>
        /// int
        /// </returns>
        public const String ChooseNextMapList = "ChooseNextMapList";
        /// <summary>
        /// Set a list of maps defined in the playlist with the specified filename as the current selection of the server, and load the gameinfos from the same file. Only available to Admin.
        /// </summary>
        /// <example>
        /// LoadMatchSettings (string)
        /// </example>
        /// <returns>
        /// int
        /// </returns>
        public const String LoadMatchSettings = "LoadMatchSettings";
        /// <summary>
        /// Add a list of maps defined in the playlist with the specified filename at the end of the current selection. Only available to Admin.
        /// </summary>
        /// <example>
        /// AppendPlaylistFromMatchSettings (string)
        /// </example>
        /// <returns>
        /// int
        /// </returns>
        public const String AppendPlaylistFromMatchSettings = "AppendPlaylistFromMatchSettings";
        /// <summary>
        /// Save the current selection of map in the playlist with the specified filename, as well as the current gameinfos. Only available to Admin.
        /// </summary>
        /// <example>
        /// SaveMatchSettings (string)
        /// </example>
        /// <returns>
        /// int
        /// </returns>
        public const String SaveMatchSettings = "SaveMatchSettings";
        /// <summary>
        /// Insert a list of maps defined in the playlist with the specified filename after the current map. Only available to Admin.
        /// </summary>
        /// <example>
        /// InsertPlaylistFromMatchSettings (string)
        /// </example>
        /// <returns>
        /// int
        /// </returns>
        public const String InsertPlaylistFromMatchSettings = "InsertPlaylistFromMatchSettings";
        /// <summary>
        ///
        /// </summary>
        /// <example>
        /// GetPlayerList (int,int,int)
        /// </example>
        /// <returns>
        /// array
        /// </returns>
        public const String GetPlayerList = "GetPlayerList";
        /// <summary>
        ///
        /// </summary>
        /// <example>
        /// GetPlayerInfo (string,int)
        /// </example>
        /// <returns>
        /// struct
        /// </returns>
        public const String GetPlayerInfo = "GetPlayerInfo";
        /// <summary>
        ///
        /// </summary>
        /// <example>
        /// GetDetailedPlayerInfo (string)
        /// </example>
        /// <returns>
        /// struct
        /// </returns>
        public const String GetDetailedPlayerInfo = "GetDetailedPlayerInfo";
        /// <summary>
        ///
        /// </summary>
        /// <example>
        /// GetMainServerPlayerInfo (int)
        /// </example>
        /// <returns>
        /// struct
        /// </returns>
        public const String GetMainServerPlayerInfo = "GetMainServerPlayerInfo";
        /// <summary>
        ///
        /// </summary>
        /// <example>
        /// GetCurrentRanking (int,int)
        /// </example>
        /// <returns>
        /// array
        /// </returns>
        public const String GetCurrentRanking = "GetCurrentRanking";
        /// <summary>
        ///
        /// </summary>
        /// <example>
        /// GetCurrentRankingForLogin (string)
        /// </example>
        /// <returns>
        /// array
        /// </returns>
        public const String GetCurrentRankingForLogin = "GetCurrentRankingForLogin";
        /// <summary>
        /// Returns the current winning team for the race in progress. (-1: if not in team mode, or draw match)
        /// </summary>
        /// <example>
        /// GetCurrentWinnerTeam ()
        /// </example>
        /// <returns>
        /// int
        /// </returns>
        public const String GetCurrentWinnerTeam = "GetCurrentWinnerTeam";
        /// <summary>
        ///
        /// </summary>
        /// <example>
        /// ForceScores (array,boolean)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String ForceScores = "ForceScores";
        /// <summary>
        /// Force the team of the player. Only available in team mode. You have to pass the login and the team number (0 or 1). Only available to Admin.
        /// </summary>
        /// <example>
        /// ForcePlayerTeam (string,int)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String ForcePlayerTeam = "ForcePlayerTeam";
        /// <summary>
        /// Force the team of the player. Only available in team mode. You have to pass the playerid and the team number (0 or 1). Only available to Admin.
        /// </summary>
        /// <example>
        /// ForcePlayerTeamId (int,int)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String ForcePlayerTeamId = "ForcePlayerTeamId";
        /// <summary>
        /// Force the spectating status of the player. You have to pass the login and the spectator mode (0: user selectable, 1: spectator, 2: player, 3: spectator but keep selectable). Only available to Admin.
        /// </summary>
        /// <example>
        /// ForceSpectator (string,int)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String ForceSpectator = "ForceSpectator";
        /// <summary>
        /// Force the spectating status of the player. You have to pass the playerid and the spectator mode (0: user selectable, 1: spectator, 2: player, 3: spectator but keep selectable). Only available to Admin.
        /// </summary>
        /// <example>
        /// ForceSpectatorId (int,int)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String ForceSpectatorId = "ForceSpectatorId";
        /// <summary>
        /// Force spectators to look at a specific player. You have to pass the login of the spectator (or '' for all) and the login of the target (or '' for automatic), and an integer for the camera type to use (-1 = leave unchanged, 0 = replay, 1 = follow, 2 = free). Only available to Admin.
        /// </summary>
        /// <example>
        /// ForceSpectatorTarget (string,string,int)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String ForceSpectatorTarget = "ForceSpectatorTarget";
        /// <summary>
        /// Force spectators to look at a specific player. You have to pass the id of the spectator (or -1 for all) and the id of the target (or -1 for automatic), and an integer for the camera type to use (-1 = leave unchanged, 0 = replay, 1 = follow, 2 = free). Only available to Admin.
        /// </summary>
        /// <example>
        /// ForceSpectatorTargetId (int,int,int)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String ForceSpectatorTargetId = "ForceSpectatorTargetId";
        /// <summary>
        /// Pass the login of the spectator. A spectator that once was a player keeps his player slot, so that he can go back to race mode. Calling this function frees this slot for another player to connect. Only available to Admin.
        /// </summary>
        /// <example>
        /// SpectatorReleasePlayerSlot (string)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SpectatorReleasePlayerSlot = "SpectatorReleasePlayerSlot";
        /// <summary>
        /// Pass the playerid of the spectator. A spectator that once was a player keeps his player slot, so that he can go back to race mode. Calling this function frees this slot for another player to connect. Only available to Admin.
        /// </summary>
        /// <example>
        /// SpectatorReleasePlayerSlotId (int)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String SpectatorReleasePlayerSlotId = "SpectatorReleasePlayerSlotId";
        /// <summary>
        /// Enable control of the game flow: the game will wait for the caller to validate state transitions. Only available to Admin.
        /// </summary>
        /// <example>
        /// ManualFlowControlEnable (boolean)
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String ManualFlowControlEnable = "ManualFlowControlEnable";
        /// <summary>
        /// Allows the game to proceed. Only available to Admin.
        /// </summary>
        /// <example>
        /// ManualFlowControlProceed ()
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String ManualFlowControlProceed = "ManualFlowControlProceed";
        /// <summary>
        /// Returns whether the manual control of the game flow is enabled. 0 = no, 1 = yes by the xml-rpc client making the call, 2 = yes, by some other xml-rpc client. Only available to Admin.
        /// </summary>
        /// <example>
        /// ManualFlowControlIsEnabled ()
        /// </example>
        /// <returns>
        /// int
        /// </returns>
        public const String ManualFlowControlIsEnabled = "ManualFlowControlIsEnabled";
        /// <summary>
        /// Returns the transition that is currently blocked, or '' if none. (That's exactly the value last received by the callback.) Only available to Admin.
        /// </summary>
        /// <example>
        /// ManualFlowControlGetCurTransition ()
        /// </example>
        /// <returns>
        /// string
        /// </returns>
        public const String ManualFlowControlGetCurTransition = "ManualFlowControlGetCurTransition";
        /// <summary>
        /// Returns the current match ending condition. Return values are: 'Playing', 'ChangeMap' or 'Finished'.
        /// </summary>
        /// <example>
        /// CheckEndMatchCondition ()
        /// </example>
        /// <returns>
        /// string
        /// </returns>
        public const String CheckEndMatchCondition = "CheckEndMatchCondition";
        /// <summary>
        ///
        /// </summary>
        /// <example>
        /// GetNetworkStats ()
        /// </example>
        /// <returns>
        /// struct
        /// </returns>
        public const String GetNetworkStats = "GetNetworkStats";
        /// <summary>
        /// Start a server on lan, using the current configuration. Only available to SuperAdmin.
        /// </summary>
        /// <example>
        /// StartServerLan ()
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String StartServerLan = "StartServerLan";
        /// <summary>
        /// Start a server on internet, using the current configuration. Only available to SuperAdmin.
        /// </summary>
        /// <example>
        /// StartServerInternet ()
        /// </example>
        /// <returns>
        /// boolean
        /// </returns>
        public const String StartServerInternet = "StartServerInternet";

    }
}
