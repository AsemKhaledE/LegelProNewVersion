using LegelProNewVersion.Models;
using LegelProNewVersion.Repository.Interface;
using LegelProNewVersion.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LegelProNewVersion.Controllers
{
    public class SystemConfigController : Controller
    {
        private readonly ISystemConfigRepository _systemConfigRepository;
        private readonly IMainDashboardRepository _mainDashboardRepository;
        private readonly ILoginStyleRepository _loginStyleRepository;

        public SystemConfigController(ISystemConfigRepository systemConfigRepository, IMainDashboardRepository mainDashboardRepository, ILoginStyleRepository loginStyleRepository)
        {
            _systemConfigRepository = systemConfigRepository;
            _mainDashboardRepository = mainDashboardRepository;
            _loginStyleRepository = loginStyleRepository;
        }
        public ActionResult Index()
        {
            return View();
        }
        //get all records table SystemConfig
        public IActionResult MainConfig(int id)
        {
            var systemConfig = _systemConfigRepository.GetOneOfDetails(id);
            return View(systemConfig);
        }
        //Update table SystemConfig
        public ActionResult EditMainConfig(int id)
        {
            ViewBag.LoginStyles = new SelectList(_loginStyleRepository.ListLoginStyle(), "Id", "StyleNameEnglish");
            ViewBag.MainStyles = new SelectList(_mainDashboardRepository.ListMainStyle(), "Id", "StyleNameEnglish");
            var product = _systemConfigRepository.GetOneOfUpdate(id);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditMainConfig(int id, UpdateSystemConfigViewModel updateSystemConfig)
        {
            try
            {
                if (ModelState.IsValid is false)
                {
                    ViewBag.LoginStyles = new SelectList(_loginStyleRepository.ListLoginStyle(), "Id", "StyleNameEnglish");
                    ViewBag.MainStyles = new SelectList(_mainDashboardRepository.ListMainStyle(), "Id", "StyleNameEnglish");                  
                }
                _systemConfigRepository.UpdateConfigSystem(id, updateSystemConfig);
                return RedirectToAction(nameof(MainConfig));
            }
            catch
            {
                return View();
            }
        }
        //get all records table LoginStyle
        public IActionResult LoginStyle()
        {
            var records = _loginStyleRepository.ListLoginStyle();
            return View(records);
        }

        //create table MainStyle

        public ActionResult CreateMainStyle()
        {
            return View();
        }   

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateMainStyle(tbl_MainStyle mainStyle)
        {
            try
            {
                _mainDashboardRepository.CreateMainStyle(mainStyle);
                return RedirectToAction(nameof(MainStyle));
            }
            catch
            {

                return View();
            }
        }
        //create table LoginStyle
        public ActionResult CreateLoginStyle()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateLoginStyle(tbl_LoginStyle loginStyle)
        {
            try
            {
                _loginStyleRepository.CreateLoginStyle(loginStyle);
                return RedirectToAction(nameof(LoginStyle));

            }
            catch
            {

                return View();
            }
        }
        //updaet table LoginStyle

        public IActionResult EditLoginStyle(int id)
        {
            ViewBag.ThemeBackgroundColor = _loginStyleRepository.GetOne(id).LoginBackground;
            ViewBag.LoginColor = _loginStyleRepository.GetOne(id).LoginColor;
            ViewBag.ThemeTextColor = _loginStyleRepository.GetOne(id).TextColor;
            ViewBag.ThemeTextFont = _loginStyleRepository.GetOne(id).TextFont;
            var loginStyle = _loginStyleRepository.GetOne(id);
            return View(new EditLoginStyleViewModel(loginStyle));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditLoginStyle(EditLoginStyleViewModel input)
        {
            try
            {
                if (ModelState.IsValid is false)
                {
                    ViewBag.ThemeBackgroundColor = _loginStyleRepository.GetOne(input.Id).LoginBackground;
                    ViewBag.LoginColor = _loginStyleRepository.GetOne(input.Id).LoginColor;
                    ViewBag.ThemeTextColor = _loginStyleRepository.GetOne(input.Id).TextColor;
                    ViewBag.ThemeTextColor = _loginStyleRepository.GetOne(input.Id).TextColor;
                }
                _loginStyleRepository.UpdateLoginStyle(input);
                return RedirectToAction(nameof(LoginStyle));
            }
            catch
            {
                return View();
            }
        }
        //get all Records MainStyle
        public IActionResult MainStyle()
        {
            var records = _mainDashboardRepository.ListMainStyle();
            return View(records);
        }
        //updaet table MainStyle
        public ActionResult EditMainStyle(int id)
        {
            var MainStyle = _mainDashboardRepository.GetOne(id);
            return View(MainStyle);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditMainStyle(int id, tbl_MainStyle mainStyle)
        {
            try
            {
                _mainDashboardRepository.UpdateMainStyle(id, mainStyle);
                return RedirectToAction(nameof(MainStyle));
            }
            catch
            {
                return View();
            }
        }
    }
}
