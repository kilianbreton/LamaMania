using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTK.IO.Xml;
using static NTK.Other.NTKF;
using NTK.IO;
using TMXmlRpcLib;
using System.IO;
using System.Net;
using LamaPlugin;


namespace LamaController
{
    public enum Game
    {
        TM,
        SM
    }

    public class LamaController
    {
        XmlNode mainConfig;
        XmlNode pluginsConfig;
        XmlNode logsConfig;
        List<InGamePlugin> plugins = new List<InGamePlugin>();
        string ip;
        int port;
        string login;
        string pass;
        Game game;
        bool connected;


        public LamaController(XmlDocument config)
        {
            this.logsConfig = config["Logs"];
            //manage logger


            this.mainConfig = config["Main"];
            this.ip = this.mainConfig["Ip"].Value;
            this.port = (int)this.mainConfig["Port"].LValue;
            this.login = this.mainConfig["Login"].Value;
            this.pass = this.mainConfig["Password"].Value;
         

            this.pluginsConfig = config["Plugins"];
            foreach(XmlNode node in this.pluginsConfig.Childs)
            {
                if(!node.haveAttribute("enable") 
                || (node.haveAttribute("enable") && node.getAttribute("enable").Value.ToUpper().Equals("TRUE")))
                {
                    loadPlugin(node.Value);
                }
            }
          



        }




        void loadPlugin(string name)
        {
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

            if(args.Count != 0)
            {
                foreach(string arg in args)
                {
                    plugins.Add(loader.getClassInstance<InGamePlugin>(arg));
                }
            }
            else
            {
                plugins.AddRange(loader.getAllInstances<InGamePlugin>());
            }


        }

    }
}
