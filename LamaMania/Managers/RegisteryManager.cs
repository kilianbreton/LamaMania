using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LamaMania
{
    public class RegisteryManager
    {

        public bool RootKeyExist { get; set; }

        public RegisteryManager()
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey(@"KBT\LamaMania", true);
            if(rk == null)
            {
                //rk = Registry.CurrentUser.CreateSubKey(@"KBT\LamaMania");
                RootKeyExist = false;
            }
            else
            {
                RootKeyExist = true;

            }


            

            //storing the values  
          //  rk.SetValue("Setting1", "This is our setting 1");
           /* key.SetValue("Setting2", "This is our setting 2");
            key.Close();*/
        }




        public void saveKeys()
        {

        }


    }
}
