using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LamaPlugin
{
    public static class StaticM
    {
        public static void checkRequirements(IEnumerable<IBasePlugin> pluginsList)
        {
            foreach(IBasePlugin plug in pluginsList)
            {
                foreach(Requirement req in plug.Requirements)
                {
                    if(req.Type == RequirementType.PLUGIN)
                    {

                    }
                }
            }


        }

        public static T useT<T>(object obj)
        {
            return (T) obj;
        }


        


        public static void parseTime(int time, out int h, out int m, out int s)
        {
            h = 0;
            m = time / 60;
            if (m >= 60)
            {
                h = m / 60;
                m = m % 60;
            }
            s = time % 60;
        }

    }
}
