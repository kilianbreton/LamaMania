using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NTK.IO.Xml;
using NTK.Database;
using static LamaMania.Program;

namespace LamaMania
{
    public class ServersManager
    {
        XmlNode serversCfg;
        string path;
        DirectoryInfo serversDir;



        public ServersManager(string path, XmlNode serversCfg)
        {
            lama.log("NOTICE", "Init Servers manager");
            this.path = path;
            this.serversCfg = serversCfg;
            this.serversDir = new DirectoryInfo(path);
        }


        /// <summary>
        /// Get server config by id
        /// </summary>
        /// <param name="id">Server id</param>
        /// <returns></returns>
        public XmlNode getCfg(int id)
        {
            int cpt = 0;
            
            //search
            while(serversCfg[cpt].getAttibuteV("id") != id.ToString() && cpt < serversCfg.Childs.Count) { cpt++; }
            
            if (serversCfg[cpt].getAttibuteV("id") == id.ToString())
            {
                return serversCfg[cpt];
            }

            throw new LamaBadServerId(id);
        }


        /// <summary>
        /// Get server config by name
        /// </summary>
        /// <param name="name">Server name</param>
        /// <returns></returns>
        public XmlNode getCfg(string name)
        {

            int cpt = 0;

            //search
            while (serversCfg[cpt].getChildV("name") != name && cpt < serversCfg.Childs.Count) { cpt++; }

            if (serversCfg[cpt].getChildV("name") == name)
            {
                return serversCfg[cpt];
            }

            throw new LamaBadServerName(name);
        }

        /// <summary>
        /// Return Db connection instance from ServerId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public NTKDatabase loadDatabase(int id)
        {
            XmlNode cfg = getCfg(id);

            //Open database connection
            if (cfg["database"].haveAttribute("value") && cfg["database"].getAttibuteV("value").ToUpper().Equals("TRUE"))
            {
                string ip = cfg["database"]["ip"].Value;
                string login = cfg["database"]["login"].Value;
                string passwd = cfg["database"]["passwd"].Value;
                string baseName = cfg["database"]["baseName"].Value;
                return NTKD_MySql.overrideInstance(ip, login, passwd, baseName);
            }
            else
            {
                string name = cfg["name"].Value;
                throw new LamaNoDbServerException(name);
            }

        }



        /// <summary>
        /// Return Db connection instance from ServerName
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public NTKDatabase loadDatabase(string name)
        {
            XmlNode cfg = getCfg(name);

            //Open database connection
            if (cfg["database"].haveAttribute("value") && cfg["database"].getAttibuteV("value").ToUpper().Equals("TRUE"))
            {
                string ip = cfg["database"]["ip"].Value;
                string login = cfg["database"]["login"].Value;
                string passwd = cfg["database"]["passwd"].Value;
                string baseName = cfg["database"]["baseName"].Value;
                return NTKD_MySql.overrideInstance(ip, login, passwd, baseName);
            }
            else
            {
                throw new LamaNoDbServerException(name);
            }

        }

        public int getIdByName(string name)
        {
            return int.Parse(getCfg(name).getAttibuteV("id"));
        }

        public string getNameById(int id)
        {
            return getCfg(id).getChildV("name");
        }


        public void removeById(int id)
        {
            serversCfg.removeChildsByAttribute("server", "id", id.ToString());
        }


        public string[] getServersList()
        {
            string[] l = new string[serversCfg.count()];
            int cpt = 0;
            foreach(XmlNode n in serversCfg)
            {
                l[cpt++] = n.getChildV("name");
            }
            return l;
        }


    }



    //========================================================================================================================================
    //==Exceptions============================================================================================================================
    //========================================================================================================================================


    public class LamaBadServerId : Exception
    {
        public LamaBadServerId(int serverId) : base("this server id does not exist : " + serverId)
        {

        }

    }



    public class LamaBadServerName : Exception
    {
        public LamaBadServerName(string serverName) : base("this server name does not exist : " + serverName)
        {

        }

    }



    public class LamaNoDbServerException : Exception
    {
        public LamaNoDbServerException(string serverName) : base(serverName + " does not have a configured database")
        {

        }

    }

}
