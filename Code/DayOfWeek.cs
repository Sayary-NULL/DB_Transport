using Newtonsoft.Json;
using System.Collections.Generic;

namespace Test1.Code
{
    public struct DayOfWeek
    {
        [JsonProperty("МК")]
        public List<double> SC { get; set; }
        [JsonProperty("СК")]
        public List<double> MC { get; set; }
        [JsonProperty("БК")]
        public List<double> LC { get; set; }
        [JsonProperty("ОМК")]
        public List<double> ESC { get; set; }
        [JsonProperty("ОБК")]
        public List<double> ELC { get; set; }
        [JsonIgnore]
        public string JsonSTR { get; set; }

        public static DayOfWeek operator *(DayOfWeek a11, double a2)
        {
            var a1 = new DayOfWeek
            {
                SC = new List<double>(a11.SC),
                MC = new List<double>(a11.MC),
                LC = new List<double>(a11.LC),
                ESC = new List<double>(a11.ESC),
                ELC = new List<double>(a11.ELC)
            };

            if (a1.SC != null)
                a1.SC[1] *= a2;
            if (a1.MC != null)
                a1.MC[1] *= a2;
            if (a1.LC != null)
                a1.LC[1] *= a2;
            if (a1.ESC != null)
                a1.ESC[1] *= a2;
            if (a1.ELC != null)
                a1.ELC[1] *= a2;

            return a1;
        }
    }
}
