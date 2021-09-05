using System;
using System.Collections.Generic;
using System.Text;

namespace LamaPlugin
{
    public enum RequirementContext
    {
        LOCAL,
        REMOTE,
        S_XML_RPC_REMOTE
    }

    public enum RequirementType
    {
        PLUGIN,
        DATABASE,
        FILE,
        CONTEXT,
        XmlRpcConnection,
        ExternalTool,
    }

    [Serializable]
    public class Requirement
    {
        private RequirementType type;
        private string value;
        
        public Requirement(RequirementType type, string value)
        {
            this.type = type;
            this.value = value;
        }

        public Requirement(RequirementType type, bool value)
        {
            if (value)
                this.value = "TRUE";
            else
                this.value = "FALSE";

            this.type = type;
        }


        public Requirement(RequirementContext context)
        {
            this.type = RequirementType.CONTEXT;
            this.value = context.ToString();
        }


        public RequirementType Type { get => type; set => type = value; }
        public string Value { get => value; set => this.value = value; }
    }
}
