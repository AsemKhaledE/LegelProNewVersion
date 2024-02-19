using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LegelProNewVersion.Models
{
    public class tbl_UserRole
    {
        [Key]
        public int Id { get; set; }     
        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public tbl_Users User { get; set; }
        public int EmployeeId { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        public tbl_Employee tbl_Employee { get; set; }    
        public bool IsAdd { get; set; }
        public bool IsView { get; set; }
        public bool IsDetails { get; set; }
        public bool IsEdit { get; set; }
        public bool IsDelete { get; set; }
        public bool IsMaker { get; set; }
        public bool IsChecher { get; set; }
        public int DepartmentId { get; set; }
        [ForeignKey(nameof(DepartmentId))]
        public tbl_Department tbl_Department { get; set; }
        public int? SubDepartmentId { get; set; }
        [ForeignKey(nameof(SubDepartmentId))]
        public tbl_SubDepartment SubDepartment { get; set; }
        [ForeignKey(nameof(tbl_Pages))]
        public int PageId { get; set; }
        public tbl_Pages tbl_Pages { get; set; }
    }
}
