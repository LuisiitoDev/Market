using luigiDev.Market.Entities;
using luigiDev.Market.Entities.DBConfig;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace luigiDev.Market.DataAccess.StoreRepository
{
    public class StoreMongoContext
    {
        readonly IMongoDatabase _database;
        public StoreMongoContext(IOptions<MongoSettings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(options.Value.DataBase);
        }

        public IMongoCollection<Store> Stores => _database.GetCollection<Store>(nameof(Store));
    }
}
