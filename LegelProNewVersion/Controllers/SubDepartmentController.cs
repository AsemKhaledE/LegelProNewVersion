using LegelProNewVersion.Models;
using LegelProNewVersion.Repository.Interface;
using LegelProNewVersion.Repository.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using PointOfSale.Web.Controllers;
using System.Globalization;

namespace LegelProNewVersion.Controllers
{
    public class SubDepartmentController : Controller
    {
        private readonly ISubDepartmentRepository _subDepartmentRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IStringLocalizer<SubDepartmentController> _localizer;
        private readonly IApproveStatusRepository _approveStatusRepository;
        public SubDepartmentController(IDepartmentRepository departmentRepository, ISubDepartmentRepository subDepartmentRepository, IRoleRepository roleRepository, IStringLocalizer<SubDepartmentController> localizer, IApproveStatusRepository approveStatusRepository)
        {
            _departmentRepository = departmentRepository;
            _subDepartmentRepository = subDepartmentRepository;
            _roleRepository = roleRepository;
            _localizer = localizer;
            _approveStatusRepository = approveStatusRepository;
        }
        public IActionResult Index()
        {
            var currentCulture = CultureInfo.CurrentCulture.Name.StartsWith("ar");
            if (currentCulture == true)
            {
                ViewBag.Departments = new SelectList(_departmentRepository.List().Where(x => x.ApproveStatusId == 2 && x.DepartmentId > 2), "DepartmentId", "DepartmentArabicName");
                ViewBag.ApproveStatus = new SelectList(_approveStatusRepository.List(), "ApproveStatusId", "ApproveArabicName");
            }
            else
            {
                ViewBag.Departments = new SelectList(_departmentRepository.List().Where(x => x.ApproveStatusId == 2 && x.DepartmentId > 2), "DepartmentId", "DepartmentEnglishName");
                ViewBag.ApproveStatus = new SelectList(_approveStatusRepository.List(), "ApproveStatusId", "ApproveEnglishName");
            }

            var record = _subDepartmentRepository.List();
            return View(record);
        }
        [HttpPost]
        public ActionResult Create(tbl_SubDepartment tbl_SubDepartment)
        {
            try
            {
                _subDepartmentRepository.Add(tbl_SubDepartment);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult GetSubDepartmentById(int subDepartmentId)
        {
            var currentCulture = CultureInfo.CurrentCulture.Name.StartsWith("ar");
            if (currentCulture == true)
            {
                ViewBag.Departments = new SelectList(_departmentRepository.List().Where(x => x.ApproveStatusId == 2 && x.DepartmentId > 2), "DepartmentId", "DepartmentArabicName");
                ViewBag.ApproveStatus = new SelectList(_approveStatusRepository.List(), "ApproveStatusId", "ApproveArabicName");
            }
            else
            {
                ViewBag.Departments = new SelectList(_departmentRepository.List().Where(x => x.ApproveStatusId == 2 && x.DepartmentId > 2), "DepartmentId", "DepartmentEnglishName");
                ViewBag.ApproveStatus = new SelectList(_approveStatusRepository.List(), "ApproveStatusId", "ApproveEnglishName");
            }

            var getSubDepartment = _subDepartmentRepository.GetById(subDepartmentId);
            return PartialView("_Edit", getSubDepartment);
        }
        [HttpGet]
        public ActionResult GetDetails(int subDepartmentId)
        {
            var currentCulture = CultureInfo.CurrentCulture.Name.StartsWith("ar");
            if (currentCulture == true)
            {
                ViewBag.Departments = new SelectList(_departmentRepository.List().Where(x => x.ApproveStatusId == 2 && x.DepartmentId > 2), "DepartmentId", "DepartmentArabicName");
                ViewBag.ApproveStatus = new SelectList(_approveStatusRepository.List(), "ApproveStatusId", "ApproveArabicName");
            }
            else
            {
                ViewBag.Departments = new SelectList(_departmentRepository.List().Where(x => x.ApproveStatusId == 2 && x.DepartmentId > 2), "DepartmentId", "DepartmentEnglishName");
                ViewBag.ApproveStatus = new SelectList(_approveStatusRepository.List(), "ApproveStatusId", "ApproveEnglishName");
            }

            var getDepartment = _subDepartmentRepository.GetById(subDepartmentId);
            return PartialView("_Details", getDepartment);
        }


        [HttpPost]
        public IActionResult Edit(int subDepartmentId, tbl_SubDepartment subDepartment)
        {
            try
            {
                if (ModelState.IsValid is false)
                {
                    var currentCulture = CultureInfo.CurrentCulture.Name.StartsWith("ar");
                    if (currentCulture == true)
                    {
                        ViewBag.Departments = new SelectList(_departmentRepository.List().Where(x => x.ApproveStatusId == 2 && x.DepartmentId > 2), "DepartmentId", "DepartmentArabicName");
                        ViewBag.ApproveStatus = new SelectList(_approveStatusRepository.List(), "ApproveStatusId", "ApproveArabicName");
                    }
                    else
                    {
                        ViewBag.Departments = new SelectList(_departmentRepository.List().Where(x => x.ApproveStatusId == 2 && x.DepartmentId > 2), "DepartmentId", "DepartmentEnglishName");
                        ViewBag.ApproveStatus = new SelectList(_approveStatusRepository.List(), "ApproveStatusId", "ApproveEnglishName");
                    }

                }
                _subDepartmentRepository.Update(subDepartmentId, subDepartment);
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
                var approved = _subDepartmentRepository.ApproveAll();

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
                var denial = _subDepartmentRepository.DenialAll();
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
                var allApproved = _subDepartmentRepository.AreAllApproved();
                return Ok(new { success = true, allApproved });
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return Ok(new { success = false, error = ex.Message });
            }
        }
        [HttpPost]
        public IActionResult CheckEnglishName(tbl_SubDepartment model)
        {
            try
            {
                var isEnFound = _subDepartmentRepository.IsNameEnglishFound(model.SubDepartmentEnglishName);
                var currentCulture = CultureInfo.CurrentCulture.Name.StartsWith("ar");
                if (isEnFound == true)
                {
                    if (currentCulture == true)
                    {
                        return Ok(".اسم الادارة الفرعية باللغة الإنجليزية موجود بالفعل");
                    }
                    else
                    {
                        return Ok("SubDepartment English Name Already Exists.");
                    }
                }
                if (string.IsNullOrWhiteSpace(model.SubDepartmentEnglishName))
                {
                    if (currentCulture == true)
                    {
                        return Ok(".اسم الادارة الفرعية باللغة الإنجليزية مطلوب");
                    }
                    else
                    {
                        return Ok("SubDepartment English Name is required.");
                    }
                }
                if (model.SubDepartmentEnglishName.Length > 50)
                    if (currentCulture == true)
                    {
                        return Ok(".الحد الأقصى لطول اسم الادارة الفرعية باللغة الإنجليزية هو 50 حرفًا");
                    }
                    else
                    {
                        return Ok("The maximum length for SubDepartment English Name is 50 characters.");
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
        public IActionResult CheckArabicName(tbl_SubDepartment model)
        {
            try
            {
                var isArFound = _subDepartmentRepository.IsNameArabicFound(model.SubDepartmentArabicName);
                var currentCulture = CultureInfo.CurrentCulture.Name.StartsWith("ar");
                if (isArFound == true)
                {
                    if (currentCulture == true)
                    {
                        return Ok(".اسم الادارة الفرعية باللغة العربية موجود بالفعل");
                    }
                    else
                    {
                        return Ok("SubDepartment Arabic Name Already Exists.");
                    }
                }
                if (string.IsNullOrWhiteSpace(model.SubDepartmentArabicName))
                {
                    if (currentCulture == true)
                    {
                        return Ok(".اسم الادارة الفرعية باللغة العربية مطلوب");
                    }
                    else
                    {
                        return Ok("SubDepartment Arabic Name is required.");
                    }
                }
                if (model.SubDepartmentArabicName.Length > 50)
                    if (currentCulture == true)
                    {
                        return Ok(".الحد الأقصى لطول اسم الادارة الفرعية باللغة العربية هو 50 حرفًا");
                    }
                    else
                    {
                        return Ok("The maximum length for SubDepartment Arabic Name is 50 characters.");
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
