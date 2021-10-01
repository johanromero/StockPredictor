using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Microsoft.ML;
using SPDomain.DataModel;
using SPDomain.Persistent;

namespace SPData.Services
{
    public static class PredictionService
    {
        public static MLContext mlContext { get; set; } = new MLContext();


        public static Prediction RunAllPredictions(StockData input)
        {
            var p = new Prediction();
            var rootLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            
            p.OneDayPred = RunPrediction(input, Path.Combine(rootLocation, "../../../../MLTAscend.MVC/wwwroot/PredictionModels/OneDayPred_model.zip")).Score;

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
