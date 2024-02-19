using LegelProNewVersion.Data;
using LegelProNewVersion.Models;
using LegelProNewVersion.Repository.Interface;

namespace LegelProNewVersion.Repository.Service
{
    public class EntityRepository : IEntityRepository
    {
        LegelProNewVersionDbContext _context;
        public EntityRepository(LegelProNewVersionDbContext context)
        {
            _context = context;
        }
        public void AddEntity(tbl_Entities tbl_Entities)
        {
            try
            {
                _context.Add(tbl_Entities);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        public void EditEntity(int entityId, tbl_Entities tbl_Entities)
        {
            try
            {
                _context.Update(tbl_Entities);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<tbl_Entities> GetAllEntity()
        {
            var records = _context.tbl_Entities.ToList();
            return records;
        }

        public tbl_Entities GetById(int id)
        {
            var entity = _context.tbl_Entities!.FirstOrDefault(f => f.EntitieId == id);
            return entity!;
        }

        public List<tbl_Entities> ApproveAll()
        {
            try
            {
                var entitysToApprove = _context.tbl_Entities.Where(b => b.ApproveStatusId != 2).ToList();
                foreach (var entity in entitysToApprove)
                {
                    entity.ApproveStatusId = 2;
                }
                _context.SaveChanges();
                return entitysToApprove;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public bool AreAllApproved()
        {
            return _context.tbl_Entities.All(b => b.ApproveStatusId == 2);
        }

        public List<tbl_Entities> DenialAll()
        {
            try
            {
                var entitysToDenial = _context.tbl_Entities.Where(b => b.ApproveStatusId == 1).ToList();
                foreach (var entity in entitysToDenial)
                {
                    entity.ApproveStatusId = 3;
                }
                _context.SaveChanges();
                return entitysToDenial;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
