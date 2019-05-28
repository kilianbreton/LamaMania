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
    public partial class BooleanScriptSetting : UserControl, IScriptSetting
    {
        private string name;

        public BooleanScriptSetting(string name, string title, bool value)
        {
            InitializeComponent();
            this.name = name;
            this.flatCheckBox1.Text = title;
            this.flatCheckBox1.Checked = value;
        }

        private void StringScriptSetting_Load(object sender, EventArgs e)
        {

        }

        public string SettingName { get => name; }
        public object SettingValue { get => this.flatCheckBox1.Checked; }

        public string getValueType { get => "Boolean"; }
    }
}
