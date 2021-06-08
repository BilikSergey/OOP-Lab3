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
    public partial class FormExhibit : Form
    {
        public FormExhibit()
        {
            InitializeComponent();
            allExhibit = new List<Exhibit>();
            allWorkOfArt = new List<WorkOfArt>();
            allFunds = new List<Funds>();
        }
        List<Exhibit> allExhibit;
        List<WorkOfArt> allWorkOfArt;
        List<Funds> allFunds;

        private void FormExhibit_Load(object sender, EventArgs e)
        {           
            try
            {
                XmlSerializer deSerializer = new XmlSerializer(typeof(List<WorkOfArt>));
               
                using (TextReader reader = new StreamReader("all_workofart.xml"))
                {
                    allWorkOfArt = (List<WorkOfArt>)deSerializer.Deserialize(reader);
                }
                foreach (WorkOfArt stud in allWorkOfArt)
                {
                    listBox1.Items.Add(stud);
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Не вдалося знайти файл із раніше збереженими даними,\nпочинаємо <<з чистого листа>>.\nДеталі помилки: " + e.ToString());
                allWorkOfArt = new List<WorkOfArt>();            
            }





            try
            {
                XmlSerializer deSerializer = new XmlSerializer(typeof(List<Funds>));
                using (TextReader reader = new StreamReader("all_funds.xml"))
                {
                    allFunds = (List<Funds>)deSerializer.Deserialize(reader);
                }
                foreach (Funds stud in allFunds)
                {
                    listBox2.Items.Add(stud);
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Не вдалося знайти файл із раніше збереженими даними,\nпочинаємо <<з чистого листа>>.\nДеталі помилки: " + e.ToString());
                allFunds = new List<Funds>();
            }





            try
            {
                XmlSerializer deSerializer = new XmlSerializer(typeof(List<Exhibit>));

                using (TextReader reader = new StreamReader("all_money.xml"))
                {
                    allExhibit = (List<Exhibit>)deSerializer.Deserialize(reader);
                }
                foreach (Exhibit stud in allExhibit)
                {
                    listBox3.Items.Add(stud);
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Не вдалося знайти файл із раніше збереженими даними,\nпочинаємо <<з чистого листа>>.\nДеталі помилки: " + e.ToString());
                allExhibit = new List<Exhibit>();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            WorkOfArt newWorkOfArt = new WorkOfArt();
            Form3EditWorkOfArt formEditWorkOfArt = new Form3EditWorkOfArt(newWorkOfArt);
            if (formEditWorkOfArt.ShowDialog() == DialogResult.OK)
            {
                listBox1.Items.Add(newWorkOfArt.ToString());
                allWorkOfArt.Add(newWorkOfArt);
            }
            else
            {
                MessageBox.Show("Ви самі вибрали _Н_Е_ зберігати");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Funds newFunds = new Funds();
            Form2 Form2 = new Form2(newFunds);
            if (Form2.ShowDialog() == DialogResult.OK)
            {
                listBox1.Items.Add(newFunds.ToString());
                allFunds.Add(newFunds);
            }
            else
            {
                MessageBox.Show("Ви самі вибрали _Н_Е_ зберігати");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Exhibit newExhibit = new Exhibit();
            FormEditMoney formEditMoney = new FormEditMoney(newExhibit);
            if (formEditMoney.ShowDialog() == DialogResult.OK)
            {
                listBox3.Items.Add(newExhibit.ToString());
                allExhibit.Add(newExhibit);
            }
            else
            {
                MessageBox.Show("Ви самі вибрали _Н_Е_ зберігати");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            int idx = listBox1.SelectedIndex;
            if (idx < 0 || idx >= allWorkOfArt.Count)
            {
                MessageBox.Show("Виберіть рівно один витвір мистецтва");
                return;
            }
            Form3EditWorkOfArt formEditStudent = new Form3EditWorkOfArt(allWorkOfArt[listBox1.SelectedIndex]);
            if (formEditStudent.ShowDialog() == DialogResult.OK)
            {
                listBox1.Items[idx] = allWorkOfArt[listBox1.SelectedIndex].ToString();
            }
            else
            {
                MessageBox.Show("Ви самі вибрали _Н_Е_ зберігати");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int idx = listBox2.SelectedIndex;
            if (idx < 0 || idx >= allFunds.Count)
            {
                MessageBox.Show("Виберіть рівно один фонд");
                return;
            }
            Form2 formEditStudent = new Form2(allFunds[listBox2.SelectedIndex]);
            if (formEditStudent.ShowDialog() == DialogResult.OK)
            {
                listBox2.Items[idx] = allFunds[listBox2.SelectedIndex].ToString();
            }
            else
            {
                MessageBox.Show("Ви самі вибрали _Н_Е_ зберігати");
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            int idx = listBox3.SelectedIndex;
            if (idx < 0 || idx >= allExhibit.Count)
            {
                MessageBox.Show("Виберіть рівно одну суму");
                return;
            }
            FormEditMoney formEditMoney = new FormEditMoney(allExhibit[listBox3.SelectedIndex]);
            if (formEditMoney.ShowDialog() == DialogResult.OK)
            {
                listBox3.Items[idx] = allExhibit[listBox3.SelectedIndex].ToString();
            }
            else
            {
                MessageBox.Show("Ви самі вибрали _Н_Е_ зберігати");
            }
        }
        private void FormExhibit_FormClosing(object sender, FormClosingEventArgs e)
        {
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<WorkOfArt>));
                using (TextWriter writer = new StreamWriter("all_workofart.xml"))
                {
                    serializer.Serialize(writer, allWorkOfArt);
                }
            }

            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Funds>));
                using (TextWriter writer = new StreamWriter("all_funds.xml"))
                {
                    serializer.Serialize(writer, allFunds);
                }
            }

            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Exhibit>));
                using (TextWriter writer = new StreamWriter("all_money.xml"))
                {
                    serializer.Serialize(writer, allExhibit);
                }
            }
        }       
    }
}
