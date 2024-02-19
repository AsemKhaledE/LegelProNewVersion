using Microsoft.AspNetCore.Mvc;

namespace LegelProNewVersion.Controllers
{
    public class ErrorController : Controller
    {
        [HttpGet("/Error/AccessDenied")]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
