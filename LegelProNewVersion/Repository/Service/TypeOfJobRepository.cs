using LegelProNewVersion.Data;
using LegelProNewVersion.Models;
using LegelProNewVersion.Repository.Interface;

namespace LegelProNewVersion.Repository.Service
{
    public class TypeOfJobRepository : ITypeOfJobRepository
    {
        LegelProNewVersionDbContext _context;
        public TypeOfJobRepository(LegelProNewVersionDbContext context)
        {
            _context = context;
        }
        public void Add(tbl_TypeOfJob tbl_TypeOfJob)
        {
            try
            {
                _context.Add(tbl_TypeOfJob);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public tbl_TypeOfJob GetById(int typeOfJobId)
        {
            try
            {
                var typeOfJob = _context.tbl_TypeOfJobs!.FirstOrDefault(f => f.TypeOfJobId == typeOfJobId);
                return typeOfJob!;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        public List<tbl_TypeOfJob> List()
        {
            try
            {
                var list = _context.tbl_TypeOfJobs.ToList();
                return list;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        public void Update(int typeOfJobId, tbl_TypeOfJob tbl_TypeOfJob)
        {
            try
            {
                _context.tbl_TypeOfJobs.Update(tbl_TypeOfJob);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public List<tbl_TypeOfJob> ApproveAll()
        {
            try
            {
                var typeOfJobsToApprove = _context.tbl_TypeOfJobs.Where(b => b.ApproveStatusId == 1).ToList();
                foreach (var typeOfJob in typeOfJobsToApprove)
                {
                    typeOfJob.ApproveStatusId = 2;
                }
                _context.SaveChanges();
                return typeOfJobsToApprove;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public bool AreAllApproved()
        {
            return _context.tbl_TypeOfJobs.All(b => b.ApproveStatusId ==2);
        }

        public List<tbl_TypeOfJob> DenialAll()
        {
            try
            {
                var typeOfJobsToDenial = _context.tbl_TypeOfJobs.Where(b => b.ApproveStatusId == 1).ToList();
                foreach (var typeOfJob in typeOfJobsToDenial)
                {
                    typeOfJob.ApproveStatusId = 3;
                }
                _context.SaveChanges();
                return typeOfJobsToDenial;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public bool IsNameArFound(string nameAr)
        {
            var isAlreadyExists = _context.tbl_TypeOfJobs.Any(x => x.NameAr == nameAr);
            return isAlreadyExists;
        }
        public bool IsNameEnFound(string nameEn)
        {
            var isAlreadyExists = _context.tbl_TypeOfJobs.Any(x => x.NameEn == nameEn);
            return isAlreadyExists;
        }
    }
}
