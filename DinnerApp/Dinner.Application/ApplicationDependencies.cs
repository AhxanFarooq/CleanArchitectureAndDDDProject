using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;

namespace Dinner.Application;
public static class ApplicationDependencies{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        return services;
    }
}