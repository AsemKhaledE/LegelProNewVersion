using LegelProNewVersion.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LegelProNewVersion.ViewModels
{
    public class EmployeeViewModel
    {
        public int EmployeeId { get; set; }
        public string EmployeeArabicName { get; set; }
        public string EmployeeEnglishName { get; set; }
        public string? PhoneNumber { get; set; }
        public string Address { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime UserStartDate { get; set; }
        public DateTime UserEndDate { get; set; }
        public int? SubDepartmentId { get; set; }
        public int DepartmentId { get; set; }
        public int UserId { get; set; }
        public int ApproveStatusId { get; set; }
        public string? ReasonForRejection { get; set; }

        public int BranchId { get; set; }
        public int tbl_JobId { get; set; }
        public int TypeOfJobId { get; set; }
    }

}