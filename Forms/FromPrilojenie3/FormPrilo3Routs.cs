using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using Test1.Code;

namespace Test1.Forms
{
    public partial class FormPrilo3 : Form
    {
        List<Code.Schedule> Schedules;
        Dictionary<int, ClassTransport> dict2;
        Rout Rout;

        public FormPrilo3()
        {
            InitializeComponent();

            Schedules = new List<Schedule>();
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
                Execut();
                DataGridV();
            }
            else MessageBox.Show(this, "Дата выборки пересекаеться", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LoadScheled()
        {
            string Table = "Вариант_рейса";
            Schedules.Clear();

            string sqlexp = $"SELECT * FROM {Table} WHERE ID_Маршрут = {Rout.ID} ORDER BY ID_Маршрут, ID_Номер_Расписания,ID_История";

            using (SqlConnection connect = new SqlConnection(StaticValues.ConnectionString))
            {
                connect.Open();
                SqlCommand com = new SqlCommand(sqlexp, connect);
                SqlCommand countColums = new SqlCommand($"SELECT Count(COLUMN_NAME) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{Table}'", connect);

                var countcolums = (int)countColums.ExecuteScalar();
                var rez = com.ExecuteReader();

                if (rez.HasRows)
                {
                    while (rez.Read())
                    {
                        Test1.Code.Schedule schedule = new Test1.Code.Schedule();
                        schedule.ID_Rout = rez.GetInt32(0);
                        schedule.ID_Number_Schedule = rez.GetInt32(1);
                        schedule.ID_History = rez.GetInt32(2);
                        schedule.Miliage = rez.GetDouble(3);
                        schedule.Type_Schedule = rez.GetString(4);
                        var ret = schedule.SetMonday(rez.GetString(5));
                        ret &= schedule.SetTuesday(rez.GetString(6));
                        ret &= schedule.SetWednesday(rez.GetString(7));
                        ret &= schedule.SetThursday(rez.GetString(8));
                        ret &= schedule.SetFriday(rez.GetString(9));
                        ret &= schedule.SetSaturday(rez.GetString(10));
                        ret &= schedule.SetSunday(rez.GetString(11));
                        ret &= schedule.SetHoliday(rez.GetString(12));
                        schedule.With = rez.GetDateTime(13);

                        if (rez.GetValue(14) != DBNull.Value)
                            schedule.By = rez.GetDateTime(14);
                        else schedule.By = new DateTime();

                        schedule.SetDayOfWork(rez.GetString(15));
                        Schedules.Add(schedule);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormSearchRout searchRout = new FormSearchRout();
            searchRout.ShowDialog();
            if(searchRout.IsClose)
            {
                textBox1.Text = searchRout.SelecetRout.ID.ToString();
                textBox2.Text = searchRout.SelecetRout.Poryd;
                textBox3.Text = searchRout.SelecetRout.Name;
                Rout = searchRout.SelecetRout;
                LoadScheled();
                button1.Enabled = true;
            }
        }
    }
}
