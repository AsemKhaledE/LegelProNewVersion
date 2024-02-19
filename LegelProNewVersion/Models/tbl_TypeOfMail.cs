using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LegelProNewVersion.Models
{
    public class tbl_TypeOfMail
    {
        [Key]
        public int TypeOfMailId { get; set; }
        [Required, MaxLength(50)]
        public string TypeOfMailArabicName { get; set; }
        [Required, MaxLength(50)]
        public string TypeOfMailEnglishName { get; set; }
        public int DepartmentId { get; set; }
        [ForeignKey(nameof(DepartmentId))]
        public tbl_Department tbl_Department { get; set; }
        public tbl_TypeMail tbl_TypeMail { get; set; }
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
