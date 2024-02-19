using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using LegelProNewVersion.Repository.Service;

namespace LegelProNewVersion
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class PermissionAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private readonly string _permission;

        public PermissionAuthorizeAttribute(string permission)
        {
            _permission = permission;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var permissions = context.HttpContext.Session.Keys.ToList();
            if (permissions.Count == 0)
            {
                var user = new IdentityInfo(context.HttpContext);
                ExternalPermissionRepository permissionRepository = new ExternalPermissionRepository();

                var userPermissions = permissionRepository.GetUserRoles(user.UserId);
                var allPermissions = permissionRepository.GetRoles();
                foreach (var permission in allPermissions)
                {
                    bool isPre = userPermissions.Contains(permission);
                    context.HttpContext.Session.SetInt32(permission, isPre ? 1 : 0);
                }
            }

            var permitted = context.HttpContext.Session.GetInt32(_permission);
            if (permitted == null || permitted == 0)
            {
                context.Result = new ForbidResult();
            }
        }
    }

    public class IdentityInfo : IByUser
    {
        private readonly HttpContext _context;

        public IdentityInfo(HttpContext accessor)
        {
            _context = accessor;
        }

        public string FullName
            => GetValue(ClaimTypes.Name);

        public int UserId
            => GetIntValue(ApplicationClaimTypes.UserId);

        public string Email
            => GetValue(ClaimTypes.Email);

        public int RoleId => GetIntValue(ApplicationClaimTypes.RoleId);

        public bool HasMultiRoles => GetListIntValue(ApplicationClaimTypes.RoleId).Count > 1;

        public List<int> RoleIds => GetListIntValue(ApplicationClaimTypes.RoleId);

        private string GetValue(string key)
        {
            if (_context.User == null) return string.Empty;

            return _context.User.FindFirstValue(key);
        }

        private int GetIntValue(string key)
        {
            int result = 0;
            if (_context.User == null) return result;

            var user = _context.User.FindFirstValue(key);
            if (user == null) return result;
            else
                if (int.TryParse(user, out result))
                return result;
            return result;
        }

        private List<int> GetListIntValue(string key)
        {
            if (_context.User == null) return new List<int>();

            var value = _context.User.FindAll(key);

            if (value.Any() is false) return new List<int>();

            return value.Select(x => int.Parse(x.Value)).ToList();
        }
    }

    public interface IByUser
    {
        int UserId { get; }

        string FullName { get; }
    }

    public static class ApplicationClaimTypes
    {
        private const string Root = "Thamm/schemas/claims/";

        public const string UserId = Root + "user-id";

        public const string RoleId = Root + "role-id";

        public const string PersonId = Root + "person-id";
    }
}
