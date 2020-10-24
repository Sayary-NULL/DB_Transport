using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1.Code
{
    public class Rout
    {
        public int ID { get; set; }
        public int ID_History { get; set; }
        public int ID_Contract { get; set; }
        public string Registr { get; set; }
        public string Poryd { get; set; }
        public string TypeOfRegular { get; set; }
        public string TypeOnOut { get; set; }
        public string Name { get; set; }
        public string Type_communication { get; set; }
        public long INN { get; set; }

        public string[] ToRow()
        {
            string[] rez = new string[10];

            rez[0] = ID.ToString();
            rez[1] = ID_History.ToString();
            rez[2] = ID_Contract.ToString();
            rez[3] = Registr;
            rez[4] = Poryd;
            rez[5] = TypeOfRegular;
            rez[6] = TypeOnOut;
            rez[7] = Name;
            rez[8] = Type_communication;
            rez[9] = INN.ToString();

            return rez;
        }
    }
}
