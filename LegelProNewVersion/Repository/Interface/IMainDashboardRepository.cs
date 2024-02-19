using LegelProNewVersion.Models;
using LegelProNewVersion.ViewModels;
using System.Collections.Generic;

namespace LegelProNewVersion.Repository.Interface
{
    public interface IMainDashboardRepository
    {
        tbl_MainStyle GetOne(int id);
        List<tbl_MainStyle> ListMainStyle();
        void UpdateMainStyle(int id, tbl_MainStyle U_MainStyles);
        void CreateMainStyle(tbl_MainStyle A_MainStyles);

    }
}
