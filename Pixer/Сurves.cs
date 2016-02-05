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
    public partial class Сurves : Form
    {
        public pixerApi.Pixer pia;

        public Сurves(pixerApi.Pixer pia)
        {
            InitializeComponent();
            this.pia = pia;
            button1.DialogResult = DialogResult.OK;
            button2.DialogResult = DialogResult.Cancel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                pia.Curves.setCorrect(new Point[] { new Point(int.Parse(textBox1.Text), int.Parse(textBox2.Text)), new Point(int.Parse(textBox3.Text), int.Parse(textBox4.Text)) },true);
            if (radioButton2.Checked)
                pia.Curves.setCorrect(new Point[] { new Point(int.Parse(textBox1.Text), int.Parse(textBox2.Text)), new Point(int.Parse(textBox3.Text), int.Parse(textBox4.Text)),
                new Point(int.Parse(textBox5.Text), int.Parse(textBox6.Text))}, true);
            if (radioButton3.Checked)
                pia.Curves.setCorrect(new Point[] { new Point(int.Parse(textBox1.Text), int.Parse(textBox2.Text)), new Point(int.Parse(textBox3.Text), int.Parse(textBox4.Text)),
                new Point(int.Parse(textBox5.Text), int.Parse(textBox6.Text)),new Point(int.Parse(textBox7.Text), int.Parse(textBox8.Text))}, true);
            if (radioButton4.Checked)
                pia.Curves.setCorrect(new Point[] { new Point(int.Parse(textBox1.Text), int.Parse(textBox2.Text)), new Point(int.Parse(textBox3.Text), int.Parse(textBox4.Text)),
                new Point(int.Parse(textBox5.Text), int.Parse(textBox6.Text)),new Point(int.Parse(textBox7.Text), int.Parse(textBox8.Text)),
                new Point(int.Parse(textBox9.Text), int.Parse(textBox10.Text))}, true);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                pia.Curves.setCorrect(new Point[] { new Point(int.Parse(textBox1.Text), int.Parse(textBox2.Text)), new Point(int.Parse(textBox3.Text), int.Parse(textBox4.Text)) });
            if (radioButton2.Checked)
                pia.Curves.setCorrect(new Point[] { new Point(int.Parse(textBox1.Text), int.Parse(textBox2.Text)), new Point(int.Parse(textBox3.Text), int.Parse(textBox4.Text)),
                new Point(int.Parse(textBox5.Text), int.Parse(textBox6.Text))});
            if (radioButton3.Checked)
                pia.Curves.setCorrect(new Point[] { new Point(int.Parse(textBox1.Text), int.Parse(textBox2.Text)), new Point(int.Parse(textBox3.Text), int.Parse(textBox4.Text)),
                new Point(int.Parse(textBox5.Text), int.Parse(textBox6.Text)),new Point(int.Parse(textBox7.Text), int.Parse(textBox8.Text))});
            if (radioButton4.Checked)
                pia.Curves.setCorrect(new Point[] { new Point(int.Parse(textBox1.Text), int.Parse(textBox2.Text)), new Point(int.Parse(textBox3.Text), int.Parse(textBox4.Text)),
                new Point(int.Parse(textBox5.Text), int.Parse(textBox6.Text)),new Point(int.Parse(textBox7.Text), int.Parse(textBox8.Text)),
                new Point(int.Parse(textBox9.Text), int.Parse(textBox10.Text))});
        }
    }
}
