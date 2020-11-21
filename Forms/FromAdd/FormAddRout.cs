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
        struct Id_of_Name
        {
            public int ID;
            public string Name;
            public string Display_Name => $"{ID} {Name}";
            public string Display_ID => ID.ToString("00");
        }

        public FormAddRout()
        {
            InitializeComponent();

            comboBox1.SelectedIndex = 0;

            comboBox2.DataSource = GetNameRegion();
            comboBox2.DisplayMember = "Display_Name";
            comboBox2.ValueMember = "Display_ID";

            comboBox3.DataSource = GetNameCity();
            comboBox3.DisplayMember = "Display_Name";
            comboBox3.ValueMember = "Display_ID";
        }

        private List<Id_of_Name> GetNameRegion()
        {
            List<Id_of_Name> id_Of_Regions = new List<Id_of_Name>();

            using(SqlConnection connection = new SqlConnection(StaticValues.ConnectionString))
            {
                SqlCommand com = new SqlCommand("SELECT * FROM Id_of_Name_Area ORDER BY ID", connection);
                connection.Open();

                var rez = com.ExecuteReader();

                if(rez.HasRows)
                {
                    while(rez.Read())
                    {
                        id_Of_Regions.Add(new Id_of_Name
                        {
                            ID = rez.GetInt32(0),
                            Name = rez.GetString(1)
                        });
                    }
                }
            }

            return id_Of_Regions;
        }

        private List<Id_of_Name> GetNameCity()
        {
            List<Id_of_Name> id_Of_Regions = new List<Id_of_Name>();

            var selectItem = (Id_of_Name)comboBox2.SelectedItem;

            using (SqlConnection connection = new SqlConnection(StaticValues.ConnectionString))
            {
                SqlCommand com = new SqlCommand($"SELECT * FROM Id_Name_City WHERE ID_Area = {selectItem.ID} ORDER BY ID", connection);
                connection.Open();

                var rez = com.ExecuteReader();

                if (rez.HasRows)
                {
                    while (rez.Read())
                    {
                        id_Of_Regions.Add(new Id_of_Name
                        {
                            ID = rez.GetInt32(1),
                            Name = rez.GetString(2)
                        });
                    }
                }
            }

            return id_Of_Regions;
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
                typeofmes = new SqlParameter("@typeofmes", "Городской");
            else if(comboBox1.SelectedIndex == 1)
                typeofmes = new SqlParameter("@typeofmes", "Пригородный");
            else typeofmes = new SqlParameter("@typeofmes", "Междугородный");

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
            textBox2.Text = textBox2.Text.Trim();
            textBox2.SelectionStart = textBox2.Text.Length;

            if (String.IsNullOrWhiteSpace(textBox2.Text))
                return;

            if (!int.TryParse(textBox2.Text, out int number))
            {
                MessageBox.Show(this, "Значение должно содержать только цифры!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Text = textBox2.Text.Remove(textBox2.Text.Length - 1);
                textBox2.SelectionStart = textBox2.Text.Length;
                return;
            }

            if (textBox2.Text.Length <= 3)
            {
                var rez = (Id_of_Name)comboBox2.SelectedItem;
                var rez1 = (Id_of_Name)comboBox3.SelectedItem;
                textBox8.Text = (rez.Display_ID) + rez1.Display_ID + number.ToString("000");
            }
            else
            {
                textBox2.Text = textBox2.Text.Remove(3);
                textBox2.SelectionStart = 3;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text.Length > 10)
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
                textBox1.SelectionStart = textBox1.Text.Length;
            }
            toolTip1.SetToolTip(label14, $"({textBox1.Text.Length} / 10 символов)");
        }

        private void textBox6_DoubleClick(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        private void textBox7_DoubleClick(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        private void textBox8_Enter(object sender, EventArgs e)
        {
            textBox2.Focus();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.DataSource = GetNameCity();

            if(!String.IsNullOrWhiteSpace(textBox2.Text))
            {
                textBox2_TextChanged(sender, e);
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(textBox2.Text))
            {
                textBox2_TextChanged(sender, e);
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void keyPress_next_tabIndex(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SelectNextControl(ActiveControl, true, true, true, true);
                e.Handled = true;
            }
        }
    }
}
