using LegelProNewVersion.Models;
using LegelProNewVersion.ViewModels;
using LegelProNewVersion.Repository.Interface;
using LegelProNewVersion.Repository.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LegelProNewVersion.Controllers
{
    public class SubDepartRoleController : Controller
    {
        private readonly ISupDepartRoleRepository _supDepartRoleRepository;
        private readonly IStringLocalizer _localizer;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ISubDepartmentRepository _subDepartmentRepository;
        private readonly IPageRepository _pageRepository;
        public SubDepartRoleController(ISupDepartRoleRepository supDepartRoleRepository, IStringLocalizer<SubDepartRoleController> localizer
            , IDepartmentRepository departmentRepository
            , IPageRepository pageRepository
            , ISubDepartmentRepository subDepartmentRepository
            )
        {
            _supDepartRoleRepository = supDepartRoleRepository;
            _localizer = localizer;
            _departmentRepository = departmentRepository;
            _pageRepository = pageRepository;
            _subDepartmentRepository = subDepartmentRepository;
        }
        public IActionResult Index()
        {


            var records = _supDepartRoleRepository.GetSubDepartRoles();
            return View(records);
        }
        public IActionResult ViewCreate()
        {
            var currentCulture = CultureInfo.CurrentCulture.Name.StartsWith("ar");
            if (currentCulture == true)
            {
                ViewBag.Departments = new SelectList(_departmentRepository.List().Where(x => x.ApproveStatusId == 2 && x.DepartmentId > 2), "DepartmentId", "DepartmentArabicName");

            }
            else
            {
                ViewBag.Departments = new SelectList(_departmentRepository.List().Where(x => x.ApproveStatusId == 2 && x.DepartmentId > 2), "DepartmentId", "DepartmentEnglishName");
            }
            var allPagesTblPages = _pageRepository.ListPages();
            var allPagesListPage = _pageRepository.ListPagesVM(allPagesTblPages);
            var model = new SubDepartmentRoleViewModel
            {
                SelectedPages = allPagesListPage
            };
            return PartialView("_SubDepartRoleForm", model);
        }
        bool IsSelcte(List<ListPage> SelectedPages,out string Error)
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
        public IActionResult Create(SubDepartmentRoleViewModel viewModel)
        {
            try
            {
                if (viewModel.SelectedPages != null && viewModel.SelectedPages.Any())
                {
                    var departmentId = viewModel.DepartmentId;
                    var subDepartmentId = viewModel.SubDepartmentId;

                    foreach (var selectedPage in viewModel.SelectedPages)
                    {
                        if (selectedPage.IsView && (selectedPage.IsAdd || selectedPage.IsEdit || selectedPage.IsDetails || selectedPage.IsDelete))
                        {

                            var subDepartmentRoleForPage = new tbl_SubDepartmentRole
                            {
                                DepartmentId = departmentId,
                                SubDepartmentId = subDepartmentId,
                                RoleNameEn = selectedPage.RoleNameEn,
                                RoleNameAr = selectedPage.RoleNameAr,
                                IsAdd = selectedPage.IsAdd,
                                IsEdit = selectedPage.IsEdit,
                                IsView = selectedPage.IsView,
                                IsDetails = selectedPage.IsDetails,
                                IsDelete = selectedPage.IsDelete,
                                PageId = selectedPage.PageId,
                            };

                            _supDepartRoleRepository.Add(subDepartmentRoleForPage);
                        }
                    }
                    _supDepartRoleRepository.SaveChanges();
                }

                return RedirectToAction("Index", "SubDepartRole");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while processing your request.");
            }
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(SubDepartmentRoleViewModel viewModel)
        {
            try
            {
                if (viewModel.SelectedPages?.Any() == true)
                {
                    _supDepartRoleRepository.RemoveRolesByDepartmentAndSubDepartment(viewModel.DepartmentId, viewModel.SubDepartmentId);

                    foreach (var selectedPage in viewModel.SelectedPages.Where(sp =>
                        sp.IsView && (sp.IsAdd || sp.IsEdit || sp.IsDetails || sp.IsDelete)))
                    {
                        var newRole = new tbl_SubDepartmentRole
                        {
                            DepartmentId = viewModel.DepartmentId,
                            SubDepartmentId = viewModel.SubDepartmentId,
                            RoleNameEn = selectedPage.RoleNameEn,
                            RoleNameAr = selectedPage.RoleNameAr,
                            IsAdd = selectedPage.IsAdd,
                            IsEdit = selectedPage.IsEdit,
                            IsView = selectedPage.IsView,
                            IsDetails = selectedPage.IsDetails,
                            IsDelete = selectedPage.IsDelete,
                            PageId = selectedPage.PageId,
                        };

                        _supDepartRoleRepository.Add(newRole);
                    }

                    _supDepartRoleRepository.SaveChanges();
                }

                return RedirectToAction("Index", "SubDepartRole");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while processing your request.");
            }

            return View(viewModel);
        }


        public IActionResult GetSubRolesByDepartId(int departmentId, int subDepartmentId)
        {
            var currentCulture = CultureInfo.CurrentCulture.Name.StartsWith("ar");
            if (currentCulture == true)
            {
                ViewBag.Departments = new SelectList(_departmentRepository.List().Where(x => x.ApproveStatusId == 2 && x.DepartmentId > 2), "DepartmentId", "DepartmentArabicName");
                ViewBag.SubDepartments = new SelectList(_subDepartmentRepository.List().Where(x => x.ApproveStatusId == 2 && x.DepartmentId > 2), "SubDepartmentId", "SubDepartmentArabicName");
            }
            else
            {
                ViewBag.Departments = new SelectList(_departmentRepository.List().Where(x => x.ApproveStatusId == 2 && x.DepartmentId > 2), "DepartmentId", "DepartmentEnglishName");
                ViewBag.SubDepartments = new SelectList(_subDepartmentRepository.List().Where(x => x.ApproveStatusId == 2 && x.DepartmentId > 2), "SubDepartmentId", "SubDepartmentEnglishName");
            }
            var subDepartmentRoles = _supDepartRoleRepository.GetSubRolesWithPages(departmentId, subDepartmentId);
            return PartialView("_Edit", subDepartmentRoles);
        }

        public IActionResult GetDetails(int departmentId, int subDepartmentId)
        {
            var currentCulture = CultureInfo.CurrentCulture.Name.StartsWith("ar");
            if (currentCulture == true)
            {
                ViewBag.Departments = new SelectList(_departmentRepository.List().Where(x => x.ApproveStatusId == 2 && x.DepartmentId > 2), "DepartmentId", "DepartmentArabicName");
                ViewBag.SubDepartments = new SelectList(_subDepartmentRepository.List().Where(x => x.ApproveStatusId == 2 && x.DepartmentId > 2), "SubDepartmentId", "SubDepartmentArabicName");
            }
            else
            {
                ViewBag.Departments = new SelectList(_departmentRepository.List().Where(x => x.ApproveStatusId == 2 && x.DepartmentId > 2), "DepartmentId", "DepartmentEnglishName");
                ViewBag.SubDepartments = new SelectList(_subDepartmentRepository.List().Where(x => x.ApproveStatusId == 2 && x.DepartmentId > 2), "SubDepartmentId", "SubDepartmentEnglishName");
            }
            var subDepartmentRoles = _supDepartRoleRepository.GetSubRolesWithPages(departmentId, subDepartmentId);
            return PartialView("_Details", subDepartmentRoles);
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
            bool isValid = IsSelcte(viewModel.SelectedPages,out Error);
            if(Error== "lessData")
            {
                Error = CultureInfo.CurrentCulture.Name.StartsWith("ar")
                  ? "برجاء اضافة صلاحية اخري مع صلاحية المشاهدة"
                  : "Please add another permission With IsView";
                return Json(new ViewModels.ValidationResult { IsValid = false, ErrorMessage = Error });
            }
            else if(Error == "noData")
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

