using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTK.IO;


namespace LamaPlugin
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
            return "[" + this.Type + "]\t[" + this.Date.ToShortDateString() + "][" + this.Date.ToShortTimeString() + "]>" + this.Text;
        }
    }

    /// <summary>
    /// Lama Logger
    /// </summary>
    public class LamaLog : Log
    {
        public const string NOTICE = "NOTICE";
        public const string SUCCESS = "SUCCESS";
        public const string INFO = "INFO";
        public const string WARNING = "WARNING";
        public const string ERROR = "ERROR";
        public const string NOCONSOLE = "NOCONSOLE";

        private string path;
        private bool writeNotices;
        private bool writeConsole;

        /// <summary>
        /// Init logger
        /// </summary>
        /// <param name="path"></param>
        /// <param name="writeNotices"></param>
        public LamaLog(string path, bool writeNotices = true, bool writeConsole = false)
        {
            this.path = path;
            this.add("NOTICE", "[INIT]==============================================================================================================================================");
            this.writeNotices = writeNotices;
            this.writeConsole = writeConsole;
            this.flush();
        }
        /// <summary>
        /// 
        /// </summary>
        public LamaLog()
        {

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
                    if (this.writeConsole && elem.Type != LamaLog.NOCONSOLE)
                    {
                        switch (elem.Type)
                        {
                            case NOTICE:
                                Console.ResetColor();
                                Console.Write("[NOTICE]");
                               
                                break;
                            case INFO:
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write("[INFO]"); 

                             
                                break;

                            case WARNING:
                               
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("[WARN]");
                                break;

                            case SUCCESS:
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("[SUCCESS]");
                                break;
                            case ERROR:
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("[ERROR]");
                                break;
                        }
                        Console.WriteLine(elem.Text);
                    }
                }
                
                sw.Close();
                lines.Clear();
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
            }

        }
        /// <summary>
        /// 
        /// </summary>
        public bool WriteNotices { get => writeNotices; set => writeNotices = value; }

    }
}
