using LegelProNewVersion.Data;
using LegelProNewVersion.Models;
using LegelProNewVersion.Repository.Interface;
using System.Drawing.Drawing2D;

namespace LegelProNewVersion.Repository.Service
{
    public class JobRepository : IJobRepository
    {
        LegelProNewVersionDbContext _context;
        public JobRepository(LegelProNewVersionDbContext context)
        {
            _context = context;
        }
        public void Add(tbl_Job newJobs)
        {
            try
            {
                _context.tbl_Jobs.Add(newJobs);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<tbl_Job> ApproveAll()
        {
            try
            {
                var jobsToApprove = _context.tbl_Jobs.Where(b => b.ApproveStatusId == 1).ToList();
                foreach (var job in jobsToApprove)
                {
                    job.ApproveStatusId = 2;
                }
                _context.SaveChanges();
                return jobsToApprove;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public bool AreAllApproved()
        {
            return _context.tbl_Jobs.All(b => b.ApproveStatusId ==2);
        }

        public List<tbl_Job> DenialAll()
        {
            try
            {
                var jobsToDenial = _context.tbl_Jobs.Where(b => b.ApproveStatusId == 1).ToList();
                foreach (var job in jobsToDenial)
                {
                    job.ApproveStatusId = 3;
                }
                _context.SaveChanges();
                return jobsToDenial;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public tbl_Job GetById(int id)
        {
            var job = _context.tbl_Jobs!.FirstOrDefault(f => f.JobId == id);
            return job!;
        }

        public List<tbl_Job> List()
        {
            try
            {
                var job = _context.tbl_Jobs!.ToList();
                return job;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(int jobId, tbl_Job job)
        {
            try
            {
                _context.Update(job);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public void Delete(int id)
        {
            try
            {
                var job = GetById(id);
                if (job != null)
                {
                    _context.tbl_Jobs.Remove(job);
                    _context.SaveChanges();

                }
                else
                {
                    throw new Exception("job Not Found");
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public bool IsNameEnglishFound(string EnglishName)
        {
            var isAlreadyExists = _context.tbl_Jobs.Any(x => x.JobEnglishName == EnglishName);
            return isAlreadyExists;
        }

        public bool IsNameArabicFound(string ArabicName)
        {
            var isAlreadyExists = _context.tbl_Jobs.Any(x => x.JobArabicName == ArabicName);
            return isAlreadyExists;
        }
    }
}
