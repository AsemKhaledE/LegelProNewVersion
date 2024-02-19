using LegelProNewVersion.Repository.Interface;
using LegelProNewVersion.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics.X86;
using System.Security.Claims;
using LegelProNewVersion.Repository.Service;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using Microsoft.AspNetCore.Identity;
using static System.Runtime.InteropServices.JavaScript.JSType;
using LegelProNewVersion.Models;

namespace LegelProNewVersion.Controllers
{
    public class LoginStyleController : Controller
    {
        private readonly ISystemConfigRepository _systemConfigRepository;
        private readonly ILoginStyleRepository _loginStyleRepository;
        private readonly IAdvancedSettingRepository _advancedSettingRepository;
        private readonly IPageRepository _pageRepository;
        private readonly ISupDepartRoleRepository _supDepartRoleRepository;
        public LoginStyleController(ISystemConfigRepository systemConfigRepository
            , ILoginStyleRepository loginStyleRepository
            , IAdvancedSettingRepository advancedSettingRepository, IPageRepository pageRepository
            , ISupDepartRoleRepository supDepartRoleRepository
            )
        {
            _systemConfigRepository = systemConfigRepository;
            _loginStyleRepository = loginStyleRepository;
            _advancedSettingRepository = advancedSettingRepository;
            _pageRepository = pageRepository;
            _supDepartRoleRepository = supDepartRoleRepository;
        }
        public IActionResult Style1()
        {
            var data = _loginStyleRepository.BackgroundStyle();
            ViewBag.ThemeBackgroundColor = data.tbl_LoginStyle.LoginBackground;
            ViewBag.ThemeTextFont = data.tbl_LoginStyle.TextFont;
            ViewBag.ThemeLoginColor = data.tbl_LoginStyle.LoginColor;
            ViewBag.ThemeTextColor = data.tbl_LoginStyle.TextColor;
            return View();
        }

        public IActionResult Style2()
        {
            return View();
        }
        public ActionResult Style3()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Style3(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var getAdvanceSettingData = _advancedSettingRepository.GetById(1);
                if (getAdvanceSettingData != null)
                {
                    if (getAdvanceSettingData.CheckedData == false)
                    {
                        List<tbl_SubDepartmentRole> GetList = _supDepartRoleRepository.GetSubDepartNameEmpty();
                        foreach (var rol in GetList)
                        {
                            tbl_Pages pages = _pageRepository.GetById(rol.PageId);
                            rol.RoleNameAr=pages.NameAr;
                            rol.RoleNameEn=pages.NameEn;
                            _supDepartRoleRepository.Edit(rol);
                        }
                    }
                }
                string Error = "";
                var user = _loginStyleRepository.GetUser(loginViewModel, out Error);
                if (Error == "")
                {
                    if (user != null && user.UserId > 0)
                    {
                        ExternalPermissionRepository permissionRepository = new ExternalPermissionRepository();

                        var userPermissions = permissionRepository.GetUserRoles(user.UserId.Value);
                        if (userPermissions.Count == 0)
                        {
                            ModelState.AddModelError(string.Empty, "برجاء اضافة صلاحيات ثم اعادة المحاولة");
                            return View(loginViewModel);
                        }
                        var allPermissions = permissionRepository.GetRoles();
                        foreach (var permission in allPermissions)
                        {
                            bool isPre = userPermissions.Contains(permission);
                            HttpContext.Session.SetInt32(permission, isPre ? 1 : 0);
                        }

                        var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                        identity.AddClaim(new Claim(ClaimTypes.Email, user.Email));
                        identity.AddClaim(new Claim(ClaimTypes.Name, $"{user.UserName}"));

                        //foreach (var roleId in user.rol)
                        //{
                        //    identity.AddClaim(new Claim(ApplicationClaimTypes.RoleId, roleId.ToString()));
                        //}

                        identity.AddClaim(new Claim(ApplicationClaimTypes.UserId, user.UserId.ToString()));



                        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

                        return RedirectToAction("Home", "MainStyle");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Incorrect email or password");
                        return View(loginViewModel);
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View();
            }

        }

        public IActionResult GetMenuStyle()
        {
            return RedirectToAction("Home", "MainStyle");
        }
        [HttpGet]
        public async Task<ActionResult> Logout()
        {
            try
            {
                await HttpContext.SignOutAsync();
                return RedirectToAction("Style3", "LoginStyle");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }

}
