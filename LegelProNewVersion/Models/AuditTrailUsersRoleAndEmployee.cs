namespace LegelProNewVersion.Models
{
    public partial class AuditTrailUsersRoleAndEmployee
    {
        public int Id { get; set; }
        public int EmpID { get; set; }
        public int TableTypeId { get; set; }
        public string TableType { get; set; }
        public int TableID { get; set; }
        public DateTime ActionDateTime { get; set; }
        public DateTime? CheckerDateTime { get; set; }
        public string ActionMaker { get; set; }
        public string ActionChecker { get; set; }
        public string ActionType { get; set; }
        public string UserName { get; set; }
        public string NameAr { get; set; }
        public string BranchName { get; set; }
        public string JobName { get; set; }
        public string PositionName { get; set; }
        public bool IsActive { get; set; }
        public int ApprovedOrDenialID { get; set; }
        public string ExpirationDate { get; set; }
        public string Permition { get; set; }
        public string Note { get; set; }
    }
}
