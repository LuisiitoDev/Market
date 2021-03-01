using luigiDev.Market.DataAccess.ProductRepository;
using luigiDev.Market.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace luiguiDev.Market.Business.ProductBusiness
{
    public class ProductBusiness : IProductBusiness
    {
        readonly IProductService productService;
        public ProductBusiness(IProductService productService)
        {
            this.productService = productService;
        }

        public async Task<bool> CreateProductAsync(Product product)
        {
            try
            {
                return await productService.CreateProductAsync(product);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> DeleteProductAsync(Guid productoId)
        {
            try
            {
                return await productService.DeleteProductAsync(productoId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Product> GetProductoByIdAsync(Guid productoId)
        {
            try
            {
                return await productService.GetProductoByIdAsync(productoId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            try
            {
                return await productService.GetProductsAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Product>> GetProductStoreAsync(Guid storeId)
        {
            try
            {
                return await productService.GetProductStoreAsync(storeId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> UpdateProductAsync(Product product)
        {
            try
            {
                return await productService.UpdateProductAsync(product);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
