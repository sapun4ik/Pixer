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
    public partial class HSV : Form
    {
        public pixerApi.Pixer pia;
        public HSV(pixerApi.Pixer pia)
        {
            InitializeComponent();
            this.pia = pia;
            button_OK.DialogResult = DialogResult.OK;
            button_Cancel.DialogResult = DialogResult.Cancel;
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            pia.Correction.HSB(trackBar1.Value, trackBar2.Value, trackBar3.Value,true);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            pia.Correction.HSB(trackBar1.Value, trackBar2.Value, trackBar3.Value);
        }
    }
}
