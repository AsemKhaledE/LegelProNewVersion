using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LegelProNewVersion.Models
{
    public class tbl_LoginStyle
    {
        public int Id { get; set; }
        [MaxLength(75)]
        public string StyleNameArabic { get; set; }
        [MaxLength(75)]
        public string StyleNameEnglish { get; set; }
        [MaxLength(16)]
        public string TextColor { get; set; }
        [MaxLength(50)]
        public string TextFont { get; set; }
        [MaxLength(16)]
        public string LoginColor { get; set; }
        [MaxLength(16)]
        public string LoginBackground { get; set; }
        public bool IsMultiImage { get; set; }
        public int TimeInterval { get; set; } = 10;   
        public tbl_SystemConfig tbl_SystemConfig { get; set; }
        public List<tbl_LoginStyleImages> tbl_LoginStyleImages { get; set; }
        [MaxLength(150)]
        public string LoginPath { get; set; }
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
