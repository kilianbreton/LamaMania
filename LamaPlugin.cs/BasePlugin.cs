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

namespace LamaPlugin
{
    public abstract class BasePlugin
    {
        private XmlRpcClient client;
        protected Dictionary<int, string> handles = new Dictionary<int, string>();

        private string author = "";
        private string plugin = "";
        private float version = 0.1F;

        protected string Author { get => author; set => author = value; }
        protected string Plugin { get => plugin; set => plugin = value; }
        protected float Version { get => version; set => version = value; }

        public string getAuthor { get => author; }
        public string getPlugin { get => plugin; }
        public float getVersion { get => version; }


        //Constructeurs

        public BasePlugin() { }

        public BasePlugin(XmlRpcClient client)
        {
            this.client = client;
        }

        public void setClient(XmlRpcClient client)
        {
            this.client = client;
        }

        //Protected

        protected void asyncRequest(String methodeName, object[] param = null)
        {
            if (param == null)
                param = new object[] { };
            this.handles.Add(this.client.AsyncRequest(methodeName, param, basicResult), methodeName);
        }

        protected void asyncRequest(String methodeName, object[] param, GbxCallCallbackHandler handler)
        {
            if (param == null)
                param = new object[] { };
            this.client.AsyncRequest(methodeName, param, handler);
        }

        //Abstract

        public abstract void onLoad(List<Dictionary<string, string>> lamaConfig);

        public abstract void onGbxCallBack(object sender, GbxCallbackEventArgs args);

        public abstract void onGbxAsyncResult(GbxCall res);

    }
}