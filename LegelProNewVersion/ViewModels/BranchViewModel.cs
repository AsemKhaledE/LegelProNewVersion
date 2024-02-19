using LegelProNewVersion.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LegelProNewVersion.ViewModels
{
    public class BranchViewModel
    {
        public int BranchId { get; set; }
        public string BranchArabicName { get; set; }
        public string BranchEnglishName { get; set; }
        public int AreaId { get; set; }
        public int ApproveStatusId { get; set; }
        public string? ReasonForRejection { get; set; }

    }

}
