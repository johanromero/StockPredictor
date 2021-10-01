using Microsoft.ML;
using SPDomain.DataModel;
using System;
using System.IO;

namespace SPTrainer
{
    public static class SPModelTrainer
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

            // Data process configuration with pipeline data transformations 
            var dataProcessPipeline = mlContext.Transforms.Text.FeaturizeText("Date_tf", "Date")
                                      .Append(mlContext.Transforms.CopyColumns("Features", "Date_tf"));

            // Train the model


            ITransformer model = trainingPipeline.Fit(trainingDataView);

            // Save the model for later comsumption from end-user apps
            using (var file = File.OpenWrite(outputModelPath))
            {
                mlContext.Model.Save(model, trainingDataView.Schema, file);
            }


            StockData dataSample = new StockData()
            {
                open = 73.55F,
                high = 74.17F,
                low = 73.17F,
                close = 73.85F,
                timestamp = "2017-09-27",
                volume = 18934048
            };
            var path = "../../../../MLTAscend.MVC/wwwroot/PredictionModels/OneDayPred_model.zip";
            // Evaluate quality of Model
            var evalResult = Evaluate(mlContext, dataSample,path, trainingDataView, trainingPipeline);

        }

        public static PredictionResult Evaluate(MLContext mlContext, StockData input, string outputModelPath, IDataView trainingDataView, IEstimator<ITransformer> trainingPipeline)
        {
            Console.WriteLine("Testing Forecast model");

            // Read the model that has been previously saved by the method SaveModel

            ITransformer trainedModel;
            DataViewSchema modelSchema;

            using (var stream = File.OpenRead(outputModelPath))
            {
                trainedModel = mlContext.Model.Load(stream, out modelSchema);
            }

            var predictionEngine = mlContext.Model.CreatePredictionEngine<StockData, PredictionResult>(trainedModel);

            Console.WriteLine("** Testing Model **");

            // Predict the nextperiod/month forecast to the one provided

            PredictionResult prediction = predictionEngine.Predict(input);
            Console.WriteLine($"Product: {input.timestamp}, Forecast Prediction (high): {prediction.Score}");
            Console.WriteLine("done");
            return prediction;


           
        }
    }
}
