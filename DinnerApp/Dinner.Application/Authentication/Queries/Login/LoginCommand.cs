using Dinner.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace Dinner.Application.Authentication.Queries.Login;

public record LoginCommand(string email, string password) : IRequest<ErrorOr<AuthenticationResponse>>;