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
    public partial class DoubleScriptSetting : UserControl, IScriptSetting
    {
        private string name;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="title"></param>
        /// <param name="value"></param>
        public DoubleScriptSetting(string name, string title, double value)
        {
            InitializeComponent();
            this.name = name;
            this.flatLabel1.Text = title;
            this.flatTextBox1.Text = value.ToString();
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
        /// <param name="color"></param>
        public void setColor(Color color)
        {
            this.BackColor = color;
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
        public object SettingValue { get => double.Parse(this.flatTextBox1.Text); }
        /// <summary>
        /// 
        /// </summary>
        public string getValueType { get => "Double"; }
    }
}
