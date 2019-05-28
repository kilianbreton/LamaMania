﻿/* ----------------------------------------------------------------------------------
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

namespace LamaPlugin
{
    /// <summary>
    /// Abstract class for plugins
    /// </summary>
    public abstract class BasePlugin
    {
        private XmlRpcClient client;
        private List<Requirement> requirements = new List<Requirement>();
        protected Dictionary<int, string> handles = new Dictionary<int, string>();
        protected Log logger;


        private string author = "";
        private string name = "";
        private string version = "";


        /// <summary>
        /// Init
        /// </summary>
        public BasePlugin() { }
        

        /// <summary>
        /// Method for plugin manager
        /// </summary>
        /// <param name="client"></param>
        public void setClient(XmlRpcClient client)
        {
            this.client = client;
        }

        public void setLogger(Log logger)
        {
            this.logger = logger;
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
        /// Send async request
        /// </summary>
        /// <param name="methodeName"></param>
        /// <param name="param"></param>
        /// <param name="handler"></param>
        protected void asyncRequest(String methodeName, object[] param, GbxCallCallbackHandler handler)
        {
            if (param == null)
                param = new object[] { };
            this.client.AsyncRequest(methodeName, param, handler);
        }
      
        protected void log(string type, string text)
        {
            logger.add(type, text);
            logger.flush();
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////
        // ABSTRACT //////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////

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

        ///////////////////////////////////////////////////////////////////////////////////////////////////
        // GETTERS ///////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////
        

        public string Author { get => author; protected set => author = value; }
        public string Name { get => name; protected set => name = value; }
        public string Version { get => version; protected set => version = value; }
        public List<Requirement> Requirements { get => requirements; protected set => requirements = value; }

   
      
    }
}
