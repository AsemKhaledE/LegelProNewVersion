using LegelProNewVersion.Models;
using LegelProNewVersion.ViewModels;
using System.Collections.Generic;

namespace LegelProNewVersion.Repository.Interface
{
    public interface ISystemConfigRepository
    {
        AllSystemConfigViewModel GetAllConfigData();
        WelcomeScreenAPIResponse GetAPIConfigData();
        void CreateConfigSystem(tbl_SystemConfig SystemConfig);
        void CreateLoginStyle(List<tbl_LoginStyle> LoginStyles);
        void CreateMainStyle(List<tbl_MainStyle> MainStyles);
        void CreateLoginStyleImage(List<tbl_LoginStyleImages> loginStyleImages);
        void UpdateConfigSystem(int id, UpdateSystemConfigViewModel U_SystemConfig);
        UpdateSystemConfigViewModel GetOneOfUpdate(int id);
        tbl_SystemConfig GetOneOfDetails(int id);
    }
}
