namespace SPDataService.Services
{
    public class Prediction
    {
        public string Ticker { get; set; }
        public string Date { get; set; }
        public double OneMonth { get; set; }
        public double SixMonths { get; set; }
        public double OneYear { get; set; }
        public double FiveYears { get; set; }
    }
}
