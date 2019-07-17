using Microsoft.AspNetCore.Mvc;

namespace www.Controllers
{
    [Route("[controller]")]
    public class StuffController : Controller
    {
        [HttpGet]
        public IActionResult Index() {
            return Ok();
        }
    }
}