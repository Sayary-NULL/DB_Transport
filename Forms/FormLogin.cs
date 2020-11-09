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

namespace Test1.Forms
{
    public partial class FormLogin : Form
    {
        public bool Logged = false;

        public FormLogin()
        {
            InitializeComponent();
            if(Settings1.Default.EnableSaveLogin)
            {
                tbLogin.Text = Settings1.Default.Login;
                tbPass.Text = Settings1.Default.Password;
                tbIP.Text = Settings1.Default.Adress;
                checkBox1.Checked = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = String.Format(Test1.DB_Resource.StrConnection, tbIP.Text, tbLogin.Text, tbPass.Text);

            using(SqlConnection connect = new SqlConnection(str))
            {
                try
                {
                    connect.Open();
                    Logged = true;
                    Test1.Code.StaticValues.IPAdress = tbIP.Text;
                    Test1.Code.StaticValues.Login = tbLogin.Text;
                    Test1.Code.StaticValues.Password = tbPass.Text;

                    if(checkBox1.Checked)
                    {
                        //MessageBox.Show(this, "Лучший способ сохранить это записать, записывайте, я подожду.", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        Settings1.Default.Login = tbLogin.Text;
                        Settings1.Default.Password = tbPass.Text;
                        Settings1.Default.Adress = tbIP.Text;
                        Settings1.Default.EnableSaveLogin = true;
                    }
                    else Settings1.Default.EnableSaveLogin = false;
                    Settings1.Default.Save();

                    this.Close();
                }
                catch
                {
                    MessageBox.Show(this, "Ошибка IP адресса или Имя пользователя или Пароля", "Ошибка входа", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void tbIP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                tbLogin.Focus();
            }
        }

        private void tbLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                tbPass.Focus();
            }
        }

        private void tbPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                button1_Click(sender, new EventArgs());
            }
        }
    }
}
