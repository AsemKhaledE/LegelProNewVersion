using LegelProNewVersion.Models;
using LegelProNewVersion.ViewModels;
using System.Collections.Generic;

namespace LegelProNewVersion.Repository.Interface
{
    public interface ILoginStyleRepository
    {
        tbl_LoginStyle GetOne(int id);
        List<tbl_LoginStyle> ListLoginStyle();
        void UpdateLoginStyle(EditLoginStyleViewModel U_loginStyle);
        void CreateLoginStyle(tbl_LoginStyle A_loginStyle);
        tbl_SystemConfig BackgroundStyle();
        UserViewModel GetUser(LoginViewModel loginViewModel ,out string Error);
    }
}
