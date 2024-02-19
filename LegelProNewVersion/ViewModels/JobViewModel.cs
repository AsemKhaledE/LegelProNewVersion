using LegelProNewVersion.Models;
using System.ComponentModel.DataAnnotations;

namespace LegelProNewVersion.ViewModels
{
    public class JobViewModel
    {
        public int JobId { get; set; }
        [Required, MaxLength(50)]
        public string JobArabicName { get; set; }
        [Required, MaxLength(50)]
        public string JobEnglishName { get; set; } 
        public int ApproveStatusId { get; set; } 
        public string? ReasonForRejection { get; set; }

    }
}
