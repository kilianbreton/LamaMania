using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LamaMania
{
    /// <summary>
    /// 
    /// </summary>
    public struct ManiaStyle
    {
        /// <summary>
        /// 
        /// </summary>
        public Color color;
        /// <summary>
        /// 
        /// </summary>
        public bool italic;
        /// <summary>
        /// 
        /// </summary>
        public bool bold;
        /// <summary>
        /// 
        /// </summary>
        public bool underline;
        /// <summary>
        /// 
        /// </summary>
        public bool wide;

    }

    /// <summary>
    /// 
    /// </summary>
    public partial class ManiaLabel : UserControl
    {
        private string maniaCodeText;
        private string text;
        private Dictionary<int, List<ManiaStyle>> styles = new Dictionary<int, List<ManiaStyle>>();
        private Font font = new Font(new FontFamily("Arial"), 18f);
        private List<Label> letters = new List<Label>();

        /// <summary>
        /// 
        /// </summary>
        public ManiaLabel()
        {
            InitializeComponent();



        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="plainText"></param>
        public ManiaLabel(string plainText)
        {
            this.BackColor = Color.Gray;
            this.Size = new Size(6000,6000);
            int x = 10;
            foreach (char c in plainText)
            {
                Label l = new Label();
                l.Text = c.ToString();
                l.Font = font;
                l.ForeColor = Color.Orange;
                l.Size = new Size(Convert.ToInt32(l.Font.Size), Convert.ToInt32(l.Font.Size)*2);
                

                this.Controls.Add(l);
                letters.Add(l);

                l.Location = new Point(x, 5);

                
                x += + 0 + Convert.ToInt32(l.Font.SizeInPoints);
            }
            InitializeComponent();
         
            

        }



    }
}
