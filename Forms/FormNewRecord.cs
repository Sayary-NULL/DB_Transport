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

namespace Test1.Forms
{
    public partial class FormNewRecord : Form
    {
        public FormNewRecord(int ID_Nomber, int ID_Hist)
        {
            InitializeComponent();
            comboBox2.Items.Add("пярмой");
            comboBox2.Items.Add("обратный");
            comboBox2.SelectedIndex = 0;

            textBox1.Text = (ID_Nomber).ToString();
            textBox2.Text = (ID_Hist).ToString();

            DateTime date = DateTime.Now;

            dateTimePicker1.Value = new DateTime(date.Year, 1, 1);
            dateTimePicker2.Value = new DateTime(date.Year, 12, 31);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormCalcDateForClass calcDateForClass = new FormCalcDateForClass();
            calcDateForClass.ShowDialog();

            if(!calcDateForClass.isClose)
            {
                textBox4.Text = calcDateForClass.JSON;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormCalcDateForClass calcDateForClass = new FormCalcDateForClass();
            calcDateForClass.ShowDialog();

            if (!calcDateForClass.isClose)
            {
                textBox5.Text = calcDateForClass.JSON;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormCalcDateForClass calcDateForClass = new FormCalcDateForClass();
            calcDateForClass.ShowDialog();

            if (!calcDateForClass.isClose)
            {
                textBox6.Text = calcDateForClass.JSON;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormCalcDateForClass calcDateForClass = new FormCalcDateForClass();
            calcDateForClass.ShowDialog();

            if (!calcDateForClass.isClose)
            {
                textBox7.Text = calcDateForClass.JSON;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FormCalcDateForClass calcDateForClass = new FormCalcDateForClass();
            calcDateForClass.ShowDialog();

            if (!calcDateForClass.isClose)
            {
                textBox8.Text = calcDateForClass.JSON;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FormCalcDateForClass calcDateForClass = new FormCalcDateForClass();
            calcDateForClass.ShowDialog();

            if (!calcDateForClass.isClose)
            {
                textBox9.Text = calcDateForClass.JSON;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FormCalcDateForClass calcDateForClass = new FormCalcDateForClass();
            calcDateForClass.ShowDialog();

            if (!calcDateForClass.isClose)
            {
                textBox10.Text = calcDateForClass.JSON;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            FormCalcDateForClass calcDateForClass = new FormCalcDateForClass();
            calcDateForClass.ShowDialog();

            if (!calcDateForClass.isClose)
            {
                textBox11.Text = calcDateForClass.JSON;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            FormSearchRout rout = new FormSearchRout();
            rout.ShowDialog();
            if(rout.IsClose)
            {
                textBox12.Text = rout.SelecetRout.ID.ToString();
                textBox13.Text = rout.SelecetRout.Name;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox12.Text == "")
            {
                return;
            }

            string part1 = "INSERT INTO Вариант_рейса (ID_Маршрут, ID_Номер_Расписания, ID_История, Пробег, Тип_рейса, Пн, Вт, Ср, Чт, Пт, Сб, Вс, Пр, Начало_действия, Дата_окончания, Дни_работы) ",
                part2 = "VALUES (@ID_Маршрут, @ID_Номер_Расписания, @ID_История, @Пробег, @Тип_рейса, @Пн, @Вт, @Ср, @Чт, @Пт, @Сб, @Вс, @Пр, @With, @By, @day)";
            SqlCommand com = new SqlCommand(part1 + part2);
            
            SqlParameter IDpar = new SqlParameter("@ID_Маршрут", textBox12.Text);
            com.Parameters.Add(IDpar);
            SqlParameter ID_Num = new SqlParameter("@ID_Номер_Расписания", Int32.Parse(textBox1.Text) + 1);
            com.Parameters.Add(ID_Num);
            SqlParameter ID_Hist = new SqlParameter("@ID_История", textBox2.Text);
            com.Parameters.Add(ID_Hist);
            SqlParameter Prob = new SqlParameter("@Пробег", textBox3.Text);
            com.Parameters.Add(Prob);
            SqlParameter Type_mes;
            if(comboBox2.SelectedIndex == 0)
                Type_mes = new SqlParameter("@Тип_рейса", "прямой");
            else Type_mes = new SqlParameter("@Тип_рейса", "обратный");
            com.Parameters.Add(Type_mes);
            SqlParameter Pn = new SqlParameter("@Пн", textBox4.Text);
            com.Parameters.Add(Pn);
            SqlParameter Vt = new SqlParameter("@Вт", textBox5.Text);
            com.Parameters.Add(Vt);
            SqlParameter Sr = new SqlParameter("@Ср", textBox6.Text);
            com.Parameters.Add(Sr);
            SqlParameter Cht = new SqlParameter("@Чт", textBox7.Text);
            com.Parameters.Add(Cht);
            SqlParameter Pt = new SqlParameter("@Пт", textBox8.Text);
            com.Parameters.Add(Pt);
            SqlParameter Sb = new SqlParameter("@Сб", textBox9.Text);
            com.Parameters.Add(Sb);
            SqlParameter Vs = new SqlParameter("@Вс", textBox10.Text);
            com.Parameters.Add(Vs);
            SqlParameter Pr = new SqlParameter("@Пр", textBox11.Text);
            com.Parameters.Add(Pr);
            SqlParameter With = new SqlParameter("@With", dateTimePicker1.Value);
            com.Parameters.Add(With);
            SqlParameter By = new SqlParameter("@By", dateTimePicker2.Value);
            com.Parameters.Add(By);
            SqlParameter DayOfWork = new SqlParameter("@day", textBox14.Text);
            com.Parameters.Add(DayOfWork);

            using (SqlConnection con = new SqlConnection(StaticValues.ConnectionString))
            {
                con.Open();
                com.Connection = con;
                try
                {
                    var rez = com.ExecuteNonQuery();
                    MessageBox.Show("Ок");
                }
                catch(Exception ex)
                { 
                    MessageBox.Show("Ошибка");
                    System.Diagnostics.Debug.WriteLine(ex);
                }
            }
            
            this.Close();
        }
    }
}