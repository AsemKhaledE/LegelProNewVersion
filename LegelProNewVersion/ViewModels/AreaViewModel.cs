using LegelProNewVersion.Models;

namespace LegelProNewVersion.ViewModels
{
    public class AreaViewModel
    {
        public int AreaId { get; set; }
        public string AreaArabicName { get; set; }
        public string AreaEnglishName { get; set; }
        public int ApproveStatusId { get; set; }
        public string? ReasonForRejection { get; set; }
    }
}
