using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMXmlRpcLib;

namespace LamaPlugin
{
    public static class StaticM
    {
        /// <summary>
        /// Simple request
        /// </summary>
        /// <param name="client"></param>
        /// <param name="methodName"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static GbxCall Request(this XmlRpcClient client, string methodName, params object[] param)
        {
            return client.Request(methodName, param);
        }


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
