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
            Console.Write("Fichier gbx : ");
            string s = Console.ReadLine();
            if (s != "" && s.ToUpper().Contains(".GBX"))
                {

                MapInformation mi = MapParser.ReadFile(s);
                Console.WriteLine("AuthorExtra : " + mi.AuthorExtra);
                Console.WriteLine("AuthorLogin : " + mi.AuthorLogin);
                Console.WriteLine("AuthorNickName : " + mi.AuthorNickName);
                Console.WriteLine("AuthorScore : " + mi.AuthorScore);
                Console.WriteLine("AuthorTime : " + mi.AuthorTime);
                Console.WriteLine("AuthorVersion : " + mi.AuthorVersion);
                Console.WriteLine("AuthorZone : " + mi.AuthorZone);
                Console.WriteLine("BronzeTime : " + mi.BronzeTime);
                Console.WriteLine("Checkpoints : " + mi.Checkpoints);
                Console.WriteLine("Comments : " + mi.Comments);
                Console.WriteLine("DecorationEnvironmentAuthor : " + mi.DecorationEnvironmentAuthor);
                Console.WriteLine("DecorationEnvironmentId : " + mi.DecorationEnvironmentId);
                Console.WriteLine("Editor : " + mi.Editor);
                Console.WriteLine("Environment : " + mi.Environment);
                Console.WriteLine("GoldTime : " + mi.GoldTime);
                Console.WriteLine("HasThumbnail : " + mi.HasThumbnail);


                Console.WriteLine("HeaderXml : "); //+ mi.HeaderXml);

                XmlDocument xmld = new XmlDocument(mi.HeaderXml, false);
                Console.Write(xmld.print());

                Console.WriteLine("IsMultilap : " + mi.IsMultilap);
                Console.WriteLine("Laps : " + mi.Laps);
                Console.WriteLine("MapStyle : " + mi.MapStyle);
                Console.WriteLine("MapType : " + mi.MapType);
                Console.WriteLine("MapTypeId : " + mi.MapTypeId);
                Console.WriteLine("Mood : " + mi.Mood);
                Console.WriteLine("Name : " + mi.Name);
                Console.WriteLine("Price : " + mi.Price);
                Console.WriteLine("SilverTime : " + mi.SilverTime);
                Console.WriteLine("Thumbnail : " + mi.Thumbnail);
                writeBytes(mi.Thumbnail);

                Console.WriteLine("TitleId : " + mi.TitleId);
                Console.WriteLine("UId : " + mi.UId);
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
            }
            else
            {

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
