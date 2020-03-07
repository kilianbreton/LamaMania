using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTK.IO.Xml;

namespace LamaPlugin
{
    //##########################################################################################################
    //# STRUCTS ################################################################################################
    //##########################################################################################################

  
   

    


    public struct MLAudio
    {

    }

    public struct MLMusic
    {

    }

  


    //##########################################################################################################
    //# CLASS ##################################################################################################
    //##########################################################################################################


    public class ManialinkFile
    {
        private XmlDocument xmlManialink;
        private List<ManiaLinkNode> nodes = new List<ManiaLinkNode>();
       

        private string header;


        public ManialinkFile(bool header)
        {
            if(header)
                this.header = "<?xml version=\"1.0\" encoding=\"utf - 8\" standalone=\"yes\" ?>";
            else
                this.header = null;
        }


        public XmlDocument getXmlDocument()
        {
            XmlDocument xmld = new XmlDocument();
            XmlNode root = xmld.addNode("manialink")
                               .addAttribute("version", "3");

            root.AutoClose = false;
          
            foreach (ManiaLinkNode mln in nodes)
            {
                root.addChild(mln.toXml());
            }

            return xmld;
        }


        public string getXmlText()
        {
            return getXmlDocument().print();
        }




        public List<ManiaLinkNode> Nodes { get => nodes; set => nodes = value; }


    }
}
