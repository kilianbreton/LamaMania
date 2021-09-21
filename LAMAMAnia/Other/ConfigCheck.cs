using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTK.IO.Xml;


namespace LamaMania
{
    public class ConfigCheck
    {
        XmlDocument config;

        
        public ConfigCheck(XmlDocument cfg)
        {
            config = cfg;
        }

        public bool Check(out string msg)
        {
            msg = "";
            bool res = serversCheck(out msg);
            if(!res)
            {
                res = configServPluginsCheck(out msg);
                if(!res)
                {
                    res = toolsCheck(out msg);
                }
            }
            return res;
        }



        public bool serversCheck(out string msg)
        {
            msg = "";
            foreach(XmlNode serv in config[0]["servers"])
            {
                string sid = serv.getAttibuteV("id");
                if (int.TryParse(sid, out int id))
                {

                }
                else
                {
                    msg = "Error : Id '" + sid +"' is not an integer in servers list";
                    return false;
                }
            }
            
            
            return true;
        }

        public bool configServPluginsCheck(out string msg)
        {
            msg = "";
            return false;
        }



        public bool toolsCheck(out string msg)
        {
            msg = "";
            return false;
        }









    }
}
