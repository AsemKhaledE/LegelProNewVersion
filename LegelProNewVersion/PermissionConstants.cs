using LegelProNewVersion.Models;
using Microsoft.Extensions.Localization;
using System.Drawing.Drawing2D;

namespace LegelProNewVersion
{
    public class PermissionConstants(IStringLocalizer<tbl_Pages> localizer)
    {
        public const string ViewSystemConfig = "system-configurations";
        public const string ViewBranches = "view-branches";
        public const string ViewClients = "view-clients";
        public const string ViewRegions = "view-regions";
        public const string ViewJobs = "view-jobs";
        public const string ViewEntities = "view-entities";
        public const string ViewDepartments = "view-department";
        public const string ViewSubDepartments = "view-sub-departments";
        public const string ViewMailers = "view-mailers";
        public const string ViewTheImportanceOfMail = "view-the-importance-of-mail";
        public const string ViewTypesOfMail = "view-types-of-mail";
        public const string ViewManagePermissions = "view-manage-permissions";
        public const string ViewTypeOfJob = "view-type-of-job";
        public const string ViewEmployee = "view-employee";
        public const string ViewSubRoles = "sub-Roles";
        public const string ViewEmployeeRoles = "emlpoyee-Roles";
    }
}
