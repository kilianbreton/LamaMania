using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Text.RegularExpressions;
using NTK.IO.Xml;
using static NTK.Other.NTKF;

namespace ConsoleTest
{
    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string res = "";
            XmlDocument xmld = new XmlDocument(@"D:\gbxmeth.html");
            XmlNode root = xmld[0];
            foreach(XmlNode tr in root.Childs)
            {
              //  Console.WriteLine();
                res += "/// <summary>\n/// " + tr[2] + "\n/// </summary>\n/// <example>\n/// " + tr[0] + "\n/// </example>\n/// <returns>\n/// " + tr[1] + "\n/// </returns>\npublic const String " + delseps(tr[0].Value," (",")") + " = " + "\"" + delseps(tr[0].Value, " (", ")") + "\";\n" ;
            }
            Console.Write(res);
            Console.ReadKey();
        }


    }
}
