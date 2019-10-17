/* 
----------------------------------------------------------------------------------
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
using NTK.IO.Ini;
using LamaLang;
using LamaPlugin;
using System.Windows.Forms;
using FlatUITheme;
using System.Diagnostics;
using System.Threading;

namespace LamaMania
{
   


    /// <summary>
    /// Lama Configuration
    /// </summary>
    public class Lama
    {
        public static LocalesManager localesManager;
        /// <summary>
        /// Start mode : -1 = select and start, >=0 = autostart id
        /// </summary>
        public static int startMode = -1;
        /// <summary>
        /// Servers list
        /// </summary>
        public static Dictionary<int, String> servers = new Dictionary<int, string>();
        /// <summary>
        /// Plugin manager
        /// </summary>
        public static PluginManager pluginManager;
        /// <summary>
        /// Index of selected server
        /// </summary>
        public static int serverIndex;
        /// <summary>
        /// Main xml config
        /// </summary>
        public static XmlDocument mainConfig;
        /// <summary>
        /// 
        /// </summary>
        public static IniDocument iniFile;
        /// <summary>
        /// 
        /// </summary>
        public static bool externalServer = false;
        /// <summary>
        /// 
        /// </summary>
        public static string serverPath = @"\Servers\";


        /// <summary>
        /// Make maniaplanet invisible
        /// </summary>
        public static bool invisibleServer = false;
        /// <summary>
        /// Server is launched
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
        public static Dictionary<string, string> scriptSettingsLocales = new Dictionary<string, string>();
        /// <summary>
        /// 
        /// </summary>
        public static Process serverProcess;
        /// <summary>
        /// 
        /// </summary>
        public static bool serverProcessExited = true;
        /// <summary>
        /// 
        /// </summary>
        public static bool connected = false;
        /// <summary>
        /// 
        /// </summary>
        public static bool useLogs = true;
        /// <summary>
        /// 
        /// </summary>
        public static Log lamaLogger;
        /// <summary>
        /// 
        /// </summary>
        public static LoadForm loadForm = new LoadForm();
        /// <summary>
        /// 
        /// </summary>
        public static Thread loadThread;
        /// <summary>
        /// 
        /// </summary>
        public static int previousMapId = -1;
        /// <summary>
        /// 
        /// </summary>
        public static int currentMapId = -1;
        /// <summary>
        /// 
        /// </summary>
        public static int nbPlayers = 0;
        /// <summary>
        /// 
        /// </summary>
        public static int maxPlayers = 0;
        /// <summary>
        /// 
        /// </summary>
        public static int maxSpectators = 0;
        /// <summary>
        /// 
        /// </summary>
        public static bool inEditMode = false;


        /////////////////////////////////////////////////////////////////////////////////////////////////////
        // Methods /////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Add a log line in Lama.log
        /// </summary>
        /// <param name="type"></param>
        /// <param name="msg"></param>
        public static void log(string type, string msg)
        {
            if (lamaLogger != null)
            {
                lamaLogger.add(type, msg);
                lamaLogger.flush();
            }
            else
            {
                onError(null, "Try to log without logger", "Application try to log with lamaLogger but it's not instancied");
            }
        }
      
        /// <summary>
        /// Show Error dialog
        /// </summary>
        /// <param name="sender">Use this</param>
        /// <param name="title">Dialog title</param>
        /// <param name="text"></param>
        public static void onError(object sender, string title, string text)
        {
            //MessageBox.Show(text + "\nFrom : " + sender.GetType().Name, title, MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            LamaDialog dialog = new LamaDialog(title, text + "\nFrom : " + sender.GetType().Name, FlatAlertBox._Kind.Error, MessageBoxButtons.OK);
            dialog.ShowDialog();
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
        /// Get lama property from plugins
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static object getLamaProperty(LamaProperty name)
        {

            switch (name)
            {
                case LamaProperty.CONNECTED:
                    return Lama.connected;
                case LamaProperty.CURRENTMAPID:
                    return Lama.currentMapId;
                case LamaProperty.INVISIBLESERVER:
                    return Lama.invisibleServer;
                case LamaProperty.LANG:
                    return Lama.lang;
                case LamaProperty.LAUNCHED:
                    return Lama.launched;
                case LamaProperty.MAINCONFIG:
                    return Lama.mainConfig;
                case LamaProperty.MAXPLAYERS:
                    return Lama.maxPlayers;
                case LamaProperty.MAXSPECTATORS:
                    return Lama.maxSpectators;
                case LamaProperty.NBPLAYERS:
                    return Lama.nbPlayers;
                case LamaProperty.PREVIOUSMAPID:
                    return Lama.previousMapId;
                case LamaProperty.REMOTE:
                    return Lama.remote;
                case LamaProperty.REMOTEADRS:
                    return Lama.remoteAdrs;
                case LamaProperty.REMOTEPORT:
                    return Lama.remotePort;
                case LamaProperty.SCRIPTSETTINGSLOCALES:
                    return Lama.scriptSettingsLocales;
                case LamaProperty.STARTMODE:
                    return Lama.startMode;
                case LamaProperty.INEDITMODE:
                    return Lama.inEditMode;
                default:
                    throw new Exception("Unknown property : " + name);
            }

   
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void Process_Disposed(object sender, EventArgs e)
        {
            Lama.launched = false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void Process_Exited(object sender, EventArgs e)
        {
            Lama.launched = false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void Process_DataReceived(object sender, DataReceivedEventArgs e)
        {
          
        }
    }
}
