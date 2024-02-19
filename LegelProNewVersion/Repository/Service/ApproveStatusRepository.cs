using LegelProNewVersion.Data;
using LegelProNewVersion.Models;
using LegelProNewVersion.Repository.Interface;

namespace LegelProNewVersion.Repository.Service
{
    public class ApproveStatusRepository : IApproveStatusRepository
    {
        LegelProNewVersionDbContext _context;
        public ApproveStatusRepository(LegelProNewVersionDbContext context)
        {
            _context = context;
        }
        public List<tbl_ApproveStatus> List()
        {
            var records = _context.tbl_ApproveStatuses.ToList();
            return records;
        }
    }
}
