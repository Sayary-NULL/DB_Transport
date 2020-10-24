using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1.Code
{
    class ClassTransport
    {
        public double SC;
        public double MC;
        public double LC;
        public double ESC;
        public double ELC;

        public static ClassTransport operator +(ClassTransport a1, DayOfWeek a2)
        {
            if (a2.SC != null)
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
}
