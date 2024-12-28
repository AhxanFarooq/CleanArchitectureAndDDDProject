using Microsoft.Extensions.DependencyInjection;
using Dinner.Application.Services.Authentication;

namespace Dinner.Application;
public static class ApplicationDependencies{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        return services;
    }
}