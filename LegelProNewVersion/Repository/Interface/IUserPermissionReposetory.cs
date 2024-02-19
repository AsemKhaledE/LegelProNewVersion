using LegelProNewVersion.Models;
using LegelProNewVersion.ViewModels;
using Microsoft.AspNet.Identity;

namespace LegelProNewVersion.Repository.Interface
{
    public interface IUserPermissionReposetory
    {
        List<tbl_Pages> ListPage();
        tbl_Users FindById(int id);
        List<tbl_UserPages> GetUserPages(int userId);
        void ManageUserPagesTransaction(UserPagesViewModel model);
    }
}
