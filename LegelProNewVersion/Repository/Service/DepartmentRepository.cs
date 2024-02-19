using LegelProNewVersion.Data;
using LegelProNewVersion.Models;
using LegelProNewVersion.Repository.Interface;
using LegelProNewVersion.ViewModels;
using System.Data.Entity;

namespace LegelProNewVersion.Repository.Service
{
    public class DepartmentRepository : IDepartmentRepository
    {
        LegelProNewVersionDbContext _context;
        public DepartmentRepository(LegelProNewVersionDbContext context)
        {
            _context = context;
        }
        public void Add(DepartmentViewModel departmentViewModel)
        {
            try
            {
                var tbl_Department = new tbl_Department
                {
                    DepartmentEnglishName = departmentViewModel.DepartmentEnglishName,
                    DepartmentArabicName = departmentViewModel.DepartmentArabicName,
                    DepartmentId = departmentViewModel.DepartmentId,
                    ApproveStatusId = departmentViewModel.ApproveStatusId,
                    BranchId=departmentViewModel.BranchId,
                    IsSupDepartment=departmentViewModel.IsSupDepartment,
                    ReasonForRejection = departmentViewModel.ReasonForRejection,

                };

                _context.tbl_Departments.Add(tbl_Department);
                _context.SaveChanges();

                if (departmentViewModel.IsSupDepartment == false)
                {
                    var subDepartment = new tbl_SubDepartment
                    {
                        SubDepartmentEnglishName = tbl_Department.DepartmentEnglishName,
                        SubDepartmentArabicName = tbl_Department.DepartmentArabicName,
                        DepartmentId = tbl_Department.DepartmentId,
                        ApproveStatusId = tbl_Department.ApproveStatusId,
                        ReasonForRejection = tbl_Department.ReasonForRejection,
                    };

                    _context.tbl_SubDepartments.Add(subDepartment);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(int departmentId)
        {
            try
            {

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public tbl_Department GetById(int departmentId)
        {
            try
            {
                var getDepartment = _context.tbl_Departments.Include(x=>x.tbl_Branch).FirstOrDefault(x => x.DepartmentId == departmentId);
                return getDepartment!;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<tbl_Department> List()
        {
            try
            {
                var list =_context.tbl_Departments.Include(x => x.tbl_Branch).ToList();
                return list;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Update(int departmentId, tbl_Department tbl_Department )
        {
            try
            {
                _context.tbl_Departments.Update(tbl_Department);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public bool AreAllApproved()
        {
            return _context.tbl_Departments.All(b => b.ApproveStatusId ==2);
        }
        public List<tbl_Department> ApproveAll()
        {
            try
            {
                var departmentsToApprove = _context.tbl_Departments.Where(b => b.ApproveStatusId == 1).ToList();
                foreach (var department in departmentsToApprove)
                {
                    department.ApproveStatusId = 2;
                }
                _context.SaveChanges();
                return departmentsToApprove;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<tbl_Department> DenialAll()
        {
            try
            {
                var departmentsToDenial = _context.tbl_Departments.Where(b => b.ApproveStatusId == 1).ToList();
                foreach (var department in departmentsToDenial)
                {
                    department.ApproveStatusId = 3;
                }
                _context.SaveChanges();
                return departmentsToDenial;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public bool IsNameEnglishFound(string EnglishName)
        {
            var isAlreadyExists = _context.tbl_Departments.Any(x => x.DepartmentEnglishName == EnglishName);
            return isAlreadyExists;
        }

        public bool IsNameArabicFound(string ArabicName)
        {
            var isAlreadyExists = _context.tbl_Departments.Any(x => x.DepartmentArabicName == ArabicName);
            return isAlreadyExists;
        }
    }
}
