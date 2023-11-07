using Microsoft.ML;
using SPTrainer.Models;
using System;
using System.IO;
using System.Reflection;

namespace SPDataService.Services
{
    public static class PredictionService
    {
        public static MLContext mlContext { get; set; } = new MLContext();


        public static Prediction RunAllPredictions(StockData input)
        {
            var p = new Prediction();
            var rootLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            p.Ticker = input.Ticker;
            p.Date = input.Date;


            var oneMonthPath = String.Format("../../../../SPTrainer/PredictionModels/{0}/OneMonth.zip", p.Ticker.ToUpper());
            var sixMonthsPath = String.Format("../../../../SPTrainer/PredictionModels/{0}/SixMonths.zip", p.Ticker.ToUpper());
            var oneYearPath = String.Format("../../../../SPTrainer/PredictionModels/{0}/OneYear.zip", p.Ticker.ToUpper());
            var fiveYearsPath = String.Format("../../../../SPTrainer/PredictionModels/{0}/FiveYears.zip", p.Ticker.ToUpper());


            p.OneMonth = RunPrediction(input, Path.Combine(rootLocation, oneMonthPath)).Score;
            p.SixMonths = RunPrediction(input, Path.Combine(rootLocation, sixMonthsPath)).Score;
            p.OneYear = RunPrediction(input, Path.Combine(rootLocation, oneYearPath)).Score;
            p.FiveYears = RunPrediction(input, Path.Combine(rootLocation, fiveYearsPath)).Score;
            return p;
        }

        private static PredictionResult RunPrediction(StockData input, string modelPath)
        {

            // Read the model that has been previously saved by the method SaveModel
            ITransformer trainedModel;

            using (var stream = File.OpenRead(modelPath))
            {
                trainedModel = mlContext.Model.Load(stream, out DataViewSchema schema);
            }

            var predictionEngine = mlContext.Model.CreatePredictionEngine<StockData, PredictionResult>(trainedModel);

            // Predict the nextperiod/month forecast to the one provided

            return predictionEngine.Predict(input);
        }
    }
}
