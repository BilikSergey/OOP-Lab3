using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lab3
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 newForm = new Form1();
            newForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3WorkOfArt newForm = new Form3WorkOfArt();
            newForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormExhibit newForm = new FormExhibit();
            newForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormHall newForm = new FormHall();
            newForm.Show();
        }
    }
}
