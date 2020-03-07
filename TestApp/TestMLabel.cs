using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LamaMania;


namespace TestApp
{
    public partial class TestMLabel : Form
    {
        public TestMLabel()
        {
            InitializeComponent();

            this.Controls.Add(new ManiaLabel("test label"));



        }
    }
}
