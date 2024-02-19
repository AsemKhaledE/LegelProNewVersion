using LegelProNewVersion.Migrations;
using LegelProNewVersion.Models;
using LegelProNewVersion.ViewModels;

namespace LegelProNewVersion.Repository.Interface
{
    public interface IUserRoleRepository
    {
        List<tbl_UserRole> GetListUserRoles();
        UserRoleViewModel GetUserRolesWithPages(int userId, int employeeId);
        void RemoveUserRolesById(int userId, int employeeId);
        void Add(tbl_UserRole tbl_UserRole);
        void SaveChanges();
        tbl_UserRole GetPageRole(int userId,int PageId);
    }
}
