using LegelProNewVersion.Models;

namespace LegelProNewVersion.Repository.Interface
{
    public interface ISubDepartmentRepository
    {
        List<tbl_SubDepartment> List();
        tbl_SubDepartment GetById(int subDepartmentId);
        void Add(tbl_SubDepartment tbl_SubDepartment);
        void Update(int subDepartmentId, tbl_SubDepartment tbl_SubDepartment);
        void Delete(int subDepartmentId);
        List<tbl_SubDepartment> ApproveAll();
        List<tbl_SubDepartment> DenialAll();
        bool AreAllApproved();
        bool IsNameEnglishFound(string EnglishName);
        bool IsNameArabicFound(string ArabicName);
    }
}
