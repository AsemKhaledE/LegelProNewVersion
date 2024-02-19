using LegelProNewVersion.Data;
using LegelProNewVersion.Models;
using LegelProNewVersion.Repository.Interface;

namespace LegelProNewVersion.Repository.Service
{
    public class MainDashboardRepository : IMainDashboardRepository
    {
        LegelProNewVersionDbContext _context;
        public MainDashboardRepository(LegelProNewVersionDbContext context)
        {
            _context = context;
        }

        public void CreateMainStyle(tbl_MainStyle A_MainStyles)
        {
            try
            {
                _context.Add(A_MainStyles);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }




        public tbl_MainStyle GetOne(int id)
        {
            var mainDashboard = _context.tbl_MainStyles.FirstOrDefault(f => f.Id == id);
            return mainDashboard!;
        }

        public List<tbl_MainStyle> ListMainStyle()
        {
            try
            {
                var list = _context.tbl_MainStyles.ToList();
                return list;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


        public void UpdateMainStyle(int id, tbl_MainStyle U_MainStyles)
        {
            try
            {
                _context.Update(U_MainStyles);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
    }
}
