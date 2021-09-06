using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTK.IO.Xml;

namespace LamaPlugin.ManiaLink
{
    
    public class MLFrameModel : ManiaLinkNode
    {
        private string id = "";
            
        public MLFrameModel() : base(true)
        {
        }

        public MLFrameModel(string id) : base(true)
        {
            this.id = id;
        }

        public string Id { get => id; set => id = value; }

        public override XmlNode toXml()
        {
            XmlNode ret = new XmlNode("frame");
            ret.addAttribute("id", this.id);
            ret.AutoClose = true;

            foreach (ManiaLinkNode n in Childs)
            {
                ret.addChild(n.toXml());
            }

            return ret;
        }
    }
}


