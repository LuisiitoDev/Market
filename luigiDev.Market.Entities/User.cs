using System;
namespace luigiDev.Market.Entities
{
    public class User
    {
        public Guid UserId = Guid.NewGuid();
        public string FistName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string password { get; set; }
    }
}
