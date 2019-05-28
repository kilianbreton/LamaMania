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
    public partial class StringScriptSetting : UserControl, IScriptSetting
    {
        private string name;

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

        public string SettingName { get => name; }
        public object SettingValue { get => this.flatTextBox1.Text; }
        public string getValueType { get => "String"; }
    }
}
