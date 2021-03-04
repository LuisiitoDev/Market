using luigiDev.Market.DataAccess.UserRepository;
using luigiDev.Market.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace luiguiDev.Market.Business.UserBusiness
{
    public class UserBusiness : IUserBusiness
    {
        readonly IUserService userService;
        public UserBusiness(IUserService userService)
        {
            this.userService = userService;
        }
        public async Task<bool> CreateUserAsync(User user)
        {
            try
            {
                return await userService.CreateUserAsync(user);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> DeleteUserAsync(Guid userId)
        {
            try
            {
                return await userService.DeleteUserAsync(userId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<User> LoginUserAsync(string email, string password)
        {
            try
            {
                return await userService.LoginUserAsync(email, password);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
