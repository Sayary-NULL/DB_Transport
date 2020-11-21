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
    public partial class FormSearchConractor : Form
    {
        private List<string> INNs;

        public bool Selected = false;
        public string INN = "";
        public string Name = "";

        public FormSearchConractor()
        {
            InitializeComponent();
            INNs = new List<string>();
            LoadComboBox();
        }

        public void LoadComboBox()
        {
            using(SqlConnection connection = new SqlConnection(StaticValues.ConnectionString))
            {
                SqlCommand com = new SqlCommand("SELECT ИНН FROM Подрядчик GROUP BY ИНН", connection);
                connection.Open();

                var rez = com.ExecuteReader();
                if(rez.HasRows)
                {
                    while(rez.Read())
                    {
                        comboBox1.Items.Add(rez.GetValue(0));
                        INNs.Add(rez.GetValue(0).ToString());
                    }
                }
            }
        }

        private void comboBox1_TextUpdate(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            var text = comboBox1.Text;
            foreach (var item in INNs)
            {
                if (item.StartsWith(text) || String.IsNullOrWhiteSpace(text))
                    comboBox1.Items.Add(item);
            }
            comboBox1.SelectionStart = comboBox1.Text.Length;
            comboBox1.DroppedDown = true;
        }

        private void comboBox1_Enter(object sender, EventArgs e)
        {
            comboBox1.DroppedDown = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string exp = "SELECT * FROM Подрядчик ";
            SqlCommand com = new SqlCommand();

            if (!String.IsNullOrWhiteSpace(comboBox1.Text))
            {
                SqlParameter INN = new SqlParameter("@INN", comboBox1.Text);
                com.Parameters.Add(INN);

                exp += "WHERE ИНН = @INN ";
            }

            if(!String.IsNullOrWhiteSpace(textBox1.Text))
            {
                SqlParameter Name = new SqlParameter("@Name", "%" + textBox1.Text + "%");
                com.Parameters.Add(Name);

                if (String.IsNullOrWhiteSpace(comboBox1.Text))
                    exp += "WHERE ";
                else exp += "OR ";

                exp += "Наименование LIKE @Name";
            }

            using (SqlConnection connection = new SqlConnection(StaticValues.ConnectionString))
            {
                com.Connection = connection;
                com.CommandText = exp;
                connection.Open();

                var rez = com.ExecuteReader();

                if(rez.HasRows)
                {
                    
                    while(rez.Read())
                    {
                        dataGridView1.Rows.Add(rez.GetValue(0), rez.GetValue(1), rez.GetValue(2), rez.GetValue(3));
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 1 || dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберете одну запись");
                return;
            }

            INN = dataGridView1.SelectedCells[0].Value.ToString();
            Name = dataGridView1.SelectedCells[1].Value.ToString();
            Selected = true;
            this.Close();
        }
    }
}
