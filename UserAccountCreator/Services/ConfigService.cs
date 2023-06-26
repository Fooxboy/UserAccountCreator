using LiteDB;
using System.Collections.Generic;
using UserAccountCreator.Models;

namespace UserAccountCreator.Services
{
    public class ConfigService
    {
        private string _dbPath => "config.db";

        public Config GetConfig()
        {
            using(var db = new LiteDatabase(_dbPath))
            {
                var collections = db.GetCollection<Config>("config");

                if(collections.Count() == 0)
                {
                    var config = new Config() { Login = "", DCs = new List<string>() };
                    collections.Insert(config);

                    return config;
                }
                return collections.Query().FirstOrDefault();
            }
        }

        public void SetConfig(Config config)
        {
            using(var db = new LiteDatabase(_dbPath))
            {
                var collections = db.GetCollection<Config>("config");
                collections.Update(config);
            }
        }
    }
}
