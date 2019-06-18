using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LamaPlugin
{
    public abstract class BasePlugin
    {
        private List<Requirement> requirements = new List<Requirement>();

        private string author = "";
        private string name = "";
        private string version = "";

        public BasePlugin() { }


        ///////////////////////////////////////////////////////////////////////////////////////////////////
        // GETTERS ///////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////

        public List<Requirement> Requirements { get => requirements; protected set => requirements = value; }

        public string Author { get => author; protected set => author = value; }
        public string Name { get => name; protected set => name = value; }
        public string Version { get => version; protected set => version = value; }
    }
}
