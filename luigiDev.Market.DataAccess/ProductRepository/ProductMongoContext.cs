using luigiDev.Market.Entities;
using luigiDev.Market.Entities.DBConfig;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace luigiDev.Market.DataAccess.ProductRepository
{
    public class ProductMongoContext
    {
        readonly IMongoDatabase _database;
        public ProductMongoContext(IOptions<MongoSettings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(options.Value.DataBase);
        }

        public IMongoCollection<Product> Products => _database.GetCollection<Product>(nameof(Product));
    }
}
