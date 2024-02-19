using LegelProNewVersion.Models;

namespace LegelProNewVersion.Repository.Interface
{
    public interface IAdvancedSettingRepository
    {
        tbl_AdvancedSetting Edit(tbl_AdvancedSetting tbl_AdvancedSetting,out string Error);
        tbl_AdvancedSetting GetById(int id);

    }
}
