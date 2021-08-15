using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTK.IO.Xml;


namespace LamaPlugin.ManiaLink
{
    public class MLFrame : ManiaLinkNode
    {
        private int x = 0;
        private int y = 0;
        private int z = 0;

        public MLFrame() : base(true)
        {
        }

        public MLFrame(int x, int y) : base(true)
        {
            this.x = x;
            this.y = y;
        }
        public MLFrame(int x, int y, int z) : base(true)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public override XmlNode toXml()
        {
            XmlNode ret = new XmlNode("frame");
            ret.addAttribute("pos", this.x + " " + this.y);
            ret.addAttribute("z-index", this.z.ToString());
            ret.AutoClose = true;

            foreach(ManiaLinkNode n in Childs)
            {
                ret.addChild(n.toXml());
            }

            return ret;
        }
    }
}
