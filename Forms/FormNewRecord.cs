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
    public partial class FormNewRecord : Form
    {
        public FormNewRecord(int ID_Nomber, int ID_Hist)
        {
            InitializeComponent();

            comboBox2.SelectedIndex = 0;

            textBox1.Text = (ID_Nomber).ToString();
            textBox2.Text = (ID_Hist).ToString();

            using(SqlConnection connect = new SqlConnection(StaticValues.ConnectionString))
            {
                string sqlCom = "SELECT [ID] FROM Маршрут GROUP BY ID";
                SqlCommand com = new SqlCommand(sqlCom, connect);
                connect.Open();
                var rez = com.ExecuteReader();

                if (rez.HasRows)
                {
                    while(rez.Read())
                    {
                        comboBox1.Items.Add(rez.GetInt32(0));
                    }
                }
            }
            DateTime date = DateTime.Now;

            dateTimePicker1.Value = new DateTime(date.Year, 1, 1);
            dateTimePicker2.Value = new DateTime(date.Year, 12, 31);

            comboBox1.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormCalcDateForClass calcDateForClass = new FormCalcDateForClass();
            calcDateForClass.ShowDialog();

            if(!calcDateForClass.isClose)
            {
                textBox4.Text = calcDateForClass.JSON;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormCalcDateForClass calcDateForClass = new FormCalcDateForClass();
            calcDateForClass.ShowDialog();

            if (!calcDateForClass.isClose)
            {
                textBox5.Text = calcDateForClass.JSON;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormCalcDateForClass calcDateForClass = new FormCalcDateForClass();
            calcDateForClass.ShowDialog();

            if (!calcDateForClass.isClose)
            {
                textBox6.Text = calcDateForClass.JSON;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormCalcDateForClass calcDateForClass = new FormCalcDateForClass();
            calcDateForClass.ShowDialog();

            if (!calcDateForClass.isClose)
            {
                textBox7.Text = calcDateForClass.JSON;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FormCalcDateForClass calcDateForClass = new FormCalcDateForClass();
            calcDateForClass.ShowDialog();

            if (!calcDateForClass.isClose)
            {
                textBox8.Text = calcDateForClass.JSON;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FormCalcDateForClass calcDateForClass = new FormCalcDateForClass();
            calcDateForClass.ShowDialog();

            if (!calcDateForClass.isClose)
            {
                textBox9.Text = calcDateForClass.JSON;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FormCalcDateForClass calcDateForClass = new FormCalcDateForClass();
            calcDateForClass.ShowDialog();

            if (!calcDateForClass.isClose)
            {
                textBox10.Text = calcDateForClass.JSON;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            FormCalcDateForClass calcDateForClass = new FormCalcDateForClass();
            calcDateForClass.ShowDialog();

            if (!calcDateForClass.isClose)
            {
                textBox11.Text = calcDateForClass.JSON;
            }
        }
    }
}
