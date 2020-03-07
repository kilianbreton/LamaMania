using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LamaMania
{
    /// <summary>
    /// 
    /// </summary>
    public class Updater
    {
        /// <summary>
        /// 
        /// </summary>
        public Updater()
        {

        }


        /// <summary>
        /// check for update, return true if update required.
        /// </summary>
        /// <returns></returns>
        public async Task<bool> CheckForUpdate()
        {
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<Version> GetNewVersion()
        {
            return null;
        }

        /// <summary>
        /// return true if update success
        /// </summary>
        /// <returns></returns>
        public async Task<bool> Update()
        {


            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<bool> Install()
        {

            return true;
        }


    }
}
