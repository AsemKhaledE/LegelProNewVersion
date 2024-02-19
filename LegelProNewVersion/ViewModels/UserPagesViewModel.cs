using LegelProNewVersion.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace LegelProNewVersion.ViewModels
{
    public class UserPagesViewModel
    {
        public int PageId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public List<PageViewModel> AllPages { get; set; }
        public UserPagesViewModel()
        {

        }
        public UserPagesViewModel(tbl_UserPages item)
        {
            UserId = item.UserId;
            PageId = item.PageId;
            UserName = item.Users.UserName;
        }
        public tbl_UserPages ToEntity()
        {
            var p = new tbl_UserPages
            {   
                UserId = UserId,
                PageId = PageId
            };
            return p;
        }
    }
}
