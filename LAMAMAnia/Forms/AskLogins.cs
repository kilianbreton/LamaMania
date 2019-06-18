using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LamaMania
{
    /// <summary>
    /// 
    /// </summary>
    public partial class AskLogins : Form
    {
        private AskLoginsResult result;

        /// <summary>
        /// Init AskLogins
        /// </summary>
        /// <param name="login"></param>
        public AskLogins(string login)
        {
            InitializeComponent();
            tb_login.Text = login;
        }

        /// <summary>
        /// Special ShowDialog with AskLoginsResult
        /// </summary>
        /// <returns></returns>
        public AskLoginsResult getDialogResult()
        {
            base.ShowDialog();
            return this.result;
        }

        private void b_cancel_Click(object sender, EventArgs e)
        {
            this.result = new AskLoginsResult(false);
            this.Close();
        }

        private void b_connect_Click(object sender, EventArgs e)
        {
            this.result = new AskLoginsResult(true, tb_login.Text, tb_pass.Text);
            this.Close();
        }


        /// <summary>
        /// Result class for AskLogins
        /// </summary>
        public class AskLoginsResult
        {
            private bool res;
            private string login;
            private string pass;

            /// <summary>
            /// 
            /// </summary>
            /// <param name="res"></param>
            /// <param name="login"></param>
            /// <param name="pass"></param>
            public AskLoginsResult(bool res, string login, string pass)
            {
                this.res = res;
                this.login = login;
                this.pass = pass;
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="res"></param>
            public AskLoginsResult(bool res)
            {
                this.res = res;
            }

            /// <summary>
            /// 
            /// </summary>
            public bool Res { get => res; set => res = value; }
            /// <summary>
            /// 
            /// </summary>
            public string Login { get => login; set => login = value; }
            /// <summary>
            /// 
            /// </summary>
            public string Pass { get => pass; set => pass = value; }
        }
    }
}
