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
using NTK.IO;
using LamaLang;
using LamaPlugin;
using System.Windows.Forms;

namespace LAMAMAnia
{
    /// <summary>
    /// Lama Configuration
    /// </summary>
    public class Lama
    {
        /// <summary>
        /// Start mode : -1 = select and start, >=0 = autostart id
        /// </summary>
        public static int startMode = -1;
        /// <summary>
        /// Servers list
        /// </summary>
        public static Dictionary<int, String> servers = new Dictionary<int, string>();
        /// <summary>
        /// Plugins list
        /// </summary>
        public static List<BasePlugin> plugins = new List<BasePlugin>();
        /// <summary>
        /// Main xml config
        /// </summary>
        public static XmlDocument mainConfig;
        /// <summary>
        /// Make maniaplanet invisible
        /// </summary>
        public static bool invisibleServer = false;
        /// <summary>
        /// Is launched
        /// </summary>
        public static bool launched = false;
        /// <summary>
        /// Is remote
        /// </summary>
        public static bool remote = false;
        /// <summary>
        /// Remote IP
        /// </summary>
        public static string remoteAdrs;
        /// <summary>
        /// Remote port
        /// </summary>
        public static int remotePort;
        /// <summary>
        /// Language Module
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

        public static Log lamaLogger;

        public static LoadForm loadForm = new LoadForm();

        //Methodes--------------------------------------------------------------------------
       
        /// <summary>
        /// Add a log line in Lama.log
        /// </summary>
        /// <param name="type"></param>
        /// <param name="msg"></param>
        public static void log(string type, string msg)
        {
            lamaLogger.add(type, msg);
            lamaLogger.flush();
        }

        /// <summary>
        /// Convert seconds to H M S
        /// </summary>
        /// <param name="time"></param>
        /// <param name="h"></param>
        /// <param name="m"></param>
        /// <param name="s"></param>
        public static void parseTime(int time, out int h, out int m, out int s)
        {
            h = 0;
            m = 0;
            s = 0;
            while (time >= 60)
            {
                time = time - 60;
                if (++m == 60)
                {
                    m = 0;
                    h++;
                }
            }
            s = time;
        }

        /// <summary>
        /// Show Error dialog
        /// </summary>
        /// <param name="sender">Use this</param>
        /// <param name="title">Dialog title</param>
        /// <param name="text"></param>
        public static void onError(object sender, string title, string text)
        {
            MessageBox.Show(text + "\nFrom : " + sender.GetType().Name, title, MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Show Exception dialog
        /// </summary>
        /// <param name="sender">Use this</param>
        /// <param name="exception">Catched exception</param>
        public static void onException(object sender, Exception exception)
        {
            const string HEAD = "Error : #exceptionName from #functionName in #sender : \n #exceptionText";
            var txt = HEAD.Replace("#exceptionName", typeof(Exception).Name);
            txt = txt.Replace("#functionName", exception.TargetSite.Name);
            txt = txt.Replace("#sender", sender.GetType().Name);
            txt = txt.Replace("#exceptionText", exception.Message);

            MessageBox.Show(txt, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
        }

        /// <summary>
        /// 0 = string, 1 = int, 2 = bool
        /// </summary>
        /// <returns></returns>
        public static int getType(object value) {
            if (value.GetType() == true.GetType())
            {
                return 2;
            }
            else if(value.GetType() == 0.1.GetType())
            {
                return 3;
            }
            else if (value.GetType() == 0.GetType())
            {
                return 1;
            }
            else if (value.GetType() == "".GetType())
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// Get key of value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="dic"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T getKeyFromValue<T,T2>(IDictionary<T,T2> dic, T2 value)
        {
            T ret = default(T);
            foreach(KeyValuePair<T,T2> kvp in dic)
            {
                if(kvp.Value.Equals(value))
                {
                    ret = kvp.Key;
                    break;
                }
            }
            return ret;
        } 

    }
}
