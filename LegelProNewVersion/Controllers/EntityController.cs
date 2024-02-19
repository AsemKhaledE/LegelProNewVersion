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
    public class EntityController : Controller
    {
        private readonly IEntityRepository _entityRepository;
        private readonly IApproveStatusRepository _approveStatusRepository;
        private readonly IStringLocalizer<JobController> _localizer;
        public EntityController(IEntityRepository entityRepository, IStringLocalizer<JobController> localizer, IApproveStatusRepository approveStatusRepository)
        {
            _entityRepository = entityRepository;
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
            var getAll =_entityRepository.GetAllEntity();
            return View(getAll);
        }

        [HttpPost]
        public ActionResult Create(EntityViewModel tbl_Entities)
        {
            try
            {
                var entity = new tbl_Entities
                {
                    EntitieArabicName=tbl_Entities.EntitieArabicName,
                    EntitieEnglishName=tbl_Entities.EntitieEnglishName,
                    ApproveStatusId=tbl_Entities.ApproveStatusId,
                    ReasonForRejection=tbl_Entities.ReasonForRejection,
                };
                _entityRepository.AddEntity(entity);
                return RedirectToAction(nameof(Index));
            }
            catch
            {

                return View();
            }
        }

         [HttpGet]
        public ActionResult GetEntityById(int entityId)
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

            var entity = _entityRepository.GetById(entityId);
            return PartialView("_Edit", entity);
        }
        [HttpGet]
        public ActionResult GetDetails(int entityId)
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
            var entity = _entityRepository.GetById(entityId);
            return PartialView("_Details", entity);
        }


        [HttpPost]
        public IActionResult Edit(int entityId, tbl_Entities tbl_Entities)
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
                _entityRepository.EditEntity(entityId, tbl_Entities);
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
                var approved = _entityRepository.ApproveAll();

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
                var denial = _entityRepository.DenialAll();

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
                var allApproved = _entityRepository.AreAllApproved();

                return Ok(new { success = true, allApproved });
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return Ok(new { success = false, error = ex.Message });
            }
        }

    }
}
