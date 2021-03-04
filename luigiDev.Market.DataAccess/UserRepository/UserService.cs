using luigiDev.Market.Entities;
using luigiDev.Market.Entities.DBConfig;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace luigiDev.Market.DataAccess.UserRepository
{
    public class UserService : IUserService
    {
        readonly UserMongoContext _context;
        public UserService(IOptions<MongoSettings> options)
        {
            _context = new UserMongoContext(options);
        }
        public async Task<bool> CreateUserAsync(User user)
        {
            await _context.Users.InsertOneAsync(user);
            return true;
        }

        public async Task<bool> DeleteUserAsync(Guid userId)
        {
            var builder = Builders<User>.Filter.Eq("UserId", userId);
            var actionResult = await _context.Users.DeleteOneAsync(builder);
            return actionResult.IsAcknowledged && actionResult.DeletedCount > 0;
        }

        public async Task<User> LoginUserAsync(string email, string password)
        {
            var filterEmail = Builders<User>.Filter.Eq("Email", email);
            var filterPassword = Builders<User>.Filter.Eq("password", password);
            return await _context.Users.Find(Builders<User>.Filter.And(filterEmail,filterPassword)).FirstOrDefaultAsync();
        }
    }
}
