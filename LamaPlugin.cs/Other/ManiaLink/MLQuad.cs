using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTK.IO.Xml;

namespace LamaPlugin
{
    public class MLQuad : ManiaLinkNode
    {
        private int x;
        private int y;
        private int zIndex;
        private int width;
        private int height;
        private string bgcolor;
        private string style;
        private string substyle;
        private string action;



        public MLQuad(int x, int y) : base(false)
        {
            this.x = x;
            this.y = y;
        }

        public MLQuad(int x, int y, int zIndex) : base(false)
        {
            this.x = x;
            this.y = y;
            this.zIndex = zIndex;
        }

        public MLQuad(int x, int y, int width, int height) : base(false)
        {
            this.x = x;
            this.y = y;

            this.width = width;
            this.height = height;
        }

        public MLQuad(int x, int y, int zIndex, int width, int height) : base(false)
        {
            this.x = x;
            this.y = y;
            this.zIndex = zIndex;
            this.width = width;
            this.height = height;
        }

        public MLQuad(int x, int y, int zIndex, int width, int height, string bgcolor) : base(false)
        {
            this.x = x;
            this.y = y;
            this.zIndex = zIndex;
            this.width = width;
            this.height = height;
            this.bgcolor = bgcolor;
        }

        public MLQuad(int x, int y, int zIndex, int width, int height, string bgcolor, string style) : base(false)
        {
            this.x = x;
            this.y = y;
            this.zIndex = zIndex;
            this.width = width;
            this.height = height;
            this.bgcolor = bgcolor;
            this.style = style;
        }

        public MLQuad(int x, int y, int zIndex, int width, int height, string bgcolor, string style, string substyle) : base(false)
        {
            this.x = x;
            this.y = y;
            this.zIndex = zIndex;
            this.width = width;
            this.height = height;
            this.bgcolor = bgcolor;
            this.substyle = substyle;
            this.style = style;
        }

        public MLQuad(int x, int y, int zIndex, int width, int height, string bgcolor, string style, string substyle, string action) : base(false)
        {
            this.x = x;
            this.y = y;
            this.zIndex = zIndex;
            this.width = width;
            this.height = height;
            this.bgcolor = bgcolor;
            this.substyle = substyle;
            this.style = style;
            this.action = action;
        }



        public override XmlNode toXml()
        {
            XmlNode ret = new XmlNode("quad");

            ret.addAttribute("pos", this.x + " " + this.y)
                .addAttribute("z-index", this.zIndex.ToString())
                .addAttribute("size", this.width + " " + this.height)
                .addAttribute("bgcolor", this.bgcolor)
                .addAttribute("style", this.style)
                .addAttribute("substyle", this.substyle)
                .addAttribute("action", this.action);
            ret.AutoClose = true;


            return ret;
        }


        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public int ZIndex { get => zIndex; set => zIndex = value; }
        public int Width { get => width; set => width = value; }
        public int Height { get => height; set => height = value; }
        public string Bgcolor { get => bgcolor; set => bgcolor = value; }
        public string Style { get => style; set => style = value; }
        public string Substyle { get => substyle; set => substyle = value; }
        public string Action { get => action; set => action = value; }
    }
}
