using LegelProNewVersion.Models;
using Microsoft.EntityFrameworkCore;

namespace LegelProNewVersion.Data
{
    public class LegelProNewVersionDbContext : DbContext
    {
        public LegelProNewVersionDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<tbl_LoginStyle> tbl_LoginStyles { get; set; }
        public DbSet<tbl_MainStyle> tbl_MainStyles { get; set; }
        public DbSet<tbl_SystemConfig> tbl_SystemConfigs { get; set; }
        public DbSet<tbl_LoginStyleImages> tbl_LoginStyleImages { get; set; }
        public DbSet<tbl_ApproveStatus> tbl_ApproveStatuses { get; set; }
        public DbSet<tbl_Users> tbl_Users { get; set; }
        public DbSet<tbl_UserRole> UserRoles { get; set; }
        public DbSet<tbl_Pages> tbl_Pages { get; set; }
        public DbSet<tbl_UserPages> UserPages { get; set; }
        public DbSet<tbl_RolePages> RolePages { get; set; }
        public DbSet<tbl_Employee> Employees { get; set; }
        public DbSet<tbl_Areas> tbl_Areas { get; set; }
        public DbSet<tbl_Bank> tbl_Banks { get; set; }
        public DbSet<tbl_Branch> tbl_Branchs { get; set; }
        public DbSet<tbl_Client> tbl_Clients { get; set; }
        public DbSet<tbl_Entities> tbl_Entities { get; set; }
        public DbSet<tbl_Job> tbl_Jobs { get; set; }
        public DbSet<tbl_Mailer> tbl_Mailers { get; set; }
        public DbSet<tbl_Department> tbl_Departments { get; set; }
        public DbSet<tbl_SubDepartment> tbl_SubDepartments { get; set; }
        public DbSet<tbl_TypeOfJob> tbl_TypeOfJobs { get; set; }
        public DbSet<tbl_TypeOfMail> tbl_TypeOfMail { get; set; }
        public DbSet<tbl_TheImportanceOfMail> TheImportanceOfMails { get; set; }
        public DbSet<tbl_SubDepartmentRole> tbl_SubDepartmentRoles { get; set; }
        public DbSet<tbl_AdvancedSetting> tbl_AdvancedSettings { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.SeedData();
            builder.Entity<tbl_LoginStyle>().ToTable("tbl_LoginStyle", "Login");
            builder.Entity<tbl_MainStyle>().ToTable("tbl_MainStyle", "Main");
            builder.Entity<tbl_SystemConfig>().ToTable("tbl_SystemConfig", "System");
            builder.Entity<tbl_LoginStyleImages>().ToTable("tbl_LoginStyleImages", "Login");
            builder.Entity<tbl_Client>().ToTable("tbl_Client", "MainDetails");
            builder.Entity<tbl_Areas>().ToTable("tbl_Areas", "MainDetails");
            builder.Entity<tbl_Bank>().ToTable("tbl_Bank", "MainDetails");
            builder.Entity<tbl_Branch>().ToTable("tbl_Branch", "MainDetails");
            builder.Entity<tbl_Entities>().ToTable("tbl_Entities", "MainDetails");
            builder.Entity<tbl_Job>().ToTable("tbl_Job", "MainDetails");
            builder.Entity<tbl_Mailer>().ToTable("tbl_Mailer", "MainDetails");
            builder.Entity<tbl_Department>().ToTable("tbl_Department", "MainDetails");
            builder.Entity<tbl_SubDepartment>().ToTable("tbl_SubDepartment", "MainDetails");
            builder.Entity<tbl_TypeOfJob>().ToTable("tbl_TypeOfJob", "MainDetails");
            builder.Entity<tbl_TypeOfMail>().ToTable("tbl_TypeOfMail", "MainDetails");
            builder.Entity<tbl_TheImportanceOfMail>().ToTable("tbl_TheImportanceOfMail", "MainDetails");
            builder.Entity<tbl_Users>().ToTable("tbl_Users", "Security");
            builder.Entity<tbl_UserRole>().ToTable("tbl_UserRole", "Security");
            builder.Entity<tbl_Pages>().ToTable("tbl_Pages", "Security");
            builder.Entity<tbl_UserPages>().ToTable("tbl_UserPages", "Security");
            builder.Entity<tbl_Employee>().ToTable("tbl_Employee", "Security");
            builder.Entity<tbl_RolePages>().ToTable("tbl_RolePages", "Security");
            builder.Entity<tbl_ApproveStatus>().ToTable("tbl_ApproveStatus", "Security");
            builder.Entity<tbl_SubDepartmentRole>().ToTable("tbl_SubDepartmentRole", "Security");
            builder.Entity<tbl_AdvancedSetting>().ToTable("tbl_AdvancedSetting", "System");
        }
    }
}
