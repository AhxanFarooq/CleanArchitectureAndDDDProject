using Dinner.Domain.Entities;

namespace Dinner.Application.Common.Interface.Persistence
{
    public interface IUserRepository
    {
        User? GetUserByEmailAsync(string email);
        void CreateUserAsync(User user);
    }
}