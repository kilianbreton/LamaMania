using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LamaMania.UserConstrols
{
    /// <summary>
    /// 
    /// </summary>
    public partial class StringScriptSetting : UserControl, IScriptSetting
    {
        private string name;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="title"></param>
        /// <param name="value"></param>
        public StringScriptSetting(string name, string title, string value)
        {
            InitializeComponent();
            this.name = name;
            this.flatLabel1.Text = title;
            this.flatTextBox1.Text = value;
        }

     

        private void StringScriptSetting_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        public string SettingName { get => name; }
        /// <summary>
        /// 
        /// </summary>
        public object SettingValue { get => this.flatTextBox1.Text; }
        /// <summary>
        /// 
        /// </summary>
        public string getValueType { get => "String"; }
    }
}
