using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace LamaMania
{
    public partial class LogViewer : Form
    {
        public LogViewer(string path)
        { 
            InitializeComponent();

            StreamReader sr = new StreamReader(path);
            richTextBox1.Text = sr.ReadToEnd();
            sr.Close();
        }

        private void b_quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
