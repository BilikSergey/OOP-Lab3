using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace Lab3
{
    public partial class FormHall : Form
    {
        public FormHall()
        {
            InitializeComponent();
            allHall = new List<Hall>();
        }
        List<Hall> allHall;

        private void FormHall_Load(object sender, EventArgs e)
        {
            try
            {
                XmlSerializer deSerializer = new XmlSerializer(typeof(List<Hall>));
                using (TextReader reader = new StreamReader("all_hall.xml"))
                {
                    allHall = (List<Hall>)deSerializer.Deserialize(reader);
                }
                foreach (Hall stud in allHall)
                {
                    listBox1.Items.Add(stud);
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Не вдалося знайти файл із раніше збереженими даними,\nпочинаємо <<з чистого листа>>.\nДеталі помилки: " + e.ToString());
                allHall = new List<Hall>();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hall newHall = new Hall();
            FormEditHall formEditHall = new FormEditHall(newHall);
            if (formEditHall.ShowDialog() == DialogResult.OK)
            {
                listBox1.Items.Add(newHall.ToString());
                allHall.Add(newHall);
            }
            else
            {
                MessageBox.Show("Ви самі вибрали _Н_Е_ зберігати");
            }
        }

        private void FormHall_FormClosing(object sender, FormClosingEventArgs e)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Hall>));
            using (TextWriter writer = new StreamWriter("all_hall.xml"))
            {
                serializer.Serialize(writer, allHall);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int idx = listBox1.SelectedIndex;
            if (idx < 0 || idx >= allHall.Count)
            {
                MessageBox.Show("Виберіть рівно один виставковий зал");
                return;
            }
            FormEditHall formEditHall = new FormEditHall(allHall[listBox1.SelectedIndex]);
            if (formEditHall.ShowDialog() == DialogResult.OK)
            {
                listBox1.Items[idx] = allHall[listBox1.SelectedIndex].ToString();
            }
            else
            {
                MessageBox.Show("Ви самі вибрали _Н_Е_ зберігати");
            }
        }
    }
}

