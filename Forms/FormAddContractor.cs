using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Test1.Code;

namespace Test1.Forms
{
    public partial class FormAddContractor : Form
    {
        public FormAddContractor()
        {
            InitializeComponent();
            label3.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show(this, "Поле \"Наименование\" должно быть заполнено!", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            SqlParameter inn = new SqlParameter 
            {
                ParameterName = "@inn",
                Value = Int64.Parse(textBox1.Text),
                SqlDbType = System.Data.SqlDbType.BigInt
            };

            SqlParameter name = new SqlParameter("@name", textBox2.Text);
            SqlParameter mesto = new SqlParameter("@mesto", null);
            SqlParameter fio = new SqlParameter("@fio", "NULL");

            if (radioButton1.Checked)
            {
                mesto.Value = textBox3.Text;
            }
            else fio.Value = textBox3.Text;

            SqlCommand com = new SqlCommand("INSERT INTO Подрядчик (ИНН, Наименование, Место_Нахождение, ФИО) VALUES (@inn, @name, @mesto, @fio)");
            com.Parameters.Add(inn);
            com.Parameters.Add(mesto);
            com.Parameters.Add(name);
            com.Parameters.Add(fio);

            using (SqlConnection connection = new SqlConnection(StaticValues.ConnectionString))
            {
                connection.Open();
                com.Connection = connection;
                var rez = com.ExecuteNonQuery();
                if(rez == 1)
                {
                    MessageBox.Show(this, "Ok");
                    this.Close();
                }
                else
                {
                    MessageBox.Show(this, "Error");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label3.Text = "Место нахождения";
            textBox3.ReadOnly = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label3.Text = "ФИО";
            textBox3.ReadOnly = false;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (!Int64.TryParse(textBox1.Text, out _))
            {
                MessageBox.Show(this, "Строка ИНН должен содержать только цифры!");
                textBox1.Focus();
                return;
            }

            if(textBox1.Text.Length != 10 && textBox1.Text.Length != 12)
            {
                MessageBox.Show(this, "Строка ИНН должен состоять из 10 или 12 символов!");
                textBox1.Focus();
                return;
            }
        }

        private void FormAddContractor_SizeChanged(object sender, EventArgs e)
        {
            int x = this.Size.Width;
            x -= 2 * 20;
            textBox1.Size = new Size(x, 20);
            textBox2.Size = new Size(x, 20);
            textBox3.Size = new Size(x, 20);

            x = this.Size.Width/2;
            var loc = groupBox1.Location;
            groupBox1.Location = new Point(x - 65, loc.Y);
            loc = button1.Location;
            button1.Location = new Point(x - 45, loc.Y);
            loc = button2.Location;
            button2.Location = new Point(x - 45, loc.Y);
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if(!radioButton1.Checked && !radioButton2.Checked)
                this.ActiveControl = null;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                groupBox1.Focus();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(textBox3.Text))
            {
                button1.Enabled = true;
            }
            else button1.Enabled = false;

            var len = textBox3.Text.Length;
            if (len > 100)
            {
                textBox3.Text = textBox3.Text.Remove(len - 1);
                textBox3.SelectionStart = len - 1;
                len--;
            }

            label5.Text = $"({len}/100 символов)";
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                button1_Click(sender, e);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            var len = textBox2.Text.Length;
            if (len > 100)
            {
                textBox2.Text = textBox2.Text.Remove(len-1);
                textBox2.SelectionStart = len - 1;
                len--;
            }

            label4.Text = $"({len}/100 символов)";
        }
    }
}
