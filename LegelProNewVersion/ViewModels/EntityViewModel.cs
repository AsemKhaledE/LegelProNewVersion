using LegelProNewVersion.Models;

namespace LegelProNewVersion.ViewModels
{
    public class EntityViewModel
    {
        public int EntitieId { get; set; }
        public string EntitieArabicName { get; set; }
        public string EntitieEnglishName { get; set; }
        public int ApproveStatusId { get; set; }
        public string? ReasonForRejection { get; set; }

    }

}
