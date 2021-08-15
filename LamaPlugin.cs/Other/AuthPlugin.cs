using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LamaPlugin.Other
{
    /// <summary>
    /// Inherit this class with name : AuthMyPlugin
    /// </summary>
    public abstract class AuthPlugin
    {
        private string key;
        public AuthPlugin(string key)
        {
            this.key = key;
        }

        public string Key { get => key; }
    }
}
