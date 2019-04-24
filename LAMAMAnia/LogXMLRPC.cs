using System;
using System.Collections.Generic;
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
            
        }
    }
}
