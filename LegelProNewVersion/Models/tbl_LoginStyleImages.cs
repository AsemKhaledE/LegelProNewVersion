using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LegelProNewVersion.Models
{
    public class tbl_LoginStyleImages
    {
        public int Id { get; set; }
        [ForeignKey(nameof(tbl_LoginStyleId))]
        public int tbl_LoginStyleId { get; set; }
        public tbl_LoginStyle tbl_LoginStyle { get; set; }
        [MaxLength(100)]
        public string ImagePath { get; set; }
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
