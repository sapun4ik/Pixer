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
    public partial class ColorOverlay : Form
    {
        private pixerApi.Pixer pia;
        private Color color;
        public ColorOverlay(pixerApi.Pixer pia)
        {
            InitializeComponent();
            this.pia = pia;
            button_OK.DialogResult = DialogResult.OK;
            button_Cancel.DialogResult = DialogResult.Cancel;
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            pia.Correction.ColorOverlay(panelColor.BackColor, opacity_trackBar.Value, true);
        }

        private void opacity_trackBar_Scroll(object sender, EventArgs e)
        {
            pia.Correction.ColorOverlay(panelColor.BackColor,opacity_trackBar.Value);
        }

        private void panelColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            DialogResult result = colorDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                color = Color.FromArgb(colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B);
                panelColor.BackColor = Color.FromArgb(color.R, color.G, color.B);
            }
        }
    }
}
