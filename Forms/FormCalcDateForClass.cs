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
    public partial class FormCalcDateForClass : Form
    {
        public bool isClose = true;
        public string JSON = "";

        public FormCalcDateForClass()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Test1.Code.DayOfWeek classTransport = new Code.DayOfWeek();

            classTransport.SC = new List<double>();
            classTransport.SC.Add((int)numericUpDown1.Value);
            classTransport.SC.Add((int)numericUpDown2.Value);

            classTransport.MC = new List<double>();
            classTransport.MC.Add((int)numericUpDown3.Value);
            classTransport.MC.Add((int)numericUpDown4.Value);

            classTransport.LC = new List<double>();
            classTransport.LC.Add((int)numericUpDown5.Value);
            classTransport.LC.Add((int)numericUpDown6.Value);

            classTransport.ESC = new List<double>();
            classTransport.ESC.Add((int)numericUpDown7.Value);
            classTransport.ESC.Add((int)numericUpDown8.Value);

            classTransport.ELC = new List<double>();
            classTransport.ELC.Add((int)numericUpDown9.Value);
            classTransport.ELC.Add((int)numericUpDown10.Value);

            JSON = JsonConvert.SerializeObject(classTransport);

            isClose = false;
            this.Close();
        }
    }
}
