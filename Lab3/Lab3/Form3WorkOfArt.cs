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
    public partial class Form3WorkOfArt : Form
    {
        public Form3WorkOfArt()
        {
            InitializeComponent();
            allWorkOfArt = new List<WorkOfArt>();
        }
        List<WorkOfArt> allWorkOfArt;
        private void Form3WorkOfArt_Load(object sender, EventArgs e)
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
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void Form3WorkOfArt_FormClosing(object sender, FormClosingEventArgs e)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<WorkOfArt>));
            using (TextWriter writer = new StreamWriter("all_workofart.xml"))
            {
                serializer.Serialize(writer, allWorkOfArt);
            }
        }

        

        private void button2_Click(object sender, EventArgs e)
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
    }
}
