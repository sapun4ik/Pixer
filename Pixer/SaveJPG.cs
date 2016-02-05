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
    public partial class SaveJPG : Form
    {
        private pixerApi.Pixer pia;
        private Form1 fm1;
        bool path = false;
        public SaveJPG(pixerApi.Pixer pia, Form1 fm1)
        {
            InitializeComponent();
            this.pia = pia;
            this.fm1 = fm1;
            button1.DialogResult = DialogResult.OK;
            button2.DialogResult = DialogResult.Cancel;
        }

        private void SaveJPG_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = fm1.pictureBox1.Image;
            pictureBox2.Image = fm1.pictureBox1.Image;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                label6.Text = fbd.SelectedPath;
                path = true;
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            //
            pictureBox2.Image = pia.showSaveImage(trackBar1.Value);
            textBox1.Text = trackBar1.Value.ToString();
            //lab3.Text = trackBar1.Value.ToString();
            label3.Text = pia.FileWeightBefore(pixerApi.Pixer.FileWeightFormat.KB) + "KB";
            label4.Text = pia.FileWeightAfter(pixerApi.Pixer.FileWeightFormat.KB) + "KB";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pia.SaveJpg(label6.Text + "/" + textBox2.Text + ".jpg", trackBar1.Value);
        }
    }
}
