using core;
using Microsoft.AspNetCore.Mvc;

namespace www.Controllers
{
    [Route("[controller]")]
    public class StuffController : Controller
    {
        IStuffHolder stuffHolder;

        public StuffController(IStuffHolder stuffHolder) {
            this.stuffHolder = stuffHolder;
        }

        [HttpGet]
        public IActionResult Index() {
            return Ok(stuffHolder.Get());
        }
    }
}