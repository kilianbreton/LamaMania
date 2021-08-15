using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTK.IO.Xml;

namespace LamaPlugin.ManiaLink
{
    public class MLLabel : ManiaLinkNode
    {
        private string text;
        private int x;
        private int y;
        private int zIndex;
        private string bgcolor;

        public MLLabel(string text) : base(false)
        {
            this.text = text;
        }

        public MLLabel(string text, int x, int y) : base(false)
        {
            this.text = text;
            this.x = x;
            this.y = y;
        }

        public MLLabel(string text, int x, int y, int zIndex) :base(false)
        {
            this.text = text;
            this.x = x;
            this.y = y;
            this.zIndex = zIndex;
        }

        public MLLabel(string text, int x, int y, int zIndex, string bgcolor) : base(false)
        {
            this.text = text;
            this.x = x;
            this.y = y;
            this.zIndex = zIndex;
            this.bgcolor = bgcolor;
        }

        public override XmlNode toXml()
        {
            XmlNode ret = new XmlNode("label");

            ret.addAttribute("pos", this.x + " " + this.y)
                .addAttribute("z-index", this.zIndex.ToString())
                .addAttribute("text", this.text)
                .addAttribute("bgcolor", this.bgcolor);
            ret.AutoClose = true;

            return ret;
        }


        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public int ZIndex { get => zIndex; set => zIndex = value; }
        public string Bgcolor { get => bgcolor; set => bgcolor = value; }
        public string Text { get => text; set => text = value; }
    }
}
