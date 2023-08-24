using System;
using System.Collections.Generic;
using System.Text;

namespace SPDataService.Services
{
    public class Prediction
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Ticker { get; set; }
        public DateTime CreationDate { get; set; }
        public double OneMonth { get; set; }
        public double SixMonths { get; set; }
        public double OneYear { get; set; }
        public double FiveYears { get; set; }
    }
}
