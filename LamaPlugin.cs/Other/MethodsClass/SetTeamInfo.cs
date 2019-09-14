using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LamaPlugin.Other.MethodsClass
{
    public class SetTeamInfo : Abstract.AbstractXmlRpcMethod<bool>
    {
        const string name = "SetTeamInfo";
        public SetTeamInfo(string a, double b, string c, string d, double e, string f, string g, double h, string i) 
            : base(name, new object[] 
            {
                a,
                b,
                c,
                d,
                e,
                f,
                g,
                h,
                i
            }) { }
    }
}
