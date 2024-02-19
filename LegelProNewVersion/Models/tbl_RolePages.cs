using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LegelProNewVersion.Models
{
    public class tbl_RolePages
    {
        [Key]
        public int Id { get; set; }
        public int SubId { get; set; }
        [ForeignKey(nameof(SubId))]
        public tbl_SubDepartmentRole subDepartmentRole { get; set; }
        [ForeignKey(nameof(tbl_Pages))]
        public int PageId { get; set; }
        public tbl_Pages tbl_Pages { get; set; }
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
