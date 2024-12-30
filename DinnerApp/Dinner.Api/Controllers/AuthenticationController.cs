using Microsoft.AspNetCore.Mvc;
using Dinner.Contracts.Authentication;
using Dinner.Application.Services.Authentication;
using Dinner.Api.Filters;

namespace Dinner.Api.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthenticationController(IAuthenticationService authenticationService) : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService = authenticationService;


        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            var register = _authenticationService.RegisterAsync(request.Email, request.Password, request.FirstName, request.LastName);
            return Ok(new AuthenticationResponse(register.User.Email, register.User.FirstName, register.User.LastName, register.Token, register.User.Id));
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var login =  _authenticationService.LoginAsync(request.Email, request.Password);
            return Ok(new AuthenticationResponse(login.User.Email, login.User.FirstName, login.User.LastName, login.Token, login.User.Id));
        }
    }
}