using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LegelProNewVersion.Models
{
    public class tbl_Branch
    {
        [Key]
        public int BranchId { get; set; }
        [Required, MaxLength(50)]
        public string BranchArabicName { get; set; }
        [Required, MaxLength(50)]
        public string BranchEnglishName { get; set; }
        public int AreaId { get; set; }
        [ForeignKey(nameof(AreaId))]
        public tbl_Areas tbl_Areas { get; set; }
        public int ApproveStatusId { get; set; }
        [ForeignKey(nameof(ApproveStatusId))]
        public tbl_ApproveStatus tbl_ApproveStatus { get; set; }
        public string? ReasonForRejection { get; set; }

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
