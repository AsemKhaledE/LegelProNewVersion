using LegelProNewVersion.Models;
using System.Drawing.Drawing2D;

namespace LegelProNewVersion.Repository.Interface
{
    public interface IJobRepository
    {
        List<tbl_Job> List();
        tbl_Job GetById(int id);
        void Add(tbl_Job tbl_Job);
        void Update(int jobId, tbl_Job tbl_Job);
        void Delete(int id);
        List<tbl_Job> ApproveAll();
        List<tbl_Job> DenialAll();
        bool AreAllApproved();
        bool IsNameEnglishFound(string EnglishName);
        bool IsNameArabicFound(string ArabicName);
    }
}
