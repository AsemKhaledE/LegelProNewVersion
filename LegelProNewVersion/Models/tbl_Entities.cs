using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LegelProNewVersion.Models
{
    public class tbl_Entities
    {
        [Key]
        public int EntitieId { get; set; }
        [Required, MaxLength(50)]
        public string EntitieArabicName { get; set; }
        [Required, MaxLength(50)]
        public string EntitieEnglishName { get; set; }
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
