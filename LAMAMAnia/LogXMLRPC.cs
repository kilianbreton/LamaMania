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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTK.IO;

namespace LAMAMAnia
{
    public class LogLineXMLRPC : LogLine
    {
        public LogLineXMLRPC(String type, String text, DateTime date) : base(type, text, date) { }

        public override string toText()
        {
            return "[" + Date.ToShortDateString() + "][" + Type + "]>" + Text;
        }
    }


    public class LogXMLRPC : Log
    {
        private string path;


        public LogXMLRPC(String path)
        {
            this.path = path;
        }

        public override void add(string type, string text)
        {
            base.lines.Add(new LogLineXMLRPC(type, text, DateTime.Now));
        }

        public override void flush()
        {
            try
            {
                StreamWriter sw = new StreamWriter(path, true);
                foreach (LogLine elem in lines)
                {
                    sw.WriteLine(elem.toText());
                }
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

        }
    }
}
