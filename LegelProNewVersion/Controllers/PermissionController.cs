using LegelProNewVersion.Models;
using LegelProNewVersion.Repository.Interface;
using LegelProNewVersion.Repository.Service;
using LegelProNewVersion.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LegelProNewVersion.Controllers
{
    public class PermissionController : Controller
    {
        private readonly IUserPermissionReposetory _userPermissionReposetory;
        private readonly ISystemConfigRepository _systemConfigRepository;

        public PermissionController(IUserPermissionReposetory userPermissionReposetory, ISystemConfigRepository systemConfigRepository)
        {
            _userPermissionReposetory = userPermissionReposetory;
            _systemConfigRepository = systemConfigRepository;
        }
        [PermissionAuthorize(PermissionConstants.ViewManagePermissions)]
        public IActionResult ManagePermissions(int userId)
        {
            var user = _userPermissionReposetory.FindById(userId);
            var allPages = _userPermissionReposetory.ListPage();
            var userPages = _userPermissionReposetory.GetUserPages(userId);
            var selectedPageIds = userPages.Select(up => up.PageId).ToList();
            // Map your domain models to view models

            var viewModel = new UserPagesViewModel
            {
                UserId = user.UserId,
                UserName = user.UserName,
                // Other properties...
                AllPages = allPages.Select(Page => new PageViewModel
                {
                    PageId = Page.PageId,
                    Name = Page.Name,
                    IsSelected = user.tbl_UserPages != null && user.tbl_UserPages.Any(up => up.PageId == Page.PageId)
                }).ToList()
            };
            if (user == null || viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ManagePermissions(UserPagesViewModel model)
        {
            _userPermissionReposetory.ManageUserPagesTransaction(model);
            return  RedirectToAction("Index", "Employee");
        }
       
    }
}
