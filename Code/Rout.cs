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
        public string Poryd { get; set; }
        public string TypeOnOut { get; set; }
        public string TypeOfRegular { get; set; }
        public string Name { get; set; }
        public string Type_communication { get; set; }

        public string[] ToRow()
        {
            string[] rez = new string[7];

            rez[0] = ID.ToString();
            rez[1] = ID_History.ToString();
            rez[2] = Poryd;
            rez[3] = TypeOnOut;
            rez[4] = TypeOfRegular;
            rez[5] = Name;
            rez[6] = Type_communication;

            return rez;
        }
    }
}
