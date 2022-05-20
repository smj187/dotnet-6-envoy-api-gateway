using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace ProtectedService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProtectedController : ControllerBase
    {
        [HttpGet]
        [Route("user")]
        public IActionResult User()
        {
            var user = AuthenticationHeaderValue.Parse(Request.Headers["x-current-user"]);
            return Ok($"Hello {user}!");
        }

        [HttpGet]
        [Route("private")]
        public IActionResult Private() => Ok("private");
    }
}