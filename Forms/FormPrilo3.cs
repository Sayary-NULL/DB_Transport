using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test1.Forms
{
    public partial class FormPrilo3 : Form
    {
        List<Code.Schedule> Schedules;
        Dictionary<int, ClassA> dict2;

        public FormPrilo3(List<Code.Schedule> schedules)
        {
            InitializeComponent();

            Schedules = schedules;
        }

        private void Execut()
        {
            DateTime @new = new DateTime();

            if (dict2 == null)
                dict2 = new Dictionary<int, ClassA>();
            else dict2.Clear();
            

            foreach (var item in Schedules)
            {
                if (item.By == @new)
                    continue;

                for (DateTime i = item.With; i <= item.By; i = i.AddDays(1))
                {
                    if (!(dTPWith.Value <= i && i <= dTPBy.Value)) // проверяем промежуток отчета
                        continue;

                    ClassA classA = new ClassA();

                    if (dict2.ContainsKey(i.Month))
                        classA = dict2[i.Month];

                    switch (i.DayOfWeek)
                    {
                        case System.DayOfWeek.Monday:
                            if (item.DayOfWork.Contains(1))
                            {
                                classA += item.Monday;
                            }
                            break;
                        case System.DayOfWeek.Tuesday:
                            if (item.DayOfWork.Contains(2))
                            {
                                classA += item.Tuesday;
                            }
                            break;
                        case System.DayOfWeek.Wednesday:
                            if (item.DayOfWork.Contains(3))
                            {
                                classA += item.Wednesday;
                            }
                            break;
                        case System.DayOfWeek.Thursday:
                            if (item.DayOfWork.Contains(4))
                            {
                                classA += item.Thursday;
                            }
                            break;
                        case System.DayOfWeek.Friday:
                            if (item.DayOfWork.Contains(5))
                            {
                                classA += item.Friday;
                            }
                            break;
                        case System.DayOfWeek.Saturday:
                            if (item.DayOfWork.Contains(6))
                            {
                                classA += item.Saturday;
                            }
                            break;
                        case System.DayOfWeek.Sunday:
                            if (item.DayOfWork.Contains(7))
                            {
                                classA += item.Sunday;
                            }
                            break;
                    }

                    dict2[i.Month] = classA;
                }
            }
        }

        private void DataGridV()
        {
            dataGridView1.Rows.Clear();

            for (int i = 0; i < 12; i++)
            {
                dataGridView1.Rows.Add(Test1.Code.StaticValues.months[i]);
            }

            foreach (var item in dict2)
            {
                dataGridView1[1, item.Key - 1].Value = item.Value.SC;
                dataGridView1[2, item.Key - 1].Value = item.Value.MC;
                dataGridView1[3, item.Key - 1].Value = item.Value.LC;
                dataGridView1[4, item.Key - 1].Value = item.Value.ESC;
                dataGridView1[5, item.Key - 1].Value = item.Value.ELC;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dTPWith.Value <= dTPBy.Value)
            {
                Execut();
                DataGridV();
            }
            else MessageBox.Show(this, "Дата выборки пересекаеться", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
