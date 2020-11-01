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
    public partial class FormAddRout : Form
    {
        public FormAddRout()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            label8.Text = $"({textBox3.Text.Length}/100 символов)";            
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox3.Text.Length >= 100 && e.KeyChar != 8) // 8 - backspace
                e.Handled = true;
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(textBox2.Text))
                    _ = int.Parse(textBox2.Text);
                else textBox2.Text = textBox2.Text.Trim();
            }
            catch
            {
                MessageBox.Show("Регистровый номер должен состоять тлько из цифр!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var contr = new FormSearchConrtact();
            contr.ShowDialog();
            if(contr.IsSelected)
            {
                textBox6.Text = contr.ID;
                textBox7.Text = contr.Number;
                button3.Enabled = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Порядковый номер должен быть заполенен!");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Реестровый номер должен быть заполенен!");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Наименование маршрута должно быть заполнено!");
                return;
            }

            SqlParameter id = new SqlParameter
            {
                ParameterName = "@id",
                SqlDbType = SqlDbType.Int,
                Value = int.Parse(textBox8.Text)
            };            
            SqlParameter por = new SqlParameter("@por", textBox1.Text);
            SqlParameter reestr = new SqlParameter("@reestr", textBox2.Text);
            SqlParameter name = new SqlParameter("@name", textBox3.Text);
            SqlParameter poryInOut = new SqlParameter("@poryd", textBox4.Text);
            SqlParameter typeoftransport = new SqlParameter("@typeof", textBox5.Text);
            SqlParameter contract = new SqlParameter 
            {
                ParameterName = "@contract",
                SqlDbType = SqlDbType.Int,
                Value = int.Parse(textBox6.Text)
            };
            SqlParameter typeofmes;

            if(comboBox1.SelectedIndex == 0)
                typeofmes = new SqlParameter("@typeofmes", "городской");
            else if(comboBox1.SelectedIndex == 1)
                typeofmes = new SqlParameter("@typeofmes", "пригородный");
            else typeofmes = new SqlParameter("@typeofmes", "междугородный");

            SqlCommand com = new SqlCommand("INSERT INTO Маршрут ([ID],[ID_Истории],[ID_Договор],[Регистрационный_номер],[Порядковый_номер],[Вид_регулярной_перевозки],[Порядок_посадки_и_высадки_пассажиров],[Наименование],[Тип_сообщения]) " +
                                                         "VALUES (@id, 1, @contract, @reestr, @por, @poryd, @typeof, @name, @typeofmes)");
            com.Parameters.Add(id);
            com.Parameters.Add(por);
            com.Parameters.Add(reestr);
            com.Parameters.Add(name);
            com.Parameters.Add(poryInOut);
            com.Parameters.Add(typeoftransport);
            com.Parameters.Add(contract);
            com.Parameters.Add(typeofmes);

            using (SqlConnection connection = new SqlConnection(StaticValues.ConnectionString))
            {
                com.Connection = connection;
                connection.Open();
                var rez = com.ExecuteNonQuery();
                if ((int)rez == 1)
                    MessageBox.Show("Ok");
                else MessageBox.Show("Err");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if(!String.IsNullOrWhiteSpace(textBox2.Text))
            {
                if (textBox2.Text.Length <= 3)
                    textBox8.Text = "7601" + int.Parse(textBox2.Text).ToString("000");
                else
                {
                    textBox2.Text = textBox2.Text.Remove(3);
                    textBox2.SelectionStart = 3;
                }
            }
        }
    }
}
