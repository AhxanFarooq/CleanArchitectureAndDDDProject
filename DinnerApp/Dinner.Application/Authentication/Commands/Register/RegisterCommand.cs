using Dinner.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace DinnerApp.Application.Authentication.Commands.Register
{
    public record RegisterCommand(string email, string password, string firstName, string lastName) : IRequest<ErrorOr<AuthenticationResponse>>;
    
}