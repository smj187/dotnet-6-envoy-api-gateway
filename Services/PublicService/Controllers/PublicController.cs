using Microsoft.AspNetCore.Mvc;

namespace PublicService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PublicController : ControllerBase
    {
        [HttpGet]
        public IActionResult Public() => Ok("this public endpoint is rate limited by envoy");
    }
}