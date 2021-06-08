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
    public partial class Form3EditWorkOfArt : Form
    {
        WorkOfArt theWorkOfArt;
        public Form3EditWorkOfArt(WorkOfArt workOfArt)
        {
            theWorkOfArt = workOfArt;
            InitializeComponent();
            if (theWorkOfArt != null && theWorkOfArt.size != null && theWorkOfArt.size.Length != 0)
            {
                textBox1.Text = theWorkOfArt.name;
                textBox2.Text = "" + theWorkOfArt.old;
                textBox3.Text = theWorkOfArt.size;
            }
        }

        private void Form3EditWorkOfArt_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            theWorkOfArt.name = textBox1.Text;
            theWorkOfArt.old = Int32.Parse(textBox2.Text);
            theWorkOfArt.size = textBox3.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            Regex regexGroupFormat = new Regex("^[0-9]*\\-\\d+\\-\\d+$");
            if (!regexGroupFormat.IsMatch(textBox3.Text))
            {
                e.Cancel = true;
                MessageBox.Show("Формат розміру: (вказати розмір витвору, а саме висоту ширину та довжину, через дефіс)");
            }
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
