using LegelProNewVersion.Models;
using LegelProNewVersion.Repository.Interface;
using LegelProNewVersion.Repository.Service;
using LegelProNewVersion.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using System.Globalization;

namespace LegelProNewVersion.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IJobRepository _jobRepository;
        private readonly IBranchRepository _branchRepository;
        private readonly IApproveStatusRepository _approveStatusRepository;
        private readonly ITypeOfJobRepository _typeOfJobRepository;
        private readonly ISubDepartmentRepository _subDepartmentRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IStringLocalizer<EmployeeController> _localizer;

        public EmployeeController(IEmployeeRepository employeeRepository,
            IDepartmentRepository departmentRepository,
            ISubDepartmentRepository subDepartmentRepository,
            IJobRepository jobRepository,
            IBranchRepository branchRepository,
            IApproveStatusRepository approveStatusRepository,
            ITypeOfJobRepository typeOfJobRepository
            , IStringLocalizer<EmployeeController> localizer)
        {
            _employeeRepository = employeeRepository;
            _jobRepository = jobRepository;
            _branchRepository = branchRepository;
            _approveStatusRepository = approveStatusRepository;
            _typeOfJobRepository = typeOfJobRepository;
            _departmentRepository = departmentRepository;
            _subDepartmentRepository = subDepartmentRepository;
            _localizer = localizer;
        }
        public IActionResult Index()
        {
            try
            {
                var currentCulture = CultureInfo.CurrentCulture.Name.StartsWith("ar");

                var getListJob = _jobRepository.List().Where(x => x.ApproveStatusId == 2);
                var getListBranch = _branchRepository.GetBranches().Where(x => x.ApproveStatusId == 2);
                var getListApproveStatus = _approveStatusRepository.List();
                var getListTypeOfJob = _typeOfJobRepository.List().Where(x => x.ApproveStatusId == 2);
                var getDepartment = _departmentRepository.List().Where(x => x.ApproveStatusId == 2 && x.DepartmentId > 2);
                var getSupDepartment = _subDepartmentRepository.List().Where(x => x.ApproveStatusId == 2);
                var jobs = new List<SelectListItem>();
                var branchs = new List<SelectListItem>();
                var approveStatus = new List<SelectListItem>();
                var typeOfJob = new List<SelectListItem>();
                var departments = new List<SelectListItem>();
                var supDepartments = new List<SelectListItem>();
                if (currentCulture == true)
                {
                    foreach (var record in getListJob)
                    {

                        jobs.Add(new SelectListItem { Text = record.JobArabicName, Value = record.JobId.ToString() });
                    }

                    foreach (var record in getListBranch)
                    {

                        branchs.Add(new SelectListItem { Text = record.BranchArabicName, Value = record.BranchId.ToString() });
                    }

                    foreach (var record in getListApproveStatus)
                    {

                        approveStatus.Add(new SelectListItem { Text = record.ApproveArabicName, Value = record.ApproveStatusId.ToString() });
                    }

                    foreach (var record in getListTypeOfJob)
                    {

                        typeOfJob.Add(new SelectListItem { Text = record.NameAr, Value = record.TypeOfJobId.ToString() });
                    }

                    foreach (var record in getDepartment)
                    {

                        departments.Add(new SelectListItem { Text = record.DepartmentArabicName, Value = record.DepartmentId.ToString() });
                    }

                    foreach (var record in getSupDepartment)
                    {

                        supDepartments.Add(new SelectListItem { Text = record.SubDepartmentArabicName, Value = record.SubDepartmentId.ToString() });
                    }
                }
                else 
                {
                    foreach (var record in getListJob)
                    {

                        jobs.Add(new SelectListItem { Text = record.JobEnglishName, Value = record.JobId.ToString() });
                    }

                    foreach (var record in getListBranch)
                    {

                        branchs.Add(new SelectListItem { Text = record.BranchEnglishName, Value = record.BranchId.ToString() });
                    }

                    foreach (var record in getListApproveStatus)
                    {

                        approveStatus.Add(new SelectListItem { Text = record.ApproveEnglishName, Value = record.ApproveStatusId.ToString() });
                    }

                    foreach (var record in getListTypeOfJob)
                    {

                        typeOfJob.Add(new SelectListItem { Text = record.NameEn, Value = record.TypeOfJobId.ToString() });
                    }

                    foreach (var record in getDepartment)
                    {

                        departments.Add(new SelectListItem { Text = record.DepartmentEnglishName, Value = record.DepartmentId.ToString() });
                    }

                    foreach (var record in getSupDepartment)
                    {

                        supDepartments.Add(new SelectListItem { Text = record.SubDepartmentEnglishName, Value = record.SubDepartmentId.ToString() });
                    }
                }
                
                ViewData["JobItem"] = jobs;
                ViewData["DepartmentItem"] = departments;
                ViewData["SupDepartmentItem"] = supDepartments;
                ViewData["TypeOfJobItem"] = typeOfJob;
                ViewData["BranchItem"] = branchs;
                ViewData["ApproveStatusItem"] = approveStatus;
                var employee = _employeeRepository.ListEmployee();
                return View(employee);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Create(EmployeeViewModel viewModel)
        {
            try
            {
                _employeeRepository.AddEmpolyee(viewModel);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult GetSubDepartment(int id)
        {
            var getListSubDepartment = _employeeRepository.GetListSubDepartmentById(id).Where(x => x.ApproveStatusId == 2).ToList();

            if (getListSubDepartment.Count == 0)
            {
                return Ok("not found Sub-Department for this Department");
            }
            return Ok(getListSubDepartment);
        }

        [HttpGet]
        public ActionResult GetEmployeeById(int employeeId)
        {
            ViewBag.ApproveStatus = new SelectList(_approveStatusRepository.List(), "ApproveStatusId", "ApproveEnglishName");
            ViewBag.Jobs = new SelectList(_jobRepository.List().Where(x => x.ApproveStatusId == 2), "JobId", "JobEnglishName");
            ViewBag.TypeOfJobs = new SelectList(_typeOfJobRepository.List().Where(x => x.ApproveStatusId == 2), "TypeOfJobId", "Name");
            ViewBag.Branchs = new SelectList(_branchRepository.GetBranches().Where(x => x.ApproveStatusId == 2), "BranchId", "BranchEnglishName");
            ViewBag.Departments = new SelectList(_departmentRepository.List().Where(x => x.ApproveStatusId == 2), "DepartmentId", "DepartmentEnglishName");
            ViewBag.SubDepartments = new SelectList(_subDepartmentRepository.List().Where(x => x.ApproveStatusId == 2), "SubDepartmentId", "SubDepartmentEnglishName");
            var employee = _employeeRepository.GetEmployeeById(employeeId);
            return PartialView("_Edit", employee);
        }

        [HttpGet]
        public ActionResult GetDetails(int employeeId)
        {
            ViewBag.ApproveStatus = new SelectList(_approveStatusRepository.List(), "ApproveStatusId", "ApproveEnglishName");
            ViewBag.Jobs = new SelectList(_jobRepository.List().Where(x => x.ApproveStatusId == 2), "JobId", "JobEnglishName");
            ViewBag.TypeOfJobs = new SelectList(_typeOfJobRepository.List().Where(x => x.ApproveStatusId == 2), "TypeOfJobId", "Name");
            ViewBag.Branchs = new SelectList(_branchRepository.GetBranches().Where(x => x.ApproveStatusId == 2), "BranchId", "BranchEnglishName");
            ViewBag.Departments = new SelectList(_departmentRepository.List().Where(x => x.ApproveStatusId == 2 && x.DepartmentId > 2), "DepartmentId", "DepartmentEnglishName");
            ViewBag.SubDepartments = new SelectList(_subDepartmentRepository.List().Where(x => x.ApproveStatusId == 2), "SubDepartmentId", "SubDepartmentEnglishName");
            var employee = _employeeRepository.GetEmployeeById(employeeId);
            return PartialView("_Details", employee);
        }

        [HttpPost]
        public IActionResult Edit(EmployeeViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid is false)
                {
                    ViewBag.ApproveStatus = new SelectList(_approveStatusRepository.List(), "ApproveStatusId", "ApproveEnglishName");
                    ViewBag.Jobs = new SelectList(_jobRepository.List().Where(x => x.ApproveStatusId == 2), "JobId", "JobEnglishName");
                    ViewBag.TypeOfJobs = new SelectList(_typeOfJobRepository.List().Where(x => x.ApproveStatusId == 2), "TypeOfJobId", "Name");
                    ViewBag.Branchs = new SelectList(_branchRepository.GetBranches().Where(x => x.ApproveStatusId == 2), "BranchId", "BranchEnglishName");
                    ViewBag.Departments = new SelectList(_departmentRepository.List().Where(x => x.ApproveStatusId == 2 && x.DepartmentId > 2), "DepartmentId", "DepartmentEnglishName");
                    ViewBag.SubDepartments = new SelectList(_subDepartmentRepository.List().Where(x => x.ApproveStatusId == 2), "SubDepartmentId", "SubDepartmentEnglishName");
                }
                _employeeRepository.UpdateEmployeeAndUser(viewModel);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }

}

