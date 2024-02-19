using LegelProNewVersion.Models;
using System.Drawing.Drawing2D;

namespace LegelProNewVersion.Repository.Interface
{
    public interface IImportanceOfMailRepository
    {
        List<tbl_TheImportanceOfMail> List();
        tbl_TheImportanceOfMail GetById(int id);
        void Add(tbl_TheImportanceOfMail importanceOfMail);
        void Update(int id, tbl_TheImportanceOfMail importanceOfMail);
        void Delete(int id);
        List<tbl_TheImportanceOfMail> ApproveAll();
        List<tbl_TheImportanceOfMail> DenialAll();
        bool AreAllApproved();
        bool IsNameEnglishFound(string EnglishName);
        bool IsNameArabicFound(string ArabicName);
    }
}
