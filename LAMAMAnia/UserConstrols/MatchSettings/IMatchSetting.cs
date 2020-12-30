using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LamaMania.UserConstrols
{
    public interface IMatchSetting
    {
        string SettingName { get; }

        /// <summary>
        /// Get setting's value
        /// </summary>
        object SettingDefaultValue { get; }
        
        string getType { get; }

        UserControl GetControl();
    }
}
