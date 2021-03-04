using luigiDev.Market.Entities;
using luigiDev.Market.Entities.DBConfig;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace luigiDev.Market.DataAccess.ProductRepository
{
    public class ProductService : IProductService
    {
        readonly ProductMongoContext _context;
        public ProductService(IOptions<MongoSettings> options)
        {
            _context = new ProductMongoContext(options);
        }

        public async Task<bool> CreateProductAsync(Product product)
        {
            await _context.Products.InsertOneAsync(product);
            return true;
        }

        public async Task<bool> DeleteProductAsync(Guid productoId)
        {
            var actionResult = await _context.Products.DeleteOneAsync(Builders<Product>.Filter.Eq("ProductId", productoId));
            return actionResult.IsAcknowledged && actionResult.DeletedCount > 0;
        }

        public async Task<Product> GetProductoByIdAsync(Guid productoId)
        {
            var filter = Builders<Product>.Filter.Eq("ProductId", productoId);
            return await _context.Products.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _context.Products.Find(_ => true).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductStoreAsync(Guid storeId)
        {
            var filter = Builders<Product>.Filter.Eq("StoreId", storeId);
            return await _context.Products.Find(filter).ToListAsync();
        }

        public async Task<bool> UpdateProductAsync(Product product)
        {
            var updateResult = await _context.Products.ReplaceOneAsync(x => x.ProductId.Equals(product.ProductId), product, new UpdateOptions { IsUpsert = true });
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}
