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
using System.Windows.Interop;
using Test1.Code;

namespace Test1.Forms
{
    public partial class FormMain : Form
    {
        bool sized = false;

        private List<Schedule> Schedules;

        private List<Rout> Routs;

        private List<Contract> Contracts;

        private List<Contractor> Contractors;

        ComboBox comboBoxID_SCH;

        //DataGridView dataGrid;

        public FormMain()
        {
            InitializeComponent();
            InitializeComponents();

            Schedules = new List<Test1.Code.Schedule>();
            Routs = new List<Rout>();
            Contracts = new List<Contract>();
            Contractors = new List<Contractor>();

            LNameDataGrid.Text = "";
            LoadGridRout();
        }

        private void LoadComboBox()
        {
            comboBoxID_SCH.Items.Add("All");
            using (SqlConnection connect = new SqlConnection(String.Format(Test1.DB_Resource.StrConnection, Test1.Code.StaticValues.IPAdress, Test1.Code.StaticValues.Login, Test1.Code.StaticValues.Password)))
            {
                SqlCommand com = new SqlCommand("SELECT ID From Маршрут GROUP BY ID", connect);
                connect.Open();
                var rez = com.ExecuteReader();

                if(rez.HasRows)
                {
                    while (rez.Read())
                        comboBoxID_SCH.Items.Add(rez.GetInt32(0));
                }
            }
            comboBoxID_SCH.SelectedIndex = 0;
        }

        private void InitializeComponents()
        {
            comboBoxID_SCH = new ComboBox();
            /*comboBoxID_SCH.Top = 25;
            comboBoxID_SCH.Left = 15;
            comboBoxID_SCH.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxID_SCH.SelectedValueChanged += ChangeComboBox;
            this.Controls.Add(comboBoxID_SCH);*/
        }

        private void FormMain_SizeChanged(object sender, EventArgs e)
        {
            if(!sized)
            {
                this.MaximumSize = this.MinimumSize = this.Size;
                sized = true;
            }
        }

        private void расчитатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Test1.Forms.FormPrilo3 formPrilo3 = new Test1.Forms.FormPrilo3(Schedules);
            formPrilo3.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Font fon = dGWMain.ColumnHeadersDefaultCellStyle.Font;
            dGWMain.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", fon.Size + 1);

            fon = dGWMain.RowsDefaultCellStyle.Font;
            if (fon == null)
                fon = new Font("Microsoft Sans Serif", 8);
            dGWMain.RowsDefaultCellStyle.Font = new Font("Microsoft Sans Serif", fon.Size + 1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Font fon = dGWMain.ColumnHeadersDefaultCellStyle.Font;
            dGWMain.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", fon.Size - 1);

            fon = dGWMain.RowsDefaultCellStyle.Font;
            if (fon == null)
                fon = new Font("Microsoft Sans Serif", 8);
            dGWMain.RowsDefaultCellStyle.Font = new Font("Microsoft Sans Serif", fon.Size - 1);
        }

        private void добавитьЗаписьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (comboBoxID_SCH.SelectedIndex != 0)
            {
                int ID_NUM = 0;
                int ID_HIS = 1;
                if (Schedules.Count() != 0)
                {
                    ID_NUM = Schedules.Last().ID_Number_Schedule;
                    ID_HIS = Schedules.Last().ID_History;
                }
                
                FormNewRecord formComp = new FormNewRecord(ID_NUM, ID_HIS);
                formComp.ShowDialog();
            }
            else MessageBox.Show("Выбирете конкретный маршрут!");
        }

        private void маршрутToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadGridRout();
        }

        private void LoadGridSchedules()
        {
            string Table = "Вариант_рейса";
            LNameDataGrid.Text = Table;
            dGWMain.Rows.Clear();
            dGWMain.Columns.Clear();
            Schedules.Clear();

            string sqlexp;
            if (comboBoxID_SCH.SelectedIndex > 0)
                sqlexp = $"SELECT * FROM {Table} WHERE ID_Маршрут = {comboBoxID_SCH.SelectedItem} ORDER BY ID_Маршрут, ID_Номер_Расписания,ID_История";
            else sqlexp = $"SELECT * FROM {Table} ORDER BY ID_Маршрут, ID_Номер_Расписания, ID_История";

            using (SqlConnection connect = new SqlConnection(StaticValues.ConnectionString))
            {
                connect.Open();
                SqlCommand com = new SqlCommand(sqlexp, connect);
                SqlCommand countColums = new SqlCommand($"SELECT Count(COLUMN_NAME) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{Table}'", connect);

                var countcolums = (int)countColums.ExecuteScalar();
                var rez = com.ExecuteReader();

                if (rez.HasRows)
                {
                    for (int i = 0; i < countcolums; i++)
                        dGWMain.Columns.Add(rez.GetName(i), rez.GetName(i));

                    while (rez.Read())
                    {
                        Test1.Code.Schedule schedule = new Test1.Code.Schedule();
                        schedule.ID_Rout = rez.GetInt32(0);
                        schedule.ID_Number_Schedule = rez.GetInt32(1);
                        schedule.ID_History = rez.GetInt32(2);
                        schedule.Miliage = rez.GetDouble(3);
                        schedule.Type_Schedule = rez.GetString(4);
                        var ret = schedule.SetMonday(rez.GetString(5));
                        ret &= schedule.SetTuesday(rez.GetString(6));
                        ret &= schedule.SetWednesday(rez.GetString(7));
                        ret &= schedule.SetThursday(rez.GetString(8));
                        ret &= schedule.SetFriday(rez.GetString(9));
                        ret &= schedule.SetSaturday(rez.GetString(10));
                        ret &= schedule.SetSunday(rez.GetString(11));
                        ret &= schedule.SetHoliday(rez.GetString(12));
                        schedule.With = rez.GetDateTime(13);

                        if (rez.GetValue(14) != DBNull.Value)
                            schedule.By = rez.GetDateTime(14);
                        else schedule.By = new DateTime();

                        schedule.SetDayOfWork(rez.GetString(15));
                        Schedules.Add(schedule);
                        dGWMain.Rows.Add(schedule.ToRows());
                    }
                }
            }
        }

        private void LoadGridRout()
        {
            string Table = "Маршрут";
            LNameDataGrid.Text = Table;

            dGWMain.Rows.Clear();
            dGWMain.Columns.Clear();
            Routs.Clear();

            string sqlexp = $"SELECT * FROM {Table} ORDER BY ID, ID_Истории"; 

            using (SqlConnection connect = new SqlConnection(StaticValues.ConnectionString))
            {
                connect.Open();
                SqlCommand com = new SqlCommand(sqlexp, connect);
                SqlCommand countColums = new SqlCommand($"SELECT Count(COLUMN_NAME) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{Table}'", connect);

                var countcolums = (int)countColums.ExecuteScalar();
                var rez = com.ExecuteReader();

                if (rez.HasRows)
                {
                    for (int i = 0; i < countcolums; i++)
                        dGWMain.Columns.Add(rez.GetName(i), rez.GetName(i));

                    while (rez.Read())
                    {
                        Rout rout = new Rout();

                        rout.ID = rez.GetInt32(0);
                        rout.ID_History = rez.GetInt32(1);
                        rout.ID_Contract = rez.GetInt32(2);
                        rout.Registr = rez.GetString(3);
                        rout.Poryd = rez.GetString(4);
                        rout.TypeOfRegular = rez.GetString(5);
                        rout.TypeOnOut = rez.GetString(6);
                        rout.Name = rez.GetString(7);
                        rout.Type_communication = rez.GetString(8);
                        rout.INN = rez.GetInt64(9);
                        
                        dGWMain.Rows.Add(rout.ToRow());
                        Routs.Add(rout);
                    }
                }
            }
        }

        private void LoadGridContract()
        {
            string Table = "Договор";
            LNameDataGrid.Text = Table;

            dGWMain.Rows.Clear();
            dGWMain.Columns.Clear();
            Contracts.Clear();

            string sqlexp = $"SELECT * FROM {Table} ORDER BY ID";

            using (SqlConnection connect = new SqlConnection(StaticValues.ConnectionString))
            {
                connect.Open();
                SqlCommand com = new SqlCommand(sqlexp, connect);
                SqlCommand countColums = new SqlCommand($"SELECT Count(COLUMN_NAME) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{Table}'", connect);

                var countcolums = (int)countColums.ExecuteScalar();
                var rez = com.ExecuteReader();

                if (rez.HasRows)
                {
                    for (int i = 0; i < countcolums; i++)
                        dGWMain.Columns.Add(rez.GetName(i), rez.GetName(i));

                    while (rez.Read())
                    {
                        Contract cont = new Contract();

                        cont.ID = rez.GetInt32(0);
                        cont.Nomber_Contract = rez.GetString(1);
                        cont.With = rez.GetDateTime(2);
                        cont.By = rez.GetDateTime(3);
                        cont.money = rez.GetDecimal(4);

                        dGWMain.Rows.Add(cont.ToRow());
                        Contracts.Add(cont);
                    }
                }
            }
        }

        private void LoadGridContractor()
        {
            string Table = "Подрядчик";
            LNameDataGrid.Text = Table;
            dGWMain.Rows.Clear();
            dGWMain.Columns.Clear();
            Contracts.Clear();

            string sqlexp = $"SELECT * FROM {Table} ORDER BY ИНН";

            using (SqlConnection connect = new SqlConnection(StaticValues.ConnectionString))
            {
                connect.Open();
                SqlCommand com = new SqlCommand(sqlexp, connect);
                SqlCommand countColums = new SqlCommand($"SELECT Count(COLUMN_NAME) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{Table}'", connect);

                var countcolums = (int)countColums.ExecuteScalar();
                var rez = com.ExecuteReader();

                if (rez.HasRows)
                {
                    for (int i = 0; i < countcolums; i++)
                        dGWMain.Columns.Add(rez.GetName(i), rez.GetName(i));

                    while (rez.Read())
                    {
                        Contractor contr = new Contractor();

                        contr.INN = rez.GetInt64(0);
                        contr.Name = rez.GetString(1);

                        if (rez.GetValue(2) != DBNull.Value)
                            contr.Adress = rez.GetString(2);
                        else contr.Adress = "";

                        if (rez.GetValue(3) != DBNull.Value)
                            contr.FIO = rez.GetString(3);
                        else contr.FIO = "";

                        dGWMain.Rows.Add(contr.ToRow());
                        Contractors.Add(contr);
                    }
                }
            }
        }

        private void вариантРейсаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadGridSchedules();
        }

        private void договорToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadGridContract();
        }

        private void подрятчикToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadGridContractor();
        }
    }
}
