using System;
using System.Collections.Generic;
using System.Text;

namespace LamaLang
{
    public class NodeLang
    {
        private List<NodeLang> nodes = new List<NodeLang>();
        private string name;
        private string value;

       

        public NodeLang(string name, string value)
        {
            this.name = name;
            this.value = value;
        }

        public NodeLang(string name)
        {
            this.name = name;
        }

        public NodeLang(string name, NodeLang child)
        {
            this.name = name;
            this.nodes.Add(child);
        }

        public NodeLang this[string name]
        {
            get
            {
                int cpt = 0;
                while(cpt < nodes.Count && name != nodes[cpt].Name) { cpt++; }

                if (name == nodes[cpt].Name)
                    return nodes[cpt];
                else
                    throw new Exception("Node " + name + " undefined");
            }
        }

        public NodeLang addChild(string name, string value)
        {
            NodeLang child = new NodeLang(name, value);
            nodes.Add(child);
            return child;
        }

        public NodeLang addChild(string name)
        {
            NodeLang child = new NodeLang(name);
            nodes.Add(child);
            return child;
        }

        public NodeLang addChild(string name, NodeLang child)
        {
            nodes.Add(child);
            return child;
        }

        public List<NodeLang> Nodes { get => nodes; set => nodes = value; }
        public string Name { get => name; set => name = value; }
        public string Value { get => value; set => this.value = value; }


    }
}
