using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LamaPlugin;

namespace UAsecoPlugin
{
    public class ExempleUpdateMethod : UpdateMethod
    {
        string path;


        public ExempleUpdateMethod(string path)
        {
            this.path = path;
        }

        public override bool CheckVersion()
        {
            throw new NotImplementedException();
        }

        public override string DownLoad(string finalPath)
        {
            throw new NotImplementedException();
        }
    }
}
