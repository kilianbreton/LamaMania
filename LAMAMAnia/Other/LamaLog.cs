using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTK.IO;


namespace LamaMania
{
    /// <summary>
    /// Représente une ligne de log
    /// </summary>
    public class LamaLogLine : LogLine
    {
        /// <summary>
        /// Création d'une nouvelle ligne
        /// </summary>
        /// <param name="type">ERROR, NOTICE, WARNING</param>
        /// <param name="text"></param>
        public LamaLogLine(string type, string text) : base(type, text, DateTime.Now) { }

        /// <summary>
        /// Return string logLine
        /// </summary>
        /// <returns></returns>
        public override string toText()
        {
            return "[" + this.Type + "] [" + this.Date.ToShortDateString() + "][" + this.Date.ToShortTimeString() + "]>" + this.Text;
        }
    }

    /// <summary>
    /// Lama Logger
    /// </summary>
    public class LamaLog : Log
    {
        private string path;
        private bool writeNotices;

        /// <summary>
        /// Init logger
        /// </summary>
        /// <param name="path"></param>
        /// <param name="writeNotices"></param>
        public LamaLog(string path, bool writeNotices = true)
        {
            this.path = path;
            this.writeNotices = writeNotices;
            this.add("NOTICE", "[INIT]==============================================================================================================================================");
            this.flush();
        }

     
        /// <summary>
        /// Add logLine to temp list
        /// </summary>
        /// <param name="type"></param>
        /// <param name="text"></param>
        public override void add(string type, string text)
        {
            if(type != "NOTICE" || writeNotices)
                this.lines.Add(new LamaLogLine(type, text));
        }

        /// <summary>
        /// Write logLine list and clear list
        /// </summary>
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
                lines.Clear();
            }
            catch (Exception e)
            {
                Lama.onException(this, e);
            }

        }

        public bool WriteNotices { get => writeNotices; set => writeNotices = value; }

    }
}
