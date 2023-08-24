using Microsoft.ML;
using SPTrainer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPTrainer
{
    static class Program
    {
        static void Main(string[] args)
        {

            MLContext mlContext = new MLContext(seed: 1);

            StockData dataSample = new StockData()
            {
                Open = (long)73.55F,
                High = (long)74.17F,
                Low = (long)73.17F,
                Close = (long)73.85F,
                Date = DateTime.Now.ToString("MM/dd/yyyy"),
                Volume = 18934048
            };
            Dictionary<string, string> algorithms = new Dictionary<string, string>
            {
                {"1", "SDCA" }, {"2", "LbfgsPoisson" }, {"3", "OnlineGradient" }
            };
            
            bool continueLoop = true;
            while (continueLoop)
            {

            Console.Clear();
            Console.WriteLine("Enter the symbol:");
            var symbol = Console.ReadLine();

            Console.WriteLine("Choose an algorithm:");
            Console.WriteLine("1) SDCA (Default)");
            Console.WriteLine("2) Lbfgs Poisson");
            Console.WriteLine("3) Online Gradient");
            Console.Write("\r\nSelect an option: ");

            var selection = Console.ReadLine();
            var algorithm = algorithms[selection];

            // Evaluate quality of Model
            var oneMonthPath = String.Format("../../../Data/{0}/OneMonth.csv", symbol);
            var sixMonthPath = String.Format("../../../Data/{0}/SixMonths.csv", symbol);
            var oneYearPath = String.Format("../../../Data/{0}/OneYear.csv", symbol);
            var fiveYearsPath = String.Format("../../../Data/{0}/FiveYears.csv", symbol);

            //OneMonth
            var outputPath = String.Format("../../../PredictionModels/{0}/OneMonth.zip", symbol);
            SPModelTrainer.TrainAndSaveModel(mlContext, oneMonthPath, outputPath, algorithm);
            var evalResult = SPModelTrainer.TestPrediction(mlContext, dataSample, outputPath);
            //SixMonth
            outputPath = String.Format("../../../PredictionModels/{0}/SixMonths.zip", symbol);
            SPModelTrainer.TrainAndSaveModel(mlContext,sixMonthPath, outputPath, algorithm);
            SPModelTrainer.TestPrediction(mlContext, dataSample, outputPath);
            //OneYear
            outputPath = String.Format("../../../PredictionModels/{0}/OneYear.zip", symbol);
            SPModelTrainer.TrainAndSaveModel(mlContext, oneYearPath, outputPath, algorithm);
            SPModelTrainer.TestPrediction(mlContext, dataSample, outputPath);
            //FiveYears
            outputPath = String.Format("../../../PredictionModels/{0}/FiveYears.zip", symbol);
            SPModelTrainer.TrainAndSaveModel(mlContext,fiveYearsPath, outputPath, algorithm);
            SPModelTrainer.TestPrediction(mlContext, dataSample, outputPath);


            Console.WriteLine("Do you like to test another algorithm? (Y)/(N)");
            var answer = Console.ReadLine();
            continueLoop = answer.ToLower() == "y";

            }
        }

    }
}
