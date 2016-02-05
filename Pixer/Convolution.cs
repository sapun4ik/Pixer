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
    public partial class Convolution : Form
    {
        public pixerApi.Pixer pia;

        public Convolution(pixerApi.Pixer pia)
        {
            InitializeComponent();
            this.pia = pia;
            button_OK.DialogResult = DialogResult.OK;
            button_Cancel.DialogResult = DialogResult.Cancel;
        }

        private void TextChanged(object sender, EventArgs e)
        {
            double[] Matrix = { 0,0,0,0,0,
                                 0,0,0,0,0,
                                 0,0,1,0,0,
                                 0,0,0,0,0,
                                 0,0,0,0,0, };
            try
            {
                int i = 0;
                foreach (var control in this.groupBox1.Controls)
                {
                    if (control is TextBox)
                    {
                        Matrix[i++] = double.Parse((control as TextBox).Text);
                    }
                }
                pia.Filters.Convolution(Matrix, int.Parse(offset_textBox.Text), 5);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            double[] Matrix = { 0,0,0,0,0,
                                 0,0,0,0,0,
                                 0,0,1,0,0,
                                 0,0,0,0,0,
                                 0,0,0,0,0, };
            try
            {
                int i = 0;
                foreach (var control in this.groupBox1.Controls)
                {
                    if (control is TextBox)
                    {
                        Matrix[i++] = double.Parse((control as TextBox).Text);
                    }
                }
                pia.Filters.Convolution(Matrix, int.Parse(offset_textBox.Text), 5, true);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

        }
    }
}
