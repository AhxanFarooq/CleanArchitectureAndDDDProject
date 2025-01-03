using Dinner.Application.Common.Interface.Authentication;
using Dinner.Application.Common.Interface.Persistence;
using Dinner.Application.Common.Interface.Services;
using Dinner.Infrastructure.Authentication;
using Dinner.Infrastructure.Persistence;
using Dinner.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Dinner.Infrastructure
{
    public static class InfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configurationManager)
        {
            services.AddAuth(configurationManager);
            services.AddScoped<IDateTimeProvider, DateTimeProvider>();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }

        public static IServiceCollection AddAuth(this IServiceCollection services, ConfigurationManager configurationManager)
        {
            JwtSetting jwtSetting = new JwtSetting();
            configurationManager.Bind(JwtSetting.Jwt, jwtSetting);
            services.AddSingleton(Options.Create(jwtSetting));

            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();


            services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = jwtSetting.Issuer,
                        ValidateAudience = true,
                        ValidAudience = jwtSetting.Audience,
                        ValidateLifetime = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSetting.SecretKey)),
                        ValidateIssuerSigningKey = true
                    };
                });
            return services;
        }
    }
}