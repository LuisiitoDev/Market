using luigiDev.Market.Entities;
using luiguiDev.Market.Business.UserBusiness;
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
    public class UserController : ControllerBase
    {
        readonly IUserBusiness userBusiness;
        public UserController(IUserBusiness userBusiness)
        {
            this.userBusiness = userBusiness;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody]User user)
        {
            try
            {
                return Ok(await userBusiness.CreateUserAsync(user));
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [Route("Delete/{userId}")]
        public async Task<IActionResult> Delete(Guid userId)
        {
            try
            {
                return Ok(await userBusiness.DeleteUserAsync(userId));
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromHeader]string email, [FromHeader]string password)
        {
            try
            {
                return Ok(await userBusiness.LoginUserAsync(email, password));
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
