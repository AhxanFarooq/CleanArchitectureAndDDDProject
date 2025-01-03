using System.Net;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Dinner.Api.Controllers
{
    [ApiController]
    public class BaseController: ControllerBase
    {
        [Route("/Problem")]
        public IActionResult Problem(List<Error> errors)
        {
            if(errors.Count == 0)
            {
                return Problem();
            }
            if(errors.All(e=>e.Type == ErrorType.Validation))
            {
                
                return ValidationProblem(errors);
            }
            var firstError = errors.FirstOrDefault();
            return Problem(firstError);
        }

        private IActionResult ValidationProblem(List<Error> errors)
        {
            var modelDictionary = new ModelStateDictionary();
                foreach(var error in errors)
                {
                    modelDictionary.AddModelError(error.Code, error.Description);
                }
            return ValidationProblem(modelDictionary);
        }
        private IActionResult Problem(Error error)
        {
            
            var statusCode = error.Type switch
            {
                ErrorType.Validation => (int)HttpStatusCode.BadRequest,
                ErrorType.Conflict => (int)HttpStatusCode.Conflict,
                ErrorType.NotFound => (int)HttpStatusCode.NotFound,
                ErrorType.Unauthorized => (int)HttpStatusCode.Unauthorized,
                ErrorType.Forbidden => (int)HttpStatusCode.Forbidden,
                _ => (int)HttpStatusCode.InternalServerError
            };
            return Problem(statusCode: statusCode, detail: error.Description);
        }
    }
}