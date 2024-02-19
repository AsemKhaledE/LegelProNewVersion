using LegelProNewVersion.Models;
using System.Net.Mail;

namespace LegelProNewVersion.ViewModels
{
    public class UserViewModel
    {
        public int? UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Error { get; set; }

        public UserViewModel()
        {

        }

        public UserViewModel(tbl_Users item, string error)
        {
            if(error=="")
            {
                UserId = item.UserId;
                UserName = item.UserName;
                Email = item.Email;
                Password = item.Password;
                Error = error;
            }
            else
            {
                Error = error;
            }
        }
        public tbl_Users ToEntity()
        {
            var u = new tbl_Users
            {
                UserName = UserName,
                Email = Email,
                Password = Password
            };
            if (UserId.HasValue)
                u.UserId = UserId.Value;
            return u;
        }

    }

}
