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
    public class AreaController : Controller
    {
        private readonly IAreasRepository _areasRepository;
        private readonly IStringLocalizer<AreaController> _localizer;
        private readonly IApproveStatusRepository _approveStatusRepository;
        private readonly IUserRoleRepository _userRoleRepository;
        public AreaController(IAreasRepository areasRepository, IStringLocalizer<AreaController> localizer, 
                              IApproveStatusRepository approveStatusRepository,IUserRoleRepository userRoleRepository)
        {
            _areasRepository = areasRepository;
            _localizer = localizer;
            _approveStatusRepository = approveStatusRepository;
            _userRoleRepository = userRoleRepository;
        }
        public ActionResult Index()
        {
            try
            {
                var currentCulture = CultureInfo.CurrentCulture.Name.StartsWith("ar");
                if (currentCulture == true)
                {
                    ViewBag.ApproveStatus = new SelectList(_approveStatusRepository.List().Where(x => x.ApproveStatusId == 1), "ApproveStatusId", "ApproveArabicName");
                }
                else
                {
                    ViewBag.ApproveStatus = new SelectList(_approveStatusRepository.List().Where(x => x.ApproveStatusId == 1), "ApproveStatusId", "ApproveEnglishName");
                }
                var records = _areasRepository.List().OrderBy(x => x.AreaArabicName);
                ViewBag.PageData = _userRoleRepository.GetListUserRoles();
                return View(records);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Create(AreaViewModel viewModel)
        {
            try
            {
                var area = new tbl_Areas
                {
                    AreaArabicName = viewModel.AreaArabicName,
                    AreaEnglishName = viewModel.AreaEnglishName,
                    ApproveStatusId = viewModel.ApproveStatusId,
                    ReasonForRejection = viewModel.ReasonForRejection,
                };


                _areasRepository.Add(area);
                return RedirectToAction("Index", "Area");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");

                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                }

                return RedirectToAction("Error", "Home");
            }
        }

        [HttpGet]
        public ActionResult GetAreaById(int areaId)
        {
            var currentCulture = CultureInfo.CurrentCulture.Name.StartsWith("ar");
            if (currentCulture == true)
            {
                ViewBag.ApproveStatus = new SelectList(_approveStatusRepository.List().Where(x => x.ApproveStatusId == 1), "ApproveStatusId", "ApproveArabicName");
            }
            else
            {
                ViewBag.ApproveStatus = new SelectList(_approveStatusRepository.List().Where(x => x.ApproveStatusId == 1), "ApproveStatusId", "ApproveEnglishName");
            }
            var area = _areasRepository.GetById(areaId);
            return PartialView("_Edit", area);
        }

        [HttpGet]
        public ActionResult GetDetails(int areaId)
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
            var area = _areasRepository.GetById(areaId);
            return PartialView("_Details", area);
        }
        [HttpPost]
        public ActionResult Details(tbl_Areas areas)
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
            _areasRepository.Update(areas);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public ActionResult Approve(int areaId)
        {
            try
            {
                var area = _areasRepository.GetById(areaId);

                if (area != null)
                {
                    area.ApproveStatusId = 2;
                    area.ReasonForRejection = "";

                    _areasRepository.Update(area);

                    return Json(new { success = true, message = "Approval successful" });
                }
                else
                {
                    return Json(new { success = false, error = "Area not found" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }
        [HttpPost]
        public ActionResult Denial(int areaId)
        {
            try
            {
                var area = _areasRepository.GetById(areaId);

                if (area != null)
                {
                    area.ApproveStatusId = 3;
                    _areasRepository.Update(area);
                    return PartialView("_Denial", area);
                }
                else
                {
                    return Json(new { success = false, error = "Area not found" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }
        [HttpPost]
        public IActionResult Denial(tbl_Areas areas)
        {
            try
            {
                areas.ApproveStatusId = 3;
                _areasRepository.Update(areas);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult Edit(tbl_Areas areas)
        {
            try
            {
                areas.ApproveStatusId = 1;
                _areasRepository.Update(areas);
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
                var approved = _areasRepository.ApproveAll();

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
                var denial = _areasRepository.DenialAll();
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
                var allApproved = _areasRepository.AreAllApproved();
                return Ok(new { success = true, allApproved });
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return Ok(new { success = false, error = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult CheckEnglishName(tbl_Areas model)
        {
            try
            {
                var isEnFound = _areasRepository.IsNameEnglishFound(model.AreaEnglishName);
                var currentCulture = CultureInfo.CurrentCulture.Name.StartsWith("ar");
                if (isEnFound == true)
                {
                    if (currentCulture == true)
                    {
                        return Ok("اسم المنطقة باللغة الإنجليزية موجود بالفعل");
                    }
                    else
                    {
                        return Ok("Area English Name Already Exists");
                    }
                }
                if (string.IsNullOrWhiteSpace(model.AreaEnglishName))
                {
                    if (currentCulture == true)
                    {
                        return Ok("اسم المنطقة باللغة الإنجليزية مطلوب");
                    }
                    else
                    {
                        return Ok("Area English Name is required");
                    }
                }
                if (model.AreaEnglishName.Length > 50)
                    if (currentCulture == true)
                    {
                        return Ok("الحد الأقصى لطول اسم المنطقة باللغة الإنجليزية هو 50 حرفًا");
                    }
                    else
                    {
                        return Ok("The maximum length for Area English Name is 50 characters");
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
        public IActionResult CheckArabicName(tbl_Areas model)
        {
            try
            {
                var isArFound = _areasRepository.IsNameArabicFound(model.AreaArabicName);
                var currentCulture = CultureInfo.CurrentCulture.Name.StartsWith("ar");
                if (isArFound == true)
                {
                    if (currentCulture == true)
                    {
                        return Ok("اسم المنطقة باللغة العربية موجود بالفعل");
                    }
                    else
                    {
                        return Ok("Area Arabic Name Already Exists");
                    }
                }
                if (string.IsNullOrWhiteSpace(model.AreaArabicName))
                {
                    if (currentCulture == true)
                    {
                        return Ok("اسم المنطقة باللغة العربية مطلوب");
                    }
                    else
                    {
                        return Ok("Area Arabic Name is required");
                    }
                }
                if (model.AreaArabicName.Length > 50)
                    if (currentCulture == true)
                    {
                        return Ok("الحد الأقصى لطول اسم المنطقة باللغة العربية هو 50 حرفًا");
                    }
                    else
                    {
                        return Ok("The maximum length for Area Arabic Name is 50 characters");
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

