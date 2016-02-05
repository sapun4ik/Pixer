using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pixer
{
    public partial class Difference : Form
    {
        public pixerApi.Pixer pia;
        Bitmap bmp = null;
        public Difference(pixerApi.Pixer pia)
        {
            InitializeComponent();
            this.pia = pia;
            button2.DialogResult = DialogResult.OK;
            button3.DialogResult = DialogResult.Cancel;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            textBox1.Text = trackBar1.Value.ToString();
            pia.Filters.Difference(bmp, trackBar1.Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opd = new OpenFileDialog();
            if (opd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (Bitmap bm = new Bitmap(opd.FileName))
                    {
                        bmp = new Bitmap(bm);
                        pictureBox1.Image = bmp;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pia.Filters.Difference(bmp, trackBar1.Value,true);
        }
    }
}
