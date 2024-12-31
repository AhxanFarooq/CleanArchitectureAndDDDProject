using System.Net;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace Dinner.Api.Controllers
{
    [ApiController]
    public class BaseController: ControllerBase
    {
        [Route("/Problem")]
        public IActionResult Problem(List<Error> errors)
        {
            var firstError = errors.FirstOrDefault();
            var statusCode = firstError.Type switch
            {
                ErrorType.Validation => (int)HttpStatusCode.BadRequest,
                ErrorType.Conflict => (int)HttpStatusCode.Conflict,
                ErrorType.NotFound => (int)HttpStatusCode.NotFound,
                ErrorType.Unauthorized => (int)HttpStatusCode.Unauthorized,
                ErrorType.Forbidden => (int)HttpStatusCode.Forbidden,
                _ => (int)HttpStatusCode.InternalServerError
            };
            return Problem(statusCode: statusCode, detail: firstError.Description);
        }
    }
}