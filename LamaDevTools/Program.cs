using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LamaDevTools
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length > 0)
            {
                switch(args[0].ToLower())
                {
                    case "-h":

                        break;
                    case "-v":
                        string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
                        Console.WriteLine("LDT : " + version);
                        break;

                }
            }
            else
            {

            }


        }

        static void cli()
        {



        }

    }
}
