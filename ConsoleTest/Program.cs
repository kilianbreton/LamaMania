using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Text.RegularExpressions;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex rx = new Regex("^/[a-zA-Z0-9_ ]");
            string msg = "";
            while(msg != "q")
            {
                msg = Console.ReadLine();
                Console.WriteLine("-" + rx.IsMatch(msg));

            }


            Console.ReadKey();
        }


    }
}
