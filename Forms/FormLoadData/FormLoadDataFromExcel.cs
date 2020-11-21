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
using Excel = Microsoft.Office.Interop.Excel;

namespace Test1.Forms
{
    struct Data
    {
        public string contract;
        public int number;
        public string poryd;
        public string name;
        public string type_soob;
    }

    public partial class FormLoadDataFromExcel : Form
    {
        List<Data> datas;
        public FormLoadDataFromExcel()
        {
            InitializeComponent();
            datas = new List<Data>();
        }

        string ReApContract(string str)
        {
            char[] del = { '-', '/' };
            var rez = str.Split(del);
            return rez[0] + "-" + rez[1] + "/" + rez[2];
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

            Excel.Worksheet ObjWorkSheet = (Excel.Worksheet)ObjWorkBook.Sheets[12]; //получить 1-й лист
            var lastCell = ObjWorkSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell);//последнюю ячейку
            // размеры базы
            int lastColumn = (int)lastCell.Column;
            int lastRow = (int)lastCell.Row;
            progressBar1.PerformStep();
            dataGridView1.Columns.Add("Contract","Договор");
            dataGridView1.Columns.Add("colum1", "Реестр");
            dataGridView1.Columns.Add("colum2", "Порядок");
            dataGridView1.Columns.Add("colum3", "Наименование");
            dataGridView1.Columns.Add("colum4", "тип сообщение");
            Data data = new Data();

            progressBar1.Maximum = lastRow * 10;

            for (int i = 6; i < lastRow; i++)
            {
                data.contract = ObjWorkSheet.Cells[i + 1, 1].Text.ToString();
                var number = ObjWorkSheet.Cells[i + 1, 2].Text.ToString();
                data.poryd = ObjWorkSheet.Cells[i + 1, 3].Text.ToString();
                data.name = ObjWorkSheet.Cells[i + 1, 4].Text.ToString();
                data.type_soob = ObjWorkSheet.Cells[i + 1, 5].Text.ToString();

                if (!String.IsNullOrEmpty(data.contract))
                    data.contract = ReApContract(data.contract);

                if (String.IsNullOrWhiteSpace(number))
                    continue;

                data.number = int.Parse(number);

                dataGridView1.Rows.Add(data.contract, data.number, data.poryd, data.name, data.type_soob);
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
            using (SqlConnection connect = new SqlConnection(StaticValues.ConnectionString))
            {
                string exp;
                SqlCommand com = new SqlCommand();
                com.Connection = connect;
                connect.Open();
                foreach (var item in datas)
                {
                    int id_contract = -1;
                    if(!String.IsNullOrEmpty(item.contract))
                    {
                        exp = $"SELECT ID FROM Договор WHERE Номер_Договора = '{item.contract}'";
                        com.CommandText = exp;
                        var rez_str = com.ExecuteScalar();

                        if (rez_str == null)
                        {
                            exp = $"INSERT INTO Договор (Номер_Договора, Дата_начала, Дата_окончания) VALUES('{item.contract}', '2020-01-01', '2020-12-31'); SELECT max(ID) From Договор;";
                            com.CommandText = exp;
                            id_contract = (int)com.ExecuteScalar();
                        }
                        else id_contract = (int)rez_str;
                    }

                    exp = $"INSERT INTO Маршрут VALUES ({7601000+item.number}, 1, '{item.poryd}', 'РТ', 'УОП', '{item.name}', '{item.type_soob}')";
                    com.CommandText = exp;
                    var rez = com.ExecuteNonQuery();

                    if (rez == 0)
                        System.Diagnostics.Debug.WriteLine(item.number);

                    if(id_contract != -1)
                    {
                        exp = $"INSERT INTO Rout_Contract Values ({7601000 + item.number}, {id_contract})";
                        com.CommandText = exp;
                        com.ExecuteNonQuery();
                    }
                }
            }               
        }
    }
}
