using LegelProNewVersion.Models;
using System.Drawing.Drawing2D;

namespace LegelProNewVersion.Repository.Interface
{
    public interface IMailerRepository
    {
        List<tbl_Mailer> List();
        tbl_Mailer GetById(int mailerId);
        void Add(tbl_Mailer tbl_Mailer);
        void Update(int mailerId, tbl_Mailer tbl_Mailer);
        void Delete(int mailerId);
        List<tbl_Mailer> ApproveAll();
        List<tbl_Mailer> DenialAll();
        bool AreAllApproved();
        bool IsNameEnglishFound(string EnglishName);
        bool IsNameArabicFound(string ArabicName);
    }
}
