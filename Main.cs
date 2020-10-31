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

namespace Test1
{
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
