using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Text.RegularExpressions;
using NTK.IO.Xml;
using static NTK.Other.NTKF;
using NTK;
using XmlRpcEncrypted;
using TMXmlRpcLib;
using NTK.EventsArgs;
using System.IO.Compression;
using System.IO;
using LamaPlugin;
using GBXMapParser;
using LamaMania;
using Records;
using NTK.Security;

namespace ConsoleTest
{
    class Program
    {
        static SXmlRpcEncrypted service;
        static NTKClient client;

        public static List<string> tChars;
        static string chars = "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z";

        static List<string> argsExists = new List<string>();
        

        static void Main(string[] args)
        {
            LocalRecords r = new LocalRecords();
            Console.WriteLine(r.makeManialink(null));


            Console.ReadLine();
            return;
            
            string file = File.ReadAllText(@"D:\styles.txt");
            IEnumerable<string> l = file.Split(',');
            foreach(string s in l)
            {
                string s2 = s.Replace("\"", "").Trim();
                Console.WriteLine("public const string " + s2 + " = \"" + s2 + "\";");

            }





            Console.ReadLine();
            return;
        
        }



        static void writeBytes(byte[] data)
        {
            string s = "";
            int cpt = 1;
            foreach(byte b in data)
            {
                s += b.ToString("X2") + " ";

                if(cpt % 32 == 0)
                {
                    s += "\n";
                }
                cpt++;
            }

            Console.WriteLine(s);

        }





        static string getArgName(int i)
        {
            int cpt = 1; 
            string ret = tChars[i % tChars.Count];
            string ret2 = ret;

            while (argsExists.Contains(ret))
            {
                ret = ret2 + cpt++;
            }
            argsExists.Add(ret);
            return ret;
        }

        static void client_ident(object sender, IdentificationEventArgs args)
        {
            Console.WriteLine("Authentified");
        }

        static async void client_getservice(object sender, GetServiceEventArgs args)
        {
            service = (SXmlRpcEncrypted)args.get;
            await service.c_asyncRequest("NextMap", new object[] { }, asyncResult);
        }

        static void client_connect(object sender, OnConnectEventArgs args)
        {
            Console.WriteLine("Connected");
        }

        static void gbxCallBack(object sender, GbxCallbackEventArgs args)
        {

        }

        static void asyncResult(GbxCall res)
        {
            var p = res.Params;
        }

    }
}
