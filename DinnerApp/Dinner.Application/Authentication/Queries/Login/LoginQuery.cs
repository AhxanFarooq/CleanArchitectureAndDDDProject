using Dinner.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace Dinner.Application.Authentication.Queries.Login;

public record LoginQuery(string email, string password) : IRequest<ErrorOr<AuthenticationResponse>>;