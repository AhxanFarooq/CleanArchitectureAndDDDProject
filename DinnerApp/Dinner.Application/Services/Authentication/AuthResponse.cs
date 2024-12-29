using Dinner.Domain.Entities;

namespace Dinner.Application.Services.Authentication
{
    public record AuthResponse(User User, string Token);
}