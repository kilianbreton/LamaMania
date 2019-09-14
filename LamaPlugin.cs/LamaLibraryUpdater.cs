using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTK;

namespace LamaPlugin
{
    public class LamaLibraryUpdater : UpdateMethod
    {
        NTKClient client;
        string LamaAdrs = "lamamania.fr";
        int LamaPort = 9699;

        public LamaLibraryUpdater(string author, string pluginName, Version version) : base(author, pluginName, version)
        {
            this.client = new NTKClient(LamaAdrs, LamaPort, author, pluginName);
            

        }

        public override bool CheckVersion()
        {
            bool ret = true;
            this.client.connect();
            this.client.headerCheck(this.client.User, false);
            this.client.authenticate(this.client.User);
            this.client.writeMsg("GET VERSION");
            string version = this.client.readMsg();


            return ret;
        }

        public override string DownLoad(string finalPath)
        {
            throw new NotImplementedException();
        }
    }
}
