namespace LegelProNewVersion.ViewModels
{
    public class DepartmentViewModel
    {
        public string DepartmentEnglishName { get; set; }
        public string DepartmentArabicName { get; set; }
        public int DepartmentId { get; set; }
        public int ApproveStatusId { get; set; }
        public int BranchId { get; set; }
        public bool IsSupDepartment { get; set; }
        public int RoleId { get; set; }
        public string? ReasonForRejection { get; set; }

    }
}
