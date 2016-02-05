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
    public partial class BrightnessAndContrast : Form
    {
        public pixerApi.Pixer pia; 
        public BrightnessAndContrast(pixerApi.Pixer pia)
        {
            InitializeComponent();
            this.pia = pia;
            button_OK.DialogResult = DialogResult.OK;
            button_Cancel.DialogResult = DialogResult.Cancel;
        }

        private void trackBar_Brightness_Scroll(object sender, EventArgs e)
        {
            textBox_Brightness.Text = trackBar_Brightness.Value.ToString();
            textBox_Contrast.Text = trackBar_Contrast.Value.ToString();

            pia.Correction.BrightnessAndContrast(trackBar_Brightness.Value, trackBar_Contrast.Value);
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            pia.Correction.BrightnessAndContrast(trackBar_Brightness.Value, trackBar_Contrast.Value,true);
        }
    }
}
