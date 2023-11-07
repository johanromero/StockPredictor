using Microsoft.ML;
using SPTrainer.Models;
using System;
using System.Collections.Generic;

namespace SPTrainer
{
    static class Program
    {
        static void Main(string[] args)
        {

            MLContext mlContext = new MLContext(seed: 1);

            StockData dataSample = new StockData()
            {

                Date = DateTime.Now.ToString("MM/dd/yyyy")
            };
            Dictionary<string, string> algorithms = new Dictionary<string, string>
            {
                {"1", "SDCA" }, {"2", "LbfgsPoisson" }, {"3", "OnlineGradient" }
            };

            Dictionary<string, string> symbols = new Dictionary<string, string>
            {
                {"1", "MSFT" }, {"2", "AAPL" }, {"3", "AMZN" }
            };

            bool continueLoop = true;
            while (continueLoop)
            {

                Console.Clear();
                Console.WriteLine("Enter the company:");
                Console.WriteLine("1) Microsoft");
                Console.WriteLine("2) Apple");
                Console.WriteLine("3) Amazon");
                var selection = Console.ReadLine();
                if (!symbols.ContainsKey(selection))
                {
                    Console.WriteLine("Invalid company....");
                    Console.ReadLine();
                    continue;
                }
                var symbol = symbols[selection];
                Console.Clear();

                Console.WriteLine("Choose an algorithm:");
                Console.WriteLine("1) SDCA (Default)");
                Console.WriteLine("2) Lbfgs Poisson");
                Console.WriteLine("3) Online Gradient");
                Console.Write("\r\nSelect an option: ");

                selection = Console.ReadLine();

                if (!algorithms.ContainsKey(selection))
                {
                    Console.WriteLine("Invalid selection....");
                    Console.ReadLine();
                    continue;
                }
                var algorithm = algorithms[selection];


                // Evaluate quality of Model

                var oneMonthPath = String.Format("../../../Data/{0}/OneMonth.csv", symbol);

                var sixMonthPath = String.Format("../../../Data/{0}/SixMonths.csv", symbol);

                var oneYearPath = String.Format("../../../Data/{0}/OneYear.csv", symbol);

                var fiveYearsPath = String.Format("../../../Data/{0}/FiveYears.csv", symbol);

                //OneMonth
                Console.WriteLine("············Creating models with ONE MONTH of data···············");
                var outputPath = String.Format("../../../PredictionModels/{0}/OneMonth.zip", symbol);
                
                SPModelTrainer.TrainAndSaveModel(mlContext, oneMonthPath, outputPath, algorithm);
                var evalResult = SPModelTrainer.TestPrediction(mlContext, dataSample, outputPath);
                //SixMonth
                Console.WriteLine("············Creating models with SIX MONTHS of data···············");
                outputPath = String.Format("../../../PredictionModels/{0}/SixMonths.zip", symbol);
                SPModelTrainer.TrainAndSaveModel(mlContext, sixMonthPath, outputPath, algorithm);
                SPModelTrainer.TestPrediction(mlContext, dataSample, outputPath);
                //OneYear
                Console.WriteLine("············Creating models with ONE YEAR of data···············");
                outputPath = String.Format("../../../PredictionModels/{0}/OneYear.zip", symbol);
                SPModelTrainer.TrainAndSaveModel(mlContext, oneYearPath, outputPath, algorithm);
                SPModelTrainer.TestPrediction(mlContext, dataSample, outputPath);
                //FiveYears
                Console.WriteLine("············Creating models with FIVER YEARS of data···············");
                outputPath = String.Format("../../../PredictionModels/{0}/FiveYears.zip", symbol);
                SPModelTrainer.TrainAndSaveModel(mlContext, fiveYearsPath, outputPath, algorithm);
                SPModelTrainer.TestPrediction(mlContext, dataSample, outputPath);


                Console.WriteLine("Do you like to model another stock? (Y)/(N)");
                var answer = Console.ReadLine();
                continueLoop = answer.ToLower() == "y";

            }
        }

    }
}
