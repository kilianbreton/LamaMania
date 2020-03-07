using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTK;
using NTK.Service;
using NTK.IO;
using XmlRpcEncrypted;
using TMXmlRpcLib;
using LamaMania;
using NTK.Other;

namespace ServerTest
{
    class Program
    {
        private static string login = "SuperAdmin";
        private static string pass = "SDG5454tuf54sd4HJK54F";

        static void Main(string[] args)
        {
            try
            {
                Console.Write("XmlRpc Connect : 127.0.0.1:5001");
                XmlRpcClient client = new XmlRpcClient("127.0.0.1", 5001);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" [OK]");
                Console.ResetColor();
                Console.Write("Authenticate : SuperAdmin");
                GbxCall authAnsw = client.Request("Authenticate", login, pass);
                if (authAnsw.Params[0].Equals(true)) //Auth success---------------------------------
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(" [OK]");
                    Console.ResetColor();
                    client.EnableCallbacks(true);
                    client.EventGbxCallback += new GbxCallbackHandler(gbxCallBack);
                    client.EventOnDisconnectCallback += new OnDisconnectHandler(gbxDisconnect);
                    Console.WriteLine();
                    Console.WriteLine("Start NTKServer ...");
                    
                    NTKServer server = new NTKServer(1141, CTYPE.OTHER, true, new SXmlRpcEncrypted(client, login, pass))
                    {
                        Stype = SXmlRpcEncrypted.S_NAME,
                      //  ConsoleLog = Log_NTK.getInstance("logs.txt", true),
                    };

                    server.start();
                }

            }
            catch (NotConnectedException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" [ERROR]");
                Console.ResetColor();
                Console.WriteLine("Unable to open XMLRPC socket");
            }

            Console.ReadLine();
        }

        private static void gbxDisconnect(object o)
        {
          
        }

        private static void gbxCallBack(object o, GbxCallbackEventArgs e)
        {
            
        }
    }
}
