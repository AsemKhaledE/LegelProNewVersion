using Microsoft.AspNetCore.Mvc;

namespace LegelProNewVersion.Controllers
{
    public class RolesController : Controller
    {
        public IActionResult EmployeeRoles()
        {
            return View();
        }
        public IActionResult SubDepartmentRoles()
        {
            return View();
        }
    }
}
