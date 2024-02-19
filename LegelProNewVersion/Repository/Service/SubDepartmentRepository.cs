using LegelProNewVersion.Data;
using LegelProNewVersion.Models;
using LegelProNewVersion.Repository.Interface;
using System.Data.Entity;

namespace LegelProNewVersion.Repository.Service
{
    public class SubDepartmentRepository : ISubDepartmentRepository
    {
        LegelProNewVersionDbContext _context;
        public SubDepartmentRepository(LegelProNewVersionDbContext context)
        {
            _context = context;
        }
        public void Add(tbl_SubDepartment tbl_SubDepartment)
        {
            try
            {
                _context.tbl_SubDepartments.Add(tbl_SubDepartment);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(int subDepartmentId)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public tbl_SubDepartment GetById(int subDepartmentId)
        {
            try
            {
                var getSub = _context.tbl_SubDepartments.Include(x=>x.tbl_Department).FirstOrDefault(x => x.SubDepartmentId == subDepartmentId);
                return getSub!;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<tbl_SubDepartment> List()
        {
            try
            {
                var records = _context.tbl_SubDepartments.Include(x => x.tbl_Department).ToList();
                return records;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(int subDepartmentId, tbl_SubDepartment tbl_SubDepartment)
        {
            try
            {
                _context.tbl_SubDepartments.Update(tbl_SubDepartment);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool AreAllApproved()
        {
            return _context.tbl_SubDepartments.All(b => b.ApproveStatusId ==2);
        }
        public List<tbl_SubDepartment> ApproveAll()
        {
            try
            {
                var subDepartmentsToApprove = _context.tbl_SubDepartments.Where(b => b.ApproveStatusId == 1).ToList();
                foreach (var subDepartment in subDepartmentsToApprove)
                {
                    subDepartment.ApproveStatusId = 2;
                }
                _context.SaveChanges();
                return subDepartmentsToApprove;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<tbl_SubDepartment> DenialAll()
        {
            try
            {
                var subDepartmentsToDenial = _context.tbl_SubDepartments.Where(b => b.ApproveStatusId == 1).ToList();
                foreach (var subDepartment in subDepartmentsToDenial)
                {
                    subDepartment.ApproveStatusId = 3;
                }
                _context.SaveChanges();
                return subDepartmentsToDenial;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public bool IsNameEnglishFound(string EnglishName)
        {
            var isAlreadyExists = _context.tbl_SubDepartments.Any(x => x.SubDepartmentEnglishName == EnglishName);
            return isAlreadyExists;
        }

        public bool IsNameArabicFound(string ArabicName)
        {
            var isAlreadyExists = _context.tbl_SubDepartments.Any(x => x.SubDepartmentArabicName == ArabicName);
            return isAlreadyExists;
        }
    }
}
