using LegelProNewVersion.Models;
namespace LegelProNewVersion.ViewModels
{
    public class SubDepartmentRoleViewModel
    {
        public int DepartmentId { get; set; }
        public int? SubDepartmentId { get; set; }
        public List<tbl_SubDepartmentRole>? SubDepartmentRoles { get; set; }
        public List<tbl_Pages>? PagesList { get; set; }
        public List<ListPage> SelectedPages { get; set; } = new List<ListPage>();
    }
    public class ListPage
    {
        public int PageId { get; set; }
        public int SubRoleId { get; set; }
        public string RoleNameAr { get; set; }
        public string RoleNameEn { get; set; }
        public string Name { get; set; }
        public bool IsAdd { get; set; }
        public bool IsView { get; set; }
        public bool IsDetails { get; set; }
        public bool IsEdit { get; set; }
        public bool IsDelete { get; set; }
        public bool IsMaker { get; set; }
        public bool IsChecher { get; set; }
        public int DepartmentId { get; set; }
        public int? SubDepartmentId { get; set; }
    }
}
