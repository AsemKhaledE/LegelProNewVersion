using LegelProNewVersion.Models;
using LegelProNewVersion.ViewModels;

namespace LegelProNewVersion.Repository.Interface
{
    public interface IBranchRepository
    {
        List<tbl_Branch> GetBranches();
        List<tbl_Branch> ApproveAllBranches();
        List<tbl_Branch> DenialAllBranches();
        bool AreAllBranchesApproved();
        bool IsBranchNameEnglishFound(string branchEnglishName);
        bool IsBranchNameArabicFound(string branchArabicName);
        void AddBranch(tbl_Branch tbl_Branch);
        void UpdateBranch(int branchId,tbl_Branch tbl_Branch);
        tbl_Branch GetById(int branchId);
        
    }
}
