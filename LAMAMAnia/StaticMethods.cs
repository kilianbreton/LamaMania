using FlatUITheme;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LamaPlugin;
using static System.Environment;

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
                control.Invoke(new Action<FlatButton, bool>(enableControl), control, value);
            }
            else
            {
                control.Enabled = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctrl"></param>
        /// <returns></returns>
        public static string getText(Control ctrl)
        {
            if (ctrl.InvokeRequired)
            {
                return (string)ctrl.Invoke(new Func<Control, string>(getText), ctrl);
            }
            else
            {
                return ctrl.Text;
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
                label.setText(value);
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
            var tb2 = (FlatTextBox)getControl(tb);
            tb2.Text = text;
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
        public static void appendCombo(FlatComboBox cb, string value)
        {
            if(cb.InvokeRequired)
            {
                cb.Invoke(new Action<FlatComboBox, string>(appendCombo), cb, value);
            }
            else
            {
                cb.Items.Add(value);
            }
            

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
            m = time / 60;
            if (m >= 60)
            {
                h = m / 60;
                m = m % 60;
            }
            s = time % 60;
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
        /// Get ManiaPlanetServer status string from code
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string getStatus(int code)
        {
            switch (code)
            {
                case 2:
                    return "Running - Exit";
                case 3:
                    return "Running - Synchronisation";
                case 4:
                    return "Running - Play";
                case 6:
                    return "Running - Finish";
                default:
                    return code.ToString();
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
            //Program.lama.log("NOTICE", "MakeTreeView(" + dir.Name + "," + node.Text+")");
            foreach (DirectoryInfo child in dir.GetDirectories())
            {
                makeTreeview(child, node.Nodes.Add(child.Name));
            }
        }

        /// <summary>
        /// Search plugin by name, return null if not exist
        /// PluginType.Base search in all plugin type
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static IBasePlugin getPluginByName(string name, PluginType type = PluginType.Base)
        {
            int cpt = 0;
            List<IBasePlugin> lst = new List<IBasePlugin>();
            switch (type)
            {
                case PluginType.Base:
                    lst.AddRange(Program.lama.pluginManager.HomeComponentPlugins);
                    lst.AddRange(Program.lama.pluginManager.TabPlugins);
                    lst.AddRange(Program.lama.pluginManager.InGamePlugins);
                    break;
                case PluginType.HomeComponent:
                    lst.AddRange(Program.lama.pluginManager.HomeComponentPlugins);
                    break;
                case PluginType.TabPlugin:
                    lst.AddRange(Program.lama.pluginManager.TabPlugins);
                    break;
                case PluginType.InGamePlugin:
                    lst.AddRange(Program.lama.pluginManager.InGamePlugins);
                    break;
            }
            
            while (cpt < lst.Count && lst[cpt].PluginName != name) { cpt++; }

            if (cpt < lst.Count && lst[cpt].PluginName == name)
                return lst[cpt];
            else
                return null;
        }


        /// <summary>
        /// Return path from var like $APPDATA$
        /// </summary>
        /// <param name="var"></param>
        /// <returns></returns>
        public static string getPathFromVar(string var)
        {
            string ret = "";

            //using static enviornment
            switch (var)
            {
                case "$DOCUMENTS$":
                    ret = GetFolderPath(SpecialFolder.MyDocuments);
                    break;
                case "$PROGRAMS$":
                    ret = GetFolderPath(SpecialFolder.ProgramFiles);
                    break;
                case "$PROGRAMFILES$":
                    ret = GetFolderPath(SpecialFolder.ProgramFilesX86);
                    break;
                case "$APPDATA$":
                    ret = GetFolderPath(SpecialFolder.ApplicationData);
                    break;
                case "$TEMP$":
                    ret = GetFolderPath(SpecialFolder.LocalApplicationData) + @"\Temp";
                    break;

                default:
                case "$CURRENT_PATH$":
                    ret = CurrentDirectory;
                    break;


            }
            return ret;
        }


    }
}
