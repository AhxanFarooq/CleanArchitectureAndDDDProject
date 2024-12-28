namespace Dinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    public AuthResponse LoginAsync(string email, string password)
    {
        return new AuthResponse
        {
            Email = email,
            FirstName = "John",
            LastName = "Doe",
            Id = Guid.NewGuid(),
            Token = "token"
        };
    }

    public AuthResponse RegisterAsync(string email, string password, string firstName, string lastName)
    {
        return new AuthResponse
        {
            Email = email,
            FirstName = firstName,
            LastName = lastName,
            Id = Guid.NewGuid(),
            Token = "token"
        };
    }
}