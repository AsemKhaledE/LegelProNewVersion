using LegelProNewVersion.Models;

namespace LegelProNewVersion.Repository.Interface
{
    public interface IEntityRepository
    {
        void AddEntity(tbl_Entities tbl_Entities); 
        List<tbl_Entities> GetAllEntity();
        tbl_Entities GetById(int id);
        void EditEntity(int entityId,tbl_Entities tbl_Entities);
        List<tbl_Entities> ApproveAll();
        List<tbl_Entities> DenialAll();
        bool AreAllApproved();
    }
}
