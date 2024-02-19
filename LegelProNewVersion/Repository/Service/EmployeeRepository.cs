using LegelProNewVersion.Data;
using LegelProNewVersion.Models;
using LegelProNewVersion.Repository.Interface;
using LegelProNewVersion.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace LegelProNewVersion.Repository.Service
{
    public class EmployeeRepository : IEmployeeRepository
    {
        LegelProNewVersionDbContext _context;
        public EmployeeRepository(LegelProNewVersionDbContext context)
        {
            _context = context;
        }
        public void AddEmpolyee(EmployeeViewModel model)
        {
            var transaction = _context.Database.BeginTransaction();

            var subDepartments = _context.tbl_SubDepartments
              .Where(sd => sd.DepartmentId == model.DepartmentId)
              .ToList();
            try
            {
                if (subDepartments == null || subDepartments.Count == 0)
                {
                    var departmentInfo = _context.tbl_Departments
                    .Where(d => d.DepartmentId == model.DepartmentId)
                    .Select(d => new
                    {
                        EnglishName = d.DepartmentEnglishName,
                        ArabicName = d.DepartmentArabicName,
                        ApproveStatus=d.ApproveStatusId
                    })

                    .FirstOrDefault();

                    if (departmentInfo != null && !string.IsNullOrEmpty(departmentInfo.ArabicName))
                    {
                        var defaultSubDepartment = new tbl_SubDepartment
                        {
                            SubDepartmentEnglishName = departmentInfo.EnglishName,
                            SubDepartmentArabicName = departmentInfo.ArabicName,
                            DepartmentId = model.DepartmentId,
                            ApproveStatusId = model.ApproveStatusId
                        };
                        AddSubDepartment(defaultSubDepartment);
                        var subDepartmentId = defaultSubDepartment.SubDepartmentId;

                        model.SubDepartmentId = subDepartmentId;
                    }
                }
                // CreateEmployee
                var employee = new tbl_Employee
                {
                    EmployeeArabicName = model.EmployeeArabicName,
                    EmployeeEnglishName = model.EmployeeEnglishName,
                    Address = model.Address,
                    BranchId = model.BranchId,
                    ApproveStatusId = model.ApproveStatusId,
                    tbl_JobId = model.tbl_JobId,
                    TypeOfJobId = model.TypeOfJobId,
                    PhoneNumber = model.PhoneNumber,
                    DepartmentId = model.DepartmentId,
                    SubDepartmentId = model.SubDepartmentId,
                };

                _context.Employees.Add(employee);
                _context.SaveChanges();

                var lastEmployee = employee.EmployeeId;

                var user = new tbl_Users
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    Password = model.Password,
                    IsActive = true,
                    UserEndDate = model.UserEndDate,
                    UserStartDate = model.UserStartDate,
                    EmployeeId = lastEmployee,
                };

                _context.tbl_Users.Add(user);
                _context.SaveChanges();

                transaction.Commit();
            }
            catch (DbUpdateException ex)
            {
                transaction.Rollback();
                throw new Exception("Error occurred while updating the database.", ex);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception("An unexpected error occurred.", ex);
            }
        }

        public List<tbl_Employee> ListUser()
        {
            try
            {
                var users = _context.Employees.Include(x => x.tbl_Users).ToList();
                return users;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<tbl_Employee> ListEmployee()
        {

            try
            {
                var emplyee = _context.Employees
                    .Include(x => x.tbl_ApproveStatus)
                    .Include(x => x.tbl_Branch)
                    .Include(x => x.tbl_Users)
                    .Include(x => x.tbl_Jobs)
                    .Include(x => x.tbl_TypeOfJobs)
                    .Include(x => x.SubDepartment)
                    .Include(x => x.Department)
                    .ToList();
                return emplyee;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void UpdateEmployeeAndUser(EmployeeViewModel employee)
        {
            var transaction = _context.Database.BeginTransaction();

            try
            {
                // Update Employee
                var existingEmployee = _context.Employees.Find(employee.EmployeeId);

                if (existingEmployee != null)
                {
                    existingEmployee.EmployeeArabicName = employee.EmployeeArabicName;
                    existingEmployee.EmployeeEnglishName = employee.EmployeeEnglishName;
                    existingEmployee.Address = employee.Address;
                    existingEmployee.BranchId = employee.BranchId;
                    existingEmployee.ApproveStatusId = employee.ApproveStatusId;
                    existingEmployee.tbl_JobId = employee.tbl_JobId;
                    existingEmployee.TypeOfJobId = employee.TypeOfJobId;
                    existingEmployee.PhoneNumber = employee.PhoneNumber;
                    existingEmployee.DepartmentId = employee.DepartmentId;
                    existingEmployee.SubDepartmentId = employee.SubDepartmentId;

                    _context.SaveChanges();
                }

                // Update User
                var existingUser = _context.tbl_Users.Find(employee.UserId);

                if (existingUser != null)
                {
                    existingUser.UserName = employee.UserName;
                    existingUser.Email = employee.Email;
                    existingUser.Password = employee.Password;
                    existingUser.IsActive = true;
                    existingUser.UserEndDate = employee.UserEndDate;
                    existingUser.UserStartDate = employee.UserStartDate;
                    existingUser.EmployeeId = employee.EmployeeId;

                    _context.SaveChanges();
                }

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception(ex.Message);
            }
        }

        public tbl_Users GetUserById(int id)
        {
            var user = _context.tbl_Users.FirstOrDefault(x => x.UserId == id);
            return user!;
        }

        //public tbl_UserRole GetUserRoleById(int id)
        //{
        //    var userRole = _context.UserRoles.FirstOrDefault(x => x.SubId == id);
        //    return userRole!;
        //}

        public tbl_UserPages GetUserPermissionById(int id)
        {
            var userPermission = _context.UserPages.FirstOrDefault(x => x.UserId == id);
            return userPermission!;
        }

        public List<tbl_SubDepartment> GetListSubDepartmentById(int departmentId)
        {
            var listSub = _context.tbl_SubDepartments
         .Where(x => x.DepartmentId == departmentId)
         .ToList();
            return listSub;
        }

        public EmployeeViewModel GetEmployeeById(int id)
        {
            var getEmployee = _context.Employees
        .Where(x => x.EmployeeId == id)
        .Select(x => new EmployeeViewModel
        {
            EmployeeId = x.EmployeeId,
            Address = x.Address!,
            ApproveStatusId = x.ApproveStatusId,
            TypeOfJobId = x.TypeOfJobId,
            tbl_JobId = x.tbl_JobId,
            UserEndDate = x.tbl_Users.Select(u => u.UserEndDate).FirstOrDefault(),
            UserStartDate = x.tbl_Users.Select(u => u.UserStartDate).FirstOrDefault(),
            BranchId = x.BranchId,
            DepartmentId = x.DepartmentId,
            SubDepartmentId = x.SubDepartmentId,
            Email = x.tbl_Users.Select(u => u.Email).FirstOrDefault()!,
            EmployeeArabicName = x.EmployeeArabicName,
            EmployeeEnglishName = x.EmployeeEnglishName,
            Password = x.tbl_Users.Select(u => u.Password).FirstOrDefault()!,
            UserName = x.tbl_Users.Select(u => u.UserName).FirstOrDefault()!,
            PhoneNumber = x.PhoneNumber,
            UserId = x.tbl_Users.Select(u => u.UserId).FirstOrDefault(),
        })
        .FirstOrDefault();

            return getEmployee!;
        }
        public void AddSubDepartment(tbl_SubDepartment subDepartment)
        {
            _context.tbl_SubDepartments.Add(subDepartment);
            _context.SaveChanges();
        }
    }
}
