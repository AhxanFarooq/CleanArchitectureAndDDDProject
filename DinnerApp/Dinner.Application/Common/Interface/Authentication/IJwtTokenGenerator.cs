using Dinner.Domain.Entities;

namespace Dinner.Application.Common.Interface.Authentication
{
    public interface IJwtTokenGenerator
    {
        Task<string> GenerateToken(User user, string role);
    }
}