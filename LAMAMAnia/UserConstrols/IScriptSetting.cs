using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMAMAnia.UserConstrols
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
    }
}