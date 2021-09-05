using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LamaMania.Other
{
    public class LamaForm : Form
    {
        Control tool;

        public LamaForm()
        {
            this.Click += LamaForm_Click;
        }

        private void LamaForm_Click(object sender, EventArgs e)
        {
            MouseEventArgs args = (MouseEventArgs)e;
            if (args.Button == MouseButtons.Right)
            {
                MessageBox.Show(sender + " - " + e.ToString());
            }
        }

        public void addTool(Control tool)
        {
            this.tool = tool;
        }
       
        protected void addMouseEvents(Control.ControlCollection ctrls)
        {
            foreach (Control c in ctrls)
            {
                c.Click += LamaForm_Click;
                addMouseEvents(c.Controls);
            }
        }
    }
}
