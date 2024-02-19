using LegelProNewVersion.Data;
using LegelProNewVersion.Models;
using LegelProNewVersion.Repository.Interface;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace LegelProNewVersion.Repository.Service
{
    public class ExternalPermissionRepository
    {
        private ClassFunction classFunction = new ClassFunction();
        public List<string> GetUserRoles(int userId)
        {
            string cs = classFunction.GetConnectionString();
            var options = new DbContextOptionsBuilder<LegelProNewVersionDbContext>()
            .UseSqlServer(cs)
            .Options;
            var context = new LegelProNewVersionDbContext(options);

            var userRoles = context.UserRoles.Include(x => x.tbl_Pages).Where(x => x.UserId == userId).Include(x => x.tbl_Employee).Select(x => x.tbl_Pages.Name).ToList();
            return userRoles;
        }

        public List<string> GetRoles()
        {
            string cs = classFunction.GetConnectionString();
            var options = new DbContextOptionsBuilder<LegelProNewVersionDbContext>()
            .UseSqlServer(cs)
            .Options;

            var context = new LegelProNewVersionDbContext(options);
            var Roles = context.tbl_Pages.Select(x => x.Name).ToList();
            return Roles;
        }
        public string GetPageNameAr(string pageName)
        {
            string cs = classFunction.GetConnectionString();
            var options = new DbContextOptionsBuilder<LegelProNewVersionDbContext>()
            .UseSqlServer(cs)
            .Options;

            var context = new LegelProNewVersionDbContext(options);
            var nameAr = context.tbl_Pages.Where(x => x.Name == pageName).Select(x => x.NameAr).FirstOrDefault();
            return nameAr!;
        }
        public string GetPageNameEn(string pageName)
        {
            string cs = classFunction.GetConnectionString();
            var options = new DbContextOptionsBuilder<LegelProNewVersionDbContext>()
            .UseSqlServer(cs)
            .Options;

            var context = new LegelProNewVersionDbContext(options);
            var nameEn = context.tbl_Pages.Where(x => x.Name == pageName).Select(x => x.NameEn).FirstOrDefault();
            return nameEn!;
        }
        public tbl_Pages GetPageData(string pageName)
        {
            string cs = classFunction.GetConnectionString();
            var options = new DbContextOptionsBuilder<LegelProNewVersionDbContext>()
            .UseSqlServer(cs)
            .Options;

            var context = new LegelProNewVersionDbContext(options);
            var page = context.tbl_Pages.Where(x => x.Name == pageName).FirstOrDefault();
            return page!;
        }
    }
}
