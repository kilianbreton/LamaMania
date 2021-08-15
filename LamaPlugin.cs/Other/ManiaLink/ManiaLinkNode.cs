using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTK.IO.Xml;

namespace LamaPlugin.ManiaLink
{
    public abstract class ManiaLinkNode
    {
        protected bool canHaveChild;
        private List<ManiaLinkNode> childs = new List<ManiaLinkNode>();


        public ManiaLinkNode(bool canHaveChild)
        {
            this.canHaveChild = canHaveChild;
            
        }

        public List<ManiaLinkNode> Childs { get => childs; protected set => childs = value; }

        public abstract XmlNode toXml();


    }
}
