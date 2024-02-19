using LegelProNewVersion.Controllers;
using LegelProNewVersion.Models;
using LegelProNewVersion.Repository.Interface;
using LegelProNewVersion.Repository.Service;
using LegelProNewVersion.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using System.Globalization;

namespace PointOfSale.Web.Controllers
{
    public class JobController : Controller
    {
        private readonly IJobRepository _jobRepository;
        private readonly IApproveStatusRepository _approveStatusRepository;
        private readonly IStringLocalizer<JobController> _localizer;
        public JobController(IJobRepository jobRepository, IStringLocalizer<JobController> localizer, IApproveStatusRepository approveStatusRepository)
        {
            _jobRepository = jobRepository;
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
                var records = _jobRepository.List();
                return View(records);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Create(JobViewModel tbl_Jobs)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var job = new tbl_Job
                    {
                        JobArabicName = tbl_Jobs.JobArabicName,
                        JobEnglishName = tbl_Jobs.JobEnglishName,
                        ApproveStatusId = tbl_Jobs.ApproveStatusId,
                        ReasonForRejection = tbl_Jobs.ReasonForRejection,
                    };
                    _jobRepository.Add(job);
                    return RedirectToAction(nameof(Index));
                }
                return View(tbl_Jobs);
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult GetJobById(int jobId)
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

            var job = _jobRepository.GetById(jobId);
            return PartialView("_Edit", job);
        }
        [HttpGet]
        public ActionResult GetDetails(int jobId)
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
            var job = _jobRepository.GetById(jobId);
            return PartialView("_Details", job);
        }


        [HttpPost]
        public IActionResult Edit(int jobId, tbl_Job tbl_Job)
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
                _jobRepository.Update(jobId, tbl_Job);
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
                var approved = _jobRepository.ApproveAll();

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
                var denial = _jobRepository.DenialAll();

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
                var allApproved = _jobRepository.AreAllApproved();

                return Ok(new { success = true, allApproved });
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return Ok(new { success = false, error = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult CheckEnglishName(tbl_Job model)
        {
            try
            {
                var isEnFound = _jobRepository.IsNameEnglishFound(model.JobEnglishName);
                var currentCulture = CultureInfo.CurrentCulture.Name.StartsWith("ar");
                if (isEnFound == true)
                {
                    if (currentCulture == true)
                    {
                        return Ok(".اسم الوظيفة باللغة الإنجليزية موجود بالفعل");
                    }
                    else
                    {
                        return Ok("Job English Name Already Exists.");
                    }
                }
                if (string.IsNullOrWhiteSpace(model.JobEnglishName))
                {
                    if (currentCulture == true)
                    {
                        return Ok(".اسم الوظيفة باللغة الإنجليزية مطلوب");
                    }
                    else
                    {
                        return Ok("Job English Name is required.");
                    }
                }
                if (model.JobEnglishName.Length > 50)
                    if (currentCulture == true)
                    {
                        return Ok(".الحد الأقصى لطول اسم الوظيفة باللغة الإنجليزية هو 50 حرفًا");
                    }
                    else
                    {
                        return Ok("The maximum length for Job English Name is 50 characters.");
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
        public IActionResult CheckArabicName(tbl_Job model)
        {
            try
            {
                var isArFound = _jobRepository.IsNameArabicFound(model.JobArabicName);
                var currentCulture = CultureInfo.CurrentCulture.Name.StartsWith("ar");
                if (isArFound == true)
                {
                    if (currentCulture == true)
                    {
                        return Ok(".اسم الوظيفة باللغة العربية موجود بالفعل");
                    }
                    else
                    {
                        return Ok("Job Arabic Name Already Exists.");
                    }
                }
                if (string.IsNullOrWhiteSpace(model.JobArabicName))
                {
                    if (currentCulture == true)
                    {
                        return Ok(".اسم الوظيفة باللغة العربية مطلوب");
                    }
                    else
                    {
                        return Ok("Job Arabic Name is required.");
                    }
                }
                if (model.JobArabicName.Length > 50)
                    if (currentCulture == true)
                    {
                        return Ok(".الحد الأقصى لطول اسم الوظيفة باللغة العربية هو 50 حرفًا");
                    }
                    else
                    {
                        return Ok("The maximum length for Job Arabic Name is 50 characters.");
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
