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
    public class ClientController : Controller
    {
        private readonly IClientRepository _clientRepository;
        private readonly IBranchRepository _branchRepository;
        private readonly IBankRepository _bankRepository;
        private readonly IStringLocalizer<ClientController> _localizer;
        public ClientController(IClientRepository clientRepository, IBranchRepository branchRepository, IBankRepository bankRepository, IStringLocalizer<ClientController> localizer)
        {
            _clientRepository = clientRepository;
            _branchRepository = branchRepository;
            _bankRepository = bankRepository;
            _localizer = localizer;
        }
        public IActionResult Index()
        {
            try
            {
                var currentCulture = CultureInfo.CurrentCulture.Name.StartsWith("ar");
                if (currentCulture == true)
                {
                    ViewBag.Branchs = new SelectList(_branchRepository.GetBranches(), "BranchId", "BranchArabicName");
                    ViewBag.Banks = new SelectList(_bankRepository.GetBanks(), "BankId", "BankName");
                }
                else
                {
                    ViewBag.Branchs = new SelectList(_branchRepository.GetBranches(), "BranchId", "BranchEnglishName");
                    ViewBag.Banks = new SelectList(_bankRepository.GetBanks(), "BankId", "BankName");
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
           
            var record = _clientRepository.GetClients();
            return View(record);
        }

        [HttpPost]
        public ActionResult Create(ClientViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid is false)
                {
                    return View();
                }
                var entity = new tbl_Client
                {
                    Address = viewModel.Address,
                    BankId = viewModel.BankId,
                    TheDeviceName = viewModel.TheDeviceName,
                    BranchId = viewModel.BranchId,
                    ClientName = viewModel.ClientName,
                    IdentificationNumber = viewModel.IdentificationNumber,
                    NationalNumber = viewModel.NationalNumber,
                    Keywords = viewModel.Keywords,
                };
                _clientRepository.AddClient(entity);
                return RedirectToAction(nameof(Index));
            }
            catch
            {

                return View();
            }
        }

        [HttpGet]
        public ActionResult GetClientById(int clientId)
        {
            var currentCulture = CultureInfo.CurrentCulture.Name.StartsWith("ar");
            if (currentCulture == true)
            {
                ViewBag.Branchs = new SelectList(_branchRepository.GetBranches(), "BranchId", "BranchArabicName");
                ViewBag.Banks = new SelectList(_bankRepository.GetBanks(), "BankId", "BankName");
            }
            else
            {
                ViewBag.Branchs = new SelectList(_branchRepository.GetBranches(), "BranchId", "BranchEnglishName");
                ViewBag.Banks = new SelectList(_bankRepository.GetBanks(), "BankId", "BankName");
            }
            var client = _clientRepository.GetClientById(clientId);
            return PartialView("_Edit", client);
        }
        [HttpGet]
        public ActionResult GetDetails(int clientId)
        {
            var currentCulture = CultureInfo.CurrentCulture.Name.StartsWith("ar");
            if (currentCulture == true)
            {
                ViewBag.Branchs = new SelectList(_branchRepository.GetBranches(), "BranchId", "BranchArabicName");
                ViewBag.Banks = new SelectList(_bankRepository.GetBanks(), "BankId", "BankName");
            }
            else
            {
                ViewBag.Branchs = new SelectList(_branchRepository.GetBranches(), "BranchId", "BranchEnglishName");
                ViewBag.Banks = new SelectList(_bankRepository.GetBanks(), "BankId", "BankName");
            }
            var client = _clientRepository.GetClientById(clientId);
            return PartialView("_Details", client);
        }


        [HttpPost]
        public IActionResult Edit(int clientId, tbl_Client tbl_Client)
        {
            try
            {
                if (ModelState.IsValid is false)
                {
                    var currentCulture = CultureInfo.CurrentCulture.Name.StartsWith("ar");
                    if (currentCulture == true)
                    {
                        ViewBag.Branchs = new SelectList(_branchRepository.GetBranches(), "BranchId", "BranchArabicName");
                        ViewBag.Banks = new SelectList(_bankRepository.GetBanks(), "BankId", "BankName");
                    }
                    else
                    {
                        ViewBag.Branchs = new SelectList(_branchRepository.GetBranches(), "BranchId", "BranchEnglishName");
                        ViewBag.Banks = new SelectList(_bankRepository.GetBanks(), "BankId", "BankName");
                    }
                }
                _clientRepository.UpdateClient(clientId, tbl_Client);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult CheckClientName(tbl_Client model)
        {
            try
            {
                var isEnFound = _clientRepository.IsClientNameFound(model.ClientName);
                var currentCulture = CultureInfo.CurrentCulture.Name.StartsWith("ar");
                if (isEnFound == true)
                {
                    if (currentCulture == true)
                    {
                        return Ok(".اسم العميل موجود بالفعل");
                    }
                    else
                    {
                        return Ok("Client Name Already Exists.");
                    }
                }
                if (string.IsNullOrWhiteSpace(model.ClientName))
                {
                    if (currentCulture == true)
                    {
                        return Ok(".اسم العميل مطلوب");
                    }
                    else
                    {
                        return Ok("Client Name is required.");
                    }
                }
                if (model.ClientName.Length > 50)
                    if (currentCulture == true)
                    {
                        return Ok(".الحد الأقصى لطول اسم العميل هو 50 حرفًا");
                    }
                    else
                    {
                        return Ok("The maximum length for Client Name is 50 characters.");
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
        public IActionResult CheckDeviceName(tbl_Client model)
        {
            try
            {
                var isArFound = _clientRepository.IsDeviceNameFound(model.TheDeviceName);
                var currentCulture = CultureInfo.CurrentCulture.Name.StartsWith("ar");
                if (isArFound == true)
                {
                    if (currentCulture == true)
                    {
                        return Ok(".اسم الجهاز موجود بالفعل");
                    }
                    else
                    {
                        return Ok("The Device Name Already Exists.");
                    }
                }
                if (string.IsNullOrWhiteSpace(model.TheDeviceName))
                {
                    if (currentCulture == true)
                    {
                        return Ok(".اسم الجهاز مطلوب");
                    }
                    else
                    {
                        return Ok("The Device Name is required.");
                    }
                }
                if (model.TheDeviceName.Length > 50)
                    if (currentCulture == true)
                    {
                        return Ok(".الحد الأقصى لطول اسم الجهاز هو 50 حرفًا");
                    }
                    else
                    {
                        return Ok("The maximum length for The Device Name is 50 characters.");
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
        public IActionResult CheckIdentificationNumber(tbl_Client model)
       {
            var isIdentificationNumberValid = _clientRepository.IsIdentificationNumberFound(model.IdentificationNumber);
            var currentCulture = CultureInfo.CurrentCulture.Name.StartsWith("ar");

            if (isIdentificationNumberValid)
            {
                return Ok(currentCulture ? ".الرقم التعريفي موجود بالفعل" : "Identification Number Already Exists.");
            }

            if (string.IsNullOrWhiteSpace(model.IdentificationNumber))
            {
                return Ok(currentCulture ? "الرقم التعريفي مطلوب" : "Identification Number is required.");
            }

            if (model.IdentificationNumber.ToString().Length > 25)
            {
                return Ok(currentCulture ? ".الحد الأقصى لطول الرقم التعريفي هو 25 رقم" : "The maximum length for Identification Number is 25 digits.");
            }

            return Ok();
        }

        [HttpPost]
        public IActionResult CheckNationalNumber(tbl_Client model)
        {
            var isNationalNumberValid = _clientRepository.IsNationalNumberFound(model.NationalNumber);
            var currentCulture = CultureInfo.CurrentCulture.Name.StartsWith("ar");

            if (isNationalNumberValid)
            {
                return Ok(currentCulture ? ".الرقم القومي موجود بالفعل" : "National Number Already Exists.");
            }

            if (string.IsNullOrWhiteSpace(model.NationalNumber))
            {
                return Ok(currentCulture ? "الرقم القومي مطلوب" : "National Number is required.");
            }

            if (model.NationalNumber.ToString().Length > 25)
            {
                return Ok(currentCulture ? ".الحد الأقصى لطول الرقم القومي هو 25 رقم" : "The maximum length for National Number is 25 digits.");
            }

            return Ok();
        }
    }
}
