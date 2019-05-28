using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMXmlRpcLib;

namespace LAMAMAnia
{
    /// <summary>
    /// Class for add methods in other class
    /// </summary>
    public static class ExtensionsMethods
    {
        /// <summary>
        /// Cast .Params[0] to Hashtable 
        /// </summary>
        /// <param name="call"></param>
        /// <returns></returns>
        public static Hashtable getHashTable(this GbxCall call)
        {
            return (Hashtable)call.Params[0];
        }


    }
}
