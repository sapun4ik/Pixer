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
    public partial class Palette : Form
    {
        private pixerApi.Pixer pia;

        public Palette(pixerApi.Pixer pia)
        {
            InitializeComponent();
            this.pia = pia;
            button_OK.DialogResult = DialogResult.OK;
            button_Cancel.DialogResult = DialogResult.Cancel;
        }
        private void button_OK_Click(object sender, EventArgs e)
        {
            pia.Palette.setPalette(int.Parse(textBox1.Text),true);
        }
    }
}
