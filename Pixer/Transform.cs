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
    public partial class Transform : Form
    {
        private pixerApi.Pixer pia;
        private Form1 fm;
        public Transform(pixerApi.Pixer pia, Form1 fm)
        {
            InitializeComponent();
            this.pia = pia;
            this.fm = fm;
            button_OK.DialogResult = DialogResult.OK;
            button_Cancel.DialogResult = DialogResult.Cancel;
        }

        private void trackBar_X_Scroll(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                pia.Transform.Nearest(trackBar_W.Value, trackBar_H.Value, trackBar_X.Value, trackBar_Y.Value, rotate_trackBar.Value);
            if (radioButton2.Checked)
                pia.Transform.LinearInterpolation(trackBar_W.Value, trackBar_H.Value, trackBar_X.Value, trackBar_Y.Value, rotate_trackBar.Value);
            if (radioButton3.Checked)
                pia.Transform.BilinearInterpolation(trackBar_W.Value, trackBar_H.Value, trackBar_X.Value, trackBar_Y.Value, rotate_trackBar.Value);
            fm.PreviewSizeChange();
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                pia.Transform.Nearest(trackBar_W.Value, trackBar_H.Value, trackBar_X.Value, trackBar_Y.Value, rotate_trackBar.Value, true);
            if (radioButton2.Checked)
                pia.Transform.LinearInterpolation(trackBar_W.Value, trackBar_H.Value, trackBar_X.Value, trackBar_Y.Value, rotate_trackBar.Value, true);
            if (radioButton3.Checked)
                pia.Transform.BilinearInterpolation(trackBar_W.Value, trackBar_H.Value, trackBar_X.Value, trackBar_Y.Value, rotate_trackBar.Value, true);
            fm.PreviewSizeChange();
        }
    }
}
