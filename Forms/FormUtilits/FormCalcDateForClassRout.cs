using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test1.Forms
{
    public partial class FormCalcDateForClassRout : Form
    {
        public bool isClose = true;
        public string JSON = "";

        public FormCalcDateForClassRout()
        {
            InitializeComponent();
        }

        bool CorrectNumber(string str1, string str2)
        {
            var rez1 = double.Parse(str1);
            var rez2 = double.Parse(str2);

            return rez1 <= rez2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrWhiteSpace(textBox1.Text) && String.IsNullOrWhiteSpace(textBox1.Text) && String.IsNullOrWhiteSpace(textBox1.Text) && String.IsNullOrWhiteSpace(textBox1.Text) && String.IsNullOrWhiteSpace(textBox1.Text) && 
               String.IsNullOrWhiteSpace(textBox1.Text) && String.IsNullOrWhiteSpace(textBox1.Text) && String.IsNullOrWhiteSpace(textBox1.Text) && String.IsNullOrWhiteSpace(textBox1.Text) && String.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show(this, "Не заполнено ни одно из полей!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!CorrectNumber(textBox1.Text, textBox2.Text) || !CorrectNumber(textBox1.Text, textBox2.Text) || !CorrectNumber(textBox1.Text, textBox2.Text) || !CorrectNumber(textBox1.Text, textBox2.Text) || !CorrectNumber(textBox1.Text, textBox2.Text))
            {
                MessageBox.Show(this, "Одно из полей заполнено не корректно", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Test1.Code.DayOfWeek classTransport = new Code.DayOfWeek();

            classTransport.SC = new List<double>
            {
                double.Parse(textBox1.Text == "" ? "0" : textBox1.Text),
                double.Parse(textBox2.Text == "" ? "0" : textBox2.Text)
            };

            classTransport.MC = new List<double>
            {
                double.Parse(textBox4.Text == "" ? "0" : textBox4.Text),
                double.Parse(textBox3.Text == "" ? "0" : textBox3.Text)
            };

            classTransport.LC = new List<double>
            {
                double.Parse(textBox6.Text == "" ? "0" : textBox6.Text),
                double.Parse(textBox5.Text == "" ? "0" : textBox5.Text)
            };

            classTransport.ESC = new List<double>
            {
                double.Parse(textBox8.Text == "" ? "0" : textBox8.Text),
                double.Parse(textBox7.Text == "" ? "0" : textBox7.Text)
            };

            classTransport.ELC = new List<double>
            {
                double.Parse(textBox10.Text == "" ? "0" : textBox10.Text),
                double.Parse(textBox9.Text == "" ? "0" : textBox9.Text)
            };

            JSON = JsonConvert.SerializeObject(classTransport);

            isClose = false;
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var index = textBox1.Text.IndexOf(',');
            int endstr = textBox1.Text.Length;
            int len = textBox1.Text.Length;

            if(index != -1)
            {
                endstr = index;
            }

            if(endstr >= 3)
            {
                textBox1.Text = textBox1.Text.Remove(endstr - 1, 1);
                textBox1.SelectionStart = textBox1.Text.Length;
                MessageBox.Show(this,"Нельзя вводить больше 99!", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (index != -1 && !(index == len - 3 || index == len - 2 || index == len - 1))
            {
                textBox1.Text = textBox1.Text.Remove(len - 1, 1);
                textBox1.SelectionStart = textBox1.Text.Length;
                MessageBox.Show(this, "Нельзя вводить больше 99!", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }        
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            var index = textBox2.Text.IndexOf(',');
            int len = textBox2.Text.Length;

            if (index != -1 && !(index == len - 3 || index == len - 2 || index == len - 1))
            {
                textBox2.Text = textBox2.Text.Remove(len - 1, 1);
                textBox2.SelectionStart = textBox2.Text.Length;
                MessageBox.Show(this, "Нельзя вводить больше 99!", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                checkBox1.Checked = true;
                checkBox2.Checked = true;
                checkBox3.Checked = true;
                checkBox4.Checked = true;
                checkBox5.Checked = true;
                checkBox6.Checked = true;
                checkBox7.Checked = true;

                radioButton2.Checked = false;
                radioButton3.Checked = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                checkBox1.Checked = true;
                checkBox2.Checked = true;
                checkBox3.Checked = true;
                checkBox4.Checked = true;
                checkBox5.Checked = true;
                checkBox6.Checked = false;
                checkBox7.Checked = false;

                radioButton1.Checked = false;
                radioButton3.Checked = false;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = true;
                checkBox7.Checked = true;

                radioButton1.Checked = false;
                radioButton2.Checked = false;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            var index = textBox4.Text.IndexOf(',');
            int endstr = textBox4.Text.Length;
            int len = textBox4.Text.Length;

            if (index != -1)
            {
                endstr = index;
            }

            if (endstr >= 3)
            {
                textBox4.Text = textBox4.Text.Remove(endstr - 1, 1);
                textBox4.SelectionStart = textBox4.Text.Length;
                MessageBox.Show(this, "Нельзя вводить больше 99!", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (index != -1 && !(index == len - 3 || index == len - 2 || index == len - 1))
            {
                textBox4.Text = textBox4.Text.Remove(len - 1, 1);
                textBox4.SelectionStart = textBox4.Text.Length;
                MessageBox.Show(this, "Нельзя вводить больше 99!", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

            var index = textBox6.Text.IndexOf(',');
            int endstr = textBox6.Text.Length;
            int len = textBox6.Text.Length;

            if (index != -1)
            {
                endstr = index;
            }

            if (endstr >= 3)
            {
                textBox6.Text = textBox6.Text.Remove(endstr - 1, 1);
                textBox6.SelectionStart = textBox6.Text.Length;
                MessageBox.Show(this, "Нельзя вводить больше 99!", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (index != -1 && !(index == len - 3 || index == len - 2 || index == len - 1))
            {
                textBox6.Text = textBox6.Text.Remove(len - 1, 1);
                textBox6.SelectionStart = textBox6.Text.Length;
                MessageBox.Show(this, "Нельзя вводить больше 99!", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            var index = textBox8.Text.IndexOf(',');
            int endstr = textBox8.Text.Length;
            int len = textBox8.Text.Length;

            if (index != -1)
            {
                endstr = index;
            }

            if (endstr >= 3)
            {
                textBox8.Text = textBox8.Text.Remove(endstr - 1, 1);
                textBox8.SelectionStart = textBox8.Text.Length;
                MessageBox.Show(this, "Нельзя вводить больше 99!", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (index != -1 && !(index == len - 3 || index == len - 2 || index == len - 1))
            {
                textBox8.Text = textBox8.Text.Remove(len - 1, 1);
                textBox8.SelectionStart = textBox8.Text.Length;
                MessageBox.Show(this, "Нельзя вводить больше 99!", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

            var index = textBox10.Text.IndexOf(',');
            int endstr = textBox10.Text.Length;
            int len = textBox10.Text.Length;

            if (index != -1)
            {
                endstr = index;
            }

            if (endstr >= 3)
            {
                textBox10.Text = textBox10.Text.Remove(endstr - 1, 1);
                textBox10.SelectionStart = textBox10.Text.Length;
                MessageBox.Show(this, "Нельзя вводить больше 99!", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (index != -1 && !(index == len - 3 || index == len - 2 || index == len - 1))
            {
                textBox10.Text = textBox10.Text.Remove(len - 1, 1);
                textBox10.SelectionStart = textBox10.Text.Length;
                MessageBox.Show(this, "Нельзя вводить больше 99!", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            var index = textBox3.Text.IndexOf(',');
            int len = textBox3.Text.Length;

            if (index != -1 && !(index == len - 3 || index == len - 2 || index == len - 1))
            {
                textBox3.Text = textBox3.Text.Remove(len - 1, 1);
                textBox3.SelectionStart = textBox3.Text.Length;
                MessageBox.Show(this, "Нельзя вводить больше 99!", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            var index = textBox5.Text.IndexOf(',');
            int len = textBox5.Text.Length;

            if (index != -1 && !(index == len - 3 || index == len - 2 || index == len - 1))
            {
                textBox5.Text = textBox5.Text.Remove(len - 1, 1);
                textBox5.SelectionStart = textBox5.Text.Length;
                MessageBox.Show(this, "Нельзя вводить больше 99!", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            var index = textBox7.Text.IndexOf(',');
            int len = textBox7.Text.Length;

            if (index != -1 && !(index == len - 3 || index == len - 2 || index == len - 1))
            {
                textBox7.Text = textBox7.Text.Remove(len - 1, 1);
                textBox7.SelectionStart = textBox7.Text.Length;
                MessageBox.Show(this, "Нельзя вводить больше 99!", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            var index = textBox9.Text.IndexOf(',');
            int len = textBox9.Text.Length;

            if (index != -1 && !(index == len - 3 || index == len - 2 || index == len - 1))
            {
                textBox9.Text = textBox9.Text.Remove(len - 1, 1);
                textBox9.SelectionStart = textBox9.Text.Length;
                MessageBox.Show(this, "Нельзя вводить больше 99!", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Dont_enter_char(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == ',')
                return;
            else if (e.KeyChar == 8)
                return;
            else if(e.KeyChar == 13)
            {
                e.Handled = true;
                SelectNextControl(ActiveControl, true, true, true, true);
            }
            else e.Handled = true;
        }
    }
}
