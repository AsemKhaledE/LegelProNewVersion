using LegelProNewVersion.Models;
using LegelProNewVersion.Repository.Interface;
using LegelProNewVersion.Repository.Service;
using Microsoft.AspNetCore.Mvc;

namespace LegelProNewVersion.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingController : ControllerBase
    {
        private readonly IAreasRepository _areasRepository;
        private readonly ISystemConfigRepository _systemConfigRepository;
        public SettingController( ISystemConfigRepository systemConfigRepository, IAreasRepository areasRepository)
        {
           _systemConfigRepository = systemConfigRepository;
            _areasRepository = areasRepository;
        }
        //get images all 10 second 
        [HttpGet("getData")]
        public IActionResult GetData()
        {
            return Ok(new SettingViewModel());

        }

        //get time Interval and LoginPath 
        [HttpGet("getWelcomePageInterval")]
        public IActionResult GetWelcomePageInterval()
        {
            var data = _systemConfigRepository.GetAPIConfigData();
            return Ok(data);
        }

        [HttpPost("addArea")]

        public IActionResult AddArea(tbl_Areas tbl_Areas)
        {

            try
            {
                _areasRepository.Add(tbl_Areas);
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}




public class SettingViewModel
{
    public int Interval { get; set; } = 10;

    public List<string> Images { get; set; } = new List<string>();

    public SettingViewModel()
    {
        Images.Add("img1 style 3.jpg");
        Images.Add("img2 style 3.jpg");
        Images.Add("img3 style 3.jpg");
        Images.Add("img4 style 3.jpg");
        Images.Add("img5 style 3.jpg");
    }
}

