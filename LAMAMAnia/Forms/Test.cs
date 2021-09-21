using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LamaMania.Other;

namespace LamaMania
{
    public partial class Test : LamaForm
    {
        public Test()
        {

            InitializeComponent();
            addMouseEvents(this.Controls);
            this.contextMenuStrip1.Items.Add("test");
            this.contextMenuStrip1.Show();
        }
    }
}
