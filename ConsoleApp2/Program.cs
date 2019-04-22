using System;
using System.Collections.Generic;
using System.Text;
using TMXmlRpcLib;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlRpcClient client = new XmlRpcClient("127.0.0.1", 5001);
            //client.Connect("127.0.0.1",5001);
            var result = client.Request("Authenticate", new object[2]
            {
                (object)"SuperAdmin",
                (object)"SDG5454tuf54sd4HJK54F"
            });

        }
    }
}
