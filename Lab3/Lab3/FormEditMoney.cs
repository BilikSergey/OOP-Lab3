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
    public partial class FormEditMoney : Form
    {
        Exhibit theMoney;
        public FormEditMoney(Exhibit exhibit)
        {
            theMoney = exhibit;
            InitializeComponent();
            textBox2.Text = "" + theMoney.money;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            theMoney.money = Int32.Parse(textBox2.Text);
            this.DialogResult = DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            Regex regexGroupFormat = new Regex("^\\d+$");
            if (!regexGroupFormat.IsMatch(textBox2.Text))
            {
                e.Cancel = true;
                MessageBox.Show("Має бути вказане число");
            }
        }
    }
}
