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
    public partial class Medianer : Form
    {
        public pixerApi.Pixer pia;

        public Medianer(pixerApi.Pixer pia)
        {
            InitializeComponent();
            this.pia = pia;
            button_OK.DialogResult = DialogResult.OK;
            button_Cancel.DialogResult = DialogResult.Cancel;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            textBox1.Text = trackBar1.Value.ToString();
            pia.Filters.Medianer(int.Parse(textBox1.Text));
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            pia.Filters.Medianer(int.Parse(textBox1.Text));
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            pia.Filters.Medianer(int.Parse(textBox1.Text), true);
        }
    }
}
