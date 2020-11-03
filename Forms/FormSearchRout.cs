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
    public partial class FormSearchRout : Form
    {
        private List<Rout> Routs;
        private List<string> IDs;
        private List<string> SerialNumbers;
        public Rout SelecetRout;
        public bool IsClose = false;

        public FormSearchRout()
        {
            InitializeComponent();
            Routs = new List<Rout>();

            SelecetRout = null;
            IDs = new List<string>();
            SerialNumbers = new List<string>();
            loadDataToList();
        }

        private void loadDataToList()
        {
            using(SqlConnection connect = new SqlConnection(StaticValues.ConnectionString))
            {
                SqlCommand com = new SqlCommand("SELECT ID, Порядковый_номер FROM Маршрут", connect);
                connect.Open();
                var rez = com.ExecuteReader();

                if(rez.HasRows)
                {
                    while(rez.Read())
                    {
                        IDs.Add(rez.GetInt32(0).ToString());
                        comboBox1.Items.Add(rez.GetInt32(0).ToString());
                        SerialNumbers.Add(rez.GetString(1));
                        comboBox2.Items.Add(rez.GetString(1));
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Routs.Clear();
            dataGridView1.Columns.Clear();

            if(comboBox1.Text == "" && comboBox2.Text == "" && textBox3.Text == "")
            {
                MessageBox.Show(this,"Введите данные для поиска", "Ошибка поиска", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            long ID = 0;
            if (comboBox1.Text.Length != 0)
            {
                if (!Int64.TryParse(comboBox1.Text, out ID))
                {
                    MessageBox.Show(this, "Ошибка преобразования ID", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            string por = comboBox2.Text;
            string city = textBox3.Text;

            string exp = "Select * From Маршрут Where ";

            if (ID != 0)
                exp += $"ID = {ID}";

            if(por != "")
            {
                if (ID != 0)
                    exp += " OR ";

                exp += $"Порядковый_номер = '{por}'";
            }

            if(city != "")
            {
                if (ID != 0 || por != "")
                    exp += " OR ";

                exp += $"Наименование LIKE '%{city}%'";
            }

            using(SqlConnection con = new SqlConnection(StaticValues.ConnectionString))
            {
                SqlCommand com = new SqlCommand(exp, con);
                SqlCommand countColums = new SqlCommand($"SELECT Count(COLUMN_NAME) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Маршрут'", con);
                con.Open();
                var countcolums = (int)countColums.ExecuteScalar();
                var rez = com.ExecuteReader();
                
                if(rez.HasRows)
                {
                    for(int i = 0; i < countcolums; i++)
                    {
                        dataGridView1.Columns.Add(rez.GetName(i), rez.GetName(i));
                    }

                    while(rez.Read())
                    {
                        var rout = new Rout
                        {
                            ID = rez.GetInt32(0),
                            ID_History = rez.GetInt32(1),
                            ID_Contract = rez.GetInt32(2),
                            Registr = rez.GetString(3),
                            Poryd = rez.GetString(4),
                            TypeOfRegular = rez.GetString(5),
                            TypeOnOut = rez.GetString(6),
                            Name = rez.GetString(7),
                            Type_communication = rez.GetString(8)
                        };

                        dataGridView1.Rows.Add(rout.ToRow());
                        Routs.Add(rout);
                    }
                }
            }

            if(Routs.Count == 0)
            {
                MessageBox.Show(this, "Не найдено ни одной записи по вашему запросу, попробуйте изменить запрос и повторить попытку", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show(this, "Выполните корректный запрос");
                return;
            }

            if(dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show(this, "Выберите 1 запись");
                return;
            }

            SelecetRout = Routs[dataGridView1.SelectedRows[0].Index];
            IsClose = true;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_Enter(object sender, EventArgs e)
        {
            comboBox1.DroppedDown = true;
        }

        private void comboBox1_TextUpdate(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            var text = comboBox1.Text;
            foreach (var item in IDs)
            {
                if (item.StartsWith(text) || String.IsNullOrWhiteSpace(text) || String.IsNullOrEmpty(text))
                    comboBox1.Items.Add(item);
            }
            comboBox1.SelectionStart = comboBox1.Text.Length;
            comboBox1.DroppedDown = true;
        }

        private void comboBox2_TextUpdate(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            var text = comboBox2.Text;
            foreach (var item in SerialNumbers)
            {
                if (item.StartsWith(text) || String.IsNullOrWhiteSpace(text) || String.IsNullOrEmpty(text))
                    comboBox2.Items.Add(item);
            }
            comboBox2.SelectionStart = comboBox2.Text.Length;
            comboBox2.DroppedDown = true;
        }

        private void comboBox2_Enter(object sender, EventArgs e)
        {
            comboBox2.DroppedDown = true;
        }

        private void KeyPressEnter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                button1_Click(sender, new EventArgs());
        }
    }
}
