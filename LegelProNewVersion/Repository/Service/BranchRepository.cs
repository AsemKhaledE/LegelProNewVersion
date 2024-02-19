using LegelProNewVersion.Data;
using LegelProNewVersion.Models;
using LegelProNewVersion.Repository.Interface;
using LegelProNewVersion.ViewModels;
using Microsoft.Extensions.Localization;
using System.Data.Entity;
using System.Globalization;

namespace LegelProNewVersion.Repository.Service
{
    public class BranchRepository : IBranchRepository
    {
        LegelProNewVersionDbContext _context;
        private readonly IStringLocalizer<BranchRepository> _localizer;
        public BranchRepository(LegelProNewVersionDbContext context, IStringLocalizer<BranchRepository> localizer)
        {
            _context = context;
            _localizer = localizer;
        }

        public void AddBranch(tbl_Branch model)
        {
            try
            {
                if (model == null || model.AreaId == 0)
                {
                    throw new Exception("Branches And Area Not Found!");
                }
                _context.tbl_Branchs.Add(model);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        public List<tbl_Branch> ApproveAllBranches()
        {
            try
            {
                var branchesToApprove = _context.tbl_Branchs.Where(b => b.ApproveStatusId == 1).ToList();
                foreach (var branch in branchesToApprove)
                {
                    branch.ApproveStatusId = 2;
                }
                _context.SaveChanges();
                return branchesToApprove;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<tbl_Branch> GetBranches()
        {
            try
            {
                var branches = _context.tbl_Branchs.OrderBy(x => x.tbl_ApproveStatus.ApproveStatusId == 1).Include(x => x.tbl_Areas).ToList();               
                return branches;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        public tbl_Branch GetById(int branchId)
        {
            var branch = _context.tbl_Branchs.Include(x => x.tbl_Areas).FirstOrDefault(x => x.BranchId == branchId);
            return branch!;
        }

        public void UpdateBranch(int branchId, tbl_Branch tbl_Branch)
        {
            try
            {
                _context.Update(tbl_Branch);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public bool AreAllBranchesApproved()
        {
            // Check if all branches have ApproveStatusId equal to 2
            return _context.tbl_Branchs.All(b => b.ApproveStatusId ==2);
        }

        public List<tbl_Branch> DenialAllBranches()
        {
            try
            {
                var branchesToDenial = _context.tbl_Branchs.Where(b => b.ApproveStatusId == 1).ToList();
                foreach (var branch in branchesToDenial)
                {
                    branch.ApproveStatusId = 3;
                }
                _context.SaveChanges();
                return branchesToDenial;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public bool IsBranchNameEnglishFound(string branchEnglishName)
        {         
            var isBranchAlreadyExists = _context.tbl_Branchs.Any(x => x.BranchEnglishName == branchEnglishName);
            return isBranchAlreadyExists;
        }

        public bool IsBranchNameArabicFound(string branchArabicName)
        {
            var isBranchAlreadyExists = _context.tbl_Branchs.Any(x => x.BranchArabicName == branchArabicName);
            return isBranchAlreadyExists;
        }
    }
}