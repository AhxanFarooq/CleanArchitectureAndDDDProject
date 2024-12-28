namespace Dinner.Contracts.Authentication
{
    public record AuthenticationResponse(string Email, string FirstName, string LastName, string Token, Guid Id);
}