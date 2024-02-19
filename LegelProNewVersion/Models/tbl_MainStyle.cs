using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LegelProNewVersion.Models
{
    public class tbl_MainStyle
    {
        public int Id { get; set; }
        [MaxLength(75)]
        public string StyleNameArabic { get; set; }
        [MaxLength(75)]
        public string StyleNameEnglish { get; set; }
        [MaxLength(300)]
        public string DescriptionArabic { get; set; }
        [MaxLength(300)]
        public string DescriptionEnglish { get; set; }
        [MaxLength(100)]
        public string DashboardPath { get; set; }
        public string WelcomePageImagePath { get; set; }
        public tbl_SystemConfig tbl_SystemConfig { get; set; }
        public int? LastUpdateBy { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public int CreationBy { get; set; }
        public DateTime CreationDate { get; set; }
        public int ApproveBy { get; set; }
        public DateTime ApproveDate { get; set; }
        public bool IsDelete { get; set; }
        public int IsDeleteBy { get; set; }
        public DateTime IsDeleteDate { get; set; }

    }
}
