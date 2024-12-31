using Dinner.Domain.Entities;

namespace Dinner.Application.Common.Interface.Persistence
{
    public interface IUserRepository
    {
        Task<User?> GetUserByEmailAsync(string email);
        Task CreateUserAsync(User user);
    }
}