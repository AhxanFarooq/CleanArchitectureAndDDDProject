using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dinner.Api.Controllers
{
    [Route("[controller]")]
    [Authorize]
    public class DinnerController: BaseController{
        [Route("GetDinner")]
        [HttpGet]
        public IActionResult GetDinner(){
            return Ok("Dinner");
        }
    }
}