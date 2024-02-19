using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LegelProNewVersion.Models
{
    public class tbl_Users
    {
        [Key]
        public int UserId { get; set; }
        [Display(Name = "UserName")]
        public string UserName { get; set; }
        [Display(Name = "Email")]
        public string Email  { get; set; }
        [Display(Name = "Password")]
        public string? Password  { get; set; }
        public DateTime UserStartDate { get; set; }
        public DateTime UserEndDate { get; set; }
        public bool IsActive { get; set; }
        public int? LastUpdateBy { get; set; }
        public DateTime LastLoginDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public int CreationBy { get; set; }
        public DateTime CreationDate { get; set; }
        public int ApproveBy { get; set; }
        public DateTime ApproveDate { get; set; }
        public bool IsDelete { get; set; }
        public int IsDeleteBy { get; set; }
        public DateTime IsDeleteDate { get; set; }
        public int? EmployeeId { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        public tbl_Employee tbl_Employee { get; set; }
        public ICollection<tbl_UserRole> UserRoles { get; set; }
        public ICollection<tbl_UserPages> tbl_UserPages { get; set; } 
    }
}
