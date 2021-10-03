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

//#define CACHE_DEBUG

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using LamaPlugin;

namespace LamaMania
{
    static class Program
    {
        public static Lama lama;
        public static ServersManager serversManager;
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {

#if CACHE_DEBUG
            PluginManager.PMCache cache = new PluginManager.PMCache(@"Cache\PM.cache");
            cache.ClearCache();
            cache.save();
#endif


            lama = new Lama();
            if(args.Length != 0)
            {
#if CACHE_DEBUG

#else
                if(args[0].ToUpper() == "--CLEARCACHE")
                {
                    PluginManager.PMCache cache2 = new PluginManager.PMCache(@"Cache\PM.cache");
                    cache2.ClearCache();
                    cache2.save();
                }
#endif
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new HomeLauncher());
            }



           
            
        }
    }
}
