using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTK.IO.Xml;

namespace LamaPlugin.ManiaLink
{

    public class MLFrameInstance : ManiaLinkNode
    {
        MLFrameModel model;
        string id;
        int x;
        int y;
        int zIndex;
        int valign;
        int halign;

        public MLFrameInstance() : base(true)
        {
        }

        public MLFrameInstance(string id) : base(true)
        {
            this.id = id;
        }

        public MLFrameInstance(MLFrameModel model, string id) : base(true)
        {
            this.model = model;
            this.id = id;
        }

        public MLFrameInstance(MLFrameModel model, string id, int x, int y) : base(true)
        {
            this.model = model;
            this.id = id;
            this.x = x;
            this.y = y;
        }

        public MLFrameInstance(MLFrameModel model, string id, int x, int y, int zIndex, int valign, int halign) : base(true)
        {
            this.model = model;
            this.id = id;
            this.x = x;
            this.y = y;
            this.zIndex = zIndex;
            this.valign = valign;
            this.halign = halign;
        }


        public override XmlNode toXml()
        {
            XmlNode ret = new XmlNode("frame");
            ret.addAttribute("modelid", this.model.Id)
               .addAttribute("id", this.id)
               .addAttribute("pos", this.x + " " + this.y)
               .addAttribute("z-index", this.zIndex.ToString())
               .addAttribute("valign", this.valign.ToString())
               .addAttribute("halign", this.halign.ToString());
            ret.AutoClose = true;

            foreach (ManiaLinkNode n in Childs)
            {
                ret.addChild(n.toXml());
            }

            return ret;
        }




        public MLFrameModel Model { get => model; set => model = value; }
        public string Id { get => id; set => id = value; }
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public int ZIndex { get => zIndex; set => zIndex = value; }
        public int Valign { get => valign; set => valign = value; }
        public int Halign { get => halign; set => halign = value; }
    }
}


