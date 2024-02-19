using LegelProNewVersion.Data;
using LegelProNewVersion.Models;
using LegelProNewVersion.Repository.Interface;
using LegelProNewVersion.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace LegelProNewVersion.Repository.Service
{
    public class UserRoleRepository : IUserRoleRepository
    {
        LegelProNewVersionDbContext _context;
        public UserRoleRepository(LegelProNewVersionDbContext context)
        {
            _context = context;
        }
        public List<tbl_UserRole> GetListUserRoles()
        {
            var list = _context.UserRoles.Where(x => x.DepartmentId != 1).Include(x => x.User).Include(x => x.tbl_Employee).Include(x => x.tbl_Department).Include(x => x.SubDepartment).ToList().GroupBy(x => x.EmployeeId)
       .SelectMany(group => group
           .Any() ? group.Take(1) // If duplicated, take only one record
           : group) // If not duplicated, include all records
       .ToList();
            return list;
        }
        public UserRoleViewModel GetUserRolesWithPages(int userId, int employeeId)
        {
            var userRoles = _context.UserRoles.Include(x => x.tbl_Department).Include(x => x.SubDepartment).Include(x => x.User).Include(x => x.tbl_Employee)
                 .Where(x => x.UserId == userId && x.EmployeeId == employeeId)
                 .ToList();

            var pagesList = _context.tbl_Pages.ToList().Where(x => x.PageId >= 2).ToList();

            var resultUserRoles = userRoles.Select(userRole =>
            {
                var selectedPages = _context.UserRoles
                    .Where(x => x.UserId == userId && x.EmployeeId == employeeId
                    )
                    .Select(x => new ListSelectedPages
                    {
                        RoleNameAr = x.tbl_Pages.NameAr,
                        RoleNameEn = x.tbl_Pages.NameEn,
                        IsDetails = x.IsDetails,
                        IsMaker = x.IsMaker,
                        IsView = x.IsView,
                        IsAdd = x.IsAdd,
                        IsDelete = x.IsDelete,
                        IsEdit = x.IsEdit,
                        PageId = x.PageId,

                    })
                    .ToList();

                return new UserRoleViewModel
                {
                    UserId = userId,
                    EmployeeId = employeeId,
                    DepartmentId = userRole.DepartmentId,
                    SubDepartmentId = userRole.SubDepartmentId,
                    tbl_UserRoles = userRoles,
                    PagesList = pagesList,
                    SelectedPages = selectedPages
                };
            }).FirstOrDefault();
            List<ListSelectedPages> NewList = new List<ListSelectedPages>();
            foreach (var page in pagesList)
            {
                var found = userRoles.Where(x => x.PageId == page.PageId).FirstOrDefault();
                if (found == null)
                {
                    ListSelectedPages listPage = new ListSelectedPages { PageId = page.PageId, RoleNameAr = page.NameAr, RoleNameEn = page.NameEn };
                    NewList.Add(listPage);
                }
            }
            resultUserRoles!.SelectedPages.AddRange(NewList);
            return resultUserRoles!;
        }
        public void RemoveUserRolesById(int userId, int employeeId)
        {
            var rolesToRemove = _context.UserRoles
                .Where(role => role.UserId == userId && role.EmployeeId == employeeId)
                .ToList();

            if (rolesToRemove.Any())
            {
                _context.UserRoles.RemoveRange(rolesToRemove);
            }
        }
        public void Add(tbl_UserRole tbl_UserRole)
        {
            try
            {
                _context.UserRoles.Add(tbl_UserRole);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public tbl_UserRole GetPageRole(int userId, int pageId)
        {
            var page = _context.UserRoles.Where(x => x.UserId == userId && x.PageId == pageId).FirstOrDefault();
            return page!;
        }
    }
}
