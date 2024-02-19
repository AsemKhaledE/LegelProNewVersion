using LegelProNewVersion.Models;
using LegelProNewVersion.ViewModels;

namespace LegelProNewVersion.Repository.Interface
{
    public interface IDepartmentRepository
    {
        List<tbl_Department> List();
        tbl_Department GetById(int departmentId);
        void Add(DepartmentViewModel tbl_Department);
        void Update(int departmentId, tbl_Department tbl_Department);
        void Delete(int departmentId);
        List<tbl_Department> ApproveAll();
        List<tbl_Department> DenialAll();
        bool AreAllApproved();
        bool IsNameEnglishFound(string EnglishName);
        bool IsNameArabicFound(string ArabicName);
    }
}
