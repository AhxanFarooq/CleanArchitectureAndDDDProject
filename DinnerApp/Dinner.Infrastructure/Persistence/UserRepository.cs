using Dinner.Application.Common.Interface.Persistence;
using Dinner.Domain.Entities;

namespace Dinner.Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
       public static List<User> Users = new();
        public Task CreateUserAsync(User user)
        {
            Users.Add(user);
            return Task.CompletedTask;
        }
        public Task<User?> GetUserByEmailAsync(string email)
        {
            return Task.FromResult(Users.SingleOrDefault(x => x.Email == email));
        }
    }
}