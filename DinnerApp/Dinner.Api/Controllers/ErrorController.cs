
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace Dinner.Api.Controllers
{
    
    public class ErrorController : ControllerBase
    {
        [Route("/error")]
        public IActionResult Error()
        {
            Exception? exception = HttpContext.Features.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerFeature>()?.Error;

            return Problem(detail: exception?.Message, statusCode: (int)HttpStatusCode.BadRequest);

        }
    }
}