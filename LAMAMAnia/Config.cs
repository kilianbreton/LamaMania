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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTK.IO.Xml;
using LamaLang;
using LamaPlugin;

namespace LAMAMAnia
{
    /// <summary>
    /// Lama Configuration
    /// </summary>
    public class Config
    {
        /// <summary>
        /// 
        /// </summary>
        public static Dictionary<String, String> servers = new Dictionary<string, string>();
        /// <summary>
        ///
        /// </summary>
        public static List<BasePlugin> plugins;
        /// <summary>
        /// 
        /// </summary>
        public static XmlDocument mainConfig;
        /// <summary>
        /// 
        /// </summary>
        public static bool invisibleServer = false;
        /// <summary>
        /// 
        /// </summary>
        public static bool launched = false;
        /// <summary>
        /// 
        /// </summary>
        public static bool remote = false;
        /// <summary>
        /// 
        /// </summary>
        public static string remoteAdrs;
        /// <summary>
        /// 
        /// </summary>
        public static int remotePort;
        /// <summary>
        /// 
        /// </summary>
        public static BaseLang lang;
        /// <summary>
        /// 
        /// </summary>
        public static bool connected = false;
        /// <summary>
        /// 
        /// </summary>
        public static bool useLogs = true;
    }
}
