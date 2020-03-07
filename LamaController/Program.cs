//#define CLI
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LamaPlugin;
using TMXmlRpcLib;
using NTK.IO.Xml;
using CGE.OUT;


namespace LamaController
{
    class Program
    {
        // ARGS :
        //  -dev
        //  -prod
        //  -conf #configfile
        //  -test #plugin
        //  
        //
        static void Main(string[] args)
        {
            //Debug:
#if CLI
            args = new string[] { "-c" };
#endif

            bool isCli = false;
            if (args.Length > 0)
            {
                if (args[0] == "-c")
                {
                /*    WebLinkUpdater wlu = new WebLinkUpdater("http://127.0.0.1/WebLinkExemple/", new Version("1.1.1"));
                    if (!wlu.CheckVersion())
                    {
                        Loading load = new Loading("Update : ", true);
                        wlu.DownLoad(@"D:\lf.zip");
                        load.stop();
                    }*/


                    /////////////////////////////
                    LamaCLI cli = new LamaCLI();
                    isCli = true;
                    cli.start();
                }


            }
            if (!isCli)
            {
                try
                {
                    LamaController controller = new LamaController(new XmlDocument("Config.xml"));
                }
                catch(Exception e)
                {
                    Console.Write(e.Message);
                    Console.ReadLine();
                }
            }

        }
    }
}
