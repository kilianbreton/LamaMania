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
    public abstract class InGamePlugin : BasePlugin
    {
        private XmlRpcClient client;
       
        protected Dictionary<int, string> handles = new Dictionary<int, string>();
  


        /// <summary>
        /// Init
        /// </summary>
        public InGamePlugin() { }
        

        /// <summary>
        /// Method for plugin manager
        /// </summary>
        /// <param name="client"></param>
        public void setClient(XmlRpcClient client)
        {
            this.client = client;
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

        protected void asyncRequest(GbxCallCallbackHandler handler, String methodName, params object[] param)
        {
            if (param == null)
                param = new object[] { };
            this.client.AsyncRequest(methodName, param, handler);
        }

        protected void asyncRequest(String methodName, GbxCallCallbackHandler handler)
        {
            this.client.AsyncRequest(methodName, new object[] { }, handler);
        }


        protected void checkError(GbxCall res)
        {
            if (res.Error)
            {

            }
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

   
      
    }
}
