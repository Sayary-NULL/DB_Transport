using Microsoft.Office.Interop.Word;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Test1.Code;
using Word = Microsoft.Office.Interop.Word;

namespace Test1
{
    struct ClassA
    {
        public double SC;
        public double MC;
        public double LC;
        public double ESC;
        public double ELC;

        public static ClassA operator +(ClassA a1, Test1.Code.DayOfWeek a2)
        {
            if(a2.SC != null)
                a1.SC += a2.SC[1];
            if (a2.MC != null)
                a1.MC += a2.MC[1];
            if (a2.LC != null)
                a1.LC += a2.LC[1];
            if (a2.ESC != null)
                a1.ESC += a2.ESC[1];
            if (a2.ELC != null)
                a1.ELC += a2.ELC[1];

            return a1;
        }
    }

    class Program
    {
        static List<Test1.Code.Schedule> Schedules = new List<Test1.Code.Schedule>();

        public static void Main()
        {
#if !DEBUG
            Test1.Forms.FormLogin formlog = new Test1.Forms.FormLogin();
            formlog.ShowDialog();

            if (!formlog.Logged) return;
#else
            Code.StaticValues.IPAdress = "DESKTOP-PJ9KLHM";
            Code.StaticValues.Login = "test";
            Code.StaticValues.Password = "123";
#endif

            StaticValues.ConnectionString = String.Format(Test1.DB_Resource.StrConnection, Test1.Code.StaticValues.IPAdress, Test1.Code.StaticValues.Login, Test1.Code.StaticValues.Password);
            Forms.FormMain formMain = new Forms.FormMain();
            formMain.ShowDialog();
            
            //Console.ReadKey();
        }
    }
}
