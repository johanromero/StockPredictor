using SPDao;
using SPDomain.Persistent;
using StockPredictor.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.InMemory;
using System.Linq;

namespace SPDAO.Helpers
{
    public class PredictionHelper
    {
        public StockPredictorDbContext ExtContext { get; set; }
        public InMemoryDbContext IntContext { get; set; }

        public PredictionHelper()
        {
            ExtContext = new StockPredictorDbContext(StockPredictorDbContext.Configuration);
            IntContext = null;
        }

        public PredictionHelper(InMemoryDbContext context)
        {
            IntContext = context;
            ExtContext = null;
        }

        public Prediction GetPredictionByTicker(string ticker)
        {
            if (ExtContext != null && IntContext == null)
            {
                return ExtContext.Predictions.LastOrDefault(m => m.Ticker == ticker);
            }
            else
            {
                return IntContext.Predictions.LastOrDefault(m => m.Ticker == ticker);
            }
        }

        public bool SetPrediction(
            Prediction prediction, string username)
        {
            prediction.CreationDate = DateTime.Now;

            if (ExtContext != null && IntContext == null)
            {
                UserHelper uh = new UserHelper();

                var usr = uh.GetUserByUsername(username);
                prediction.User = usr;
                var e = ExtContext.Entry<Prediction>(prediction).Entity;

                e.User = usr;
                ExtContext.Predictions.Attach(e).State = EntityState.Added;

                return ExtContext.SaveChanges() > 0;
            }
            else
            {
                var uh = new UserHelper(new InMemoryDbContext());

                var us = uh.GetUserByUsername(username);
                prediction.User = us;

                var e = IntContext.Entry<Prediction>(prediction).Entity;

                e.User = us;
                IntContext.Predictions.Attach(e).State = EntityState.Added;
                return IntContext.SaveChanges() > 0;
            }
        }

        public bool SetAnonymousPrediction(Prediction prediction)
        {
            return SetPrediction(prediction, "anonymous");
        }

        public List<Prediction> GetPredictions()
        {
            if (ExtContext != null && IntContext == null)
            {
                return ExtContext.Predictions.ToList();
            }
            else
            {
                return IntContext.Predictions.ToList();
            }
        }
    }
}
