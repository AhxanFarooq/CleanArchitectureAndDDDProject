using Dinner.Application.Authentication.Queries.Login;
using Dinner.Contracts.Authentication;
using DinnerApp.Application.Authentication.Commands.Register;
using Mapster;

namespace Dinner.Api.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RegisterRequest, RegisterCommand>();

            config.NewConfig<LoginRequest, LoginQuery>();

            config.NewConfig<Dinner.Application.Authentication.Common.AuthenticationResponse, AuthenticationResponse>()
                .Map(dest=>dest.Token, src=>src.Token)
                .Map(dest=>dest, src=>src.User);
           
        }
    }
}