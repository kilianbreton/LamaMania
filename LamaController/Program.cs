using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LamaPlugin;
using TMXmlRpcLib;
using NTK.IO.Xml;


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
            if(args != null)
            {

            }

            LamaController controller = new LamaController(new XmlDocument("Config.xml"));


        }
    }
}
