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
    public class MailerController : Controller
    {
        private readonly IMailerRepository _mailerRepository;
        private readonly IApproveStatusRepository _approveStatusRepository;
        private readonly IStringLocalizer<MailerController> _localizer;
        public MailerController(IMailerRepository mailerRepository , IStringLocalizer<MailerController  > localizer, IApproveStatusRepository approveStatusRepository)
        {
            _mailerRepository = mailerRepository;
            _localizer = localizer;
            _approveStatusRepository = approveStatusRepository;
        }

        public IActionResult Index()
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
            var getAll = _mailerRepository.List();
            return View(getAll);
        }

        [HttpPost]
        public ActionResult Create(MailerViewModel viewModel)
        {
            try
            {
                var mailer = new tbl_Mailer
                {
                    MailerArabicName = viewModel.MailerArabicName,
                    MailerEnglishName = viewModel.MailerEnglishName,
                    ApproveStatusId = viewModel.ApproveStatusId,
                    ReasonForRejection = viewModel.ReasonForRejection,
                };
                _mailerRepository.Add(mailer);
                return RedirectToAction(nameof(Index));
            }
            catch
            {

                return View();
            }
        }

        [HttpGet]
        public ActionResult GetMailerById(int mailerId)
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

            var mailer = _mailerRepository.GetById(mailerId);
            return PartialView("_Edit", mailer);
        }
        [HttpGet]
        public ActionResult GetDetails(int mailerId)
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
            var mailer = _mailerRepository.GetById(mailerId);
            return PartialView("_Details", mailer);
        }


        [HttpPost]
        public IActionResult Edit(int mailerId, tbl_Mailer mailer)
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
                _mailerRepository.Update(mailerId, mailer);
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
                var approved = _mailerRepository.ApproveAll();

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
                var denial = _mailerRepository.DenialAll();

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
                var allApproved = _mailerRepository.AreAllApproved();

                return Ok(new { success = true, allApproved });
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return Ok(new { success = false, error = ex.Message });
            }
        }
        [HttpPost]
        public IActionResult CheckEnglishName(tbl_Mailer model)
        {
            try
            {
                var isEnFound = _mailerRepository.IsNameEnglishFound(model.MailerEnglishName);
                var currentCulture = CultureInfo.CurrentCulture.Name.StartsWith("ar");
                if (isEnFound == true)
                {
                    if (currentCulture == true)
                    {
                        return Ok(".اسم الجهه باللغة الإنجليزية موجود بالفعل");
                    }
                    else
                    {
                        return Ok("Mailer English Name Already Exists.");
                    }
                }
                if (string.IsNullOrWhiteSpace(model.MailerEnglishName))
                {
                    if (currentCulture == true)
                    {
                        return Ok(".اسم الجهه باللغة الإنجليزية مطلوب");
                    }
                    else
                    {
                        return Ok("Mailer English Name is required.");
                    }
                }
                if (model.MailerEnglishName.Length > 50)
                    if (currentCulture == true)
                    {
                        return Ok(".الحد الأقصى لطول اسم الجهه باللغة الإنجليزية هو 50 حرفًا");
                    }
                    else
                    {
                        return Ok("The maximum length for Mailer English Name is 50 characters.");
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
        public IActionResult CheckArabicName(tbl_Mailer model)
        {
            try
            {
                var isArFound = _mailerRepository.IsNameArabicFound(model.MailerArabicName);
                var currentCulture = CultureInfo.CurrentCulture.Name.StartsWith("ar");
                if (isArFound == true)
                {
                    if (currentCulture == true)
                    {
                        return Ok(".اسم الجهه باللغة العربية موجود بالفعل");
                    }
                    else
                    {
                        return Ok("Mailer Arabic Name Already Exists.");
                    }
                }
                if (string.IsNullOrWhiteSpace(model.MailerArabicName))
                {
                    if (currentCulture == true)
                    {
                        return Ok(".اسم الجهه باللغة العربية مطلوب");
                    }
                    else
                    {
                        return Ok("Mailer Arabic Name is required.");
                    }
                }
                if (model.MailerArabicName.Length > 50)
                    if (currentCulture == true)
                    {
                        return Ok(".الحد الأقصى لطول اسم الجهه باللغة العربية هو 50 حرفًا");
                    }
                    else
                    {
                        return Ok("The maximum length for Mailer Arabic Name is 50 characters.");
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
