using System.ComponentModel.DataAnnotations;

namespace LegelProNewVersion.Models
{
    public class tbl_Pages
    {
        [Key]
        public int PageId { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public int? LastUpdateBy { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public int CreationBy { get; set; }
        public DateTime CreationDate { get; set; }
        public int ApproveBy { get; set; }
        public DateTime ApproveDate { get; set; }
        public bool IsDelete { get; set; }
        public int IsDeleteBy { get; set; }
        public DateTime IsDeleteDate { get; set; }
        public ICollection<tbl_RolePages> rolePages { get; set; }
        public ICollection<tbl_UserPages> userPages { get; set; }

    }
}
