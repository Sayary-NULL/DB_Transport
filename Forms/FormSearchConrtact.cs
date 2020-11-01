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
    public partial class FormSearchConrtact : Form
    {
        private List<Contract> Contracts;

        public string ID;
        public string Number;
        public bool IsSelected = false;

        public FormSearchConrtact()
        {
            InitializeComponent();
            Contracts = new List<Contract>();
            LoadComboBox();
        }

        public void LoadComboBox()
        {
            using (SqlConnection connection = new SqlConnection(StaticValues.ConnectionString))
            {
                SqlCommand com = new SqlCommand("SELECT * FROM Договор", connection);
                connection.Open();

                var rez = com.ExecuteReader();
                if (rez.HasRows)
                {
                    while (rez.Read())
                    {
                        var con = new Contract();
                        con.ID = rez.GetInt32(0);
                        con.Nomber_Contract = rez.GetString(1);
                        con.With = rez.GetDateTime(2);
                        con.By = rez.GetDateTime(3);
                        con.INN = rez.GetInt64(5);

                        dataGridView1.Rows.Add(con.ID, con.Nomber_Contract, con.With.ToString("dd.MM.yyyyy"), con.By.ToString("dd.MM.yyyyy"), con.INN);
                        Contracts.Add(con);
                        comboBox1.Items.Add(con.Nomber_Contract);
                        comboBox2.Items.Add(con.INN);
                    }
                }
            }
        }

        private void comboBox1_TextUpdate(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            var text = comboBox1.Text;
            foreach (var item in Contracts)
            {
                if (item.Nomber_Contract.StartsWith(text) || String.IsNullOrWhiteSpace(text) || String.IsNullOrEmpty(text))
                    comboBox1.Items.Add(item.Nomber_Contract);
            }
            comboBox1.SelectionStart = comboBox1.Text.Length;
            comboBox1.DroppedDown = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrWhiteSpace(comboBox1.Text) && String.IsNullOrWhiteSpace(comboBox1.Text))
            {
                MessageBox.Show(this, "Одно или несколько полей должно быть заполнено!");
                return;
            }
            dataGridView1.Rows.Clear();
            bool isCom1 = false;
            bool isCom2 = false;

            foreach (var item in Contracts)
            {
                isCom1 = false;
                isCom2 = false;

                if (!String.IsNullOrWhiteSpace(comboBox1.Text))
                {
                    if (item.Nomber_Contract.StartsWith(comboBox1.Text))
                        isCom1 = true;
                }
                else isCom1 = true;

                if (!String.IsNullOrWhiteSpace(comboBox2.Text))
                {
                    if (item.INN.ToString().StartsWith(comboBox2.Text))
                        isCom2 = true;
                }
                else isCom2 = true;

                if(isCom1 && isCom2)
                    dataGridView1.Rows.Add(item.ID, item.Nomber_Contract, item.With.ToString("dd.MM.yyyyy"), item.By.ToString("dd.MM.yyyyy"), item.INN);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 1)
            {
                for (int i = 1; i < dataGridView1.SelectedRows.Count; i++)
                    dataGridView1.SelectedRows[i].Selected = false;
            }
        }

        private void comboBox1_Enter(object sender, EventArgs e)
        {
            comboBox1.DroppedDown = true;
        }

        private void comboBox2_TextUpdate(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            var text = comboBox2.Text;
            foreach (var item in Contracts)
            {
                if (item.INN.ToString().StartsWith(text) || String.IsNullOrWhiteSpace(text) || String.IsNullOrEmpty(text))
                    comboBox2.Items.Add(item.INN);
            }
            comboBox2.SelectionStart = comboBox2.Text.Length;
            comboBox2.DroppedDown = true;
        }

        private void comboBox2_Enter(object sender, EventArgs e)
        {
            comboBox2.DroppedDown = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ID = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            Number = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            IsSelected = true;
            this.Close();
        }
    }
}
