using luigiDev.Market.Entities;
using luigiDev.Market.Entities.DBConfig;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace luigiDev.Market.DataAccess.StoreRepository
{
    public class StoreService : IStoreService
    {
        readonly StoreMongoContext _context;
        public StoreService(IOptions<MongoSettings> options)
        {
            _context = new StoreMongoContext(options);
        }
        public async Task<bool> CreateStore(Store store)
        {
            await _context.Stores.InsertOneAsync(store);
            return true;
        }

        public async Task<bool> DeleteStore(Guid storeId)
        {
            var filter = Builders<Store>.Filter.Eq("StoreId",storeId);
            var actionResult = await _context.Stores.DeleteOneAsync(filter);
            return actionResult.IsAcknowledged && actionResult.DeletedCount > 0;
        }

        public async Task<IEnumerable<Store>> GetStores()
        {
            return await _context.Stores.Find(_ => true).ToListAsync();
        }

        public async Task<bool> UpdateStore(Store store)
        {
            var updateResult = await _context.Stores.ReplaceOneAsync(x => x.StoreId.Equals(store.StoreId), store, new UpdateOptions { IsUpsert = true });
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}
