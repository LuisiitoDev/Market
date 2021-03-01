using luigiDev.Market.Entities;
using luiguiDev.Market.Business.ProductBusiness;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace luigiDev.Market.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        readonly IProductBusiness productBusiness;
        public ProductController(IProductBusiness productBusiness)
        {
            this.productBusiness = productBusiness;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] Product product)
        {
            try
            {
                return Ok(await productBusiness.CreateProductAsync(product));
            }
            catch (Exception)
            {
                return StatusCode(statusCode: (int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [Route("Delete/{productId}")]
        public async Task<IActionResult> Delete(Guid productId)
        {
            try
            {
                return Ok(await productBusiness.DeleteProductAsync(productId));
            }
            catch (Exception)
            {
                return StatusCode(statusCode: (int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        [Route("{productId}")]
        public async Task<IActionResult> GetProductById(Guid productId)
        {
            try
            {
                return Ok(await productBusiness.GetProductoByIdAsync(productId));
            }
            catch (Exception)
            {
                return StatusCode(statusCode: (int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        [Route("Store/{storeId}")]
        public async Task<IActionResult> GetProductsStore(Guid storeId)
        {
            try
            {
                return Ok(await productBusiness.GetProductStoreAsync(storeId));
            }
            catch (Exception)
            {
                return StatusCode(statusCode: (int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                return Ok(await productBusiness.GetProductsAsync());
            }
            catch (Exception)
            {
                return StatusCode(statusCode: (int)HttpStatusCode.InternalServerError);
            }
        }

    }
}
