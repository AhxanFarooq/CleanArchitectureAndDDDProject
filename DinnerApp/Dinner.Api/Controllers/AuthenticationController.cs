using Microsoft.AspNetCore.Mvc;
using Dinner.Contracts.Authentication;
using DinnerApp.Application.Authentication.Commands.Register;
using MediatR;
using Dinner.Application.Authentication.Queries.Login;
using MapsterMapper;

namespace Dinner.Api.Controllers
{
    
    [Route("auth")]
    public class AuthenticationController(IMediator mediator, IMapper mapper) : BaseController
    {
        private readonly IMediator _mediator = mediator;
        private readonly IMapper _mapper = mapper;
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var registerCommand = _mapper.Map<RegisterCommand>(request);
            //var registerCommand = new RegisterCommand(request.Email, request.Password, request.FirstName, request.LastName);
            var register = await _mediator.Send(registerCommand);
            return register.Match(
                register => Ok(_mapper.Map<AuthenticationResponse>(register)),
                error => Problem(error)
            );
             
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var loginCommand = _mapper.Map<LoginQuery>(request);  
            // loginCommand = new LoginCommand(request.Email, request.Password);
            var login = await _mediator.Send(loginCommand);
            return login.Match(
                login => Ok(_mapper.Map<AuthenticationResponse>(login)),
                error => Problem(error)
            );
        }
    }
}