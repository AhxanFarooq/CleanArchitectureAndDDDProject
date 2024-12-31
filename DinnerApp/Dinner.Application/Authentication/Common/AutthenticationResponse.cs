using Dinner.Domain.Entities;

namespace Dinner.Application.Authentication.Common;

public record AuthenticationResponse(User User, string Token);