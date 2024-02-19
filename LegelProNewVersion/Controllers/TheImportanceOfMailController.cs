using LegelProNewVersion.Models;
using LegelProNewVersion.Repository.Interface;
using LegelProNewVersion.Repository.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Globalization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LegelProNewVersion.Controllers
{
    public class TheImportanceOfMailController : Controller
    {
        private readonly IImportanceOfMailRepository _importanceOfMailRepository;
        private readonly IStringLocalizer<TheImportanceOfMailController> _localizer;
        private readonly IApproveStatusRepository _approveStatusRepository;
        public TheImportanceOfMailController(IImportanceOfMailRepository importanceOfMailRepository, IStringLocalizer<TheImportanceOfMailController> localizer, IApproveStatusRepository approveStatusRepository)
        {
            _importanceOfMailRepository = importanceOfMailRepository;
            _localizer = localizer;
            _approveStatusRepository = approveStatusRepository;
        }
        public ActionResult Index()
        {
            try
            {
                var currentCulture = CultureInfo.CurrentCulture.Name.StartsWith("ar");
                if (currentCulture == true)
                {
                    ViewBag.ApproveStatus = new SelectList(_approveStatusRepository.List(), "ApproveStatusId", "ApproveArabicName");
                }
                else
                {
                    ViewBag.ApproveStatus = new SelectList(_approveStatusRepository.List(), "ApproveStatusId", "ApproveEnglishName");
                }
                var records = _importanceOfMailRepository.List();
                return View(records);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        [HttpPost]
        public IActionResult Create(tbl_TheImportanceOfMail importanceOfMail)
        {

            try
            {
                _importanceOfMailRepository.Add(importanceOfMail);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public ActionResult GetMailById(int mailId)
        {
            var currentCulture = CultureInfo.CurrentCulture.Name.StartsWith("ar");
            if (currentCulture == true)
            {
                ViewBag.ApproveStatus = new SelectList(_approveStatusRepository.List(), "ApproveStatusId", "ApproveArabicName");
            }
            else
            {
                ViewBag.ApproveStatus = new SelectList(_approveStatusRepository.List(), "ApproveStatusId", "ApproveEnglishName");
            }
            var mail = _importanceOfMailRepository.GetById(mailId);
            return PartialView("_Edit", mail);
        }

        [HttpGet]
        public ActionResult GetDetails(int mailId)
        {
            var currentCulture = CultureInfo.CurrentCulture.Name.StartsWith("ar");
            if (currentCulture == true)
            {
                ViewBag.ApproveStatus = new SelectList(_approveStatusRepository.List(), "ApproveStatusId", "ApproveArabicName");
            }
            else
            {
                ViewBag.ApproveStatus = new SelectList(_approveStatusRepository.List(), "ApproveStatusId", "ApproveEnglishName");
            }
            var mail = _importanceOfMailRepository.GetById(mailId);
            return PartialView("_Details", mail);
        }

        [HttpPost]
        public IActionResult Edit(int mailId, tbl_TheImportanceOfMail mail)
        {
            try
            {
                if (ModelState.IsValid is false)
                {
                    var currentCulture = CultureInfo.CurrentCulture.Name.StartsWith("ar");
                    if (currentCulture == true)
                    {
                        ViewBag.ApproveStatus = new SelectList(_approveStatusRepository.List(), "ApproveStatusId", "ApproveArabicName");
                    }
                    else
                    {
                        ViewBag.ApproveStatus = new SelectList(_approveStatusRepository.List(), "ApproveStatusId", "ApproveEnglishName");
                    }
                }
                _importanceOfMailRepository.Update(mailId, mail);
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
                var approved = _importanceOfMailRepository.ApproveAll();

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
                var denial = _importanceOfMailRepository.DenialAll();
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
                var allApproved = _importanceOfMailRepository.AreAllApproved();
                return Ok(new { success = true, allApproved });
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return Ok(new { success = false, error = ex.Message });
            }
        }
        [HttpPost]
        public IActionResult CheckEnglishName(tbl_TheImportanceOfMail model)
        {
            try
            {
                var isEnFound = _importanceOfMailRepository.IsNameEnglishFound(model.TheImportanceOfMailEnglishName);
                var currentCulture = CultureInfo.CurrentCulture.Name.StartsWith("ar");
                if (isEnFound == true)
                {
                    if (currentCulture == true)
                    {
                        return Ok(".اسم اهمية البريد باللغة الإنجليزية موجود بالفعل");
                    }
                    else
                    {
                        return Ok("Importance Of Mail English Name Already Exists.");
                    }
                }
                if (string.IsNullOrWhiteSpace(model.TheImportanceOfMailEnglishName))
                {
                    if (currentCulture == true)
                    {
                        return Ok(".اسم اهمية البريد باللغة الإنجليزية مطلوب");
                    }
                    else
                    {
                        return Ok("Importance Of Mail English Name is required.");
                    }
                }
                if (model.TheImportanceOfMailEnglishName.Length > 50)
                    if (currentCulture == true)
                    {
                        return Ok(".الحد الأقصى لطول اسم اهمية البريد باللغة الإنجليزية هو 50 حرفًا");
                    }
                    else
                    {
                        return Ok("The maximum length for Importance Of Mail English Name is 50 characters.");
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
        public IActionResult CheckArabicName(tbl_TheImportanceOfMail model)
        {
            try
            {
                var isArFound = _importanceOfMailRepository.IsNameArabicFound(model.TheImportanceOfMailArabicName);
                var currentCulture = CultureInfo.CurrentCulture.Name.StartsWith("ar");
                if (isArFound == true)
                {
                    if (currentCulture == true)
                    {
                        return Ok(".اسم اهمية البريد باللغة العربية موجود بالفعل");
                    }
                    else
                    {
                        return Ok("Importance Of Mail Arabic Name Already Exists.");
                    }
                }
                if (string.IsNullOrWhiteSpace(model.TheImportanceOfMailArabicName))
                {
                    if (currentCulture == true)
                    {
                        return Ok(".اسم اهمية البريد باللغة العربية مطلوب");
                    }
                    else
                    {
                        return Ok("Importance Of Mail Arabic Name is required.");
                    }
                }
                if (model.TheImportanceOfMailArabicName.Length > 50)
                    if (currentCulture == true)
                    {
                        return Ok(".الحد الأقصى لطول اسم اهمية البريد باللغة العربية هو 50 حرفًا");
                    }
                    else
                    {
                        return Ok("The maximum length for Importance Of Mail Arabic Name is 50 characters.");
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
