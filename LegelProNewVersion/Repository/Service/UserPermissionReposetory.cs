using LegelProNewVersion.Data;
using LegelProNewVersion.Models;
using LegelProNewVersion.Repository.Interface;
using LegelProNewVersion.ViewModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data.Entity;
using System.Linq;

namespace LegelProNewVersion.Repository.Service
{
    public class UserPermissionReposetory : IUserPermissionReposetory
    {
        LegelProNewVersionDbContext _context;
        public UserPermissionReposetory(LegelProNewVersionDbContext context)
        {
            _context = context;
        }

        public tbl_Users FindById(int id)
        {
            try
            {
                var user = _context.tbl_Users.FirstOrDefault(x => x.UserId == id);
                return user;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
        public List<tbl_UserPages> GetUserPages(int userId)
        {
            try
            {
                var permission = _context.UserPages
                            .Where(x => x.UserId == userId).ToList();
                return permission;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        public List<tbl_Pages> ListPage()
        {
            try
            {
                var permissions = _context.tbl_Pages.ToList();
                return permissions;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }




        public void ManageUserPagesTransaction(UserPagesViewModel model)
        {
            var transaction = _context.Database.BeginTransaction();
            try
            {

                var userPermission = GetUserPages(model.UserId);
                foreach (var permission in model.AllPages)
                {

                    if (userPermission.Any(r => r.PageId == permission.PageId) && !permission.IsSelected)
                    {
                        var e = userPermission.Where(x => x.PageId == permission.PageId).FirstOrDefault();
                        _context.UserPages.Remove(e!);
                        _context.SaveChanges();
                    }

                    if (!userPermission.Any(r => r.PageId == permission.PageId) && permission.IsSelected)
                    {
                        var newPer = new UserPagesViewModel
                        {
                            UserId = model.UserId,
                            PageId = permission.PageId,
                        };
                        _context.UserPages.Add(newPer.ToEntity());
                        _context.SaveChanges();
                    }
                }
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception(ex.Message);
            }

        }

    }
}
