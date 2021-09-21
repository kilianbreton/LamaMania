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
    public partial class BooleanScriptSetting : UserControl, IScriptSetting
    {
        private string name;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="title"></param>
        /// <param name="value"></param>
        public BooleanScriptSetting(string name, string title, bool value)
        {
            InitializeComponent();
            this.name = name;
            this.flatLabel1.Text = title;
            this.flatCheckBox1.Checked = value;
        }

        private void StringScriptSetting_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="color"></param>
        public void setColor(Color color)
        {
            this.BackColor = color;
            this.flatCheckBox1.BackColor = color;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public UserControl GetControl()
        {
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        public string SettingName { get => name; }
        /// <summary>
        /// 
        /// </summary>
        public object SettingValue { get => this.flatCheckBox1.Checked; }
        /// <summary>
        /// 
        /// </summary>
        public string getValueType { get => "Boolean"; }
    }
}
