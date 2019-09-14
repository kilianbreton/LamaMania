using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LamaPlugin;
using static LamaPlugin.StaticM;
namespace LamaMania
{
    public class ControlThreadManager
    {
        private Form form;

        public ControlThreadManager(Form form)
        {
            this.form = form;
        }


        public void setLabel(string name, string value)
        {
            useT<Label>(getControl(name)).Text = value;
        }

        /// <summary>
        /// Return .Text label's value
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string getLabel(string name)
        {
            return useT<Label>(getControl(name)).Text;
        }





        Control getControl(string name)
        {
            Control ret = null;
            if (this.form.InvokeRequired)
            {
                ret = (Control)this.form.Invoke(new Func<String, Control>(getControl), name);
            }
            else
            {
                foreach (Control c in this.form.Controls)
                {
                    if (c.Name == name)
                    {
                        ret = c;
                        break;
                    }
                    else
                    {
                        if (c.Controls.Count > 0)
                        {
                            ret = getControl(c, name);
                            if (ret != null)
                                break;
                        }
                    }
                }
            }
            return ret;
        }

        Control getControl(Control control, string name)
        {
            Control ret = null;
            foreach (Control c in control.Controls)
            {
                if(c.Name == name)
                {
                    ret = c;
                    break;
                }
                else
                {
                    if(c.Controls.Count > 0)
                    {
                        ret = getControl(c, name);
                        if (ret != null)
                            break;
                    }
                }
            }
            return ret;
        }

    }
}
