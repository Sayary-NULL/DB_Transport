using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1.Code
{
    public static class StaticValues
    {
        public static string[] months = { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };
        public static string IPAdress { get; set; }
        public static string Login { get; set; }
        public static string Password { get; set; }

        public static string ConnectionString = "";
    }
}
