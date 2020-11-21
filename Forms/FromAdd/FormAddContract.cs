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
    public partial class FormAddContract : Form
    {
        public FormAddContract()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var contractor = new FormSearchConractor();
            contractor.ShowDialog();

            if(contractor.Selected)
            {
                textBox2.Text = contractor.INN;
                textBox3.Text = contractor.Name;
                button4.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show(this, "Поле \"Номер договора\" должно быть заполнено", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SqlParameter number = new SqlParameter("@number", textBox1.Text);
            SqlParameter with = new SqlParameter("@with", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
            SqlParameter by = new SqlParameter("@by", dateTimePicker2.Value.ToString("yyyy-MM-dd"));
            SqlParameter inn = new SqlParameter
            {
                ParameterName = "@inn",
                Value = Int64.Parse(textBox2.Text),
                SqlDbType = SqlDbType.BigInt
            };

            SqlCommand com1 = new SqlCommand();
            com1.Parameters.Add(number);
            com1.Parameters.Add(with);
            com1.Parameters.Add(by);
            com1.Parameters.Add(inn);

            using (SqlConnection connection = new SqlConnection(StaticValues.ConnectionString))
            {
                connection.Open();
                
                SqlCommand com = new SqlCommand("Select max(Id) from Договор", connection);
                var id = (int)com.ExecuteScalar()+1;
                com1.CommandText = $"INSERT INTO Договор ([ID] ,[Номер_Договора] ,[Дата_начала] ,[Дата_окончания] ,[Цена] ,[ИНН_Подрядчика]) VALUES ({id},@number, @with, @by, 0, @inn)";
                com1.Connection = connection;

                var rez = (int)com1.ExecuteNonQuery();
                if (rez == 1)
                {
                    this.Close();
                }
                else MessageBox.Show("No");
            }

        }
    }
}
