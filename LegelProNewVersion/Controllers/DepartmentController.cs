using LegelProNewVersion.Models;
using LegelProNewVersion.Repository.Interface;
using LegelProNewVersion.Repository.Service;
using LegelProNewVersion.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using PointOfSale.Web.Controllers;
using System.Globalization;

namespace LegelProNewVersion.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly ISubDepartmentRepository _subDepartmentRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IBranchRepository _branchRepository;
        private readonly IApproveStatusRepository _approveStatusRepository;
        private readonly IStringLocalizer<DepartmentController> _localizer;
        public DepartmentController(IDepartmentRepository departmentRepository, ISubDepartmentRepository subDepartmentRepository, IBranchRepository branchRepository, IStringLocalizer<DepartmentController> localizer, IApproveStatusRepository approveStatusRepository)
        {
            _branchRepository = branchRepository;
            _departmentRepository = departmentRepository;
            _subDepartmentRepository = subDepartmentRepository;
            _localizer = localizer;
            _approveStatusRepository = approveStatusRepository;
        }
        public IActionResult Index()
        {
            var currentCulture = CultureInfo.CurrentCulture.Name.StartsWith("ar");
            if (currentCulture == true)
            {
                ViewBag.ApproveStatus = new SelectList(_approveStatusRepository.List(), "ApproveStatusId", "ApproveArabicName");
                ViewBag.Branchs = new SelectList(_branchRepository.GetBranches().Where(x => x.ApproveStatusId ==2), "BranchId", "BranchArabicName");
            }
            else
            {
                ViewBag.ApproveStatus = new SelectList(_approveStatusRepository.List(), "ApproveStatusId", "ApproveEnglishName");
                ViewBag.Branchs = new SelectList(_branchRepository.GetBranches().Where(x => x.ApproveStatusId ==2), "BranchId", "BranchEnglishName");
            }
           
            var records = _departmentRepository.List();
            return View(records);
        }
        [HttpPost]
        public ActionResult Create(DepartmentViewModel tbl_Department )
        {
            try
            {
                _departmentRepository.Add(tbl_Department);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult GetDepartmentById(int departmentId)
        {
            var currentCulture = CultureInfo.CurrentCulture.Name.StartsWith("ar");
            if (currentCulture == true)
            {
                ViewBag.ApproveStatus = new SelectList(_approveStatusRepository.List(), "ApproveStatusId", "ApproveArabicName");
                ViewBag.Branchs = new SelectList(_branchRepository.GetBranches().Where(x => x.ApproveStatusId ==2), "BranchId", "BranchArabicName");
            }
            else
            {
                ViewBag.ApproveStatus = new SelectList(_approveStatusRepository.List(), "ApproveStatusId", "ApproveEnglishName");
                ViewBag.Branchs = new SelectList(_branchRepository.GetBranches().Where(x => x.ApproveStatusId ==2), "BranchId", "BranchEnglishName");
            }
            var getDepartment = _departmentRepository.GetById(departmentId);
            return PartialView("_Edit", getDepartment);
        }
        [HttpGet]
        public ActionResult GetDetails(int departmentId)
        {
            var currentCulture = CultureInfo.CurrentCulture.Name.StartsWith("ar");
            if (currentCulture == true)
            {
                ViewBag.ApproveStatus = new SelectList(_approveStatusRepository.List(), "ApproveStatusId", "ApproveArabicName");
                ViewBag.Branchs = new SelectList(_branchRepository.GetBranches().Where(x => x.ApproveStatusId ==2), "BranchId", "BranchArabicName");
            }
            else
            {
                ViewBag.ApproveStatus = new SelectList(_approveStatusRepository.List(), "ApproveStatusId", "ApproveEnglishName");
                ViewBag.Branchs = new SelectList(_branchRepository.GetBranches().Where(x => x.ApproveStatusId ==2), "BranchId", "BranchEnglishName");
            }
            var getDepartment = _departmentRepository.GetById(departmentId);
            return PartialView("_Details", getDepartment);
        }


        [HttpPost]
        public IActionResult Edit(int departmentId, tbl_Department department)
        {
            try
            {
                if (ModelState.IsValid is false)
                {
                    var currentCulture = CultureInfo.CurrentCulture.Name.StartsWith("ar");
                    if (currentCulture == true)
                    {
                        ViewBag.ApproveStatus = new SelectList(_approveStatusRepository.List(), "ApproveStatusId", "ApproveArabicName");
                        ViewBag.Branchs = new SelectList(_branchRepository.GetBranches().Where(x => x.ApproveStatusId ==2), "BranchId", "BranchArabicName");
                    }
                    else
                    {
                        ViewBag.ApproveStatus = new SelectList(_approveStatusRepository.List(), "ApproveStatusId", "ApproveEnglishName");
                        ViewBag.Branchs = new SelectList(_branchRepository.GetBranches().Where(x => x.ApproveStatusId ==2), "BranchId", "BranchEnglishName");
                    }
                }
                _departmentRepository.Update(departmentId, department);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult UpdateApproveStatus()
        {
            try
            {
                // Call the service method to approve all branches with status 1
                var approved = _departmentRepository.ApproveAll();

                return Ok(new { success = true, branches = approved });
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return Ok(new { success = false, error = ex.Message });
            }

        }
        [HttpPost]
        public IActionResult UpdateDenialStatus()
        {
            try
            {
                // Call the service method to Denial all branches with status 1
                var denial = _departmentRepository.DenialAll();

                return Ok(new { success = true, branches = denial });
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return Ok(new { success = false, error = ex.Message });
            }

        }

        [HttpGet]
        public IActionResult CheckAllApproved()
        {
            try
            {
                // check if all branches are approved
                var allApproved = _departmentRepository.AreAllApproved();

                return Ok(new { success = true, allApproved });
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return Ok(new { success = false, error = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult CheckEnglishName(tbl_Department model)
        {
            try
            {
                var isEnFound = _departmentRepository.IsNameEnglishFound(model.DepartmentEnglishName);
                var currentCulture = CultureInfo.CurrentCulture.Name.StartsWith("ar");
                if (isEnFound == true)
                {
                    if (currentCulture == true)
                    {
                        return Ok(".اسم الادارة باللغة الإنجليزية موجود بالفعل");
                    }
                    else
                    {
                        return Ok("Department English Name Already Exists.");
                    }
                }
                if (string.IsNullOrWhiteSpace(model.DepartmentEnglishName))
                {
                    if (currentCulture == true)
                    {
                        return Ok(".اسم الادارة باللغة الإنجليزية مطلوب");
                    }
                    else
                    {
                        return Ok("Department English Name is required.");
                    }
                }
                if (model.DepartmentEnglishName.Length > 50)
                    if (currentCulture == true)
                    {
                        return Ok(".الحد الأقصى لطول اسم الادارة باللغة الإنجليزية هو 50 حرفًا");
                    }
                    else
                    {
                        return Ok("The maximum length for Department English Name is 50 characters.");
                    }
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                // Log the exception if needed
                return BadRequest(new { error = ex.Message });
            }
        }
        [HttpPost]
        public IActionResult CheckArabicName(tbl_Department model)
        {
            try
            {
                var isArFound = _departmentRepository.IsNameArabicFound(model.DepartmentArabicName);
                var currentCulture = CultureInfo.CurrentCulture.Name.StartsWith("ar");
                if (isArFound == true)
                {
                    if (currentCulture == true)
                    {
                        return Ok(".اسم الادارة باللغة العربية موجود بالفعل");
                    }
                    else
                    {
                        return Ok("Department Arabic Name Already Exists.");
                    }
                }
                if (string.IsNullOrWhiteSpace(model.DepartmentArabicName))
                {
                    if (currentCulture == true)
                    {
                        return Ok(".اسم الادارة باللغة العربية مطلوب");
                    }
                    else
                    {
                        return Ok("Department Arabic Name is required.");
                    }
                }
                if (model.DepartmentArabicName.Length > 50)
                    if (currentCulture == true)
                    {
                        return Ok(".الحد الأقصى لطول اسم الادارة باللغة العربية هو 50 حرفًا");
                    }
                    else
                    {
                        return Ok("The maximum length for Department Arabic Name is 50 characters.");
                    }
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                // Log the exception if needed
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
