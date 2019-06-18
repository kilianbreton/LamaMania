using FlatUITheme;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LamaMania
{
    /// <summary>
    /// Global static methods
    /// </summary>
    public static class StaticMethods
    {
        /// <summary>
        /// Add row in DataGridView
        /// </summary>
        /// <param name="dg"></param>
        /// <param name="pars"></param>
        public static void addDgRow(DataGridView dg, params object[] pars)
        {
            if (dg.InvokeRequired)
            {
                dg.Invoke(new Action<DataGridView, object[]>(addDgRow), dg, pars);
            }
            else
            {
                dg.Rows.Add(pars);
            }
        }

        /// <summary>
        /// AddRow in listBox
        /// </summary>
        /// <param name="list"></param>
        /// <param name="value"></param>
        public static void appendList(ListBox list, String value)
        {
            if (list.InvokeRequired)
            {
                list.Invoke(new Action<ListBox, String>(appendList), list, value);
            }
            else
            {
                list.Items.Add(value);
            }
        }

        /// <summary>
        /// Clear listBox
        /// </summary>
        /// <param name="list"></param>
        public static void clearList(ListBox list)
        {
            if (list.InvokeRequired) //Permet de revenir au Thread de gestion des composants UI
            {
                list.Invoke(new Action<ListBox>(clearList), list);
            }
            else
            {
                list.Items.Clear();
            }
        }

        /// <summary>
        /// Clear DataGridView
        /// </summary>
        /// <param name="dg"></param>
        public static void clearDg(DataGridView dg)
        {
            if (dg.InvokeRequired) //Permet de revenir au Thread de gestion des composants UI
            {
                dg.Invoke(new Action<DataGridView>(clearDg), dg);
            }
            else
            {
                dg.Rows.Clear();
            }
        }

        /// <summary>
        /// Clear RichTextBox
        /// </summary>
        /// <param name="rtb"></param>
        public static void clearRichText(RichTextBox rtb)
        {

            if (rtb.InvokeRequired) //Permet de revenir au Thread de gestion des composants UI
            {
                rtb.Invoke(new Action<RichTextBox>(clearRichText), rtb);
            }
            else
            {
                rtb.Clear();
            }
        }

        /// <summary>
        /// Enable control
        /// </summary>
        /// <param name="control"></param>
        /// <param name="value"></param>
        public static void enableControl(Control control, bool value)
        {
            if (control.InvokeRequired) //Permet de revenir au Thread de gestion des composants UI
            {
                control.Invoke(new Action<Button, bool>(enableControl), control, value);
            }
            else
            {
                control.Enabled = value;
            }
        }
     
        /// <summary>
        /// 
        /// </summary>
        /// <param name="label"></param>
        /// <param name="value"></param>
        public static void setLabel(Label label, String value)
        {
            if (label.InvokeRequired) //Permet de revenir au Thread de gestion des composants UI
            {
                label.Invoke(new Action<Label, String>(setLabel), label, value);
            }
            else
            {
                label.Text = value;
            }
        }
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="label"></param>
        /// <param name="color"></param>
        public static void setLabelColor(Label label, Color color)
        {
            if (label.InvokeRequired) //Permet de revenir au Thread de gestion des composants UI
            {
                label.Invoke(new Action<Label, Color>(setLabelColor), label, color);
            }
            else
            {
                label.ForeColor = color;
            }
        }
      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tb"></param>
        /// <param name="text"></param>
        public static void setTextBoxText(FlatTextBox tb, string text)
        {
            tb = (FlatTextBox)getControl(tb);
            tb.Text = text;
        }
      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <param name="v"></param>
        public static void setNumeric(FlatNumeric n, int v)
        {
            n = (FlatNumeric)getControl(n);
            n.Value = v;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cb"></param>
        /// <param name="selectedValue"></param>
        public static void setComboBox(FlatComboBox cb, string selectedValue)
        {
            cb = (FlatComboBox)getControl(cb);
            cb.SelectedText = selectedValue;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cb"></param>
        /// <param name="value"></param>
        public static void setCheckBox(FlatCheckBox cb, bool value)
        {
            cb = (FlatCheckBox)getControl(cb);
            cb.Checked = value;
        }

        /// <summary>
        /// Get the control and Invoke if required
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        public static Control getControl(Control control)
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

        /// <summary>
        /// Convert seconds to H M S
        /// </summary>
        /// <param name="time"></param>
        /// <param name="h"></param>
        /// <param name="m"></param>
        /// <param name="s"></param>
        public static void parseTime(int time, out int h, out int m, out int s)
        {
            h = 0;
            m = 0;
            s = 0;
            while (time >= 60)
            {
                time = time - 60;
                if (++m == 60)
                {
                    m = 0;
                    h++;
                }
            }
            s = time;
        }

        /// <summary>
        /// 0 = string, 1 = int, 2 = bool
        /// </summary>
        /// <returns></returns>
        public static int getType(object value)
        {
            if (value.GetType() == true.GetType())
            {
                return 2;
            }
            else if (value.GetType() == 0.1.GetType())
            {
                return 3;
            }
            else if (value.GetType() == 0.GetType())
            {
                return 1;
            }
            else if (value.GetType() == "".GetType())
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// Copy directory dir into path directory
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="path"></param>
        public static void copyDirectory(DirectoryInfo dir, string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            foreach (FileInfo file in dir.EnumerateFiles())
            {
                try
                {
                    File.Copy(file.FullName, path + file.Name);
                }
                catch (Exception) { }
            }

            foreach (DirectoryInfo child in dir.EnumerateDirectories())
            {
                copyDirectory(child, path + child.Name + "\\");
            }

        }

        /// <summary>
        /// Fill TreeView from DirectoryInfo
        /// </summary>
        /// <param name="dir">root directory</param>
        /// <param name="node">root treeview node</param>
        public static void makeTreeview(DirectoryInfo dir, TreeNode node)
        {
            foreach (DirectoryInfo child in dir.GetDirectories())
            {
                makeTreeview(child, node.Nodes.Add(child.Name));
            }
        }

    }
}
