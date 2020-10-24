using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1.Code
{
    /// <summary>
    /// Расписание
    /// </summary>
    public class Schedule
    {
        public int ID_Rout { get; set; }
        public int ID_Number_Schedule { get; set; }
        public int ID_History { get; set; }
        public double Miliage { get; set; }
        public string Type_Schedule { get; set; }
        public DayOfWeek Monday { get; private set; }
        public DayOfWeek Tuesday { get; private set; }
        public DayOfWeek Wednesday { get; private set; }
        public DayOfWeek Thursday { get; private set; }
        public DayOfWeek Friday { get; private set; }
        public DayOfWeek Saturday { get; private set; }
        public DayOfWeek Sunday { get; private set; }
        public DayOfWeek Holiday { get; private set; }
        public DateTime With { get; set; }
        public DateTime By { get; set; }
        public List<int> DayOfWork { get; private set; }

        /// <summary>
        /// Понедельник
        /// </summary>
        /// <param name="day">строка содержащая json данные о дне</param>
        /// <returns></returns>
        public bool SetMonday(string day)
        {
            try
            {
                var rez = JsonConvert.DeserializeObject<DayOfWeek>(day);
                rez.JsonSTR = day;
                Monday = rez;
                return true;
            }
            catch
            {
                Monday = new DayOfWeek();
                return false;
            }
        }

        /// <summary>
        /// Вторник
        /// </summary>
        /// <param name="day">строка содержащая json данные о дне</param>
        /// <returns></returns>
        public bool SetTuesday(string day)
        {
            try
            {
                var rez = JsonConvert.DeserializeObject<DayOfWeek>(day);
                rez.JsonSTR = day;
                Tuesday = rez;
                return true;
            }
            catch
            {
                Tuesday = new DayOfWeek();
                return false;
            }
        }


        /// <summary>
        /// Среда
        /// </summary>
        /// <param name="day">строка содержащая json данные о дне</param>
        /// <returns></returns>
        public bool SetWednesday(string day)
        {
            try
            {
                var rez = JsonConvert.DeserializeObject<DayOfWeek>(day);
                rez.JsonSTR = day;
                Wednesday = rez;
                return true;
            }
            catch
            {
                Wednesday = new DayOfWeek();
                return false;
            }
        }

        /// <summary>
        /// Четверг
        /// </summary>
        /// <param name="day">строка содержащая json данные о дне</param>
        /// <returns></returns>
        public bool SetThursday(string day)
        {
            try
            {
                var rez = JsonConvert.DeserializeObject<DayOfWeek>(day);
                rez.JsonSTR = day;
                Thursday = rez;
                return true;
            }
            catch
            {
                Thursday = new DayOfWeek();
                return false;
            }
        }

        /// <summary>
        /// Пятница
        /// </summary>
        /// <param name="day">строка содержащая json данные о дне</param>
        /// <returns></returns>
        public bool SetFriday(string day)
        {
            try
            {
                var rez = JsonConvert.DeserializeObject<DayOfWeek>(day);
                rez.JsonSTR = day;
                Friday = rez;
                return true;
            }
            catch
            {
                Friday = new DayOfWeek();
                return false;
            }
        }

        /// <summary>
        /// Суббота
        /// </summary>
        /// <param name="day">строка содержащая json данные о дне</param>
        /// <returns></returns>
        public bool SetSaturday(string day)
        {
            try
            {
                var rez = JsonConvert.DeserializeObject<DayOfWeek>(day);
                rez.JsonSTR = day;
                Saturday = rez;
                return true;
            }
            catch
            {
                Saturday = new DayOfWeek();
                return false;
            }
        }

        /// <summary>
        /// Воскресенье
        /// </summary>
        /// <param name="day">строка содержащая json данные о дне</param>
        /// <returns></returns>
        public bool SetSunday(string day)
        {
            try
            {
                var rez = JsonConvert.DeserializeObject<DayOfWeek>(day);
                rez.JsonSTR = day;
                Sunday = rez;
                return true;
            }
            catch
            {
                Sunday = new DayOfWeek();
                return false;
            }
        }

        /// <summary>
        /// Парзднечные дни
        /// </summary>
        /// <param name="day">строка содержащая json данные о дне</param>
        /// <returns></returns>
        public bool SetHoliday(string day)
        {
            try
            {
                var rez = JsonConvert.DeserializeObject<DayOfWeek>(day);
                rez.JsonSTR = day;
                Holiday = rez;
                return true;
            }
            catch
            {
                Holiday = new DayOfWeek();
                return false;
            }
        }

        /// <summary>
        /// Установка дней работы
        /// </summary>
        /// <param name="day">строка содержащая json данные о дне</param>
        /// <returns></returns>
        public void SetDayOfWork(string days)
        {
            var rez = days.Split(',');
            DayOfWork = new List<int>();

            foreach (var item in rez)
            {
                DayOfWork.Add(Int32.Parse(item));
            }
        }

        public string[] ToRows()
        {
            string[] rez = new string[16];
            rez[0] = (ID_Rout.ToString());
            rez[1] = (ID_Number_Schedule.ToString());
            rez[2] = ID_History.ToString();
            rez[3] = (Miliage.ToString());
            rez[4] = (Type_Schedule.ToString());
            rez[5] = (Monday.JsonSTR);
            rez[6] = (Tuesday.JsonSTR);
            rez[7] = (Wednesday.JsonSTR);
            rez[8] = (Thursday.JsonSTR);
            rez[9] = (Friday.JsonSTR);
            rez[10] = (Saturday.JsonSTR);
            rez[11] = (Sunday.JsonSTR);
            rez[12] = (Holiday.JsonSTR);
            rez[13] = (With.ToString("dd.MM.yyyy"));
            if (By == new DateTime())
                rez[14] = ("-");
            else rez[14] = (By.ToString("dd.MM.yyyy"));

            string day = "";
            for (int i = 0; i < DayOfWork.Count; i++)
                day += DayOfWork[i].ToString() + (i != DayOfWork.Count - 1 ? ",":"");
            rez[15] = (day);

            return rez;
        }
    }
}
