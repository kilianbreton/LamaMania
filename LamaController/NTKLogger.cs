using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTK.IO;
using System.IO;

namespace LamaController
{
    public class NTKLogger : Log
    {
        string path;
       

        public NTKLogger(string path)
        {
            this.path = path;
           
        }

        public override void add(string type, string text)
        {
            this.lines.Add(new NTKLogLine(type, text));
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
            this.lines.Clear();
        }



        class NTKLogLine : LogLine
        {
            public NTKLogLine(string type, string msg) : base(type, msg, DateTime.Now) { }

            public override string toText()
            {
                return "[" + Type + "][" + base.Date.ToShortTimeString() + "]" + base.Text;
            }
        }
    }
}
