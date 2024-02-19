using LegelProNewVersion.Models;
using System.Drawing.Drawing2D;

namespace LegelProNewVersion.Repository.Interface
{
    public interface IAreasRepository
    {
        List<tbl_Areas> List();
        tbl_Areas GetById(int id);
        void Add(tbl_Areas tbl_Areas);
        void Update(tbl_Areas tbl_Areas);
        List<tbl_Areas> ApproveAll();
        List<tbl_Areas> DenialAll();
        bool AreAllApproved();
        bool IsNameEnglishFound(string EnglishName);
        bool IsNameArabicFound(string ArabicName);
    }
}
