using System.ComponentModel.DataAnnotations;

namespace LegelProNewVersion.Models
{
    public class tbl_ApproveStatus
    {
        [Key]
        public int ApproveStatusId { get; set; }
        [MaxLength(75)]
        public string ApproveArabicName { get; set; }
        [MaxLength(75)]
        public string ApproveEnglishName { get; set; }
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
