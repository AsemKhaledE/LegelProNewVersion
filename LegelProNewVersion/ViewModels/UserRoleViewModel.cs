using LegelProNewVersion.Models;

namespace LegelProNewVersion.ViewModels
{
    public class UserRoleViewModel
    {
        public int DepartmentId { get; set; }
        public int? SubDepartmentId { get; set; }
        public int UserId { get; set; }
        public int EmployeeId { get; set; }
        public List<tbl_UserRole>? tbl_UserRoles { get; set; }

        public List<tbl_Pages>? PagesList { get; set; }

        public List<ListSelectedPages> SelectedPages { get; set; } = new List<ListSelectedPages>();
    }
    public class ListSelectedPages
    {
        public int PageId { get; set; }
        public int SubRoleId { get; set; }
        public string? RoleNameAr { get; set; }
        public string? RoleNameEn { get; set; }
        public bool IsAdd { get; set; }
        public bool IsView { get; set; }
        public bool IsDetails { get; set; }
        public bool IsEdit { get; set; }
        public bool IsDelete { get; set; }
        public bool IsMaker { get; set; }
        public bool IsChecher { get; set; }
    }
}
