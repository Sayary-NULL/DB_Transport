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
                    this.Close();
                }
                catch
                {
                    MessageBox.Show(this, "Ошибка IP адресса или Имя пользователя или Пароля", "Ошибка входа", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
