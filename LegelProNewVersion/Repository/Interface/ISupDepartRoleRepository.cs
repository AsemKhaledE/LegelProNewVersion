using LegelProNewVersion.Models;
using LegelProNewVersion.ViewModels;

namespace LegelProNewVersion.Repository.Interface
{
    public interface ISupDepartRoleRepository
    {
        List<tbl_SubDepartmentRole> GetSubDepartRoles();
        void Add(tbl_SubDepartmentRole subDepartmentRole);
        //void Edit(tbl_SubDepartmentRole subDepartmentRole);
        tbl_SubDepartmentRole Edit(tbl_SubDepartmentRole subDepartmentRole);
        List<tbl_SubDepartmentRole> GetSubDepartNameEmpty();
        void SaveChanges();
        string GetLocalizedErrorMessage(string errorMessageKey, string culture);
        SubDepartmentRoleViewModel GetSubRolesWithPages(int departmentId, int subDepartmentId);
        tbl_SubDepartmentRole GetRoleById(int departmentId, int? subDepartment);
        void RemoveRolesByDepartmentAndSubDepartment(int departmentId, int? subDepartmentId);
    }
}
