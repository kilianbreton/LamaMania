using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMXmlRpcLib;

namespace LamaMania
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
     
        /// <summary>
        /// Cast .Params[0] to Hashtable 
        /// </summary>
        /// <param name="call"></param>
        /// <returns></returns>
        public static Hashtable getHashTable(this GbxCallbackEventArgs call)
        {
            return (Hashtable)call.Response.Params[0];
        }

        /// <summary>
        /// Get key of value
        /// </summary>
        /// <typeparam name="T">Key type</typeparam>
        /// <typeparam name="T2">Value type</typeparam>
        /// <param name="dic"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T getKeyFromValue<T, T2>(this IDictionary<T, T2> dic, T2 value)
        {
            T ret = default(T);
            bool find = false;

            foreach (KeyValuePair<T, T2> kvp in dic)
            {
                if (kvp.Value.Equals(value))
                {
                    ret = kvp.Key;
                    find = true;
                    break;
                }
            }
            if (!find)
                throw new Exception("Undefined value in dictionary");
            return ret;
        }

        /// <summary>
        /// Return invoked control
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        public static T getControl<T>(this Control control)
        {
            if (control.InvokeRequired)
            {
                return (T)control.Invoke(new Func<Control, T>(getControl<T>), control);
            }
            else
            {
                return (T)(object)control;
            }
        }

    }
}
