using SPDAO.Models;
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
    public class UserPredictionHelper
    {
        public StockPredictorDbContext ExtContext { get; set; }
        public InMemoryDbContext IntContext { get; set; }

        public UserPredictionHelper()
        {
            ExtContext = new StockPredictorDbContext(StockPredictorDbContext.Configuration);
            IntContext = null;
        }

        public UserPredictionHelper(InMemoryDbContext context)
        {
            IntContext = context;
            ExtContext = null;
        }

        public UserPrediction GetUserPredictionByTicker(string ticker)
        {
            if (ExtContext != null && IntContext == null)
            {
                return ExtContext.UserPredictions.LastOrDefault(m => m.Ticker == ticker);
            }
            else
            {
                return IntContext.UserPredictions.LastOrDefault(m => m.Ticker == ticker);
            }
        }

        public bool SetUserPrediction(
            UserPrediction UserPrediction, string username)
        {
            UserPrediction.CreationDate = DateTime.Now;

            if (ExtContext != null && IntContext == null)
            {
                UserHelper uh = new UserHelper();

                var usr = uh.GetUserByUsername(username);
                UserPrediction.User = usr;
                var e = ExtContext.Entry<UserPrediction>(UserPrediction).Entity;

                e.User = usr;
                ExtContext.UserPredictions.Attach(e).State = EntityState.Added;

                return ExtContext.SaveChanges() > 0;
            }
            else
            {
                var uh = new UserHelper(new InMemoryDbContext());

                var us = uh.GetUserByUsername(username);
                UserPrediction.User = us;

                var e = IntContext.Entry<UserPrediction>(UserPrediction).Entity;

                e.User = us;
                IntContext.UserPredictions.Attach(e).State = EntityState.Added;
                return IntContext.SaveChanges() > 0;
            }
        }

        public bool SetAnonymousUserPrediction(UserPrediction UserPrediction)
        {
            return SetUserPrediction(UserPrediction, "anonymous");
        }

        public List<UserPrediction> GetUserPredictions()
        {
            if (ExtContext != null && IntContext == null)
            {
                return ExtContext.UserPredictions.ToList();
            }
            else
            {
                return IntContext.UserPredictions.ToList();
            }
        }
    }
}
