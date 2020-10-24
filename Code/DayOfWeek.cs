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
    }
}
