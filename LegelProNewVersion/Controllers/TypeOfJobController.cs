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
    public class TypeOfJobController : Controller
    {
        private readonly ITypeOfJobRepository _typeOfJobRepository;
        private readonly IApproveStatusRepository _approveStatusRepository;
        private readonly IStringLocalizer<TypeOfJobController> _localizer;
        public TypeOfJobController(ITypeOfJobRepository typeOfJobRepository, IStringLocalizer<TypeOfJobController> localizer, IApproveStatusRepository approveStatusRepository)
        {
            _typeOfJobRepository = typeOfJobRepository;
            _localizer = localizer;
            _approveStatusRepository = approveStatusRepository;
        }
        public IActionResult Index()
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
                var records = _typeOfJobRepository.List();
                return View(records);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        [HttpPost]
        public IActionResult AddTypeOfJob(TypeOfJobViewModel viewModel)
        {

            try
            {
                var entity = new tbl_TypeOfJob
                {
                    NameAr = viewModel.NameAr,
                    NameEn = viewModel.NameEn,
                    ApproveStatusId = viewModel.ApproveStatusId,
                    ReasonForRejection = viewModel.ReasonForRejection
                };
                _typeOfJobRepository.Add(entity);
                return RedirectToAction("Index", "TypeOfJob");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpGet]
        public ActionResult GetTypeOfJobById(int typeOfJobId)
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

            var typeOfJob = _typeOfJobRepository.GetById(typeOfJobId);
            return PartialView("_Edit", typeOfJob);
        }
        [HttpGet]
        public ActionResult GetDetails(int typeOfJobId)
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
            var typeOfJob = _typeOfJobRepository.GetById(typeOfJobId);
            return PartialView("_Details", typeOfJob);
        }


        [HttpPost]
        public IActionResult Edit(int typeOfJobId, tbl_TypeOfJob typeOfJob)
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
                _typeOfJobRepository.Update(typeOfJobId, typeOfJob);
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
                var approved = _typeOfJobRepository.ApproveAll();

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
                var denial = _typeOfJobRepository.DenialAll();

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
                // check if all typeOfJobs are approved
                var allApproved = _typeOfJobRepository.AreAllApproved();

                return Ok(new { success = true, allApproved });
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return Ok(new { success = false, error = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult CheckNameAr(tbl_TypeOfJob model)
        {
            try
            {
                var isEnFound = _typeOfJobRepository.IsNameArFound(model.NameAr);
                var currentCulture = CultureInfo.CurrentCulture.Name.StartsWith("ar");
                if (isEnFound == true)
                {
                    if (currentCulture == true)
                    {
                        return Ok(".اسم نوع الوظيفة موجود بالفعل");
                    }
                    else
                    {
                        return Ok("Type Of Job Name Already Exists.");
                    }
                }
                if (string.IsNullOrWhiteSpace(model.NameAr))
                {
                    if (currentCulture == true)
                    {
                        return Ok(".اسم نوع الوظيفة مطلوب");
                    }
                    else
                    {
                        return Ok("Type Of Job Name is required.");
                    }
                }
                if (model.NameAr.Length > 50)
                    if (currentCulture == true)
                    {
                        return Ok(".الحد الأقصى لطول اسم نوع الوظيفة هو 50 حرفًا");
                    }
                    else
                    {
                        return Ok("The maximum length for Type Of Job Name is 50 characters.");
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
        public IActionResult CheckNameEn(tbl_TypeOfJob model)
        {
            try
            {
                var isEnFound = _typeOfJobRepository.IsNameEnFound(model.NameEn);
                var currentCulture = CultureInfo.CurrentCulture.Name.StartsWith("ar");
                if (isEnFound == true)
                {
                    if (currentCulture == true)
                    {
                        return Ok(".اسم نوع الوظيفة بالانجليزي موجود بالفعل");
                    }
                    else
                    {
                        return Ok("Type Of Job Name Engilsh Already Exists.");
                    }
                }
                if (string.IsNullOrWhiteSpace(model.NameEn))
                {
                    if (currentCulture == true)
                    {
                        return Ok(".اسم نوع الوظيفة بالانجليزي مطلوب");
                    }
                    else
                    {
                        return Ok("Type Of Job Name Engilsh is required.");
                    }
                }
                if (model.NameEn.Length > 50)
                    if (currentCulture == true)
                    {
                        return Ok(".الحد الأقصى لطول اسم نوع الوظيفة بالانجليزي هو 50 حرفًا");
                    }
                    else
                    {
                        return Ok("The maximum length for Type Of Job Name Engilsh is 50 characters.");
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
