using Microsoft.AspNet.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LegelProNewVersion.Models
{
    public class tbl_Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required, MaxLength(50)]
        public string EmployeeArabicName { get; set; }
        [Required, MaxLength(50)]
        public string EmployeeEnglishName { get; set; }
        [Required, MaxLength(15)]
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }      
        public int ApproveStatusId { get; set; }
        [ForeignKey(nameof(ApproveStatusId))]
        public tbl_ApproveStatus tbl_ApproveStatus { get; set; }
        public string? ReasonForRejection { get; set; }

        public int BranchId { get; set; }
        [ForeignKey(nameof(BranchId))]
        public tbl_Branch tbl_Branch { get; set; }
        public ICollection<tbl_Users> tbl_Users { get; set; }
        public int DepartmentId { get; set; }
        [ForeignKey(nameof(DepartmentId))]
        public tbl_Department Department { get; set; }
        public int? SubDepartmentId { get; set; }
        [ForeignKey(nameof(SubDepartmentId))]
        public tbl_SubDepartment SubDepartment { get; set; }
        public int tbl_JobId { get; set; }
        [ForeignKey(nameof(tbl_JobId))]
        public tbl_Job tbl_Jobs { get; set; }
        public int TypeOfJobId { get; set; }
        [ForeignKey(nameof(TypeOfJobId))]
        public tbl_TypeOfJob tbl_TypeOfJobs { get; set; }
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
