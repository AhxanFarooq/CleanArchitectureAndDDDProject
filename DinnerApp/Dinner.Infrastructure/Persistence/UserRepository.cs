using Dinner.Application.Common.Interface.Persistence;
using Dinner.Domain.Entities;

namespace Dinner.Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
       public static List<User> Users = new();
        public void CreateUserAsync(User user)
        {
            Users.Add(user);
        }
        public User? GetUserByEmailAsync(string email)
        {
            return Users.SingleOrDefault(x => x.Email == email);
        }
    }
}