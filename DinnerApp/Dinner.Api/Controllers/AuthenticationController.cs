using Microsoft.AspNetCore.Mvc;
using Dinner.Contracts.Authentication;
using Dinner.Application.Services.Authentication;

namespace Dinner.Api.Controllers
{
    
    [Route("auth")]
    public class AuthenticationController(IAuthenticationService authenticationService) : BaseController
    {
        private readonly IAuthenticationService _authenticationService = authenticationService;


        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            var register = _authenticationService.RegisterAsync(request.Email, request.Password, request.FirstName, request.LastName);
            return register.Match(
                register => Ok(new AuthenticationResponse(register.User.Email, register.User.FirstName, register.User.LastName, register.Token, register.User.Id)),
                error => Problem(error)
            );
             
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var login =  _authenticationService.LoginAsync(request.Email, request.Password);
            return login.Match(
                login => Ok(new AuthenticationResponse(login.User.Email, login.User.FirstName, login.User.LastName, login.Token, login.User.Id)),
                error => Problem(error)
            );
        }
    }
}