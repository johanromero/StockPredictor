using Microsoft.EntityFrameworkCore;
using SPDAO.Models;
using StockPredictor.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SPDAO.Helpers
{
    public class UserHelper
    {
        public StockPredictorDbContext ExtContext { get; set; }
        public InMemoryDbContext IntContext { get; set; }

        public UserHelper()
        {
            ExtContext = new StockPredictorDbContext(StockPredictorDbContext.Configuration);
            IntContext = null;
        }

        public UserHelper(InMemoryDbContext context)
        {
            IntContext = context;
            ExtContext = null;
        }

        public User GetUserByUsername(string username)
        {
            if (ExtContext != null && IntContext == null)
            {
                return ExtContext.Users.FirstOrDefault(m => m.Username == username);
            }
            else
            {
                return IntContext.Users.FirstOrDefault(m => m.Username == username);
            }
        }

        public bool SetUser(User user)
        {
            var checkuser = GetUserByUsername(user.Username);
            if (checkuser != null && checkuser.Username == user.Username)
            {
                return false;
            }
            else
            {
                user.CreationDate = DateTime.Now;
                if (ExtContext != null && IntContext == null)
                {
                    ExtContext.Users.Add(user);
                    return ExtContext.SaveChanges() > 0;
                }
                else
                {
                    IntContext.Users.Add(user);
                    return IntContext.SaveChanges() > 0;
                }
            }
        }

        public List<UserPrediction> GetUserUserPredictions(string username)
        {
            if (ExtContext != null && IntContext == null)
            {
                return ExtContext.UserPredictions.Where(m => m.User.Username == username).ToList();
            }
            else
            {
                return IntContext.UserPredictions.Where(m => m.User.Username == username).ToList();
            }
        }

        public List<UserPrediction> GetAnonymousUserPredictions()
        {
            return GetUserUserPredictions("anonymous");
        }

        public List<User> GetUsers()
        {
            if (ExtContext != null && IntContext == null)
            {
                return ExtContext.Users.ToList();
            }
            else
            {
                return IntContext.Users.ToList();
            }
        }
    }
}
