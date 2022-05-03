using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SPTrainer.PredictionModels;
using Microsoft.Extensions.Logging;
using SPData.Services;
using SPApiCore.Model;
using SPDAO.Models;
using SPDataService.Services;
using SPTrainer.Models;

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

        [HttpGet]
        public Prediction Get(Symbol ticker)
        {        

            var stockData = new StockData()
            {
                timestamp = ticker.Date,
                open = (float)ticker.Open,
                high = (float)ticker.High,
                low = (float)ticker.Low,
                close = (float)ticker.Close,
                volume = ticker.Volume
            };

            return PredictionService.RunAllPredictions(stockData);

        }
    }
}
