using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMXmlRpcLib;

namespace LamaPlugin.Abstract
{
    public abstract class AbstractXmlRpcMethod<ReturnType>
    {
        protected object[] args;
        protected string methodName;
        protected int handleId;
        private ReturnType r;

        

        public AbstractXmlRpcMethod(string methodName, object[] args)
        {
            this.args = args;
            this.methodName = methodName;
        }

        public int executeMethod(XmlRpcClient client, GbxCallCallbackHandler handler)
        {
            return client.AsyncRequest(methodName, args, handler);
        }
        public int executeMethod(XmlRpcClient client)
        {
            return client.AsyncRequest(methodName, args, res => {
                this.r = (ReturnType)res.Params[0];
            });
        }


        protected ReturnType Result { get => r; set => r = value; }

    }
}
