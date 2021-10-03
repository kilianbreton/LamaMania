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
using LamaPlugin;
using System.Windows.Forms;
using FlatUITheme;
using System.Diagnostics;
using System.Threading;
using NTK.Database;


namespace LamaPlugin
{
    /// <summary>
    /// Lama Configuration
    /// </summary>
    public class Lama
    {

        public List<IManager> managers;

        /// <summary>
        /// Start mode : -1 = select and start, >=0 = autostart id
        /// </summary>
        public int startMode = -1;

        /// <summary>
        /// Servers list
        /// </summary>
        // public Dictionary<int, String> servers = new Dictionary<int, string>();

        public LocalesManager localesManager;

        /// <summary>
        /// Plugin manager
        /// </summary>
        public PluginManager pluginManager;
        
        /// <summary>
        /// Index of selected server
        /// </summary>
        public int serverIndex;
        
        /// <summary>
        /// Main xml config
        /// </summary>
        public XmlDocument mainConfig;
        
        /// <summary>
        /// 
        /// </summary>
        public IniDocument iniFile;
        
        /// <summary>
        /// 
        /// </summary>
        public bool externalServer = false;
        
        /// <summary>
        /// 
        /// </summary>
        public string serverPath = @"\Servers\";

        /// <summary>
        /// Database connection
        /// </summary>
        public NTKDatabase database;

        /// <summary>
        /// Make maniaplanet invisible
        /// </summary>
        public bool invisibleServer = false;
        
        /// <summary>
        /// Server is launched
        /// </summary>
        public bool launched = false;
        
        /// <summary>
        /// Is remote
        /// </summary>
        public bool remote = false;
        
        /// <summary>
        /// Remote IP
        /// </summary>
        public string remoteAdrs;
        
        /// <summary>
        /// Remote port
        /// </summary>
        public int remotePort;

     
        /// <summary>
        /// 
        /// </summary>
        public Dictionary<string, string> scriptSettingsLocales = new Dictionary<string, string>();
        
        /// <summary>
        /// 
        /// </summary>
        public Process serverProcess;
        
        /// <summary>
        /// 
        /// </summary>
        public bool serverProcessExited = true;
        
        /// <summary>
        /// 
        /// </summary>
        public bool connected = false;
        
        /// <summary>
        /// 
        /// </summary>
        public bool useLogs = true;
        
        /// <summary>
        /// 
        /// </summary>
        public Log lamaLogger;
        
        /// <summary>
        /// 
        /// </summary>
        public Thread loadThread;
        
        /// <summary>
        /// 
        /// </summary>
        public int previousMapId = -1;
        
        /// <summary>
        /// 
        /// </summary>
        public int currentMapId = -1;
        
        /// <summary>
        /// 
        /// </summary>
        public int nbPlayers = 0;
        
        /// <summary>
        /// 
        /// </summary>
        public int maxPlayers = 0;
        
        /// <summary>
        /// 
        /// </summary>
        public int maxSpectators = 0;
        
        /// <summary>
        /// 
        /// </summary>
        public bool inEditMode = false;

        /// <summary>
        /// 
        /// </summary>
        public string serverName = "";
     
        /// <summary>
        /// 
        /// </summary>
        public string serverLogin = "";
      
        /// <summary>
        /// 
        /// </summary>
        public string serverComment = "";

        /// <summary>
        /// 
        /// </summary>
        public List<Player> players = new List<Player>();
     
        /// <summary>
        /// 
        /// </summary>
        public List<MapInfo> maps = new List<MapInfo>();


        /////////////////////////////////////////////////////////////////////////////////////////////////////
        // Methods /////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Add a log line in Lama.log
        /// </summary>
        /// <param name="type"></param>
        /// <param name="msg"></param>
        public void log(string type, string msg)
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
        public void onError(object sender, string title, string text)
        {
            MessageBox.Show(text + "\nFrom : " + sender.GetType().Name, title, MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
         //   LamaDialog dialog = new LamaDialog(title, text + "\nFrom : " + sender.GetType().Name, FlatAlertBox._Kind.Error, MessageBoxButtons.OK);
         //   dialog.ShowDialog();
        }

        /// <summary>
        /// Show Exception dialog
        /// </summary>
        /// <param name="sender">Use this</param>
        /// <param name="exception">Catched exception</param>
        public void onException(object sender, Exception exception)
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
        public object getLamaProperty(LamaProperty name)
        {

            switch (name)
            {
                case LamaProperty.CONNECTED:
                    return this.connected;
                case LamaProperty.CURRENTMAPID:
                    return this.currentMapId;
                case LamaProperty.INVISIBLESERVER:
                    return this.invisibleServer;
                case LamaProperty.LANG:
                    return null;
               //     return this.lang;
                case LamaProperty.LAUNCHED:
                    return this.launched;
                case LamaProperty.MAINCONFIG:
                    return this.mainConfig;
                case LamaProperty.MAXPLAYERS:
                    return this.maxPlayers;
                case LamaProperty.MAXSPECTATORS:
                    return this.maxSpectators;
                case LamaProperty.NBPLAYERS:
                    return this.nbPlayers;
                case LamaProperty.PREVIOUSMAPID:
                    return this.previousMapId;
                case LamaProperty.REMOTE:
                    return this.remote;
                case LamaProperty.REMOTEADRS:
                    return this.remoteAdrs;
                case LamaProperty.REMOTEPORT:
                    return this.remotePort;
                case LamaProperty.SCRIPTSETTINGSLOCALES:
                    return this.scriptSettingsLocales;
                case LamaProperty.STARTMODE:
                    return this.startMode;
                case LamaProperty.INEDITMODE:
                    return this.inEditMode;
                case LamaProperty.PLAYERS:
                    return this.players;
                default:
                    throw new Exception("Unknown property : " + name);
            }

   
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public Player getPlayerByLogin(string login)
        {
            int cpt = 0;
            while(cpt < players.Count && players[cpt].Login != login) { cpt++; }

            if (players[cpt].Login == login)
                return players[cpt];
            else
                return null;
        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Process_Disposed(object sender, EventArgs e)
        {
            this.launched = false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Process_Exited(object sender, EventArgs e)
        {
            this.launched = false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Process_DataReceived(object sender, DataReceivedEventArgs e)
        {
          
        }
    }
}
