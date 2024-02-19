using LegelProNewVersion.Models;
using System.Drawing.Drawing2D;

namespace LegelProNewVersion.Repository.Interface
{
    public interface ITypeOfMailRepository
    {
        List<tbl_TypeOfMail> List();
        tbl_TypeOfMail GetById(int typeOfMailId);
        void Add(tbl_TypeOfMail tbl_TypeOfMail);
        void Update(int typeOfMailId, tbl_TypeOfMail tbl_TypeOfMail);
        void Delete(int typeOfMailId);
        bool IsNameEnglishFound(string EnglishName);
        bool IsNameArabicFound(string ArabicName);
    }
}
