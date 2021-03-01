using luigiDev.Market.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace luigiDev.Market.DataAccess.ProductRepository
{
    public interface IProductService
    {
        Task<bool> CreateProductAsync(Product product);
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<bool> UpdateProductAsync(Product product);
        Task<Product> GetProductoByIdAsync(Guid productoId);
        Task<bool> DeleteProductAsync(Guid productoId);
        Task<IEnumerable<Product>> GetProductStoreAsync(Guid storeId);
    }
}
