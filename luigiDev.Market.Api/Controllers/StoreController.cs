using luigiDev.Market.Entities;
using luiguiDev.Market.Business.StoreBusiness;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace luigiDev.Market.Api.Controllers
{
    /// <summary>
    /// This api allows to process transactions related to the Store
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        readonly IStoreBusiness storeBusiness;
        public StoreController(IStoreBusiness storeBusiness)
        {
            this.storeBusiness = storeBusiness;
        }

        /// <summary>
        /// Creates the specified store.
        /// </summary>
        /// <param name="store">The store.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Store store)
        {
            try
            {
                return Ok(await storeBusiness.CreateStore(store));
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Updates the specified store.
        /// </summary>
        /// <param name="store">The store.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> UpdateStore([FromBody]Store store)
        {
            try
            {
                return Ok(await storeBusiness.UpdateStore(store));
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Gets the stores.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetStores()
        {
            try
            {
                return Ok(await storeBusiness.GetStores());
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
