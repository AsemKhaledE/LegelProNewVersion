using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LegelProNewVersion.Models
{
    public class tbl_SubDepartmentRole
    {
        [Key]
        public int SubRoleId { get; set; }
        public int DepartmentId { get; set; }
        [ForeignKey(nameof(DepartmentId))]
        public tbl_Department tbl_Department { get; set; }
        public int? SubDepartmentId { get; set; }
        [ForeignKey(nameof(SubDepartmentId))]
        public tbl_SubDepartment SubDepartment { get; set; }
        public int PageId { get; set; }
        [ForeignKey(nameof(PageId))]
        public tbl_Pages tbl_Pages { get; set; }
        public ICollection<tbl_UserRole> UserRoles { get; set; }
        public ICollection<tbl_RolePages> RolePages { get; set; }
        public string RoleNameAr { get; set; }
        public string RoleNameEn { get; set; }
        public bool IsAdd { get; set;}
        public bool IsView { get; set;}
        public bool IsDetails { get; set;}
        public bool IsEdit { get; set;}
        public bool IsDelete { get; set;}
        public bool IsMaker { get; set;}
        public bool IsChecher { get; set;}
        
    }
}
