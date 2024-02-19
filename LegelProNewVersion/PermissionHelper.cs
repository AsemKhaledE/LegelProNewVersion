using LegelProNewVersion.Data;
using LegelProNewVersion.Models;
using LegelProNewVersion.Repository.Service;
using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

namespace LegelProNewVersion
{
    public static class PermissionHelper
    {
        public static bool HasPermission(HttpContext httpContext, string permission)
        {
            var permissions = httpContext.Session.Keys.ToList();

            if (permissions.Count == 0)
            {
                var user = new IdentityInfo(httpContext);
                ExternalPermissionRepository permissionRepository = new ExternalPermissionRepository();

                var userPermissions = permissionRepository.GetUserRoles(user.UserId);
                var allPermissions = permissionRepository.GetRoles();
                foreach (var userPermission in allPermissions)
                {
                    bool isPre = userPermissions.Contains(userPermission);
                    httpContext.Session.SetInt32(userPermission, isPre ? 1 : 0);
                }
            }

            var permitted = httpContext.Session.GetInt32(permission);
            if (permitted == null || permitted == 0)
            {
                return false;
            }

            return true;
        }

        public static string PermissionNameAr(string nameAr)
        {
            {
                ExternalPermissionRepository permissionRepository = new ExternalPermissionRepository();

                var getNameAr = permissionRepository.GetPageNameAr(nameAr);

                if (getNameAr != null)
                {

                    return getNameAr;
                }
                else
                {
                    return string.Empty;
                }
            }
        }
        public static string PermissionNameEn(string nameEn)
        {
            {
                ExternalPermissionRepository permissionRepository = new ExternalPermissionRepository();

                var getNameEn = permissionRepository.GetPageNameEn(nameEn);

                if (getNameEn != null)
                {

                    return getNameEn;
                }
                else
                {
                    return string.Empty;
                }
            }
        }
        public static tbl_Pages PermissionGetPageData(string pageName)
        {
            {
                ExternalPermissionRepository permissionRepository = new ExternalPermissionRepository();

                var page = permissionRepository.GetPageData(pageName);

               return page;
            }
        }
    }
}
