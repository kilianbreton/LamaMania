using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMXmlRpcLib;

namespace LamaPlugin
{
    public interface IManager
    {
        void onGbxCallBack(object sender, GbxCallbackEventArgs args);

    }
}
