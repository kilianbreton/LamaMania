using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAMAMAnia
{
    public partial class AskLogins : Form
    {
        public AskLogins(string login)
        {
            InitializeComponent();
            tb_login.Text = login;
        }

        private void b_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void b_connect_Click(object sender, EventArgs e)
        {
            var main = new Main(tb_login.Text, tb_pass.Text);
            main.Show();
        }
    }
}
