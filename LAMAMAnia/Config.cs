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
    public class Config
    {
        public static Dictionary<String, String> servers = new Dictionary<string, string>();
        public static List<BasePlugin> plugins;
        public static XmlDocument mainConfig;
        public static bool invisibleServer = false;
        public static bool launched = false;
        public static bool remote = false;
        public static string remoteAdrs;
        public static int remotePort;
        public static BaseLang lang;
        public static bool connected = false;
        public static bool useLogs = true;
    }
}
