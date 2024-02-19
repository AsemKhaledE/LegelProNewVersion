using System.ComponentModel.DataAnnotations;

namespace LegelProNewVersion.ViewModels
{
    public class ClientViewModel
    {
        public int ClientId { get; set; }
        [Required, MaxLength(50)]
        public string ClientName { get; set; }
        public string NationalNumber { get; set; }
        public string IdentificationNumber { get; set; }
        public string TheDeviceName { get; set; }
        public string Keywords { get; set; }
        public string Address { get; set; }
        public int BranchId { get; set; }
        public int BankId { get; set; }
    }
}
