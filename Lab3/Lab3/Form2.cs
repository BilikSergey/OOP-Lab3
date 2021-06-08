using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    public partial class Form2 : Form
    {
        Funds theFunds;
        public Form2(Funds funds)
        {
            theFunds = funds;
            InitializeComponent();
            if (theFunds != null && theFunds.addres != null && theFunds.addres.Length != 0)
            {
                textBox1.Text = theFunds.name;
                textBox2.Text = theFunds.addres;
            }
        }

        public Form2()
        {
            InitializeComponent();
        }


        private void textBox2_Validating_1(object sender, CancelEventArgs e)
        {
            Regex regexGroupFormat = new Regex("^[А-ЯІЄЇ]*\\-\\d*$");
            if (!regexGroupFormat.IsMatch(textBox2.Text))
            {
                e.Cancel = true;
                MessageBox.Show("Формат адреси: (великими літерами назва вулицi та номер через дефіс)");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            theFunds.name = textBox1.Text;
            theFunds.addres = textBox2.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
