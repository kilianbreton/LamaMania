﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LamaPlugin
{
    public static class StaticM
    {
        public static void checkRequirements(IEnumerable<IBase> pluginsList)
        {
            foreach(IBase plug in pluginsList)
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



    }
}