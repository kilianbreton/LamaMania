using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LamaMania.UserConstrols
{
    /// <summary>
    /// Interface for ScriptsSettings
    /// </summary>
    public interface IScriptSetting
    {
        /// <summary>
        /// Get the setting's name (S_....)
        /// </summary>
        string SettingName { get; }
        /// <summary>
        /// Get setting's value
        /// </summary>
        object SettingValue { get; }
        /// <summary>
        /// Get setting's value type
        /// </summary>
        string getValueType { get; }
        /// <summary>
        /// Set background color
        /// </summary>
        /// <param name="color"></param>
        void setColor(Color color);
        /// <summary>
        /// Get UserControl
        /// </summary>
        /// <returns></returns>
        UserControl GetControl();
    }
}