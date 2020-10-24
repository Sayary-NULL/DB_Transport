using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1.Code
{
    public class Contractor
    {
        public long INN { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string FIO { get; set; }

        public string[] ToRow()
        {
            string[] rez = new string[4];

            rez[0] = INN.ToString();
            rez[1] = Name;
            rez[2] = Adress;
            rez[3] = FIO;

            return rez;
        }
    }
}
