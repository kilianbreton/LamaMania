using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMXmlRpcLib;

namespace LamaPlugin
{
    public static class ExtensionMethods
    {
        public static void asyncRequest(this XmlRpcClient client, GbxCallCallbackHandler handler, String methodName, params object[] param)
        {
            if (param == null)
                param = new object[] { };
            client.AsyncRequest(methodName, param, handler);
        }

        public static void asyncRequest(this XmlRpcClient client, String methodName, GbxCallCallbackHandler handler)
        {
            client.AsyncRequest(methodName, new object[] { }, handler);
        }
    }
}
