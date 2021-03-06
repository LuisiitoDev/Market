using luigiDev.Market.DataAccess.ProductRepository;
using luigiDev.Market.DataAccess.StoreRepository;
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
        readonly IStoreService storeService;
        public ProductBusiness(IProductService productService, IStoreService storeService)
        {
            this.productService = productService;
            this.storeService = storeService;
        }

        public async Task<(bool created, string errorMessage)> CreateProductAsync(Product product)
        {
            try
            {
                if (await storeService.ExistsStore(product.StoreId))
                {
                    var storeCreated = await productService.CreateProductAsync(product);
                    return (storeCreated, string.Empty);
                }

                return (false, "The store does not exist, please verify the store");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<(bool deleted, string errorMessage)> DeleteProductAsync(Guid productoId)
        {
            try
            {
                var Product = await productService.GetProductoByIdAsync(productoId);

                if (Product != null)
                {
                    var deleted = await productService.DeleteProductAsync(productoId);
                    return (deleted, string.Empty);
                }

                return (false, "The product that you want to delete, does not exist");
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

        public async Task<(bool updated, string errorMessage)> UpdateProductAsync(Product product)
        {
            try
            {
                var Product = await productService.GetProductoByIdAsync(product.ProductId);

                if (Product != null)
                {
                    var updated = await productService.UpdateProductAsync(product);
                    return (updated, string.Empty);
                }

                return (false, "The product that you want to update, does not exist");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
