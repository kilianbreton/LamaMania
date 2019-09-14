using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTK;
using static NTK.Other.NTKF;
using NTK.Service;
using NTK.Security;
using TMXmlRpcLib;

namespace XmlRpcEncrypted
{
    /// <summary>
    /// NTK Service Class to manage XmlRpcEncrypted over NTK
    /// </summary>
    public class SXmlRpcEncrypted : NTKService
    {
        public const string S_NAME = "XmlRpcEncrypted";
        const string XML_PREFIX = "XML{}_";
        const string NTK_PREFIX = "NTK{}_";
        
        //Server 
        XmlRpcClient _client;
        Dictionary<int, string> _handles = new Dictionary<int, string>();
       
        //Client
        GbxCallbackHandler _callBackHandler;
        GbxCallCallbackHandler _asyncHandler;
        NTKUser _user;
     
        //Common
        string _superLogin;
        string _superPass;
        bool _isServer;
        string _context;

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Constructors /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Server Constructor
        /// </summary>
        /// <param name="client"></param>
        /// <param name="superLogin"></param>
        /// <param name="superPass"></param>
        public SXmlRpcEncrypted(XmlRpcClient client, string superLogin, string superPass) : base(new ServiceConfig
        {
            authentification = true,
            name = S_NAME,
            useBasicListen = false
        })
        {
            this._client = client;
            this.userlist = new List<NTKUser>();
            _superLogin = superLogin;
            _superPass = superPass;
            _client.EventGbxCallback += new GbxCallbackHandler(gbxCallBack);
            _isServer = true;
            _context = "Server";
        }

        /// <summary>
        /// Client Constructor
        /// </summary>
        /// <param name="superLogin"></param>
        /// <param name="superPass"></param>
        /// <param name="callBackHandler"></param>
        /// <param name="asyncHandler"></param>
        public SXmlRpcEncrypted(string superLogin, string superPass, GbxCallbackHandler callBackHandler, GbxCallCallbackHandler mainAsyncHandler) : base(new ServiceConfig()
        {
            useBasicListen = false,
            name = S_NAME
        })
        {
            _superLogin = superLogin;
            _superPass = superPass;
            _asyncHandler = mainAsyncHandler;
            _callBackHandler = callBackHandler;
            _isServer = false;
            _context = "Client";
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Public NTK Methods ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public override void initialize(params object[] args)
        {
            throw new NotImplementedException();
        }

        //Client============================================================================================================================

        public override void c_authentification(NTKUser user)
        {
            if (_isServer)
                throw new NTKBadContextException(_context, "c_authentification");

            _user = user;
            user.writeMsg("SUPERADMIN>" + _superLogin + Separators.SV + _superPass + Separators.SPV);
            string msg = user.readMsg();
            if(msg == NTKCommands.A_OK)
            {

            }
            else
            {
                
            }
        }

        public override void c_listen(NTKUser user, string cmd)
        {
            if (_isServer)
                throw new NTKBadContextException(_context, "c_listen");
                

            // Commands Prefix :
            // XML{}_#Handle{,}#Xml{;}  : XmlResponse or XmlCallBack
            // NTK{}_                   : NTKCommands
            int.TryParse(subsep(cmd, XML_PREFIX, Separators.SV), out int handle);
            string xml = subsep(cmd, Separators.SV, Separators.SPV);
            GbxCall call = new GbxCall(handle, Encoding.UTF8.GetBytes(xml));
            if (xml.Contains("methodResponse"))
            {
                
                _asyncHandler(call);
            }
            else if (xml.Contains("methodCall"))
            {
                GbxCallbackEventArgs callBack = new GbxCallbackEventArgs(call);
                _callBackHandler(this, callBack);
            }
            
            
        }

        //Server============================================================================================================================

        /// <summary>
        /// Authentication
        /// </summary>
        /// <param name="user"></param>
        /// <param name="userlist"></param>
        /// <param name="listen"></param>
        public override void s_authentification(NTKUser user, List<NTKUser> userlist, ServicelistenFunction listen)
        {
            if (!_isServer)
                throw new NTKBadContextException(_context, "s_authentification");

            this.userlist = userlist;
            bool connected = false;
            int cpt = 0;
            while (!connected && cpt <= 3)
            {
                user.writeMsg(NTKCommands.C_RL);
                cpt++;
                string cmd = user.readMsg();
                if (cmd.Contains("SUPERADMIN>"))
                {
                    string login = subsep(cmd, "SUPERADMIN>", Separators.SV);
                    string pass = subsep(cmd, Separators.SV, Separators.SPV);

                    connected = (login.Equals(_superLogin) && pass.Equals(_superPass));
                }
            }

            if(connected)
            {
                
                user.writeMsg(NTKCommands.A_OK);
                this.userlist.Add(user);
                listen(user);
            }
            else
            {
                user.writeMsg(NTKCommands.A_BAD);
                user.IsBad = true;
            }

        }

        public override void s_listen(NTKUser user)
        {
            if (!_isServer)
                throw new NTKBadContextException(_context, "s_listen");


            bool stop = false;
            while (!stop)
            {
                string cmd = user.readMsg();
                if (cmd.Contains(XML_PREFIX))
                {
                    string handle = subsep(cmd, XML_PREFIX, Separators.SV);
                    if (handle.Equals("NONE"))
                    {
                        
                    }
                    else
                    {

                    }
                }
                else if (cmd.Contains(NTK_PREFIX))
                {

                }
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Public GBX Methods ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<int> c_asyncRequest(string methodName, object[] args, GbxCallCallbackHandler handler)
        {
            if (_isServer)
                throw new NTKBadContextException(_context, "c_asyncRequest");

            GbxCall call = new GbxCall(methodName, args);

            await _user.writeMsgAsync(XML_PREFIX + "NONE" + Separators.SV + call.Xml + Separators.SPV);
            string cmd = await _user.readMsgAsync();
            string sHandle = subsep(cmd, XML_PREFIX, Separators.SV);
            int.TryParse(sHandle, out int handle);
            return handle;
        }

        


        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Private GBX Methods //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void gbxCallBack(object sender, GbxCallbackEventArgs args)
        {
            foreach (NTKUser u in userlist)
            {
                u.writeMsg(XML_PREFIX + args.Response.Handle + Separators.SV + args.Response.Xml + Separators.SPV);
            }
        }

        void gbxAsyncResult(GbxCall res)
        {
            foreach(NTKUser u in userlist)
            {
                u.writeMsg("XML{}_" + res.Handle + Separators.SV + res.Xml + Separators.SPV);
            }
        }

        void asyncRequest(string methodName, params object[] args)
        {
            if (args == null)
                args = new object[] { };
            _handles.Add(_client.AsyncRequest(methodName, args, gbxAsyncResult), methodName);
        }



        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Exceptions ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        class NTKBadContextException : Exception
        {
            public NTKBadContextException(string context, string methodCalled) : 
                base("Unable to call : " + methodCalled + " in " + context + " context") { }
        }

    }
}
