using Dinner.Application.Common.Interface.Authentication;

namespace Dinner.Application.Services.Authentication;

public class AuthenticationService(IJwtTokenGenerator jwtTokenGenerator) : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator = jwtTokenGenerator;
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
        //Generate Toke using jwt token generator
        var token = _jwtTokenGenerator.GenerateToken(Guid.NewGuid(), email, "John", "Doe", "Admin");
        return new AuthResponse
        {
            Email = email,
            FirstName = firstName,
            LastName = lastName,
            Id = Guid.NewGuid(),
            Token = token
        };
    }
}