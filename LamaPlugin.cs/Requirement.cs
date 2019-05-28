using System;
using System.Collections.Generic;
using System.Text;

namespace LamaPlugin
{
    public class Requirement
    {
        private RequirementType type;
        private string value;

        public Requirement(RequirementType type, string value)
        {
            this.type = type;
            this.value = value;
        }

        public RequirementType Type { get => type; set => type = value; }
        public string Value { get => value; set => this.value = value; }
    }
}
