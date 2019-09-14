using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LamaController
{
    public class CLIReadLineWithEvents
    {
        private List<string> previousCmds = new List<string>();
        private int prevIndex = 0;

        private List<string> cmds = new List<string>();
        public CLIReadLineWithEvents()
        {
            this.cmds.Add("help ");
            this.cmds.Add("help make");
            this.cmds.Add("help get");
            this.cmds.Add("help set");
            this.cmds.Add("help update");
            this.cmds.Add("help check");
            this.cmds.Add("make ");
            this.cmds.Add("make Locales");
            this.cmds.Add("make LocalesScriptSettings");
            this.cmds.Add("make LocalesGlobalLang");
            this.cmds.Add("set ");
            this.cmds.Add("set php_");
            this.cmds.Add("set php_version");
            this.cmds.Add("set php_path");
            this.cmds.Add("set ressources_");
            this.cmds.Add("set ressources_uaseco");
            this.cmds.Add("set ressources_path");
            this.cmds.Add("update ");
            this.cmds.Add("update All");
            this.cmds.Add("update Lcontroller");
            this.cmds.Add("update Lmania");
            this.cmds.Add("update Plugin ");
            this.cmds.Add("update Plugins");

        }

        public string ReadLine()
        {
            
            int startLIndex = Console.CursorLeft;
            string ret = "";
            this.previousCmds.Add(ret);
            bool stop = false;
            while (!stop)
            {
                int curLIndex = Console.CursorLeft;
                ConsoleKeyInfo ki = Console.ReadKey();
                ConsoleKey k = ki.Key;
                switch (k)
                {
                    case ConsoleKey.Enter:
                        stop = true;
                        break;
                    case ConsoleKey.Tab:
                        Console.SetCursorPosition(curLIndex, Console.CursorTop);
                        if (ret.Length > 1)
                        {
                            string tmp = getLikeCmd(ret);
                            int dif = tmp.Length - ret.Length;

                            for (int i = ret.Length; i < tmp.Length; i++)
                            {
                                Console.Write(tmp[i]);
                            }

                            ret = tmp;
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        Console.SetCursorPosition(startLIndex, Console.CursorTop);
                        if (this.prevIndex > 0)
                        {
                            this.prevIndex--;
                            ret = this.previousCmds[prevIndex];
                            foreach (char c in ret)
                            {
                                Console.Write(c);
                            }

                        }
                        break;

                    case ConsoleKey.DownArrow:
                        break;

                    case ConsoleKey.Clear:
                    case ConsoleKey.Backspace:
                        if (ret.Length > 0)
                        {
                            ret = ret.Substring(0, ret.Length-1);
                          
                            Console.Write(" ");
                            Console.SetCursorPosition(Console.CursorLeft  -1, Console.CursorTop);
                        }
                        else
                        {
                            Console.SetCursorPosition(Console.CursorLeft + 1, Console.CursorTop);
                        }
                        break;

                    default:
                        ret += ki.KeyChar;
                        break;
                }
            }
            Console.WriteLine();

            this.previousCmds[prevIndex] = ret;
            this.prevIndex = this.previousCmds.Count;

            return ret;
        }




        string getLikeCmd(string cmd)
        {
            string ret = "";

            foreach(string c in this.cmds)
            {
               // if (c.Contains(cmd) && c.Length > ret.Length)
                if (c.ToUpper().IndexOf(cmd.ToUpper()) == 0)
                {
                    ret = c;
                    break;
                }

            }

                       
            return ret;
        }
    }
}
