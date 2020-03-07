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
    /// <summary>
    /// 
    /// </summary>
    public partial class ExternalTool : UserControl
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        public delegate void OnRemoveHandler(object sender);
       
        /// <summary>
        /// 
        /// </summary>
        public event OnRemoveHandler Remove;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="alias"></param>
        public ExternalTool(string path, string alias)
        {
            InitializeComponent();
            tb_alias.Text = alias;
            tb_exePath.Text = path;
        }

        /// <summary>
        /// 
        /// </summary>
        public ExternalTool()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void OnRemove()
        {
            if (Remove != null)
                Remove(this);
        }

        private void B_browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                DefaultExt = "*.exe",
                Title = "OPen executable",
            };

            DialogResult r = ofd.ShowDialog();
            if(r == DialogResult.OK)
            {
                tb_exePath.Text = ofd.FileName;
            }

        }

        private void B_rm_Click(object sender, EventArgs e)
        {
            OnRemove();
        }

        /// <summary>
        /// 
        /// </summary>
        public string Alias { get { return tb_alias.Text; } }
        
        /// <summary>
        /// 
        /// </summary>
        public string Path { get { return tb_exePath.Text; } }
    }
}
