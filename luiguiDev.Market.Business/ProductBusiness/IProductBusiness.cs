using luigiDev.Market.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace luiguiDev.Market.Business.ProductBusiness
{
    public interface IProductBusiness
    {
        Task<bool> CreateProductAsync(Product product);
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<bool> UpdateProductAsync(Product product);
        Task<Product> GetProductoByIdAsync(Guid productoId);
        Task<bool> DeleteProductAsync(Guid productoId);
        Task<IEnumerable<Product>> GetProductStoreAsync(Guid storeId);
    }
}
