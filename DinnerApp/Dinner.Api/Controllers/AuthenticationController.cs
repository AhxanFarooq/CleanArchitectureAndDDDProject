using Microsoft.AspNetCore.Mvc;
using Dinner.Contracts.Authentication;
using DinnerApp.Application.Authentication.Commands.Register;
using MediatR;
using Dinner.Application.Authentication.Queries.Login;

namespace Dinner.Api.Controllers
{
    
    [Route("auth")]
    public class AuthenticationController(IMediator mediator) : BaseController
    {
        private readonly IMediator _mediator = mediator;
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var registerCommand = new RegisterCommand(request.Email, request.Password, request.FirstName, request.LastName);
            var register = await _mediator.Send(registerCommand);
            return register.Match(
                register => Ok(new AuthenticationResponse(register.User.Email, register.User.FirstName, register.User.LastName, register.Token, register.User.Id)),
                error => Problem(error)
            );
             
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var loginCommand = new LoginCommand(request.Email, request.Password);
            var login = await _mediator.Send(loginCommand);
            return login.Match(
                login => Ok(new AuthenticationResponse(login.User.Email, login.User.FirstName, login.User.LastName, login.Token, login.User.Id)),
                error => Problem(error)
            );
        }
    }
}