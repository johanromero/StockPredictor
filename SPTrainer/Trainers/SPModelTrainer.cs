using Microsoft.ML;
using SPTrainer.Models;
using System;
using System.IO;

namespace SPTrainer
{
    public static class SPModelTrainer
    {
        public static void TrainAndSaveModel(MLContext mlContext, string dataPath, string outputModelPath, string algorithm = "")
        {
            if (File.Exists(outputModelPath))
            {
                File.Delete(outputModelPath);
            }

            switch (algorithm)
            {
                case "LbfgsPoisson":
                    CreatePredictionModelLbfgsPoisson(mlContext, dataPath, outputModelPath, algorithm);
                    break;
                case "OnlineGradient":
                    CreatePredictionOnlineGradient(mlContext, dataPath, outputModelPath, algorithm);
                    break;

                default:
                    CreatePredictionModelSDCA(mlContext, dataPath, outputModelPath, algorithm);
                    break;
            }

        }

        public static void CreatePredictionModelSDCA(MLContext mlContext, string dataPath, string outputModelPath, string algorithm = "")
        {
            var trainingDataView = mlContext.Data.LoadFromTextFile<StockDataInput>(path: dataPath, hasHeader: true, separatorChar: ',');


            var trainer = mlContext.Regression.Trainers.Sdca(labelColumnName: "Close", maximumNumberOfIterations: 100);
            var pipeline = mlContext.Transforms.CustomMapping(new
                                            DateToFloatCustomAction().GetMapping(), contractName: "DateToFloat")
                                .AppendCacheCheckpoint(mlContext)
                                .Append(mlContext.Transforms.Concatenate("Features", new[] { "DateFloat", "Volume", "Open", "High", "Low" }))
                                .Append(trainer);





            //var trainingPipeline = mlContext.Transforms.Concatenate("Features",  new[] {  "open", "high", "low", "close" })
            //    .Append(mlContext.Transforms.CopyColumns("Label", inputColumnName: "close")).Append(trainerSDCA);


            // Train the model
            ITransformer model = pipeline.Fit(trainingDataView);

            mlContext.ComponentCatalog.RegisterAssembly(typeof(
                    DateToFloatCustomAction).Assembly);

            var prediction = model.Transform(trainingDataView);
            var metrics = mlContext.Regression.Evaluate(prediction, "Close", "Score");


            Console.WriteLine();
            Console.WriteLine($"*************************************************");
            Console.WriteLine($"*       Model quality metrics evaluation         ");
            Console.WriteLine($"*------------------------------------------------");

            Console.WriteLine($"*       RSquared Score:      {metrics.RSquared:0.##}");
            Console.WriteLine($"*       Root Mean Squared Error:      {metrics.RootMeanSquaredError:#.##}");
            Console.WriteLine($"*       Mean Absolute Error:      {metrics.MeanAbsoluteError:0.##}");
            Console.WriteLine($"*       Mean Squared Error:      {metrics.MeanSquaredError:#.##}");

            // Save the model for later comsumption from end-user apps
            using (
                var file = File.OpenWrite(outputModelPath))
            {
                mlContext.Model.Save(model, trainingDataView.Schema, file);
            }
        }


        public static void CreatePredictionModelLbfgsPoisson(MLContext mlContext, string dataPath, string outputModelPath, string algorithm = "")
        {
            var trainingDataView = mlContext.Data.LoadFromTextFile<StockDataInput>(path: dataPath, hasHeader: true, separatorChar: ',');


            var trainer = mlContext.Regression.Trainers.LbfgsPoissonRegression(labelColumnName: "Close", historySize:100);
            var pipeline = mlContext.Transforms.CustomMapping(new
                                            DateToFloatCustomAction().GetMapping(), contractName: "DateToFloat")
                                .AppendCacheCheckpoint(mlContext)
                                .Append(mlContext.Transforms.Concatenate("Features", new[] { "DateFloat", "Volume", "Open", "High", "Low" }))
                                .Append(trainer);





            //var trainingPipeline = mlContext.Transforms.Concatenate("Features",  new[] {  "open", "high", "low", "close" })
            //    .Append(mlContext.Transforms.CopyColumns("Label", inputColumnName: "close")).Append(trainerSDCA);


            // Train the model
            ITransformer model = pipeline.Fit(trainingDataView);

            mlContext.ComponentCatalog.RegisterAssembly(typeof(
                    DateToFloatCustomAction).Assembly);

            var prediction = model.Transform(trainingDataView);
            var metrics = mlContext.Regression.Evaluate(prediction, "Close", "Score");


            Console.WriteLine();
            Console.WriteLine($"*************************************************");
            Console.WriteLine($"*       Model quality metrics evaluation         ");
            Console.WriteLine($"*------------------------------------------------");

            Console.WriteLine($"*       RSquared Score:      {metrics.RSquared:0.##}");
            Console.WriteLine($"*       Root Mean Squared Error:      {metrics.RootMeanSquaredError:#.##}");
            Console.WriteLine($"*       Mean Absolute Error:      {metrics.MeanAbsoluteError:0.##}");
            Console.WriteLine($"*       Mean Squared Error:      {metrics.MeanSquaredError:#.##}");

            // Save the model for later comsumption from end-user apps
            using (
                var file = File.OpenWrite(outputModelPath))
            {
                mlContext.Model.Save(model, trainingDataView.Schema, file);
            }
        }


        public static void CreatePredictionOnlineGradient(MLContext mlContext, string dataPath, string outputModelPath, string algorithm = "")
        {
            var trainingDataView = mlContext.Data.LoadFromTextFile<StockDataInput>(path: dataPath, hasHeader: true, separatorChar: ',');


            var trainer = mlContext.Regression.Trainers.OnlineGradientDescent(labelColumnName: "Close", numberOfIterations: 100);
            var pipeline = mlContext.Transforms.CustomMapping(new
                                            DateToFloatCustomAction().GetMapping(), contractName: "DateToFloat")
                                .AppendCacheCheckpoint(mlContext)
                                .Append(mlContext.Transforms.Concatenate("Features", new[] { "DateFloat", "Volume", "Open", "High", "Low" }))
                                .Append(mlContext.Transforms.NormalizeMinMax("Features"))
                                .Append(trainer);





            //var trainingPipeline = mlContext.Transforms.Concatenate("Features",  new[] {  "open", "high", "low", "close" })
            //    .Append(mlContext.Transforms.CopyColumns("Label", inputColumnName: "close")).Append(trainerSDCA);


            // Train the model
            ITransformer model = pipeline.Fit(trainingDataView);

            mlContext.ComponentCatalog.RegisterAssembly(typeof(
                    DateToFloatCustomAction).Assembly);

            var prediction = model.Transform(trainingDataView);
            var metrics = mlContext.Regression.Evaluate(prediction, "Close", "Score");


            Console.WriteLine();
            Console.WriteLine($"*************************************************");
            Console.WriteLine($"*       Model quality metrics evaluation         ");
            Console.WriteLine($"*------------------------------------------------");

            Console.WriteLine($"*       RSquared Score:      {metrics.RSquared:0.##}");
            Console.WriteLine($"*       Root Mean Squared Error:      {metrics.RootMeanSquaredError:#.##}");
            Console.WriteLine($"*       Mean Absolute Error:      {metrics.MeanAbsoluteError:0.##}");
            Console.WriteLine($"*       Mean Squared Error:      {metrics.MeanSquaredError:#.##}");


            // Save the model for later comsumption from end-user apps
            using (
                var file = File.OpenWrite(outputModelPath))
            {
                mlContext.Model.Save(model, trainingDataView.Schema, file);
            }
        }


        public static PredictionResult TestPrediction(MLContext mlContext, StockData input, string outputModelPath)
        {
            Console.WriteLine("Testing Forecast model");

            // Read the model that has been previously saved by the method SaveModel

            ITransformer trainedModel;

            using (var stream = File.OpenRead(outputModelPath))
            {
                trainedModel = mlContext.Model.Load(stream, out var modelSchema);

            }

            var predictionEngine = mlContext.Model.CreatePredictionEngine<StockData, PredictionResult>(trainedModel);

            Console.WriteLine("** Testing Model **");

            // Predict the nextperiod/month forecast to the one provided

            PredictionResult prediction = predictionEngine.Predict(input);
            Console.WriteLine($"Date: {input.Date}, Forecast Prediction (high): {prediction.Score}");
            Console.WriteLine("done");
            return prediction;

        }
    }


}
