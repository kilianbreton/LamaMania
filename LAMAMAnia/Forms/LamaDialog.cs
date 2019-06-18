using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlatUITheme;

namespace LamaMania
{
    /// <summary>
    /// 
    /// </summary>
    public enum LamaSpecialButtons
    {
        /// <summary>
        /// 
        /// </summary>
        GameSlect,

    }
    /// <summary>
    /// 
    /// </summary>
    public partial class LamaDialog : Form
    {
        private static int nbInst;
        private bool isLamaButtons;
        private MessageBoxButtons buttons;
        private LamaSpecialButtons lamaButtons;
        private DialogResult result = DialogResult.OK;
      

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        /// <param name="text"></param>
        /// <param name="type"></param>
        /// <param name="buttons"></param>
        public LamaDialog(String title, String text, FlatAlertBox._Kind type = 0, MessageBoxButtons buttons = 0)
        {
            InitializeComponent();
            nbInst++;
            this.formSkin1.Text = title;
            this.label.Text = text;
            this.alertBox.kind = type;
            this.alertBox.Text = type.ToString();
            this.buttons = buttons;
            this.isLamaButtons = false;
            switch (buttons)
            {
                case MessageBoxButtons.OK:
                    b_green.Visible = true;
                    b_green.Text = "OK";
                    break;
                case MessageBoxButtons.OKCancel:
                    b_red.Visible = true;
                    b_red.Text = "Cancel";
                    b_green.Visible = true;
                    b_green.Text = "OK";
                    break;
                case MessageBoxButtons.AbortRetryIgnore:
                    b_red.Visible = true;
                    b_red.Text = "Abort";
                    b_blue.Visible = true;
                    b_blue.Text = "Retry";
                    b_green.Visible = true;
                    b_green.Text = "Ignore";
                    break;
                case MessageBoxButtons.YesNoCancel:
                    b_red.Visible = true;
                    b_red.Text = "Cancel";
                    b_blue.Visible = true;
                    b_blue.Text = "No";
                    b_green.Visible = true;
                    b_green.Text = "Yes";
                    break;
                case MessageBoxButtons.YesNo:
                    b_red.Visible = true;
                    b_red.Text = "No";
                    b_green.Visible = true;
                    b_green.Text = "Yes";
                    break;
                case MessageBoxButtons.RetryCancel:
                    b_red.Visible = true;
                    b_red.Text = "Cancel";
                    b_green.Visible = true;
                    b_green.Text = "Retry";
                    break;
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        /// <param name="text"></param>
        /// <param name="type"></param>
        /// <param name="buttons"></param>
        public LamaDialog(String title, String text, FlatAlertBox._Kind type, LamaSpecialButtons buttons)
        {
            InitializeComponent();
            nbInst++;
            this.formSkin1.Text = title;
            this.label.Text = text;
            this.alertBox.kind = type;
            this.alertBox.Text = type.ToString();
            this.lamaButtons = buttons;
            this.isLamaButtons = true;
            switch (buttons)
            {
                case LamaSpecialButtons.GameSlect:
                    b_red.Visible = true;
                    b_red.Text = "ShootMania";
                    b_green.Visible = true;
                    b_green.Text = "TrackMania";
                    break;
            }
        }



        /// <summary>
        /// 
        /// </summary>
        ~LamaDialog()
        {
            nbInst--;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public new DialogResult ShowDialog()
        {
            base.ShowDialog();
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        public static int NbInst { get => nbInst; }

        private void b_green_Click(object sender, EventArgs e)
        {
            if (isLamaButtons)
            {
                switch (this.lamaButtons)
                {
                    case LamaSpecialButtons.GameSlect:
                        this.result = DialogResult.OK;
                        break;
                }
            }
            else
            {
                switch (this.buttons)
                {
                    case MessageBoxButtons.OK:
                    case MessageBoxButtons.OKCancel:
                        this.result = DialogResult.OK;
                        break;
                    case MessageBoxButtons.RetryCancel:
                        this.result = DialogResult.Retry;
                        break;
                    case MessageBoxButtons.YesNo:
                    case MessageBoxButtons.YesNoCancel:
                        this.result = DialogResult.Yes;
                        break;
                    case MessageBoxButtons.AbortRetryIgnore:
                        this.result = DialogResult.Ignore;
                        break;
                }
            }
            this.Close();
        }

        private void b_blue_Click(object sender, EventArgs e)
        {
            if (isLamaButtons)
            {
                switch (this.lamaButtons)
                {
                    case LamaSpecialButtons.GameSlect:
                        //None
                        break;
                }
            }
            else
            {
                switch (this.buttons)
                {
                    case MessageBoxButtons.YesNo:
                    case MessageBoxButtons.YesNoCancel:
                        this.result = DialogResult.No;
                        break;
                    case MessageBoxButtons.AbortRetryIgnore:
                        this.result = DialogResult.Retry;
                        break;
                }
            }
            this.Close();
        }

        private void b_red_Click(object sender, EventArgs e)
        {
            if (isLamaButtons)
            {
                switch (this.lamaButtons)
                {
                    case LamaSpecialButtons.GameSlect:
                        this.result = DialogResult.Cancel;
                        break;
                }
            }
            else
            {
                switch (this.buttons)
                {
                    case MessageBoxButtons.OKCancel:
                    case MessageBoxButtons.RetryCancel:
                    case MessageBoxButtons.YesNoCancel:
                        this.result = DialogResult.Cancel;
                        break;
                    case MessageBoxButtons.AbortRetryIgnore:
                        this.result = DialogResult.Abort;
                        break;
                }
            }
            this.Close();
        }
    }
}
