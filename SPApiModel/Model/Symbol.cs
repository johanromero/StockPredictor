using Newtonsoft.Json;
using System;

namespace SPApiCore.Model
{
    public class Symbol
    {

        [JsonProperty("Ticker")]
        public string Ticker { get; set; }
        [JsonProperty("companyName")]
        public string CompanyName { get; set; }
        [JsonProperty("created_utc")]
        public string Date { get; set; }
        [JsonProperty("Open")]
        public double Open { get; set; }
        [JsonProperty("High")]
        public double High { get; set; }
        [JsonProperty("Low")]
        public double Low { get; set; }
        [JsonProperty("Close")]
        public double Close { get; set; }
        [JsonProperty("Volume")]
        public int Volume { get; set; }

        public Symbol()
        {
            Date = DateTime.Now.ToString("f");
        }

    }

}
