namespace LegelProNewVersion.Repository.Interface
{
    public interface IExternalPermissionRepository
    {
        List<string> GetUserPermissions(int userId);
        List<string> GetPeremissions();
        string GetPageNameAr(string pageName);
        string GetPageNameEn(string pageName);

    }
}
