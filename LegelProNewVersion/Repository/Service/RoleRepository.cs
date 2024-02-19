using LegelProNewVersion.Data;
using LegelProNewVersion.Models;
using LegelProNewVersion.Repository.Interface;

namespace LegelProNewVersion.Repository.Service
{
    public class RoleRepository : IRoleRepository
    {
        LegelProNewVersionDbContext _context;
        public RoleRepository(LegelProNewVersionDbContext context)
        {
            _context = context;
        }
        public List<tbl_SubDepartmentRole> List()
        {
            var roles =_context.tbl_SubDepartmentRoles.ToList();
            return roles;
        }
    }
}
