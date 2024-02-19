using LegelProNewVersion.Data;
using LegelProNewVersion.Models;
using LegelProNewVersion.Repository.Interface;

namespace LegelProNewVersion.Repository.Service
{
    public class AdvancedSettingRepository : IAdvancedSettingRepository
    {
        LegelProNewVersionDbContext _context;
        public AdvancedSettingRepository(LegelProNewVersionDbContext context)
        {
            _context = context;
        }
        public tbl_AdvancedSetting Edit(tbl_AdvancedSetting AdvancedSetting, out string Error)
        {
            Error = "";
            try
            {
                _context.tbl_AdvancedSettings.Update(AdvancedSetting);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                Error = ex.Message;
            }
            return AdvancedSetting;
        }

        public tbl_AdvancedSetting GetById(int id)
        {
            var getDataById = _context.tbl_AdvancedSettings.Where(x => x.Id == id).FirstOrDefault();
            return getDataById!;
        }
    }
}
