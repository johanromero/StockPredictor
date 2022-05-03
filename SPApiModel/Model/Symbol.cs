using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPApiCore.Model
{
    public class Symbol
    {

        [JsonProperty("symbol")]
        public string Ticker { get; set; }
        [JsonProperty("companyName")]
        public string CompanyName { get; set; }
        [JsonProperty("created_utc")]
        public string Date { get; set; }
        [JsonProperty("open")]
        public double Open { get; set; }
        [JsonProperty("high")]
        public double High { get; set; }
        [JsonProperty("low")]
        public double Low { get; set; }
        [JsonProperty("close")]
        public double Close { get; set; }
        [JsonProperty("volume")]
        public int Volume { get; set; }

    }

}
