using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LamaPlugin;
using TMXmlRpcLib;

namespace BasicsCommandsPlugin
{
    public class BasicsCommandPlugin : BasePlugin
    {
        //Msg const
        private const string WELCOME_MESSAGE = "Welcome on #S server, type /help to show commands !";
        private const string HEAD_USER = "User commands :";
        private const string HEAD_ADMIN = "Admin commands :";
        private const string HEAD_SUPERADMIN = "SuperAdmin commands :";

        public BasicsCommandPlugin()
        {
            this.Author = "Breton Kilian";
            this.Name = "Basics Commands";
            this.Version = "0.1";
            this.Requirements.Add(new Requirement(RequirementType.GameType, "TM"));
            this.Requirements.Add(new Requirement(RequirementType.VERSION, ">=0.3.*"));
            this.Requirements.Add(new Requirement(RequirementType.DATABASE, ">=0.3.*"));
        }


        public override bool onLoad(LamaConfig lamaConfig)
        {
            var test = lamaConfig.connected;

            return true;
        }

        public override void onGbxAsyncResult(GbxCall res)
        {
            if (this.handles.ContainsKey(res.Handle))
            {
                switch (this.handles[res.Handle])
                {
                    case "":
                        break;
                }
            }
        }

        public override void onGbxCallBack(object sender, GbxCallbackEventArgs args)
        {
            
        }

    
    }
}
