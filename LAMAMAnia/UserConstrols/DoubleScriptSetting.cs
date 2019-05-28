using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAMAMAnia.UserConstrols
{
    public partial class DoubleScriptSetting : UserControl, IScriptSetting
    {
        private string name;

        public DoubleScriptSetting(string name, string title, double value)
        {
            InitializeComponent();
            this.name = name;
            this.flatLabel1.Text = title;
            this.flatTextBox1.Text = value.ToString();
        }

     

        private void StringScriptSetting_Load(object sender, EventArgs e)
        {

        }

        public string SettingName { get => name; }
        public object SettingValue { get => double.Parse(this.flatTextBox1.Text); }
        public string getValueType { get => "Double"; }
    }
}
