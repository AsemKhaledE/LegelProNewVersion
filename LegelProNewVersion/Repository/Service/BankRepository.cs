using LegelProNewVersion.Data;
using LegelProNewVersion.Models;
using LegelProNewVersion.Repository.Interface;

namespace LegelProNewVersion.Repository.Service
{
    public class BankRepository : IBankRepository
    {
        LegelProNewVersionDbContext _context;
        public BankRepository(LegelProNewVersionDbContext context)
        {
            _context = context;
        }
        public List<tbl_Bank> GetBanks()
        {
            var banks = _context.tbl_Banks.ToList();
            return banks;
        }
    }
}
