using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTK.IO.Xml;
using static NTK.Other.NTKF;
using NTK.IO;
using NTK;
using TMXmlRpcLib;
using System.IO;
using System.Net;
using LamaPlugin;
using XmlRpcEncrypted;
using NTK.Service;
using CGE.OUT;

namespace LamaController
{
    public enum Game
    {
        TM,
        SM
    }

    public class LamaController
    {
        //CGE

        DataGrid dg;

        //Network
        NTKServer ntkServer;
        XmlRpcClient client;

        XmlNode mainConfig;
        XmlNode pluginsConfig;
        XmlNode logsConfig;
        MainLogger mainLogger;
        NTKLogger ntkLogger;

        List<InGamePlugin> plugins = new List<InGamePlugin>();
        string ip;
        int port;
        string login;
        string pass;
        Game game;
        bool connected;
        bool remoteXmlRpc = true;


        public LamaController(XmlDocument config)
        {
            Console.WriteLine("LamaController V0.1");
            Console.WriteLine("GNU");
            Console.WriteLine();

            this.logsConfig = config["Logs"];
            //manage logger


            this.mainConfig = config["Main"];
            this.ip = this.mainConfig["Ip"].Value;
            this.port = (int)this.mainConfig["Port"].LValue;
            this.login = this.mainConfig["Login"].Value;
            this.pass = this.mainConfig["Password"].Value;
        //    this.remoteXmlRpc = (this.mainConfig["RemoteXmlRpx"].Value.ToUpper().Equals("TRUE"));

            this.pluginsConfig = config["Plugins"];
            foreach(XmlNode node in this.pluginsConfig.Childs)
            {
                if ((!node.haveAttribute("enable")) || (node.haveAttribute("enable") && node.getAttribute("enable").Value.ToUpper() == "TRUE"))
                {
                    loadPlugin(node.Value);
                }
            }
            try
            {
                this.client = new XmlRpcClient(this.ip, this.port);

                if (remoteXmlRpc)
                {
                    this.ntkServer = new NTKServer(1141, CTYPE.OTHER, true, new SXmlRpcEncrypted(this.client, this.login, this.pass))
                    {   //Précisions :
                        Plugins = false,
                        FileTransfert = false,
                        Header = true,
                        Logs = new NTKLogger(@"Logs\XmlRpcEncrypted.log"),
                        ConsoleLog = new NTKLogger(@"Logs\NTKServer.log")
                    };
                    this.ntkServer.start();

                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Err: " + e.ToString());
            }
            Console.ReadKey();
        }




        void loadPlugin(string name)
        {
            Loading load = new Loading(name);
            try
            {
                load.start();

                List<string> args = new List<string>();

                //Manage params
                if (name.Contains("["))
                {
                    if (!name.Contains("]"))
                        throw new Exception("Syntax error in : " + name);

                    string param = subsep(name, "[", "]");
                    args.AddRange(param.Split('|'));
                    name = subsep(name, 0, "[");
                }

                DllLoader loader = new DllLoader(name);

                if (args.Count != 0)
                {
                    foreach (string arg in args)
                    {
                        plugins.Add(loader.getClassInstance<InGamePlugin>(arg));
                    }
                }
                else
                {
                    plugins.AddRange(loader.getAllInstances<InGamePlugin>());
                }

                load.stop();
            }
            catch(Exception e)
            {
                load.stop(true);
            }
           
        }

    }
}
