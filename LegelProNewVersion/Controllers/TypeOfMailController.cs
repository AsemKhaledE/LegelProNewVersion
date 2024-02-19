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
    public class TypeOfMailController : Controller
    {
        private readonly ITypeOfMailRepository _typeOfMailRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IStringLocalizer<TypeOfMailController> _localizer;
        public TypeOfMailController(ITypeOfMailRepository typeOfMailRepository, IDepartmentRepository departmentRepository, IStringLocalizer<TypeOfMailController> localizer)
        {
            _typeOfMailRepository = typeOfMailRepository;
            _localizer = localizer;
            _departmentRepository = departmentRepository;
        }
        public IActionResult Index()
        {
            try
            {
                var currentCulture = CultureInfo.CurrentCulture.Name.StartsWith("ar");
                var getListManagement = _departmentRepository.List().Where(x => x.ApproveStatusId ==2);
                var Departments = new List<SelectListItem>();
                if (currentCulture == true)
                {
                    foreach (var record in getListManagement)
                    {

                        Departments.Add(new SelectListItem { Text = record.DepartmentArabicName, Value = record.DepartmentId.ToString() });
                    }
                }
                else
                {
                    foreach (var record in getListManagement)
                    {

                        Departments.Add(new SelectListItem { Text = record.DepartmentEnglishName, Value = record.DepartmentId.ToString() });
                    }
                }
                   

                ViewData["ManagementItem"] = Departments;
                var records = _typeOfMailRepository.List();
                return View(records);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public ActionResult Create(TypeOfMailViewModel viewModel)
        {
            try
            {
                var entity = new tbl_TypeOfMail
                {
                    tbl_TypeMail = viewModel.tbl_TypeMail,
                    DepartmentId = viewModel.DepartmentId,
                    TypeOfMailArabicName = viewModel.TypeOfMailArabicName,
                    TypeOfMailEnglishName = viewModel.TypeOfMailEnglishName,

                };
                _typeOfMailRepository.Add(entity);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult GetTypeOfMailById(int typeOfMailId)
        {
            var currentCulture = CultureInfo.CurrentCulture.Name.StartsWith("ar");
            if (currentCulture == true)
            {
                ViewBag.Departments = new SelectList(_departmentRepository.List().Where(x => x.ApproveStatusId ==2), "DepartmentId", "DepartmentArabicName");
            }
            else
            {
                ViewBag.Departments = new SelectList(_departmentRepository.List().Where(x => x.ApproveStatusId ==2), "DepartmentId", "DepartmentEnglishName");
            }
           
            var typeOfMail = _typeOfMailRepository.GetById(typeOfMailId);
            return PartialView("_Edit", typeOfMail);
        }
        [HttpGet]
        public ActionResult GetDetails(int typeOfMailId)
        {
            var currentCulture = CultureInfo.CurrentCulture.Name.StartsWith("ar");
            if (currentCulture == true)
            {
                ViewBag.Departments = new SelectList(_departmentRepository.List().Where(x => x.ApproveStatusId ==2), "DepartmentId", "DepartmentArabicName");
            }
            else
            {
                ViewBag.Departments = new SelectList(_departmentRepository.List().Where(x => x.ApproveStatusId ==2), "DepartmentId", "DepartmentEnglishName");
            }
            var typeOfMail = _typeOfMailRepository.GetById(typeOfMailId);
            return PartialView("_Details", typeOfMail);
        }


        [HttpPost]
        public IActionResult Edit(int typeOfMailId, tbl_TypeOfMail tbl_TypeOfMail)
        {
            try
            {
                if (ModelState.IsValid is false)
                {
                    var currentCulture = CultureInfo.CurrentCulture.Name.StartsWith("ar");
                    if (currentCulture == true)
                    {
                        ViewBag.Departments = new SelectList(_departmentRepository.List().Where(x => x.ApproveStatusId ==2), "DepartmentId", "DepartmentArabicName");
                    }
                    else
                    {
                        ViewBag.Departments = new SelectList(_departmentRepository.List().Where(x => x.ApproveStatusId ==2), "DepartmentId", "DepartmentEnglishName");
                    }
                }
                _typeOfMailRepository.Update(typeOfMailId, tbl_TypeOfMail);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult CheckEnglishName(tbl_TypeOfMail model)
        {
            try
            {
                var isEnFound = _typeOfMailRepository.IsNameEnglishFound(model.TypeOfMailEnglishName);
                var currentCulture = CultureInfo.CurrentCulture.Name.StartsWith("ar");
                if (isEnFound == true)
                {
                    if (currentCulture == true)
                    {
                        return Ok(".اسم نوع البريد باللغة الإنجليزية موجود بالفعل");
                    }
                    else
                    {
                        return Ok("Type Of Mail English Name Already Exists.");
                    }
                }
                if (string.IsNullOrWhiteSpace(model.TypeOfMailEnglishName))
                {
                    if (currentCulture == true)
                    {
                        return Ok(".اسم نوع البريد باللغة الإنجليزية مطلوب");
                    }
                    else
                    {
                        return Ok("Type Of Mail English Name is required.");
                    }
                }
                if (model.TypeOfMailEnglishName.Length > 50)
                    if (currentCulture == true)
                    {
                        return Ok(".الحد الأقصى لطول اسم نوع البريد باللغة الإنجليزية هو 50 حرفًا");
                    }
                    else
                    {
                        return Ok("The maximum length for Type Of Mail English Name is 50 characters.");
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
        public IActionResult CheckArabicName(tbl_TypeOfMail model)
        {
            try
            {
                var isArFound = _typeOfMailRepository.IsNameArabicFound(model.TypeOfMailArabicName);
                var currentCulture = CultureInfo.CurrentCulture.Name.StartsWith("ar");
                if (isArFound == true)
                {
                    if (currentCulture == true)
                    {
                        return Ok(".اسم نوع البريد باللغة العربية موجود بالفعل");
                    }
                    else
                    {
                        return Ok("Type Of Mail Arabic Name Already Exists.");
                    }
                }
                if (string.IsNullOrWhiteSpace(model.TypeOfMailArabicName))
                {
                    if (currentCulture == true)
                    {
                        return Ok(".اسم نوع البريد باللغة العربية مطلوب");
                    }
                    else
                    {
                        return Ok("Type Of Mail Arabic Name is required.");
                    }
                }
                if (model.TypeOfMailArabicName.Length > 50)
                    if (currentCulture == true)
                    {
                        return Ok(".الحد الأقصى لطول اسم نوع البريد باللغة العربية هو 50 حرفًا");
                    }
                    else
                    {
                        return Ok("The maximum length for Type Of Mail Arabic Name is 50 characters.");
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
