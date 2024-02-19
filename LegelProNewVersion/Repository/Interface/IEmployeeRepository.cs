using LegelProNewVersion.Models;
using LegelProNewVersion.ViewModels;

namespace LegelProNewVersion.Repository.Interface
{
    public interface IEmployeeRepository
    {
        List<tbl_Employee> ListEmployee();
        void AddEmpolyee(EmployeeViewModel employee);
        List<tbl_SubDepartment> GetListSubDepartmentById(int departmentId);
        void UpdateEmployeeAndUser(EmployeeViewModel employee);
        EmployeeViewModel GetEmployeeById(int id);

    }
}
