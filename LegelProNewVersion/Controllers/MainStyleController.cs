using Microsoft.AspNetCore.Mvc;

namespace LegelProNewVersion.Controllers
{
    public class MainStyleController : Controller
    {
        public ActionResult Home()
        {
            ViewBag.ThemeBackgroundColorSidebar=
            ViewBag.Test = "_dashboard";
            return View();
        }
    }
}
