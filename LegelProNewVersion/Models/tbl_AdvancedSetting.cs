using System.ComponentModel.DataAnnotations;

namespace LegelProNewVersion.Models
{
    public class tbl_AdvancedSetting
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public bool CheckedData { get; set; }
    }
}
