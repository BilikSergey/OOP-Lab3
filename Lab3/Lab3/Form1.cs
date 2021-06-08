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
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            allFunds = new List<Funds>();
        }
        List<Funds> allFunds;
        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                XmlSerializer deSerializer = new XmlSerializer(typeof(List<Funds>));
                using (TextReader reader = new StreamReader("all_funds.xml"))
                {
                    allFunds = (List<Funds>)deSerializer.Deserialize(reader);
                }
                foreach (Funds stud in allFunds)
                {
                    listBox1.Items.Add(stud);
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Не вдалося знайти файл із раніше збереженими даними,\nпочинаємо <<з чистого листа>>.\nДеталі помилки: " + e.ToString());
                allFunds = new List<Funds>();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Funds newFunds = new Funds();
            Form2 formEditStudent = new Form2(newFunds);
            if (formEditStudent.ShowDialog() == DialogResult.OK)
            {
                listBox1.Items.Add(newFunds.ToString());
                allFunds.Add(newFunds);
            }
            else
            {
                MessageBox.Show("Ви самі вибрали _Н_Е_ зберігати");
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Funds>));
            using (TextWriter writer = new StreamWriter("all_funds.xml"))
            {
                serializer.Serialize(writer, allFunds);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int idx = listBox1.SelectedIndex;
            if (idx < 0 || idx >= allFunds.Count)
            {
                MessageBox.Show("Виберіть рівно один фонд");
                return;
            }
            Form2 formEditStudent = new Form2(allFunds[listBox1.SelectedIndex]);
            if (formEditStudent.ShowDialog() == DialogResult.OK)
            {
                listBox1.Items[idx] = allFunds[listBox1.SelectedIndex].ToString();
            }
            else
            {
                MessageBox.Show("Ви самі вибрали _Н_Е_ зберігати");
            }
        }
    }
}
