using Dinner.Application.Authentication.Common;
using Dinner.Application.Common.Interface.Authentication;
using Dinner.Application.Common.Interface.Persistence;
using Dinner.Domain.Entities;
using DinnerApp.Application.Authentication.Commands.Register;
using ErrorOr;
using Dinner.Domain.Common.Errors;
using MediatR;

namespace Dinner.Application.Authentication.Commands.Register;

public class RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository) : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResponse>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator = jwtTokenGenerator;
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<ErrorOr<AuthenticationResponse>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        // Check whether user exists in the database
        if (await _userRepository.GetUserByEmailAsync(request.email) is not null)
        {
            return Errors.Authentication.DuplicateEmail;
        }

        //Create user
        var user = new User
        {
            Email = request.email,
            Password = request.password,
            FirstName = request.firstName,
            LastName = request.lastName
        };
        await _userRepository.CreateUserAsync(user);

        //Generate Toke using jwt token generator
        var token = await _jwtTokenGenerator.GenerateToken(user, "Admin");
        return new AuthenticationResponse(user,token);
    }
}