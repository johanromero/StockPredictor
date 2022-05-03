using Microsoft.ML;
using Microsoft.ML.Data;
using SPTrainer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SPDataService
{
    public static class PredictionModelTrainer
    {
        public static void TrainAndSaveModel(MLContext mlContext, string dataPath, string outputModelPath)
        {
            if (File.Exists(outputModelPath))
            {
                File.Delete(outputModelPath);
            }
            CreatePredictionModel(mlContext, dataPath, outputModelPath);
        }

        public static void CreatePredictionModel(MLContext mlContext, string dataPath, string outputModelPath)
        {
            var trainingDataView = mlContext.Data.LoadFromTextFile<StockData>(path: dataPath, hasHeader: true, separatorChar: ',');

            var trainer = mlContext.Regression.Trainers.Sdca();

            var trainingPipeline = mlContext.Transforms.Concatenate("Features", inputColumnNames: new string[] { "open", "high", "low", "close", "volume" })
                  .Append(mlContext.Transforms.CopyColumns("Label", inputColumnName: "next"))
                  .Append(trainer); 

            // Train the model
            var model = trainingPipeline.Fit(trainingDataView);

            // Save the model for later comsumption from end-user apps
            mlContext.Model.Save(model, trainingDataView.Schema, outputModelPath);
        }

        public static PredictionResult TestPrediction(MLContext mlContext, StockData input, string outputModelPath)
        {
            Console.WriteLine("Testing Forecast model");

            // Load Trained Model
            DataViewSchema predictionPipelineSchema;
            ITransformer predictionPipeline = mlContext.Model.Load(outputModelPath, out predictionPipelineSchema);

            // Create PredictionEngines
            PredictionEngine<StockData, PredictionResult> predictionEngine = mlContext.Model.CreatePredictionEngine<StockData, PredictionResult>(predictionPipeline);

            // Predict the nextperiod/month forecast to the one provided

            PredictionResult prediction = predictionEngine.Predict(input);
            Console.WriteLine($"Product: {input.timestamp}, Forecast Prediction (high): {prediction.Score}");
            Console.WriteLine("done");
            return prediction;
        }
    }
}