using LegelProNewVersion.Models;

namespace LegelProNewVersion.Repository.Interface
{
    public interface ITypeOfJobRepository
    {
        List<tbl_TypeOfJob> List();
        tbl_TypeOfJob GetById(int typeOfJobId);
        void Add(tbl_TypeOfJob tbl_TypeOfJob);
        void Update(int typeOfJobId, tbl_TypeOfJob tbl_TypeOfJob);
        List<tbl_TypeOfJob> ApproveAll();
        List<tbl_TypeOfJob> DenialAll();
        bool AreAllApproved();
        bool IsNameArFound(string nameAr);
        bool IsNameEnFound(string nameEn);
    }
}
