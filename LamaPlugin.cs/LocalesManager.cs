using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NTK.IO.Xml;
using System.Windows.Forms;

namespace LamaPlugin
{
    public class LocalesManager
    {
        string appPath;
        string pluginsPath;
        string langCode;
        string appName;

        List<XmlDocument> localesPluginsFiles;
        XmlDocument appFile;

        public LocalesManager(string appName, string appPath, string pluginsPath, string langCode, Logger log)
        {
            this.appName = appName;
            this.appPath = appPath;

            try
            {
                this.appFile = new XmlDocument(appPath + @"\Config\Locales\" + langCode + "_app.xml");
            }
            catch(Exception e)
            {
                log("ERROR", "[LocalesManager.Init]" + e.Message);
            }
            
            this.pluginsPath = pluginsPath;
            
            this.langCode = langCode;
        }

        public List<string> availableLanguages()
        {
            List<string> lst = new List<string>();
            DirectoryInfo dir = new DirectoryInfo(appPath + @"\Config\Locales\");
            foreach (FileInfo f in dir.EnumerateFiles("*_app.xml"))
            {
                lst.Add(f.Name.Substring(0, f.Name.IndexOf("_")));
            }


            return lst;
        }



        public void loadAppForm(Form form)
        {
            if(appFile != null)
            {
                XmlNode cfg = this.appFile[appName + "." + form.Name];
                if (cfg != null)
                {
                    foreach (Control c in form.Controls)
                    {
                        if (cfg.isChildExist(c.Name))
                        {
                            c.Text = cfg[c.Name].Value;
                        }
                    }
                }
            }
        }



        [Obsolete]
        public void saveAppForm(Form form)
        {
            if (appFile != null)
            {
                this.appFile.AutoCreate = true;
                XmlNode cfg = this.appFile[appName + "." + form.Name];
                if (cfg == null)
                {
                    cfg = appFile.addNode(appName + "." + form.Name);
                }
                foreach(Control c in form.Controls)
                {
                    if (!cfg.isChildExist(c.Name))
                    {
                        cfg.addChild(c.Name);
                    }
                    XmlNode newNode = cfg[c.Name];
                    newNode.addAttribute("Text", "test");
                    saveControl(c, newNode);
                   
                }

            }
            appFile.save();

        }

        void saveControl(Control control, XmlNode node)
        {
            foreach (Control child in control.Controls)
            {
                if (!node.isChildExist(child.Name))
                {
                    node.addChild(child.Name);
                }
                XmlNode newNode = node[child.Name];
                newNode.addAttribute("name", "test");
                saveControl(child, newNode);
            }

        }






        public static ContextMenuStrip getTool(System.ComponentModel.IContainer container)
        {
            ContextMenuStrip c = new ContextMenuStrip(container); ;









            return c;
        }



    }
}
