using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GBXMapParser;

namespace SkinViewer
{
    public partial class Form1 : Form
    {
        public string filename = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void b_search_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            DialogResult r = opf.ShowDialog();
            switch(r)
            {
                case DialogResult.OK:
                case DialogResult.Yes:
                    filename = opf.FileName;
                    this.textBox1.Text = filename;
                    MapInformation mi = MapParser.ReadFile(filename);
                    MemoryStream mStream = new MemoryStream();

                    mStream.Write(mi.Thumbnail, 0, Convert.ToInt32(mi.Thumbnail.Length));

                    Bitmap bm = new Bitmap(mStream, false);
                    bm.RotateFlip(RotateFlipType.Rotate180FlipX);

                    this.pictureBox1.Image = bm;
                    break;

            }

        }
    }
}
