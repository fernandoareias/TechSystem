

using Microsoft.AspNetCore.Mvc;

namespace TechSystem.Api.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("v1/")]
        public object GetVersion()
        {
            return new { version = "Version 0.0.1v" };
        }
    }
}