using Dinner.Application.Authentication.Common;
using Dinner.Application.Common.Interface.Authentication;
using Dinner.Application.Common.Interface.Persistence;
using ErrorOr;
using Dinner.Domain.Common.Errors;
using MediatR;
using Dinner.Domain.Entities;

namespace Dinner.Application.Authentication.Queries.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, ErrorOr<AuthenticationResponse>>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public LoginCommandHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<ErrorOr<AuthenticationResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        // Check whether user exists in the database
    
        if (await _userRepository.GetUserByEmailAsync(request.email) is not User user)
        {
            return Errors.User.InvalidCredentials;
        }

        //Validate password
        if(user.Password != request.password)
        {
            return Errors.User.InvalidPassword;
        }

        //Generate Toke using jwt token generator

        var token = await _jwtTokenGenerator.GenerateToken(user, "Admin");

        return new AuthenticationResponse
        (
            user,
            token
        );
    }
}