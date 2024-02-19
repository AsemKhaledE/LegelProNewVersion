using System.ComponentModel.DataAnnotations;

namespace LegelProNewVersion.ViewModels
{
    public class LoginViewModel
    {

        [Required, StringLength(100)]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Password")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        //public string  Error { get; set; }
    }
}
