using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMXmlRpcLib;
using LamaPlugin;
using FlatUITheme;

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
        /// Cast .Params[0] to ArrayList
        /// </summary>
        /// <param name="call"></param>
        /// <returns></returns>
        public static ArrayList getArrayList(this GbxCall call)
        {
            return (ArrayList)call.Params[0];
        }

        /// <summary>
        /// Cast .Params[0] to ArrayList
        /// </summary>
        /// <param name="call"></param>
        /// <returns></returns>
        public static ArrayList getArrayList(this GbxCallbackEventArgs call)
        {
            return (ArrayList)call.Response.Params[0];
        }

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


        /// <summary>
        /// Get key of value
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dic"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static TKey getKeyFromValue<TKey, TValue>(this IDictionary<TKey, TValue> dic, TValue value)
        {
            TKey ret = default(TKey);
            bool find = false;

            foreach (KeyValuePair<TKey, TValue> kvp in dic)
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
            else
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uc"></param>
        /// <returns></returns>
        public static ITab getITabInterface(this UserControl uc)
        {
            return (ITab) uc;
        }

    }
}
