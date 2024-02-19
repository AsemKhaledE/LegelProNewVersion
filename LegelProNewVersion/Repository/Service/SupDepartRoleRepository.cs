using LegelProNewVersion.Data;
using LegelProNewVersion.Models;
using LegelProNewVersion.Repository.Interface;
using LegelProNewVersion.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace LegelProNewVersion.Repository.Service
{
    public class SupDepartRoleRepository : ISupDepartRoleRepository
    {
        LegelProNewVersionDbContext _context;
        public SupDepartRoleRepository(LegelProNewVersionDbContext context)
        {
            _context = context;
        }
        public void Add(tbl_SubDepartmentRole subDepartmentRole)
        {
            try
            {
                _context.tbl_SubDepartmentRoles.Add(subDepartmentRole);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void RemoveRolesByDepartmentAndSubDepartment(int departmentId, int? subDepartmentId)
        {
            var rolesToRemove = _context.tbl_SubDepartmentRoles
                .Where(role => role.DepartmentId == departmentId && role.SubDepartmentId == subDepartmentId)
                .ToList();

            if (rolesToRemove.Any())
            {
                _context.tbl_SubDepartmentRoles.RemoveRange(rolesToRemove);
            }
        }
        public tbl_SubDepartmentRole Edit(tbl_SubDepartmentRole subDepartmentRole)
        {
            try
            {
                _context.tbl_SubDepartmentRoles.Update(subDepartmentRole);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
               throw new Exception(ex.Message);
            }
            return subDepartmentRole;
        }
        public List<tbl_SubDepartmentRole> GetSubDepartNameEmpty()
        {
            var list = _context.tbl_SubDepartmentRoles.Where(x => x.RoleNameAr == "" || x.RoleNameEn == "").ToList();
            return list;
        }

        public SubDepartmentRoleViewModel GetSubRolesWithPages(int departmentId, int subDepartmentId)
        {
            var subDepartmentRoles = _context.tbl_SubDepartmentRoles.Include(x => x.tbl_Department).Include(x => x.SubDepartment)
                .Where(x => x.DepartmentId == departmentId && x.SubDepartmentId == subDepartmentId)
                .ToList();

            var pagesList = _context.tbl_Pages.ToList().Where(x => x.PageId >= 2).ToList();

            var resultsubDepartmentRoles = subDepartmentRoles.Select(subDeptRole =>
            {
                var selectedPages = _context.tbl_SubDepartmentRoles
                    .Where(x => x.DepartmentId == departmentId && x.SubDepartmentId == subDepartmentId
                    )
                    .Select(x => new ListPage
                    {
                        RoleNameAr = x.RoleNameAr,
                        RoleNameEn = x.RoleNameEn,
                        IsDetails = x.IsDetails,
                        IsMaker = x.IsMaker,
                        IsView = x.IsView,
                        IsAdd = x.IsAdd,
                        IsDelete = x.IsDelete,
                        IsEdit = x.IsEdit,
                        DepartmentId = departmentId,
                        SubDepartmentId = subDepartmentId,
                        PageId = x.PageId,
                    })
                    .ToList();

                return new SubDepartmentRoleViewModel
                {
                    DepartmentId = subDeptRole.DepartmentId,
                    SubDepartmentId = subDeptRole.SubDepartmentId,
                    SubDepartmentRoles = subDepartmentRoles,
                    PagesList = pagesList,
                    SelectedPages = selectedPages
                };
            }).FirstOrDefault();
            List<ListPage> NewList = new List<ListPage>();
            foreach (var page in pagesList)
            {
                var found = subDepartmentRoles.Where(x => x.PageId == page.PageId).FirstOrDefault();
                if (found == null)
                {
                    ListPage listPage = new ListPage { PageId = page.PageId, RoleNameAr = page.NameAr, RoleNameEn = page.NameEn };
                    NewList.Add(listPage);
                }
            }
            resultsubDepartmentRoles!.SelectedPages.AddRange(NewList);
            return resultsubDepartmentRoles!;
        }

        public List<tbl_SubDepartmentRole> GetSubDepartRoles()
        {
            var list = _context.tbl_SubDepartmentRoles.Where(x => x.DepartmentId != 1).Include(x => x.tbl_Department).Include(x => x.SubDepartment).ToList().GroupBy(x => x.SubDepartmentId)
        .SelectMany(group => group
            .Any() ? group.Take(1) // If duplicated, take only one record
            : group) // If not duplicated, include all records
        .ToList();
            return list;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public string GetLocalizedErrorMessage(string errorMessageKey, string culture)
        {

            var localizedMessages = new Dictionary<string, Dictionary<string, string>>
    {
        { "PleaseSelectDepartment", new Dictionary<string, string>
            {
                { "en", "Please Select Department" },
                { "ar", "برجاء اختيار القسم" }
            }
        },
        { "AdditionalAuthorityError", new Dictionary<string, string>
            {
                { "en", "Please have another additional authority" },
                { "ar", "برجاء صلاحية إضافية أخرى" }
            }
        },
        { "SelectOnePageError", new Dictionary<string, string>
            {
                { "en", "Please select at least one Of Pages" },
                { "ar", "برجاء اختيار واحدة على الأقل من الصفحات" }
            }
        },
    };

            if (localizedMessages.TryGetValue(errorMessageKey, out var messages))
            {
                if (messages.TryGetValue(culture, out var message))
                {
                    return message;
                }
            }

            if (localizedMessages.TryGetValue(errorMessageKey, out var defaultMessage))
            {
                if (defaultMessage.TryGetValue("en", out var defaultCultureMessage))
                {
                    return defaultCultureMessage;
                }
            }
            return errorMessageKey;
        }
        public tbl_SubDepartmentRole GetRoleById(int departmentId ,int? subDepartmentId)
        {
            return _context.tbl_SubDepartmentRoles.FirstOrDefault(r => r.DepartmentId == departmentId &&r.SubDepartmentId == subDepartmentId)!;
        }

    }
}
