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
    public partial class StringMatchSetting : UserControl, IMatchSetting
    {
        public StringMatchSetting(string name, string title, string value)
        {
            InitializeComponent();
            this.flatTextBox1.Validating += FlatTextBox1_Validating;
            this.flatLabel1.Text = name;

            this.flatTextBox1.Text = value;
        }

        private void FlatTextBox1_Validating(object sender, CancelEventArgs e)
        {
            MessageBox.Show("a");
        }

        public string SettingName => throw new NotImplementedException();

        public object SettingDefaultValue => throw new NotImplementedException();

        public string getType => throw new NotImplementedException();

      

        UserControl IMatchSetting.GetControl()
        {
            throw new NotImplementedException();
        }
    }
}
