using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LamaPlugin
{
    public class InterPluginResponse
    {
        private string callName;
        private Dictionary<string, object> param = new Dictionary<string, object>();
        private bool error;
        private string errorMessage;


        public InterPluginResponse(string callName, Dictionary<string, object> param)
        {
            this.callName = callName;
            this.param = param;
        }

        public InterPluginResponse(bool error, string errorMessage)
        {
            this.error = error;
            this.errorMessage = errorMessage;
        }



        public string CallName { get => callName; set => callName = value; }
        public Dictionary<string, object> Param { get => param; set => param = value; }
        public bool Error { get => error; set => error = value; }
        public string ErrorMessage { get => errorMessage; set => errorMessage = value; }
    }
}
