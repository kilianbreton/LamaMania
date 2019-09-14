using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LamaPlugin
{
    public enum UpdateMode
    {
        LamaLibrary,
        WebLink,
        Other
    }

    public abstract class UpdateMethod
    {
        protected UpdateMode mode;
        //WebLink
        protected string link;
        //LamaLibrary
        protected string author;
        protected string pluginName;
        protected Version version;

        
        /// <summary>
        /// LamaLibrary Mode
        /// </summary>
        /// <param name="author"></param>
        /// <param name="pluginName"></param>
        /// <param name="version"></param>
        public UpdateMethod(string author, string pluginName, Version version)
        {
            this.mode = UpdateMode.LamaLibrary;
            this.author = author;
            this.pluginName = pluginName;
            this.version = version;
        }

        /// <summary>
        /// WebLink Mode
        /// </summary>
        /// <param name="link"></param>
        public UpdateMethod(string link)
        {
            this.mode = UpdateMode.WebLink;
            this.link = link;
        }

        /// <summary>
        /// Other Mode
        /// </summary>
        /// <param name="mode"></param>
        public UpdateMethod()
        {
            this.mode = UpdateMode.Other;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="finalPath"></param>
        /// <returns>Full path</returns>
        public abstract string DownLoad(string finalPath);

        /// <summary>
        /// 
        /// </summary>
        /// <returns>True if local version = remote version</returns>
        public abstract bool CheckVersion();

    }
}
