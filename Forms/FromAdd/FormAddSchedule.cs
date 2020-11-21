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
    public partial class FormAddSchedule : Form
    {
        public FormAddSchedule()
        {
            InitializeComponent();
            comboBox2.Items.Add("пярмой");
            comboBox2.Items.Add("обратный");
            comboBox2.SelectedIndex = 0;

            textBox1.Text = "1";
            textBox2.Text = "1";

            DateTime date = DateTime.Now;

            dateTimePicker1.Value = new DateTime(date.Year, 1, 1);
            dateTimePicker2.Value = new DateTime(date.Year, 12, 31);
            button2.Focus();
            textBox1.SelectionStart = 2;
        }

        public void SetIdRout(string id)
        {
            textBox12.Text = id;
        }

        public void SetNameRout(string name)
        {
            textBox13.Text = name;
        }

        public void SetNumberHistory(string number)
        {
            textBox2.Text = number;
        }

        public void SetNumberGraph(string number)
        {
            textBox1.Text = number;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormCalcDateForClassRout calcDateForClass = new FormCalcDateForClassRout();
            calcDateForClass.ShowDialog();

            if (!calcDateForClass.isClose)
            {
                if (calcDateForClass.checkBox1.Checked)
                {
                    textBox4.Text = calcDateForClass.JSON;
                    textBox14.Text = "1,";
                }
                if (calcDateForClass.checkBox2.Checked)
                {
                    textBox5.Text = calcDateForClass.JSON;
                    textBox14.Text += "2,";
                }
                if (calcDateForClass.checkBox3.Checked)
                {
                    textBox6.Text = calcDateForClass.JSON;
                    textBox14.Text += "3,";
                }
                if (calcDateForClass.checkBox4.Checked)
                {
                    textBox7.Text = calcDateForClass.JSON;
                    textBox14.Text += "4,";
                }
                if (calcDateForClass.checkBox5.Checked)
                {
                    textBox8.Text = calcDateForClass.JSON;
                    textBox14.Text += "5,";
                }
                if (calcDateForClass.checkBox6.Checked)
                {
                    textBox9.Text = calcDateForClass.JSON;
                    textBox14.Text += "6,";
                }
                if (calcDateForClass.checkBox7.Checked)
                {
                    textBox10.Text = calcDateForClass.JSON;
                    textBox14.Text += "7,";
                }
                if (calcDateForClass.checkBox8.Checked)
                {
                    textBox11.Text = calcDateForClass.JSON;
                    textBox14.Text += "8,";
                }

                textBox14.Text = textBox14.Text.Remove(textBox14.Text.Length - 1);
                button1.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormCalcDateForClassRout calcDateForClass = new FormCalcDateForClassRout();
            calcDateForClass.ShowDialog();

            if (!calcDateForClass.isClose)
            {
                textBox5.Text = calcDateForClass.JSON;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormCalcDateForClassRout calcDateForClass = new FormCalcDateForClassRout();
            calcDateForClass.ShowDialog();

            if (!calcDateForClass.isClose)
            {
                textBox6.Text = calcDateForClass.JSON;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormCalcDateForClassRout calcDateForClass = new FormCalcDateForClassRout();
            calcDateForClass.ShowDialog();

            if (!calcDateForClass.isClose)
            {
                textBox7.Text = calcDateForClass.JSON;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FormCalcDateForClassRout calcDateForClass = new FormCalcDateForClassRout();
            calcDateForClass.ShowDialog();

            if (!calcDateForClass.isClose)
            {
                textBox8.Text = calcDateForClass.JSON;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FormCalcDateForClassRout calcDateForClass = new FormCalcDateForClassRout();
            calcDateForClass.ShowDialog();

            if (!calcDateForClass.isClose)
            {
                textBox9.Text = calcDateForClass.JSON;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FormCalcDateForClassRout calcDateForClass = new FormCalcDateForClassRout();
            calcDateForClass.ShowDialog();

            if (!calcDateForClass.isClose)
            {
                textBox10.Text = calcDateForClass.JSON;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            FormCalcDateForClassRout calcDateForClass = new FormCalcDateForClassRout();
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

                using (SqlConnection connection = new SqlConnection(StaticValues.ConnectionString))
                {
                    SqlCommand com = new SqlCommand($"SELECT max(ID_История), max(ID_Номер_Расписания) From Вариант_рейса WHERE ID_Маршрут = {textBox12.Text}", connection);
                    connection.Open();
                    var rez = com.ExecuteReader();
                    if (rez.HasRows)
                    {
                        rez.Read();
                        SetNumberHistory(rez.GetInt32(0).ToString());
                        SetNumberHistory((rez.GetInt32(1) + 1).ToString());
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox12.Text == "")
            {
                return;
            }

            if(dateTimePicker1.Value > dateTimePicker2.Value)
            {
                MessageBox.Show(this, "Даты пересекаються!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if(!double.TryParse(textBox3.Text, out _))
            {
                MessageBox.Show(this, "Ошибка преобразования, возможно вы ввели '.' вместо ','", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Text = textBox3.Text.Remove(textBox3.Text.Length - 1);
                textBox3.SelectionStart = textBox3.Text.Length;
            }
        }

        private void Focus_button10(object sender, EventArgs e)
        {
            button10_Click(sender, e);
        }

        private void focus_to_button2(object sender, EventArgs e)
        {
            button2.Focus();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            textBox4.Clear();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            textBox5.Clear();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            textBox6.Clear();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            textBox7.Clear();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            textBox8.Clear();
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            textBox9.Clear();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox10.Clear();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox11.Clear();
        }
    }
}