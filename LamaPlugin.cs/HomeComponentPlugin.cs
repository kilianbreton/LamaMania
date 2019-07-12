using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMXmlRpcLib;

namespace LamaPlugin
{
    public abstract class HomeComponentPlugin : UserControl, IHomeComponent
    {
        protected Dictionary<int, string> handles = new Dictionary<int, string>();

        protected void asyncRequest(String methodeName, params object[] param)
        {
            if (param == null)
                param = new object[] { };
            this.handles.Add(this.client.AsyncRequest(methodeName, param, onGbxAsyncResult), methodeName);
        }

        protected void asyncRequest(GbxCallCallbackHandler handler, String methodName, params object[] param)
        {
            if (param == null)
                param = new object[] { };
            this.client.AsyncRequest(methodName, param, handler);
        }

        protected void asyncRequest(String methodName, GbxCallCallbackHandler handler)
        {
            this.client.AsyncRequest(methodName, new object[] { }, handler);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Abstract ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    
        protected abstract void onGbxAsyncResult(GbxCall res);

        public abstract void onGbxCallBack(GbxCallbackEventArgs res);
       

        public XmlRpcClient client { get; set; }
        public HomeComponentType Type { get; set; }
        public string Author { get; set; }
        public string Version { get; set; }
        public List<Requirement> Requirements { get; set; }
        public string PluginName { get; set; }
    }
}
