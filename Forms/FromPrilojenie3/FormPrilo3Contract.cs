using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test1.Code;

namespace Test1.Forms.FromPrilojenie3
{
    public partial class FormPrilo3Contract : Form
    {
        List<Code.Schedule> Schedules;
        Dictionary<int, ClassTransport> dict2;

        public FormPrilo3Contract()
        {
            InitializeComponent();
            LoadContract();
            Schedules = new List<Schedule>();
        }

        private void LoadContract()
        {
            using(SqlConnection connection = new SqlConnection(Code.StaticValues.ConnectionString))
            {
                SqlCommand com = new SqlCommand("Select Номер_Договора From Договор ORDER BY Номер_Договора", connection);
                connection.Open();
                var rez = com.ExecuteReader();

                if(rez.HasRows)
                {
                    while(rez.Read())
                        comboBox1.Items.Add(rez.GetString(0));
                }
            }
        }

        private void Execut()
        {
            DateTime @new = new DateTime();

            if (dict2 == null)
                dict2 = new Dictionary<int, ClassTransport>();
            else dict2.Clear();


            foreach (var item in Schedules)
            {
                if (item.By == @new)
                    continue;

                for (DateTime i = item.With; i <= item.By; i = i.AddDays(1))
                {
                    if (!(dTPWith.Value <= i && i <= dTPBy.Value)) // проверяем промежуток отчета
                        continue;

                    ClassTransport classA = new ClassTransport();

                    if (dict2.ContainsKey(i.Month))
                        classA = dict2[i.Month];

                    switch (i.DayOfWeek)
                    {
                        case System.DayOfWeek.Monday:
                            if (item.DayOfWork.Contains(1))
                            {
                                classA += item.Monday * item.Miliage;
                            }
                            break;
                        case System.DayOfWeek.Tuesday:
                            if (item.DayOfWork.Contains(2))
                            {
                                classA += item.Tuesday * item.Miliage;
                            }
                            break;
                        case System.DayOfWeek.Wednesday:
                            if (item.DayOfWork.Contains(3))
                            {
                                classA += item.Wednesday * item.Miliage;
                            }
                            break;
                        case System.DayOfWeek.Thursday:
                            if (item.DayOfWork.Contains(4))
                            {
                                classA += item.Thursday * item.Miliage;
                            }
                            break;
                        case System.DayOfWeek.Friday:
                            if (item.DayOfWork.Contains(5))
                            {
                                classA += item.Friday * item.Miliage;
                            }
                            break;
                        case System.DayOfWeek.Saturday:
                            if (item.DayOfWork.Contains(6))
                            {
                                classA += item.Saturday * item.Miliage;
                            }
                            break;
                        case System.DayOfWeek.Sunday:
                            if (item.DayOfWork.Contains(7))
                            {
                                classA += item.Sunday * item.Miliage;
                            }
                            break;
                    }

                    dict2[i.Month] = classA;
                }
            }
        }

        private void LoadSchelude()
        {
            string number_contr = (string)comboBox1.SelectedItem;
            System.Diagnostics.Debug.WriteLine(number_contr);
            
            using(SqlConnection connection = new SqlConnection(Code.StaticValues.ConnectionString))
            {
                SqlCommand com = new SqlCommand($"select v.ID_Маршрут, v.Пробег, v.Пн, v.Вт, v.Ср, v.Чт, v.Пт, v.Сб, v.Вс, v.Пр, v.Начало_действия, v.Дата_окончания, v.Дни_работы from Вариант_рейса v JOIN Rout_Contract r ON v.ID_Маршрут = r.ID_Rout JOIN Договор d ON d.ID = r.ID_Contract where d.Номер_Договора like '{number_contr}'", connection);
                connection.Open();
                var rez = com.ExecuteReader();
                if(rez.HasRows)
                {
                    while(rez.Read())
                    {
                        Test1.Code.Schedule schedule = new Test1.Code.Schedule();
                        schedule.ID_Rout = rez.GetInt32(0);
                        schedule.Miliage = rez.GetDouble(1);
                        schedule.SetMonday(rez.GetString(2));
                        schedule.SetTuesday(rez.GetString(3));
                        schedule.SetWednesday(rez.GetString(4));
                        schedule.SetThursday(rez.GetString(5));
                        schedule.SetFriday(rez.GetString(6));
                        schedule.SetSaturday(rez.GetString(7));
                        schedule.SetSunday(rez.GetString(8));
                        schedule.SetHoliday(rez.GetString(9));
                        schedule.With = rez.GetDateTime(10);
                        schedule.By = rez.GetDateTime(11);
                        schedule.SetDayOfWork(rez.GetString(12));

                        Schedules.Add(schedule);
                    }
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
                dataGridView1[1, item.Key - 1].Value = Math.Round(item.Value.SC, 2);
                dataGridView1[2, item.Key - 1].Value = Math.Round(item.Value.MC, 2);
                dataGridView1[3, item.Key - 1].Value = Math.Round(item.Value.LC, 2);
                dataGridView1[4, item.Key - 1].Value = Math.Round(item.Value.ESC, 2);
                dataGridView1[5, item.Key - 1].Value = Math.Round(item.Value.ELC, 2);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dTPWith.Value <= dTPBy.Value)
            {
                LoadSchelude();
                Execut();
                DataGridV();
            }
            else MessageBox.Show(this, "Дата выборки пересекаеться", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
