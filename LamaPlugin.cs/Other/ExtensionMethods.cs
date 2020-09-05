using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMXmlRpcLib;
using System.Windows.Forms;
using FlatUITheme;
using System.Collections;

namespace LamaPlugin
{
    public static class ExtensionMethods
    {
      

        public static Dictionary<string, string> textBoxsNames = new Dictionary<string, string>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tb"></param>
        /// <param name="name"></param>
        public static void initName(this FlatLabel tb, string name)
        {
            tb = getControl<FlatLabel>(tb);
            if (!textBoxsNames.ContainsKey(tb.Name))
                textBoxsNames.Add(tb.Name, name);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tb"></param>
        /// <param name="text"></param>
        public static void setText(this FlatLabel tb, string text)
        {
            try
            {
                tb = getControl<FlatLabel>(tb);
                if (textBoxsNames.ContainsKey(tb.Name))
                    tb.Text = textBoxsNames[tb.Name] + " : " + text;
                else
                    tb.Text = text;
            }
            catch(Exception e)
            {
                MessageBox.Show("Erreur :" + e.Message + "\n" + "TODO : Log ");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tb"></param>
        /// <param name="name"></param>
        public static void initName(this Label tb, string name)
        {
            tb = getControl<Label>(tb);
            if (!textBoxsNames.ContainsKey(tb.Name))
                textBoxsNames.Add(tb.Name, name);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tb"></param>
        /// <param name="text"></param>
        public static void setText(this Label tb, string text)
        {
            tb = getControl<Label>(tb);
            if (textBoxsNames.ContainsKey(tb.Name))
                tb.Text = textBoxsNames[tb.Name] + text;
             //   tb.Text = textBoxsNames[tb.Name] + " : " + text;

        }

        public static void asyncRequest(this XmlRpcClient client, GbxCallCallbackHandler handler, String methodName, params object[] param)
        {
            if (param == null)
                param = new object[] { };
            client.AsyncRequest(methodName, param, handler);
        }

        public static void asyncRequest(this XmlRpcClient client, String methodName, GbxCallCallbackHandler handler)
        {
            client.AsyncRequest(methodName, new object[] { }, handler);
        }





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
     
      
        /*#####################################################################################################
        # Private copy from LamaMania.StaticMethods ###########################################################
        #####################################################################################################*/
        private static T getControl<T>(this Control control)
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


        private static Control getControl(Control control)
        {
            if (control.InvokeRequired)
            {
                return (Control)control.Invoke(new Func<Control, Control>(getControl), control);
            }
            else
            {
                return control;
            }
        }


    }
}
