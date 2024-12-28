namespace Dinner.Application.Common.Interface.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(Guid userId, string email, string firstName, string lastName, string role);
    }
}