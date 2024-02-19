using Microsoft.CodeAnalysis.Operations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LegelProNewVersion.Models
{
    public class tbl_Client
    {
        [Key]
        public int ClientId { get; set; }
        [Required, MaxLength(50)]
        public string ClientName { get; set; }
        [Required, MaxLength(25)]
        public string NationalNumber { get; set; }
        [Required, MaxLength(25)]
        public string IdentificationNumber { get; set; }
        [Required, MaxLength(50)]
        public string TheDeviceName { get; set;}
        [Required, MaxLength(50)]
        public string Keywords { get; set; }
        [Required, MaxLength(100)]
        public string Address { get; set; }
        public int BranchId { get; set; }
        [ForeignKey(nameof(BranchId))]
        public tbl_Branch tbl_Branch { get; set; }
        public int BankId { get; set; }
        [ForeignKey(nameof(BankId))]
        public tbl_Bank tbl_Bank { get; set; }
    }
}
