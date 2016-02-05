using System;
using System.Drawing;
using System.Windows.Forms;
using pixerApi;
namespace Pixer
{
    public partial class Form1 : Form
    {
        pixerApi.Pixer pia = new pixerApi.Pixer();
        public Form1()
        {
            InitializeComponent(); 
            pia.Initialization(pictureBox1);
            pia.InitializationHistogram(pictureBox2);
            
        }

        private void Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog opd = new OpenFileDialog();
            if (opd.ShowDialog() == DialogResult.OK)
            {
                pia.LoadImage(opd.FileName);
                PreviewSizeChange();
                HistCombo.SelectedIndex = 3;
                HistCombo.Enabled = true;
                изображениеToolStripMenuItem.Enabled = true;
                фильтрыToolStripMenuItem.Enabled = true;
                undoToolStripMenuItem.Enabled = true;
                redoToolStripMenuItem.Enabled = true;
                groupBox2.Enabled = true;
                numericUpDown.Enabled = true;
                pia.SaveDoc.Save(@"C:\Users\Sapun4ik\Pictures\Camera Roll\tet.pik");
            }
           
        }
        public void PreviewSizeChange()
        {
            if (pictureBox1 != null)
            {
                int PreviewSize = (int)numericUpDown.Value;
                //int PreviewSize = 100;
                pictureBox1.Width = (int)(pictureBox1.Image.Width * PreviewSize / 100);
                pictureBox1.Height = (int)(pictureBox1.Image.Height * PreviewSize / 100);
                pictureBox1.Location = new Point(viewportPanel.Width / 2 - pictureBox1.Width / 2,
                        viewportPanel.Height / 2 - pictureBox1.Height / 2);
            }
        }

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            PreviewSizeChange();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            groupBox1.Location = new Point(viewportPanel.Width - groupBox1.Width - 5, 0);
            button3.Visible = false;
            groupBox2.Location = new Point(viewportPanel.Width - groupBox2.Width - 5, groupBox1.Height);
            button2.Visible = false;
        }

        private void brightnessAndContrast_Click(object sender, EventArgs e)
        {
            BrightnessAndContrast bFrm = new BrightnessAndContrast(pia);
            if (bFrm.ShowDialog() == DialogResult.Cancel)
            {
                pia.recoveryWorkspace();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            pia.Undo();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            pia.Redo();
        }

        private void HSV_Click(object sender, EventArgs e)
        {
            HSV bFrm = new HSV(pia);
            if (bFrm.ShowDialog() == DialogResult.Cancel)
            {
                pia.recoveryWorkspace();
            }
        }

        private void invert_Click(object sender, EventArgs e)
        {
            pia.Correction.Invert();
        }

        private void binary_Click(object sender, EventArgs e)
        {
            Binary bFrm = new Binary(pia);
            if (bFrm.ShowDialog() == DialogResult.Cancel)
            {
                pia.recoveryWorkspace();
            }
        }

        private void grayscale_Click(object sender, EventArgs e)
        {
            pia.Correction.Grayscale();
        }

        private void colorOverlay_Click(object sender, EventArgs e)
        {
            ColorOverlay bFrm = new ColorOverlay(pia);
            if (bFrm.ShowDialog() == DialogResult.Cancel)
            {
                pia.recoveryWorkspace();
            }
        }

        private void pointBlackAndWhite_Click(object sender, EventArgs e)
        {

        }

        private void SCorrection_Click(object sender, EventArgs e)
        {
            pia.Correction.SCorrection(2);
        }

        private void gammaCorrection_Click(object sender, EventArgs e)
        {
            pia.Correction.GammaCorrection(2);
        }

        private void palette_Click(object sender, EventArgs e)
        {
            Palette bFrm = new Palette(pia);
            if (bFrm.ShowDialog() == DialogResult.Cancel)
            {
                pia.recoveryWorkspace();
            }
        }

        private void convolution_Click(object sender, EventArgs e)
        {
            Convolution bFrm = new Convolution(pia);
            if (bFrm.ShowDialog() == DialogResult.Cancel)
            {
                pia.recoveryWorkspace();
            }
        }

        private void gaussian_Click(object sender, EventArgs e)
        {
            Gaussian bFrm = new Gaussian(pia);
            if (bFrm.ShowDialog() == DialogResult.Cancel)
            {
                pia.recoveryWorkspace();
            }
        }

        private void normalBlur_Click(object sender, EventArgs e)
        {
            pia.Filters.NormalBlur();
        }

        private void medianer_Click(object sender, EventArgs e)
        {
            Medianer bFrm = new Medianer(pia);
            if (bFrm.ShowDialog() == DialogResult.Cancel)
            {
                pia.recoveryWorkspace();
            }
        }

        private void laplasian_Click(object sender, EventArgs e)
        {
            pia.Filters.Laplacian(2);
        }

        private void laplasianOfGaussian_Click(object sender, EventArgs e)
        {
            pia.Filters.Gaussian(1, true);
            pia.Filters.Laplacian(1);
        }

        private void rGBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pia.Channels.EditabelChannel(ColorChannelTypes.RGB);
        }

        private void rToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pia.Channels.EditabelChannel(ColorChannelTypes.Red);
        }

        private void gToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pia.Channels.EditabelChannel(ColorChannelTypes.Green);
        }

        private void bToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pia.Channels.EditabelChannel(ColorChannelTypes.Blue);
        }

        private void HistCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(HistCombo.SelectedIndex == 0) pia.setHistogramType = HistogramTypes.Red;
            if (HistCombo.SelectedIndex == 1) pia.setHistogramType = HistogramTypes.Green;
            if (HistCombo.SelectedIndex == 2) pia.setHistogramType = HistogramTypes.Blue;
            if (HistCombo.SelectedIndex == 3) pia.setHistogramType = HistogramTypes.Brightness;
            
        }

        private void SaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "bmp files (*.bmp)|*.bmp|jpg files (*.jpg)|*.jpg|All files (*.*)|*.*";
            sfd.FilterIndex = 2;
            sfd.RestoreDirectory = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                pia.saveImage(sfd.FileName);

                
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox1.Hide();
            button2.Visible = true;
            button2.Location = new Point(viewportPanel.Width - button2.Width - 5, 0);
            groupBox1.Location = new Point(viewportPanel.Width - groupBox1.Width - 5, 0);
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            groupBox1.Location = new Point(viewportPanel.Width - groupBox1.Width-5, 0);
            groupBox2.Location = new Point(viewportPanel.Width - groupBox2.Width - 5, groupBox1.Height);
            button2.Location = new Point(viewportPanel.Width - button2.Width - 5, 0);
            button3.Location = new Point(viewportPanel.Width - button3.Width - 5, groupBox1.Height);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox1.Show();
            button2.Visible = false;
            button2.Location = new Point(viewportPanel.Width - button2.Width - 5, 0);
            groupBox1.Location = new Point(viewportPanel.Width - groupBox1.Width - 5, 0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            groupBox2.Hide();
            button3.Visible = true;
            button3.Location = new Point(viewportPanel.Width - button3.Width - 5, groupBox1.Height);
            groupBox2.Location = new Point(viewportPanel.Width - groupBox2.Width - 5, groupBox1.Height);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            groupBox2.Show();
            button3.Visible = false;
            button3.Location = new Point(viewportPanel.Width - button3.Width - 5, groupBox1.Height);
            groupBox2.Location = new Point(viewportPanel.Width - groupBox2.Width - 5, groupBox1.Height);
        }

        private void red_MouseDown(object sender, MouseEventArgs e)
        {
            pia.Channels.EditabelChannel(ColorChannelTypes.Red);
        }

        private void green_MouseDown(object sender, MouseEventArgs e)
        {
            pia.Channels.EditabelChannel(ColorChannelTypes.Green);
        }

        private void blue_MouseDown(object sender, MouseEventArgs e)
        {
            pia.Channels.EditabelChannel(ColorChannelTypes.Blue);
        }

        private void rgb_MouseDown(object sender, MouseEventArgs e)
        {
            pia.Channels.EditabelChannel(ColorChannelTypes.RGB);
        }

        private void freeTransform_Click(object sender, EventArgs e)
        {
            FreeTransform bFrm = new FreeTransform(pia);
            if (bFrm.ShowDialog() == DialogResult.Cancel)
            {
                pia.Redo();
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pia.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pia.Redo();
        }

        private void transform_Click(object sender, EventArgs e)
        {
            Transform bFrm = new Transform(pia, this);
            if (bFrm.ShowDialog() == DialogResult.Cancel)
            {
                pia.Redo();
            }
        }

        private void curves_Click(object sender, EventArgs e)
        {
            Сurves bFrm = new Сurves(pia);
            if (bFrm.ShowDialog() == DialogResult.Cancel)
            {
                pia.recoveryWorkspace();
            }
        }

        private void difference_Click(object sender, EventArgs e)
        {
            Difference bFrm = new Difference(pia);
            if (bFrm.ShowDialog() == DialogResult.Cancel)
            {
                pia.recoveryWorkspace();
            }
        }

        private void SaveJPG_Click(object sender, EventArgs e)
        {
            SaveJPG bFrm = new SaveJPG(pia, this);
            if (bFrm.ShowDialog() == DialogResult.Cancel)
            {
                pia.recoveryWorkspace();
            }
        }

        //private void button1_Click(object sender, EventArgs e)
        //{

        //    OpenFileDialog opd = new OpenFileDialog();
        //    if (opd.ShowDialog() == DialogResult.OK)
        //    {
        //        pia.LoadImage(opd.FileName);
        //        trackBar8.Maximum = pia.widthImage*2;
        //        trackBar9.Maximum = pia.heightImage*2;
        //        trackBar8.Value = pia.widthImage;
        //        trackBar9.Value = pia.heightImage;

        //    }
        //    label4.Text = pia.getCountMemory.ToString();
        //    label3.Text = pia.getWorkingPosition.ToString();
        //    PreviewSizeChange();
        //}

        //private void trackBar1_Scroll(object sender, EventArgs e)
        //{
        //    pia.Correction.Binary(trackBar1.Value,false);
        //}

        //private void trackBar2_Scroll(object sender, EventArgs e)
        //{
        //    pia.Correction.ColorOverlay(Color.Azure, trackBar2.Value);
        //}

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    pia.Undo();
        //    label4.Text = pia.getCountMemory.ToString();
        //    label3.Text = pia.getWorkingPosition.ToString();
        //    PreviewSizeChange();
        //}

        //private void button3_Click(object sender, EventArgs e)
        //{
        //    pia.Redo();
        //    label4.Text = pia.getCountMemory.ToString();
        //    label3.Text = pia.getWorkingPosition.ToString();
        //    PreviewSizeChange();
        //}

        //private void button4_Click(object sender, EventArgs e)
        //{
        //    pia.saveBuffer();
        //    label4.Text = pia.getCountMemory.ToString();
        //    label3.Text = pia.getWorkingPosition.ToString();
        //    textBox3.Text = pia.widthImage.ToString();
        //    textBox4.Text = pia.heightImage.ToString();


        //}

        //private void button5_Click(object sender, EventArgs e)
        //{
        //    pia.getSpecificImage(int.Parse(textBox1.Text));
        //    label4.Text = pia.getCountMemory.ToString();
        //    label3.Text = pia.getWorkingPosition.ToString();
        //}

        //private void button6_Click(object sender, EventArgs e)
        //{
        // pia.Channels.EditabelChannel(ColorChannelTypes.Red);
        //}

        //private void button7_Click(object sender, EventArgs e)
        //{
        //    pia.Channels.EditabelChannel(ColorChannelTypes.Green);
        //}

        //private void button8_Click(object sender, EventArgs e)
        //{
        //    pia.Channels.EditabelChannel(ColorChannelTypes.Blue);
        //}

        //private void button9_Click(object sender, EventArgs e)
        //{
        //    pia.Channels.EditabelChannel(ColorChannelTypes.RGB);
        //}

        //private void button10_Click(object sender, EventArgs e)
        //{
        //  pictureBox2.Image = pia.Histograms.Histogram(Histograms.HistogramTypes.Blue);
        //}





        //private void button16_Click(object sender, EventArgs e)
        //{
        //  // pictureBox1.Image = pia.Correction.ApplyGaussianBlur((Bitmap)pictureBox1.Image, int.Parse(textBox2.Text));

        //}



        //private void button17_Click(object sender, EventArgs e)
        //{
        //    pia.Transform.Nearest(trackBar8.Value, trackBar9.Value, trackBar10.Value, trackBar11.Value, trackBar12.Value, true);

        //}

        //private void trackBar8_Scroll(object sender, EventArgs e)
        //{
        //    pia.Transform.Nearest(trackBar8.Value, trackBar9.Value, trackBar10.Value, trackBar11.Value, trackBar12.Value);
        //    //pia.Transform.Nearest(640, 426, trackBar10.Value, trackBar11.Value, 90);
        //    textBox11.Text = trackBar12.Value.ToString();
        //    PreviewSizeChange();
        //}





        //private void button19_Click(object sender, EventArgs e)
        //{
        //    pia.Correction.PointBlackAndWhite(Color.FromArgb(int.Parse(textBox5.Text), int.Parse(textBox6.Text), int.Parse(textBox7.Text)), Color.FromArgb(int.Parse(textBox8.Text), int.Parse(textBox9.Text), int.Parse(textBox10.Text)));
        //}




    }
}
