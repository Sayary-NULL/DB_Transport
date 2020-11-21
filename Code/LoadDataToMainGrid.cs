using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test1.Code
{
    public class LoadDataToMainGrid
    {
        DataGridView dGVMain;

        public LoadDataToMainGrid(DataGridView dataGrid)
        {
            dGVMain = dataGrid;
        }

        public void LoadRoutColums()
        {
            DataGridViewColumn idRout = new DataGridViewTextBoxColumn();
            idRout.Name = "ID";
            idRout.Width = 55;
            idRout.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewColumn idhist = new DataGridViewTextBoxColumn();
            idhist.Name = "ID_hist";
            idhist.HeaderText = "ID Истории";
            idhist.Width = 75;
            idhist.Visible = false;
            idhist.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewColumn pornumber = new DataGridViewTextBoxColumn();
            pornumber.Name = "poryd";
            pornumber.HeaderText = "Порядковый номер";
            pornumber.HeaderCell.Style.WrapMode = DataGridViewTriState.True;
            pornumber.Width = 75;
            pornumber.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewColumn typepere = new DataGridViewTextBoxColumn();
            typepere.Name = "typepere";
            typepere.HeaderText = "Вид регулярной перевозки";
            typepere.HeaderCell.Style.WrapMode = DataGridViewTriState.True;
            typepere.Width = 70;
            typepere.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewColumn typeofinout = new DataGridViewTextBoxColumn();
            typeofinout.Name = "typeofinout";
            typeofinout.HeaderText = "Порядок посадки и высадки пассажиров";
            typeofinout.HeaderCell.Style.WrapMode = DataGridViewTriState.True;
            typeofinout.Width = 75;
            typeofinout.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewColumn name = new DataGridViewTextBoxColumn();
            name.Name = "name";
            name.HeaderText = "Наименование";
            name.HeaderCell.Style.WrapMode = DataGridViewTriState.True;
            name.Width = 100;
            name.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewColumn typemess = new DataGridViewTextBoxColumn();
            typemess.Name = "typeofmess";
            typemess.HeaderText = "Тип сообщения";
            typemess.Width = 100;
            typemess.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dGVMain.Rows.Clear();
            dGVMain.Columns.Clear();

            dGVMain.Columns.Add(idRout);
            dGVMain.Columns.Add(name);
            dGVMain.Columns.Add(typemess);
            dGVMain.Columns.Add(idhist);
            dGVMain.Columns.Add(pornumber);
            dGVMain.Columns.Add(typepere);
            dGVMain.Columns.Add(typeofinout);
        }
        public void LoadScheduleColums()
        {
            DataGridViewColumn idRoute = new DataGridViewTextBoxColumn
            {
                Name = "ID",
                HeaderText = "Номер маршрута",
                Width = 60
            };
            idRoute.HeaderCell.Style.WrapMode = DataGridViewTriState.True;

            DataGridViewColumn idShelude = new DataGridViewTextBoxColumn
            {
                Name = "idShedule",
                HeaderText = "Вариант рейса",
                Width = 55
            };
            idShelude.HeaderCell.Style.WrapMode = DataGridViewTriState.True;

            DataGridViewColumn idHist = new DataGridViewTextBoxColumn
            {
                Name = "idHist",
                HeaderText = "Номер версии",
                Width = 55,
                Visible = false
            };
            idHist.HeaderCell.Style.WrapMode = DataGridViewTriState.True;

            DataGridViewColumn mileage = new DataGridViewTextBoxColumn
            {
                Name = "mileage",
                HeaderText = "Растояние",
                Width = 70
            };

            DataGridViewColumn typeofschelude = new DataGridViewTextBoxColumn
            {
                Name = "typeofschelude",
                HeaderText = "Тип рейса",
                Width = 65
            };

            DataGridViewColumn pn = new DataGridViewCheckBoxColumn
            {
                Name = "pn",
                HeaderText = "Понедельник",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            };

            DataGridViewColumn vt = new DataGridViewCheckBoxColumn
            {
                Name = "vt",
                HeaderText = "Вторник",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            };

            DataGridViewColumn sr = new DataGridViewCheckBoxColumn
            {
                Name = "sr",
                HeaderText = "Среда",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            };

            DataGridViewColumn cht = new DataGridViewCheckBoxColumn
            {
                Name = "cht",
                HeaderText = "Четверг",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            };

            DataGridViewColumn pt = new DataGridViewCheckBoxColumn
            {
                Name = "pt",
                HeaderText = "Пятница",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            };

            DataGridViewColumn sb = new DataGridViewCheckBoxColumn
            {
                Name = "sb",
                HeaderText = "Суббота",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            };

            DataGridViewColumn vs = new DataGridViewCheckBoxColumn
            {
                Name = "vs",
                HeaderText = "Воскресенье",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            };

            DataGridViewColumn pr = new DataGridViewCheckBoxColumn
            {
                Name = "pr",
                HeaderText = "Празднечные дни",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            };
            pr.HeaderCell.Style.WrapMode = DataGridViewTriState.True;

            DataGridViewColumn witch = new DataGridViewTextBoxColumn
            {
                Name = "witch",
                HeaderText = "Начало действия",
                Width = 55,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
            };
            witch.HeaderCell.Style.WrapMode = DataGridViewTriState.True;

            DataGridViewColumn by = new DataGridViewTextBoxColumn
            {
                Name = "by",
                HeaderText = "Дата окончания",
                Width = 55,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
            };
            by.HeaderCell.Style.WrapMode = DataGridViewTriState.True;

            DataGridViewColumn dayofworck = new DataGridViewTextBoxColumn
            {
                Name = "dayofworck",
                HeaderText = "Дни работы",
                Width = 55,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            dayofworck.HeaderCell.Style.WrapMode = DataGridViewTriState.True;

            dGVMain.Rows.Clear();
            dGVMain.Columns.Clear();

            dGVMain.Columns.Add(idRoute);
            dGVMain.Columns.Add(idShelude);
            dGVMain.Columns.Add(idHist);
            dGVMain.Columns.Add(mileage);
            dGVMain.Columns.Add(typeofschelude);
            dGVMain.Columns.Add(pn);
            dGVMain.Columns.Add(vt);
            dGVMain.Columns.Add(sr);
            dGVMain.Columns.Add(cht);
            dGVMain.Columns.Add(pt);
            dGVMain.Columns.Add(sb);
            dGVMain.Columns.Add(vs);
            dGVMain.Columns.Add(pr);
            dGVMain.Columns.Add(witch);
            dGVMain.Columns.Add(by);
            dGVMain.Columns.Add(dayofworck);
        }
        public void LoadContractColums()
        {
            DataGridViewColumn idContract = new DataGridViewTextBoxColumn
            {
                Name = "ID",
                HeaderText = "ID договора",
                Width = 60
            };
            idContract.HeaderCell.Style.WrapMode = DataGridViewTriState.True;

            DataGridViewColumn number = new DataGridViewTextBoxColumn
            {
                Name = "number",
                HeaderText = "Номер договора",
                Width = 65
            };
            number.HeaderCell.Style.WrapMode = DataGridViewTriState.True;

            DataGridViewColumn date_start = new DataGridViewTextBoxColumn
            {
                Name = "date_start",
                HeaderText = "Дата начала",
                Width = 65
            };
            date_start.HeaderCell.Style.WrapMode = DataGridViewTriState.True;

            DataGridViewColumn date_end = new DataGridViewTextBoxColumn
            {
                Name = "date_end",
                HeaderText = "Дата окончания",
                Width = 65
            };
            date_end.HeaderCell.Style.WrapMode = DataGridViewTriState.True;

            DataGridViewColumn money = new DataGridViewTextBoxColumn
            {
                Name = "money",
                HeaderText = "Цена договора",
                Width = 60,
                Visible = false
            };
            money.HeaderCell.Style.WrapMode = DataGridViewTriState.True;

            DataGridViewColumn INN = new DataGridViewTextBoxColumn
            {
                Name = "inn",
                HeaderText = "ИНН подрядчика",
                Width = 85
            };
            INN.HeaderCell.Style.WrapMode = DataGridViewTriState.True;

            dGVMain.Rows.Clear();
            dGVMain.Columns.Clear();

            dGVMain.Columns.Add(idContract);
            dGVMain.Columns.Add(number);
            dGVMain.Columns.Add(date_start);
            dGVMain.Columns.Add(date_end);
            dGVMain.Columns.Add(money);
            dGVMain.Columns.Add(INN);
        }
        public void LoadContractorColums()
        {
            DataGridViewColumn INN = new DataGridViewTextBoxColumn
            {
                Name = "inn",
                HeaderText = "ИНН подрядчика",
                Width = 80
            };
            INN.HeaderCell.Style.WrapMode = DataGridViewTriState.True;

            DataGridViewColumn name = new DataGridViewTextBoxColumn
            {
                Name = "name",
                HeaderText = "Наименование",
                Width = 185
            };

            DataGridViewColumn adress = new DataGridViewTextBoxColumn
            {
                Name = "adress",
                HeaderText = "Место нахождения",
                Width = 130
            };
            adress.HeaderCell.Style.WrapMode = DataGridViewTriState.True;

            DataGridViewColumn fio = new DataGridViewTextBoxColumn
            {
                Name = "fio",
                HeaderText = "ФИО",
                Width = 120
            };

            dGVMain.Rows.Clear();
            dGVMain.Columns.Clear();

            dGVMain.Columns.Add(INN);
            dGVMain.Columns.Add(name);
            dGVMain.Columns.Add(adress);
            dGVMain.Columns.Add(fio);
        }
        public void LoadDataToGridRout(Rout rout)
        {
            var ind = dGVMain.Rows.Add(rout.ID.ToString());
            dGVMain["ID", ind].Value = rout.ID;
            dGVMain["ID_hist", ind].Value = rout.ID_History;
            dGVMain["poryd", ind].Value = rout.Poryd;
            dGVMain["typepere", ind].Value = rout.TypeOfRegular;
            dGVMain["typeofinout", ind].Value = rout.TypeOnOut;
            dGVMain["name", ind].Value = rout.Name;
            dGVMain["typeofmess", ind].Value = rout.Type_communication;
        }
        public void LoadDataToGridSchedule(Schedule schedule)
        {
            var ind = dGVMain.Rows.Add(schedule.ID_Rout.ToString());
            dGVMain["idShedule", ind].Value = schedule.ID_Number_Schedule;
            dGVMain["idHist", ind].Value = schedule.ID_History;
            dGVMain["mileage", ind].Value = schedule.Miliage;
            dGVMain["typeofschelude", ind].Value = schedule.Type_Schedule;

            if (schedule.Monday.JsonSTR != "")
                dGVMain["pn", ind].Value = true;

            if (schedule.Tuesday.JsonSTR != "")
                dGVMain["vt", ind].Value = true;

            if (schedule.Wednesday.JsonSTR != "")
                dGVMain["sr", ind].Value = true;

            if (schedule.Thursday.JsonSTR != "")
                dGVMain["cht", ind].Value = true;

            if (schedule.Friday.JsonSTR != "")
                dGVMain["pt", ind].Value = true;

            if (schedule.Saturday.JsonSTR != "")
                dGVMain["sb", ind].Value = true;
            else dGVMain["sb", ind].Value = false;

            if (schedule.Sunday.JsonSTR != "")
                dGVMain["vs", ind].Value = true;

            if (schedule.Holiday.JsonSTR != "")
                dGVMain["pr", ind].Value = true;

            dGVMain["witch", ind].Value = schedule.With.ToString("dd.MM.yyyy");
            dGVMain["by", ind].Value = schedule.By.ToString("dd.MM.yyyy");

            string str = "";
            foreach (var day in schedule.DayOfWork)
                str += day + ",";
            str = str.Remove(str.Length - 1);

            dGVMain["dayofworck", ind].Value = str;
        }
        public void LoadDataToGridContract(Contract contract)
        {
            int ind = dGVMain.Rows.Add(contract.ID.ToString());
            dGVMain["number", ind].Value = contract.Nomber_Contract;
            dGVMain["date_start", ind].Value = contract.With.ToString("dd.MM.yyyy");
            dGVMain["date_end", ind].Value = contract.By.ToString("dd.MM.yyyy");
            dGVMain["money", ind].Value = contract.money.ToString();
            dGVMain["inn", ind].Value = contract.INN.ToString();
        }
        public void LoadDataToGridContractor(Contractor contractor)
        {
            int ind = dGVMain.Rows.Add(contractor.INN.ToString());
            dGVMain["name", ind].Value = contractor.Name;
            dGVMain["adress", ind].Value = contractor.Adress;
            dGVMain["fio", ind].Value = contractor.FIO;
            dGVMain["inn", ind].ToolTipText = $"Подсказка: подсказок нет id:{ind}";
        }
    }
}
