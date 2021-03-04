using luigiDev.Market.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace luigiDev.Market.DataAccess.UserRepository
{
    public interface IUserService
    {
        Task<bool> CreateUserAsync(User user);
        Task<bool> DeleteUserAsync(Guid userId);
        Task<User> LoginUserAsync(string email, string password);
    }
}
