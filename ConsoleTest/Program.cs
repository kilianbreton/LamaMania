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

namespace ConsoleTest
{
    class Program
    {
        static SXmlRpcEncrypted service;
        static NTKClient client;
        static List<string> tChars;
        static string chars = "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z";

        static List<string> argsExists = new List<string>();

        static void Main(string[] args)
        {


            string text = "texte avant compression";
            GZipStream gzs = new GZipStream(File.Open(@"D:\testCompression.s", FileMode.Create),CompressionLevel.Fastest);


            StreamWriter sw = new StreamWriter(gzs);

            sw.WriteLine("test");
            sw.Close();
            gzs.Close();



            return;
            //Generateur de code :

            tChars = new List<string>(chars.Split(','));

            List<string> classList = new List<string>();
            XmlDocument xmld = new XmlDocument(@"D:\ClassMeth.html");
            foreach(XmlNode tr in xmld[0]["tbody"].getChildList("tr"))
            {
                //Parse
                string name = subsep(tr[0].Value, 0, " (");
                List<string> argsC = new List<string>();
                if (!tr[0].Value.Contains("()"))
                {
                    argsC.AddRange(subsep(tr[0].Value, "(", ")").Split(','));
                }

                //return
                string ret = tr[1].Value;
                ret = ret.Replace("boolean", "bool");
                ret = ret.Replace("array", "objet[]");


                //Generate class
                string str = "using System;\n";
                str += "using System.Collections.Generic;\n";
                str += "using System.Linq;\n";
                str += "using System.Text;\n";
                str += "using System.Threading.Tasks;\n";
                str += "\n\n";
                str += "namespace LamaPlugin.Other.MethodsClass\n";
                str += "{\n";
                str += "    public class " + name + " : Abstract.AbstractXmlRpcMethod<"+ret+">\n";
                str += "    {\n";
                str += "        const string name = \""+name+"\";\n\n";
                str += "        public " + name + "(";
                int i = 0;
                foreach (string ar in argsC)
                {
                    str += ar + " " + getArgName(i);
                    if(i<argsC.Count-1)
                        str += ", ";

                    i++;
                }
                str += ")\n";
                str += "            : base(name, new objet[]\n";
                str += "            {\n";
                foreach(string ar in argsExists)
                {
                    str += "                " + ar + ",\n";
                }
                str += "            }) {}\n";
                str += "    }\n";
                str += "}";
                str += "\n\n";
                str += "\n\n";

                classList.Add(str);
                Console.WriteLine(str);
                argsExists.Clear();
            }
            Console.ReadKey();
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
