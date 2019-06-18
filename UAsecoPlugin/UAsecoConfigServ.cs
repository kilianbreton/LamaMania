using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LamaPlugin;

namespace UAsecoPlugin
{
    public class UAsecoConfigServ : TabPlugin
    {
        public UAsecoConfigServ()
        {
            this.Author = "KilianBT";
            this.Name = "UAsecoConfig";
            this.Version = "0.1";
            this.IsConfigServPlugin = true;
            this.Requirements.Add(new Requirement(RequirementType.DATABASE, "dbname:login>pass"));
            this.Requirements.Add(new Requirement(RequirementType.FILE, @"locales\main.xml"));
            this.Requirements.Add(new Requirement(RequirementType.PLUGIN, "UAsecoInGame"));            
        }

        public override Control getTab()
        {
            return new ConfigServControl();
        }
    }
}
