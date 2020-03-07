using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace LamaMania
{
    /// <summary>
    /// Gestionaire des fichiers de traductions
    /// </summary>
    public class LocalesManager : IEnumerable<LocalesFile>
    {
        private Dictionary<String, LocalesFile> files = new Dictionary<string, LocalesFile>();
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="lang"></param>
        public LocalesManager(string path, string lang)
        {
            FileStream fs = File.Open(path, FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            foreach(string s in sr.ReadToEnd().Split('\n'))
            {
                string[] tmpTab = s.Split('\t');
                if(tmpTab.Length == 3)
                {
                    if (tmpTab[0].Equals(lang)) 
                    {
                        files.Add(tmpTab[1], new LocalesFile(tmpTab[2]));
                    }
                }
                else
                {
                    throw new Exception();
                }


            }


        }

        /// <summary>
        /// Search locales file by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public LocalesFile this[string name]
        {
            get
            {
                if (files.ContainsKey(name))
                {
                    return files[name];
                }
                else
                {
                    throw new Exception();
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerator<LocalesFile> GetEnumerator()
        {
            List<LocalesFile> lst = new List<LocalesFile>();
            foreach(KeyValuePair<string, LocalesFile> kvp in files)
            {
                lst.Add(kvp.Value);
            }

            return new LocalesFileEnumerator(lst);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }



        class LocalesFileEnumerator : IEnumerator<LocalesFile>
        {
            private int index = -1;
            private List<LocalesFile> files;


            public LocalesFileEnumerator(List<LocalesFile> files)
            {
                this.files = files;
            }

            public LocalesFile Current { get; set; }

            object IEnumerator.Current { get; }

            public void Dispose()
            {
                
            }

            public bool MoveNext()
            {
                if(++this.index < this.files.Count)
                {
                    Current = this.files[index];
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public void Reset()
            {
                this.index = -1;
            }
        }

    }


    /// <summary>
    /// 
    /// </summary>
    public class LocalesFile : IEnumerable<string>
    {
        /// <summary>
        /// 
        /// </summary>
        public Dictionary<string, string> locales = new Dictionary<string, string>();
        
        /// <summary>
        /// Parse file
        /// </summary>
        /// <param name="path"></param>
        public LocalesFile(string path)
        {
            FileStream fs = File.Open(path, FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            foreach(string s in sr.ReadToEnd().Split('\n'))
            {
                string[] tmpTab = s.Split('\t');
                if(tmpTab.Length == 2)
                {
                    locales.Add(tmpTab[0], tmpTab[1]);
                }
                else
                {
                    throw new Exception();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string this[string name]
        {
            get
            {
                if (locales.ContainsKey(name))
                {
                    return locales[name];
                }
                else
                {
                    throw new Exception("Locales Setting : '" + name + " unkown");
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerator<string> GetEnumerator()
        {
            List<string> lst = new List<string>();
            foreach(KeyValuePair<string,string> kvp in locales)
            {
                lst.Add(kvp.Value);
            }
            return new LocalesSettingEnumerator(lst);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }



        class LocalesSettingEnumerator : IEnumerator<string>
        {
            private int index = -1;
            private List<string> lst = new List<string>();


            public LocalesSettingEnumerator(List<string> lst)
            {
                this.lst = lst;
            }


            public string Current { get; set; }

            object IEnumerator.Current {get;}

            public void Dispose()
            {
                
            }

            public bool MoveNext()
            {
                if(++index < lst.Count)
                {
                    Current = lst[index];
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public void Reset()
            {
                index = -1;
            }
        }


    }
}
