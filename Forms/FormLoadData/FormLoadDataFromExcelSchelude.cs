using Newtonsoft.Json;
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
using Excel = Microsoft.Office.Interop.Excel;

namespace Test1.Forms
{
    public partial class FormLoadDataFromExcelSchelude : Form
    {
        struct DataSchelude
        {
            public int number;
            public string Por;
            public string Name;
            public double len;
            public string[] Json;
            public string day;
        }

        List<DataSchelude> datas;
        public FormLoadDataFromExcelSchelude()
        {
            InitializeComponent();
            datas = new List<DataSchelude>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.DefaultExt = "*.xls;*.xlsx";
            openFileDialog1.Title = "Открыть файл";
            openFileDialog1.Filter = "Excel (*.xlsx)|*.xlsx";
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;

            Excel.Application ObjWorkExcel = new Excel.Application();
            Excel.Workbook ObjWorkBook = ObjWorkExcel.Workbooks.Open(openFileDialog1.FileName);

            Excel.Worksheet ObjWorkSheet = (Excel.Worksheet)ObjWorkBook.Sheets[1]; //получить 1-й лист
            var lastCell = ObjWorkSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell);//последнюю ячейку
            // размеры базы
            int lastColumn = (int)lastCell.Column;
            int lastRow = (int)lastCell.Row;

            dataGridView1.Columns.Add("colum1", "Реестр");
            dataGridView1.Columns.Add("colum2", "Порядок");
            dataGridView1.Columns.Add("colum3", "Наименование");
            dataGridView1.Columns.Add("colum4", "1");
            dataGridView1.Columns.Add("colum4", "2");

            DataSchelude data = new DataSchelude();

            progressBar1.Maximum = lastRow * 10;

            for (int i = 6; i < lastRow; i++)
            {
                var number = ObjWorkSheet.Cells[i + 1, 2].Text.ToString();
                data.Por = (ObjWorkSheet.Cells[i + 1, 3] as Excel.Range).Text;
                data.Name = (ObjWorkSheet.Cells[i + 1, 4] as Excel.Range).Text;
                data.len = (ObjWorkSheet.Cells[i + 1, 6] as Excel.Range).Value;
                data.Json = new string[7];

                if (number == "") continue;

                data.number = int.Parse(number);

                var day = new Test1.Code.DayOfWeek
                {
                    SC = new List<double>() { 0,0 },
                    MC = new List<double>() { 0, 0 },
                    LC = new List<double>() { 0, 0 },
                    ESC = new List<double>() { 0, 0 },
                    ELC = new List<double>() { 0, 0 }
                };

                data.day = "";
                for (int j = 0; j < 7; j++)
                {
                    bool isFlag = false;
                    var str1 = (ObjWorkSheet.Cells[i + 1, 9 + j * 4 + 0] as Excel.Range).Value;
                    var str2 = (ObjWorkSheet.Cells[i + 1, 9 + j * 4 + 1] as Excel.Range).Value;
                    var str3 = (ObjWorkSheet.Cells[i + 1, 9 + j * 4 + 2] as Excel.Range).Value;
                    var str4 = (ObjWorkSheet.Cells[i + 1, 9 + j * 4 + 3] as Excel.Range).Value;

                    var str21 = (ObjWorkSheet.Cells[i + 1, 9 + 4 * 7 + j * 4 + 0] as Excel.Range).Value;
                    var str22 = (ObjWorkSheet.Cells[i + 1, 9 + 4 * 7 + j * 4 + 1] as Excel.Range).Value;
                    var str23 = (ObjWorkSheet.Cells[i + 1, 9 + 4 * 7 + j * 4 + 2] as Excel.Range).Value;
                    var str24 = (ObjWorkSheet.Cells[i + 1, 9 + 4 * 7 + j * 4 + 3] as Excel.Range).Value;

                    if (str1 != null && str21 != null)
                    {
                        day.LC[0] = str1;
                        day.LC[1] = str21;
                        isFlag = true;
                    }
                    if (str2 != null && str22 != null)
                    {
                        day.MC[0] = str2;
                        day.MC[1] = str22;
                        isFlag = true;
                    }
                    if (str3 != null && str23 != null)
                    {
                        day.SC[0] = str3;
                        day.SC[1] = str23;
                        isFlag = true;
                    }
                    if (str4 != null && str24 != null)
                    {
                        day.ESC[0] = str4;
                        day.ESC[1] = str24;
                        isFlag = true;
                    }

                    if (isFlag)
                    {
                        data.day += $"{j + 1},";
                        data.Json[j] = JsonConvert.SerializeObject(day);
                    }
                }

                if(data.day != "")
                    data.day = data.day.Remove(data.day.Length - 1);

                dataGridView1.Rows.Add(data.number, data.Por, data.Name, data.len, data.Json[0]);
                datas.Add(data);
                progressBar1.PerformStep();
            }

            ObjWorkBook.Close(false, Type.Missing, Type.Missing); //закрыть не сохраняя
            ObjWorkExcel.Quit(); // выйти из Excel
            GC.Collect(); // убрать за собой
            progressBar1.Value = progressBar1.Maximum;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection connect = new SqlConnection(Code.StaticValues.ConnectionString))
            {
                SqlCommand com = new SqlCommand();
                com.Connection = connect;
                string str = "", str2 = "";
                connect.Open();

                foreach (var item in datas)
                {
                    str = $"INSERT INTO Вариант_рейса VALUES({7601000 + item.number}, 1, 1, {Math.Round(item.len / 2, 2).ToString().Replace(',', '.')}, 'прямой', '{item.Json[0]}', '{item.Json[1]}', '{item.Json[2]}', '{item.Json[3]}', '{item.Json[4]}', '{item.Json[5]}', '{item.Json[6]}', '', '2020-04-15', '2020-10-15', '{item.day}')";
                    str2 = $"INSERT INTO Вариант_рейса VALUES({7601000 + item.number}, 2, 1, {Math.Round(item.len / 2, 2).ToString().Replace(',', '.')}, 'обратный', '{item.Json[0]}', '{item.Json[1]}', '{item.Json[2]}', '{item.Json[3]}', '{item.Json[4]}', '{item.Json[5]}', '{item.Json[6]}','', '2020-04-15', '2020-10-15', '{item.day}')";
                    com.CommandText = str;
                    _ = com.ExecuteNonQuery();
                    com.CommandText = str2;
                    _ = com.ExecuteNonQuery();
                }
            }

            MessageBox.Show(this, "OK");
        }
    }
}
