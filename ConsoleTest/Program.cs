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
            NTKRsa rsa = new NTKRsa();
            Console.Write(rsa.getKey());
            Console.WriteLine();
            Console.WriteLine();
            Console.Write(rsa.getKey(true));
            Console.WriteLine();
            Console.WriteLine();
            LocalRecords r = new LocalRecords();
            string s = r.makeManialink(new Player("kamphate", "AnKou", 1, 0, 0, 56));
            Console.Write(s);
            Console.ReadLine();

            XmlDocument xmld = new XmlDocument("D:\\matchsettings.xml");
            XmlDocument outXml = new XmlDocument("D:\\outXml.xml");
            outXml.Nodes.Clear();

            XmlNode rOXml = outXml.addNode("matchsettings");
            XmlNode root = xmld[0];

            root.getChildList("h2");

            List<XmlNode> h2 = root.getChildList("h2");
            List<XmlNode> table = root.getChildList("table");

            if (h2.Count == table.Count)
            {
                int i = 0;
                foreach(XmlNode h in h2)
                {
                    XmlNode n = rOXml.addChild(h.Value.Replace("(+", "_")
                                                      .Replace(")", "")
                                                      .Replace(" ", "")
                                                      .Replace("&amp;", "") );

                    foreach(XmlNode tr in table[i]["tbody"].Childs)
                    {
                        string name;
                        if (tr[0].isChildExist("strong"))
                        {
                            name = tr[0]["strong"].Value;
                        }
                        else
                        {
                            if (tr[0].Value != null && tr[0].Value != "")
                                name = tr[0].Value;
                            else
                                name = "???";
                        }

                        name = name.Replace("(+", "_");
                        name = name.Replace(")", "_");
                        name = name.Replace(" ", "_");


                        XmlNode newSet = n.addChild("setting", tr[2].Value.Replace("&gt;", ""))
                                                .addAttribute("name", name);

                        if (tr[1].Value == null)
                            newSet.addAttribute("defVal", " ");
                        else
                            newSet.addAttribute("defVal", tr[1].Value.Replace("\"","")); 

                     


                    }


                    i++;
                }

            }

            Console.Write(outXml.print());
            try
            {
                outXml.save(true);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("OK !");
            }
            catch(Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Err : " + e.Message);
            }



            Console.ReadKey();

            /*

            ManialinkFile mlf = new ManialinkFile(false);
            mlf.Nodes.Add(new MLFrame(80, 10, 1));
            mlf.Nodes[0].Childs.Add(new MLQuad(0, 0, 2, 50, 50, "F00A"));

            int y = -10;
            List<string> records = new List<string>()
            {
                "1",
                "2",
                "3",
                "4",
                "5",
                "6",
                "7",
                "8",
            };

            foreach (string s in records)
            {
                mlf.Nodes[0].Childs.Add(new MLLabel(s, 80, y, 3));
                y -= 10;
            }


            Console.Write(mlf.getXmlText());





            */




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
