using Microsoft.AspNetCore.Mvc;

namespace LegelProNewVersion.Controllers
{
    public class BasicInformationController : Controller
    {
        [PermissionAuthorize(PermissionConstants.ViewClients)]
        public IActionResult Client()
        {
            return View();
        }
        [PermissionAuthorize(PermissionConstants.ViewBranches)]
        public IActionResult Branches()
        {
            return View();
        }
        [PermissionAuthorize(PermissionConstants.ViewTypesOfMail)]
        public IActionResult TypesOfMail()
        {
            return View();
        }
        [PermissionAuthorize(PermissionConstants.ViewRegions)]
        public IActionResult Region()
        {
            return View();
        }
        [PermissionAuthorize(PermissionConstants.ViewJobs)]
        public IActionResult Job()
        {
            return View();
        }
        [PermissionAuthorize(PermissionConstants.ViewEntities)]
        public IActionResult Entities()
        {
            return View();
        }
        [PermissionAuthorize(PermissionConstants.ViewDepartments)]
        public IActionResult Management()
        {
            return View();
        }
        [PermissionAuthorize(PermissionConstants.ViewMailers)]
        public IActionResult Mailers()
        {
            return View();
        }       
        [PermissionAuthorize(PermissionConstants.ViewTheImportanceOfMail)]
        public IActionResult TheImportanceOfMail()
        {
            return View();
        }
    }
}
