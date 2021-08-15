/* ----------------------------------------------------------------------------------
 * Project : LamaMania
 * Launch Authenticate Manage & Access ManiaPlanet Servers
 * Inspired by ServerMania by Cyrlaur
 * 
 * ----------------------------------------------------------------------------------
 * Author:	    Breton Kilian
 * Copyright:	April 2019 by Breton Kilian
 * ----------------------------------------------------------------------------------
 *
 * LICENSE: This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.If not, see<http://www.gnu.org/licenses/>.
 *
 * ----------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using TMXmlRpcLib;
using NTK.IO;
using System.Threading.Tasks;

namespace LamaPlugin
{
    public delegate InterPluginResponse PMInterPluginCall(IBasePlugin sender, string targetName, InterPluginArgs args);
    

    /// <summary>
    /// Abstract class for plugins
    /// </summary>
    public abstract class InGamePlugin : IBasePlugin
    {
        private XmlRpcClient client;
        private PMInterPluginCall pmInterCall;
        protected Dictionary<int, string> handles = new Dictionary<int, string>();
        protected Dictionary<string, GbxCallbackHandler> Callbacks = new Dictionary<string, GbxCallbackHandler>();

        ///////////////////////////////////////////////////////////////////////////////////////////////////
        // CONSTRUCTOR ///////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Init
        /// </summary>
        public InGamePlugin() {
            this.PluginType = PluginType.InGamePlugin;
            this.Requirements = new List<Requirement>();
        }  

        /// <summary>
        /// Method for plugin manager
        /// </summary>
        /// <param name="client"></param>
        public void setClient(XmlRpcClient client)
        {
            this.client = client;
        }

        public void setPluginManager(PMInterPluginCall pmipc)
        {
            this.pmInterCall = pmipc;
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////////
        // PROTECTED /////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Send async request
        /// </summary>
        /// <param name="methodeName"></param>
        /// <param name="param"></param>
        protected void asyncRequest(String methodeName, params object[] param)
        {
            if (param == null)
                param = new object[] { };
            this.handles.Add(this.client.AsyncRequest(methodeName, param, onGbxAsyncResult), methodeName);
        }
    
        /// <summary>
        /// Async request
        /// </summary>
        /// <param name="handler">Call back method</param>
        /// <param name="methodName">The method name</param>
        /// <param name="param">Request params</param>
        protected void asyncRequest(GbxCallCallbackHandler handler, String methodName, params object[] param)
        {
            if (param == null)
                param = new object[] { };
            this.client.AsyncRequest(methodName, param, handler);
        }
        
        /// <summary>
        /// Async request without args
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="handler"></param>
        protected void asyncRequest(String methodName, GbxCallCallbackHandler handler)
        {
            this.client.AsyncRequest(methodName, new object[] { }, handler);
        }
  
        /// <summary>
        /// Request CallBack to manage error
        /// </summary>
        /// <param name="res"></param>
        protected void checkError(GbxCall res)
        {
            if (res.Error)
            {
                Log("ERROR", "[" + this.PluginName + "]" +res.ErrorString);
            }
        }

     
        protected InterPluginResponse sendInterPluginCall(string target, string callName, Dictionary<string, object> args)
        {
            if (pmInterCall != null)
                return this.pmInterCall(this, target, new InterPluginArgs(0, callName, args));
            else
                return null;
        }

        

    



        ///////////////////////////////////////////////////////////////////////////////////////////////////
        // ABSTRACT //////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////

      

        public abstract void onDisconnect();

        public void onGbxCallBack(object sender, GbxCallbackEventArgs args, bool none)
        {
            if (Callbacks.ContainsKey(args.Response.MethodName))
            {
                Callbacks[args.Response.MethodName](sender, args);
            }
            onGbxCallBack(sender, args);
        }

        /// <summary>
        /// Actions on load
        /// </summary>
        /// <param name="lamaConfig"></param>
        public abstract bool onLoad(LamaConfig lamaConfig);

        /// <summary>
        /// CallBack Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public abstract void onGbxCallBack(object sender, GbxCallbackEventArgs args);
     
        /// <summary>
        /// Result of async request
        /// </summary>
        /// <param name="res"></param>
        public abstract void onGbxAsyncResult(GbxCall res);

        public void onPluginUpdate()
        {

        }

        public virtual InterPluginResponse onInterPluginCall(IBasePlugin sender, InterPluginArgs args)
        {
            return null;
        }

        public string aliasCall(string arg)
        {
            return null;
        }

        public GetLamaProperty GetLamaProperty { get; set; }
        public string Author { get; set; }
        public string PluginName { get; set; }
        public string Version { get; set; }
        public string PluginFolder { get; set; }
        public PluginType PluginType { get; set; }
        public List<Requirement> Requirements { get; set; }
        public OnError OnError { get; set; }
        public Logger Log { get; set; }
        public string PluginDescription { get; set; }
        
        /// <summary>
        /// For Offical Plugins
        /// </summary>
        public string PluginKey { get; set; }
    }
}
