using LegelProNewVersion.Models;
using LegelProNewVersion.Repository.Interface;
using LegelProNewVersion.Repository.Service;
using LegelProNewVersion.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using System.Globalization;

namespace LegelProNewVersion.Controllers
{
    public class UserRoleController : Controller
    {
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IStringLocalizer _localizer;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ISubDepartmentRepository _subDepartmentRepository;
        public UserRoleController(IUserRoleRepository userRoleRepository
            , IStringLocalizer<SubDepartRoleController> localizer
            , IDepartmentRepository departmentRepository
            , ISubDepartmentRepository subDepartmentRepository) 
        { 
            _userRoleRepository = userRoleRepository;
            _localizer = localizer;
            _departmentRepository = departmentRepository;
            _subDepartmentRepository = subDepartmentRepository;
        }
        public IActionResult Index()
        {
            var records = _userRoleRepository.GetListUserRoles();
            return View(records);
        }

        public IActionResult GetUserRoleByUserId(int userId, int employeeId)
        {
            var userRole = _userRoleRepository.GetUserRolesWithPages(userId, employeeId);
            return PartialView("_Edit", userRole);
        }

        [HttpPost]
        public IActionResult Edit(UserRoleViewModel viewModel)
        {
            try
            {
                if (viewModel.SelectedPages != null && viewModel.SelectedPages.Any())
                {
                    _userRoleRepository.RemoveUserRolesById(viewModel.UserId, viewModel.EmployeeId);

                    foreach (var selectedPage in viewModel.SelectedPages)
                    {
                        if (selectedPage.IsView &&( selectedPage.IsAdd || selectedPage.IsEdit || selectedPage.IsDetails || selectedPage.IsDelete))
                        {
                            var newRole = new tbl_UserRole
                            {
                                UserId = viewModel.UserId,
                                EmployeeId = viewModel.EmployeeId,
                                DepartmentId = viewModel.DepartmentId,
                                SubDepartmentId = viewModel.SubDepartmentId,
                                IsAdd = selectedPage.IsAdd,
                                IsEdit = selectedPage.IsEdit,
                                IsView = selectedPage.IsView,
                                IsDetails = selectedPage.IsDetails,
                                IsDelete = selectedPage.IsDelete,
                                PageId = selectedPage.PageId,
                            };

                            _userRoleRepository.Add(newRole);
                        }
                    }

                    _userRoleRepository.SaveChanges();
                }

                return RedirectToAction("Index", "UserRole");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while processing your request.");
            }
            return View(viewModel);
        }

        public IActionResult GetDetails(int userId, int employeeId)
        {
            var userRole = _userRoleRepository.GetUserRolesWithPages(userId, employeeId);
            return PartialView("_Details", userRole);
        }

        bool IsSelcte(List<ListPage> SelectedPages, out string Error)
        {
            Error = string.Empty;
            if (SelectedPages == null || !SelectedPages.Any())
            {
                return false;
            }
            bool Result = false;
            int Count = 0;
            foreach (var selectedPage in SelectedPages)
            {
                if (selectedPage.IsView && (selectedPage.IsAdd == false && selectedPage.IsEdit == false && selectedPage.IsDetails == false && selectedPage.IsDelete == false))
                {
                    Error = "lessData";
                    return false;
                }
                else if (selectedPage.IsView == false && (selectedPage.IsAdd == false && selectedPage.IsEdit == false && selectedPage.IsDetails == false && selectedPage.IsDelete == false))
                {
                    Error = "noData";
                    return false;
                }
                else if (selectedPage.IsView == false && (selectedPage.IsAdd == true || selectedPage.IsEdit == true || selectedPage.IsDetails == true || selectedPage.IsDelete == true))
                {
                    Error = "noIsView";
                    return false;
                }
                else
                {
                    Count++;
                }
            }
            if (Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        [HttpPost]
        public IActionResult ValidateSelectedPages(SubDepartmentRoleViewModel viewModel)
        {
            if (viewModel.DepartmentId == 0 || viewModel.SubDepartmentId == 0)
            {
                var errorMessage = CultureInfo.CurrentCulture.Name.StartsWith("ar")
                    ? "برجاء اختيار القسم"
                    : "Please Select Department";

                return Json(new ViewModels.ValidationResult { IsValid = false, ErrorMessage = errorMessage });
            }
            string Error = "";
            bool isValid = IsSelcte(viewModel.SelectedPages, out Error);
            if (Error == "lessData")
            {
                Error = CultureInfo.CurrentCulture.Name.StartsWith("ar")
                  ? "برجاء اضافة صلاحية اخري مع صلاحية المشاهدة"
                  : "Please add another permission With IsView";
                return Json(new ViewModels.ValidationResult { IsValid = false, ErrorMessage = Error });
            }
            else if (Error == "noData")
            {
                Error = CultureInfo.CurrentCulture.Name.StartsWith("ar")
                   ? "برجاء اختيار واحدة على الأقل من الصفحات"
                   : "Please select at least one Of Pages";
                return Json(new ViewModels.ValidationResult { IsValid = false, ErrorMessage = Error });
            }
            else if (Error == "noIsView")
            {
                Error = CultureInfo.CurrentCulture.Name.StartsWith("ar")
                   ? "برجاء اختيار صلاحية المشاهدة اولا ثم اختيار باقي الصلاحيات "
                   : "Please choose the permission to IsView first and then choose the rest of the permissions";
                return Json(new ViewModels.ValidationResult { IsValid = false, ErrorMessage = Error });
            }

            if (isValid)
            {
                return Json(new ViewModels.ValidationResult { IsValid = true });
            }
            else
            {
                var errorMessage = CultureInfo.CurrentCulture.Name.StartsWith("ar")
                    ? "برجاء اختيار واحدة على الأقل من الصفحات"
                    : "Please select at least one Of Pages";
                return Json(new ViewModels.ValidationResult { IsValid = false, ErrorMessage = errorMessage });
            }
        }
    }
}
