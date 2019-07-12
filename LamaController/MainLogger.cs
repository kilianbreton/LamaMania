using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTK.IO;

namespace LamaController
{
    public class MainLogger : Log
    {
        string path;
        bool notice;

        public MainLogger(string path, bool notice)
        {
            this.path = path;
            this.notice = notice;
        }

        public override void add(string type, string text)
        {
            this.add(new MainLogLine(type, text, DateTime.Now));
        }

        public override void flush()
        {
            throw new NotImplementedException();
        }
    }

    public class MainLogLine : LogLine
    {
        public MainLogLine(string type, string text, DateTime date) : base(type,text,date)
        { }

        public override string toText()
        {
            return "[" + Type + "][" + Date.ToShortDateString() + "] " + Text;
        }
    }

}
