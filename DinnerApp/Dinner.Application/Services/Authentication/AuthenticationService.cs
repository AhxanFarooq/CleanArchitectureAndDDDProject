using Dinner.Application.Common.Interface.Authentication;
using Dinner.Application.Common.Interface.Persistence;
using Dinner.Domain.Entities;

namespace Dinner.Application.Services.Authentication;

public class AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository) : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator = jwtTokenGenerator;
    private readonly IUserRepository _userRepository = userRepository;
    public AuthResponse LoginAsync(string email, string password)
    {
        // Check whether user exists in the database
    
        if (_userRepository.GetUserByEmailAsync(email) is not User user)
        {
            throw new Exception("User not exists");
        }

        //Validate password
        if(user.Password != password)
        {
            throw new Exception("Invalid password");
        }

        //Generate Toke using jwt token generator

        var token = _jwtTokenGenerator.GenerateToken(user, "Admin");

        return new AuthResponse
        (
            user,
            token
        );
    }

    public AuthResponse RegisterAsync(string email, string password, string firstName, string lastName)
    {
        // Check whether user exists in the database
        if ( _userRepository.GetUserByEmailAsync(email) is not null)
        {
            throw new Exception("User already exists");
        }

        //Create user
        var user = new User
        {
            Email = email,
            Password = password,
            FirstName = firstName,
            LastName = lastName
        };
        _userRepository.CreateUserAsync(user);

        //Generate Toke using jwt token generator
        var token = _jwtTokenGenerator.GenerateToken(user, "Admin");
        return new AuthResponse(user,token);
    }
}