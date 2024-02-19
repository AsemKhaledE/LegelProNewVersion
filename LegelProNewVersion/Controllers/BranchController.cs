using LegelProNewVersion.Models;
using LegelProNewVersion.Repository.Interface;
using LegelProNewVersion.Repository.Service;
using LegelProNewVersion.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using NuGet.Protocol.Core.Types;
using System.Globalization;

namespace LegelProNewVersion.Controllers
{
    public class BranchController : Controller
    {
        private readonly IBranchRepository _branchRepository;
        private readonly IAreasRepository _areasRepository;
        private readonly IApproveStatusRepository _approveStatusRepository;
        private readonly IStringLocalizer<BranchController> _localizer;
        public BranchController(IBranchRepository branchRepository, IAreasRepository areasRepository, IApproveStatusRepository approveStatusRepository, IStringLocalizer<BranchController> localizer)
        {
            _branchRepository = branchRepository;
            _areasRepository = areasRepository;
            _approveStatusRepository = approveStatusRepository;
            _localizer = localizer;
        }
        public IActionResult Index()
        {

            try
            {
                var currentCulture = CultureInfo.CurrentCulture.Name.StartsWith("ar");

                var getListArea = _areasRepository.List().Where(x => x.ApproveStatusId ==2);
                var areas = new List<SelectListItem>();
                var approveStatus = new List<SelectListItem>();
                var getListApproveStatus = _approveStatusRepository.List();
                if (currentCulture == true)
                {
                    foreach (var record in getListArea)
                    {

                        areas.Add(new SelectListItem { Text = record.AreaArabicName, Value = record.AreaId.ToString() });
                    }

                    foreach (var record in getListApproveStatus)
                    {

                        approveStatus.Add(new SelectListItem { Text = record.ApproveArabicName, Value = record.ApproveStatusId.ToString() });
                    }
                }
                else
                {
                    foreach (var record in getListArea)
                    {

                        areas.Add(new SelectListItem { Text = record.AreaEnglishName, Value = record.AreaId.ToString() });
                    }

                    foreach (var record in getListApproveStatus)
                    {

                        approveStatus.Add(new SelectListItem { Text = record.ApproveEnglishName, Value = record.ApproveStatusId.ToString() });
                    }
                }
                ViewData["ApproveStatusItem"] = approveStatus;
                ViewData["AreaItem"] = areas;
                var records = _branchRepository.GetBranches();
                return View(records);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Create(BranchViewModel viewModel)
        {
            var currentCulture = CultureInfo.CurrentCulture.Name.StartsWith("ar");
            try
            {
                var entity = new tbl_Branch
                {
                    BranchArabicName = viewModel.BranchArabicName,
                    BranchEnglishName = viewModel.BranchEnglishName,
                    AreaId = viewModel.AreaId,
                    ApproveStatusId = viewModel.ApproveStatusId,
                    ReasonForRejection = viewModel.ReasonForRejection,
                };
                _branchRepository.AddBranch(entity);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult GetBranchById(int branchId)
        {
            var currentCulture = CultureInfo.CurrentCulture.Name.StartsWith("ar");
            if (currentCulture == true)
            {
                ViewBag.ApproveStatus = new SelectList(_approveStatusRepository.List(), "ApproveStatusId", "ApproveArabicName");
                ViewBag.Areas = new SelectList(_areasRepository.List().Where(x => x.ApproveStatusId ==2), "AreaId", "AreaArabicName");
            }
            else
            {
                ViewBag.ApproveStatus = new SelectList(_approveStatusRepository.List(), "ApproveStatusId", "ApproveEnglishName");
                ViewBag.Areas = new SelectList(_areasRepository.List().Where(x => x.ApproveStatusId ==2), "AreaId", "AreaEnglishName");
            }

            var branch = _branchRepository.GetById(branchId);
            return PartialView("_Edit", branch);
        }
        [HttpGet]
        public ActionResult GetDetails(int branchId)
        {
            var currentCulture = CultureInfo.CurrentCulture.Name.StartsWith("ar");
            if (currentCulture == true)
            {
                ViewBag.ApproveStatus = new SelectList(_approveStatusRepository.List(), "ApproveStatusId", "ApproveArabicName");
                ViewBag.Areas = new SelectList(_areasRepository.List().Where(x => x.ApproveStatusId ==2), "AreaId", "AreaArabicName");
            }
            else
            {
                ViewBag.ApproveStatus = new SelectList(_approveStatusRepository.List(), "ApproveStatusId", "ApproveEnglishName");
                ViewBag.Areas = new SelectList(_areasRepository.List().Where(x => x.ApproveStatusId ==2), "AreaId", "AreaEnglishName");
            }
            var branch = _branchRepository.GetById(branchId);
            return PartialView("_Details", branch);
        }


        [HttpPost]
        public IActionResult Edit(int branchId, tbl_Branch viewModel)
        {
            try
            {
                if (ModelState.IsValid is false)
                {
                    var currentCulture = CultureInfo.CurrentCulture.Name.StartsWith("ar");
                    if (currentCulture == true)
                    {
                        ViewBag.ApproveStatus = new SelectList(_approveStatusRepository.List(), "ApproveStatusId", "ApproveArabicName");
                        ViewBag.Areas = new SelectList(_areasRepository.List().Where(x => x.ApproveStatusId ==2), "AreaId", "AreaArabicName");
                    }
                    else
                    {
                        ViewBag.ApproveStatus = new SelectList(_approveStatusRepository.List(), "ApproveStatusId", "ApproveEnglishName");
                        ViewBag.Areas = new SelectList(_areasRepository.List().Where(x => x.ApproveStatusId ==2), "AreaId", "AreaEnglishName");
                    }
                }
                _branchRepository.UpdateBranch(branchId, viewModel);
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
                var approvedBranches = _branchRepository.ApproveAllBranches();

                return Ok(new { success = true, branches = approvedBranches });
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
                var denialBranches = _branchRepository.DenialAllBranches();

                return Ok(new { success = true, branches = denialBranches });
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return Ok(new { success = false, error = ex.Message });
            }

        }

        [HttpGet]
        public IActionResult CheckAllBranchesApproved()
        {
            try
            {
                // check if all branches are approved
                var allApproved = _branchRepository.AreAllBranchesApproved();

                return Ok(new { success = true, allApproved });
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return Ok(new { success = false, error = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult CheckEnglishName(tbl_Branch model)
        {
            try
            {
                var isEnFound = _branchRepository.IsBranchNameEnglishFound(model.BranchEnglishName);
                var currentCulture = CultureInfo.CurrentCulture.Name.StartsWith("ar");
                if (isEnFound == true)
                {
                    if (currentCulture == true)
                    {
                        return Ok(".اسم الفرع باللغة الإنجليزية موجود بالفعل");
                    }
                    else
                    {
                        return Ok("Branch English Name Already Exists.");
                    }
                }
                if (string.IsNullOrWhiteSpace(model.BranchEnglishName))
                {
                    if (currentCulture == true)
                    {
                        return Ok(".اسم الفرع باللغة الإنجليزية مطلوب");
                    }
                    else
                    {
                        return Ok("Branch English Name is required.");
                    }
                }
                if (model.BranchEnglishName.Length > 50)
                    if (currentCulture == true)
                    {
                        return Ok(".الحد الأقصى لطول اسم الفرع باللغة الإنجليزية هو 50 حرفًا");
                    }
                    else
                    {
                        return Ok("The maximum length for Branch English Name is 50 characters.");
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
        public IActionResult CheckArabicName(tbl_Branch model)
        {
            try
            {
                var isArFound = _branchRepository.IsBranchNameArabicFound(model.BranchArabicName);
                var currentCulture = CultureInfo.CurrentCulture.Name.StartsWith("ar");
                if (isArFound == true)
                {
                    if (currentCulture == true)
                    {
                        return Ok(".اسم الفرع باللغة العربية موجود بالفعل");
                    }
                    else
                    {
                        return Ok("Branch Arabic Name Already Exists.");
                    }
                }
                if (string.IsNullOrWhiteSpace(model.BranchArabicName))
                {
                    if (currentCulture == true)
                    {
                        return Ok(".اسم الفرع باللغة العربية مطلوب");
                    }
                    else
                    {
                        return Ok("Branch Arabic Name is required.");
                    }
                }
                if (model.BranchArabicName.Length > 50)
                    if (currentCulture == true)
                    {
                        return Ok(".الحد الأقصى لطول اسم الفرع باللغة العربية هو 50 حرفًا");
                    }
                    else
                    {
                        return Ok("The maximum length for Branch Arabic Name is 50 characters.");
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
