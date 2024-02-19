using LegelProNewVersion.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace LegelProNewVersion.Controllers
{
    public class WelcomePageController : Controller
    {
        private readonly ISystemConfigRepository _systemConfigRepository;

        public WelcomePageController(ISystemConfigRepository systemConfigRepository)
        {
            _systemConfigRepository = systemConfigRepository;
        }
        //get Image and text( Ar ,En) in Welcome Screen Page 
        public IActionResult Index()
        {
            var data = _systemConfigRepository.GetAllConfigData();
            if (data.LoginStyle == null )
            {
                return RedirectToAction("MainConfig", "SystemConfig");
            }
            return View(data);
        }
        
    }
}
