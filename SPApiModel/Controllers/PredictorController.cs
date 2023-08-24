
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SPApiCore.Model;
using SPDataService.Services;
using SPTrainer.Models;
using System;

namespace SPApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PredictorController : ControllerBase
    {
        private readonly ILogger<PredictorController> _logger;

        public PredictorController(ILogger<PredictorController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public Prediction Get(Symbol ticker)
        {

            var stockData = new StockData()
            {
                Date = DateTime.Now.ToString("MM/dd/yyyy"),
                Open = (long)ticker.Open,
                High = (long)ticker.High,
                Low = (long)ticker.Low,
                Close = (long)ticker.Close,
                Volume = ticker.Volume
            };

            return PredictionService.RunAllPredictions(stockData);

        }
    } 
}
