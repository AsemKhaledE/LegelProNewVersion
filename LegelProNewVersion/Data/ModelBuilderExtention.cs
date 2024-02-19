using LegelProNewVersion.Models;
using Microsoft.EntityFrameworkCore;
using System;
using static Azure.Core.HttpHeader;

namespace LegelProNewVersion.Data
{
    public static class ModelBuilderExtention
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<tbl_ApproveStatus>().HasData(
                new tbl_ApproveStatus { ApproveStatusId = 1, ApproveArabicName = "قيد الإنتظار", ApproveEnglishName = "Pending" },
                new tbl_ApproveStatus { ApproveStatusId = 2, ApproveArabicName = "موافقة", ApproveEnglishName = "Approve" },
                new tbl_ApproveStatus { ApproveStatusId = 3, ApproveArabicName = "رفض", ApproveEnglishName = "Denial" }
                );
            modelBuilder.Entity<tbl_LoginStyleImages>().HasData(
                new tbl_LoginStyleImages { Id = 1, ImagePath = "/img1 style 3.jpg", tbl_LoginStyleId = 3 }
                );
            modelBuilder.Entity<tbl_MainStyle>().HasData(
                new tbl_MainStyle { Id = 1, StyleNameArabic = "لوحة التحكم 1", StyleNameEnglish = "Dashboard 1", DescriptionArabic = "لوحة التحكم", DescriptionEnglish = "Dashboard", DashboardPath = "_dashboard", WelcomePageImagePath = "/img/logoo.png" }
                );
            modelBuilder.Entity<tbl_LoginStyle>().HasData(
                new tbl_LoginStyle { Id = 1, LoginBackground = "white", StyleNameArabic = "النمط الاول", StyleNameEnglish = "Style1", TextFont = "cursive", TextColor = "White", LoginColor = "black", LoginPath = "/LoginStyle/style1", IsMultiImage = false },
                new tbl_LoginStyle { Id = 2, LoginBackground = "white", StyleNameArabic = "النمط الثاني", StyleNameEnglish = "Style2", TextFont = "cursive", TextColor = "black", LoginColor = "White", LoginPath = "/LoginStyle/style2", IsMultiImage = false },
                new tbl_LoginStyle { Id = 3, LoginBackground = "white", StyleNameArabic = "النمط الثالث", StyleNameEnglish = "Style3", TextFont = "cursive", TextColor = "black", LoginColor = "White", LoginPath = "/LoginStyle/style3", IsMultiImage = true }
                );
            modelBuilder.Entity<tbl_Bank>().HasData(
                new tbl_Bank { BankId = 1, BankName = "البنك العربي الافريقي" }
                       );
            modelBuilder.Entity<tbl_SystemConfig>().HasData(
                new tbl_SystemConfig
                {
                    Id = 1,
                    ActiveDirectoryEnable = true,
                    ActiveDirectoryDomain = "Active",
                    ActiveDirectoryIbmLink = "Active",
                    ActiveDirectoryIsAttachment = true,
                    ActiveDirectoryIsIbmAttachment = true,
                    ActiveDirectoryIsSendMail = true,
                    ActiveDirectoryPassword = "123",
                    ActiveDirectoryUserName = "Active@gmail.com",
                    BankBranchNumber = 1,
                    BankImagePath = "/img/BankImage.jpg",
                    BankLogoPath = "/img/Banklogo.jpg",
                    BankNameArabic = "بنك مصر",
                    EnableMultiLanguage = true,
                    EnableOTP = true,
                    BankNameEnglish = "bank misr",
                    WelcomeScreenImage = "/img/logoo.jpg",
                    WelcomeScreenTimeInterval = 10,
                    NumberOfMaxCreateUser = 1,
                    NumberOfMaxUserLoginAtTime = 1,
                    tbl_LoginStyleId = 3,
                    tbl_MainStyleId = 1,
                    WelcomeScreenTextArabic = "مرحبا",
                    WelcomeScreenTextEnglish = "Welcome"
                }
                );
            modelBuilder.Entity<tbl_Pages>().HasData(
            new tbl_Pages
            {
                PageId = 1,
                Name = "system-configurations",
                NameAr = "الاعدادات العامة للنظام الخاصة بالشركة ",
                NameEn = "System Configs"
            }, new tbl_Pages
            {
                PageId = 2,
                Name = "view-branches",
                NameAr = "الفروع",
                NameEn = "Branches "
            }, new tbl_Pages
            {
                PageId = 3,
                Name = "view-regions",
                NameAr = "المناطق",
                NameEn = "Regions "
            }, new tbl_Pages
            {
                PageId = 4,
                Name = "view-jobs",
                NameAr = "الوظائف",
                NameEn = "Jobs"
            }, new tbl_Pages
            {
                PageId = 5,
                Name = "view-entities",
                NameAr = "الجهات",
                NameEn = "Entities"
            }, new tbl_Pages
            {
                PageId = 6,
                Name = "view-department",
                NameAr = "الاقسسام الرئيسية",
                NameEn = "Departments"
            }, new tbl_Pages
            {
                PageId = 7,
                Name = "view-sub-departments",
                NameAr = "الاقسسام الفرعية",
                NameEn = "Sub-Departments"
            }, new tbl_Pages
            {
                PageId = 8,
                Name = "view-the-importance-of-mail",
                NameAr = "أهمية البريد",
                NameEn = "The Importance Of Mail"
            }, new tbl_Pages
            {
                PageId = 9,
                Name = "view-types-of-mail",
                NameAr = "نوع البريد",
                NameEn = "Types Of Mail"
            }, new tbl_Pages
            {
                PageId = 10,
                Name = "view-manage-permissions",
                NameAr = "ادارة الصلاحيات",
                NameEn = "Manage Permissions"
            }, new tbl_Pages
            {
                PageId = 11,
                Name = "view-employee",
                NameAr = "بيانات الموظفين",
                NameEn = "Employee Data"
            }, new tbl_Pages
            {
                PageId = 12,
                Name = "view-type-of-job",
                NameAr = "نوع الوظيفة",
                NameEn = "Types Of Job"
            }, new tbl_Pages
            {
                PageId = 13,
                Name = "view-mailers",
                NameAr = "جهات البريد",
                NameEn = "Mailers"
            },
             new tbl_Pages
             {
                 PageId = 14,
                 Name = "view-clients",
                 NameAr = "العملاء",
                 NameEn = "Clients "
             },
             new tbl_Pages
             {
                 PageId = 15,
                 Name = "sub-Roles",
                 NameAr = "صلاحيات الادارات الفرعية",
                 NameEn = "Sub-Department Roles"
             },
             new tbl_Pages
             {
                 PageId = 16,
                 Name = "emlpoyee-Roles",
                 NameAr = "صلاحيات الموظفين",
                 NameEn = "Emlpoyee Roles"
             }
           );
            modelBuilder.Entity<tbl_Areas>().HasData(
             new tbl_Areas
             {
                 AreaId = 1,
                 AreaArabicName = "المنطقة",
                 AreaEnglishName = "Area",
                 ApproveStatusId = 2
             }
               );
            modelBuilder.Entity<tbl_Branch>().HasData(
            new tbl_Branch
            {
                BranchId = 1,
                BranchArabicName = "الفرع الرئيسي",
                BranchEnglishName = "Main Branch",
                ApproveStatusId = 2,
                AreaId = 1
            }
            );
            modelBuilder.Entity<tbl_Job>().HasData(
            new tbl_Job
            {
                JobId = 1,
                JobArabicName = "مهندس تقني",
                JobEnglishName = "Technical Engineer",
                ApproveStatusId = 2
            }
            );
            modelBuilder.Entity<tbl_TypeOfJob>().HasData(
            new tbl_TypeOfJob
            {
                TypeOfJobId = 1,
                NameEn = "Engineer",
                NameAr = "مهندس",
                ApproveStatusId = 2
            }
            );
            modelBuilder.Entity<tbl_Department>().HasData(new tbl_Department
            {
                DepartmentId = 1,
                DepartmentArabicName = "شركة EHM",
                DepartmentEnglishName = "EHM",
                ApproveStatusId = 2,
                IsSupDepartment = false,
                BranchId = 1
            }, new tbl_Department
            {
                DepartmentId = 2,
                DepartmentArabicName = "الدعم الفني للنظام",
                DepartmentEnglishName = "System Technical Support",
                ApproveStatusId = 2,
                IsSupDepartment = true,
                BranchId = 1
            });
            modelBuilder.Entity<tbl_SubDepartment>().HasData(
                 new tbl_SubDepartment
                 {
                     SubDepartmentId =1,
                     SubDepartmentArabicName = "EHMشركة",
                     SubDepartmentEnglishName = "EHM",
                     ApproveStatusId = 2,
                     DepartmentId = 1
                 },
                 new tbl_SubDepartment
            {
                SubDepartmentId = 2,
                SubDepartmentArabicName = "منفذ النظام",
                SubDepartmentEnglishName = "Maker",
                ApproveStatusId = 2,
                DepartmentId = 2
            }, new tbl_SubDepartment
            {
                SubDepartmentId = 3,
                SubDepartmentArabicName = "مصرح النظام",
                SubDepartmentEnglishName = "Checher",
                ApproveStatusId = 2,
                DepartmentId = 2
            }
            );

            modelBuilder.Entity<tbl_SubDepartmentRole>().HasData(
             new tbl_SubDepartmentRole
             {
                 SubRoleId = 1,
                 RoleNameEn = "AdminEHM",
                 RoleNameAr = "EHMشركة",
                 DepartmentId = 1,
                 IsAdd = false,
                 IsChecher = false,
                 IsDelete = false,
                 IsDetails = false,
                 IsEdit = false,
                 IsMaker = false,
                 IsView = false,
                 PageId = 1,
                 SubDepartmentId = 1
             });
            int Count = 2;
            for ( int PageIdCount = 2; PageIdCount <= 13; PageIdCount++ )
            {
                modelBuilder.Entity<tbl_SubDepartmentRole>().HasData(
                    new tbl_SubDepartmentRole
                    {
                        SubRoleId = Count++,
                        RoleNameEn = "",
                        RoleNameAr = "",                        
                        IsAdd = true,                       
                        IsDelete = true,
                        IsDetails = true,
                        IsEdit = true,
                        IsMaker = true,
                        IsChecher = false,
                        IsView = true,
                        PageId = PageIdCount,
                        DepartmentId = 2,
                        SubDepartmentId = 2,

                    },
                     new tbl_SubDepartmentRole
                     {
                         SubRoleId = Count++,
                         RoleNameEn = "",
                         RoleNameAr = "",
                         IsAdd = false,                        
                         IsDelete = false,
                         IsDetails = true,
                         IsEdit = false,
                         IsChecher = true,
                         IsMaker = false,
                         IsView = true,
                         PageId = PageIdCount,
                         DepartmentId = 2,
                         SubDepartmentId = 3,
                     });
            }

             modelBuilder.Entity<tbl_Employee>().HasData(
            new tbl_Employee
            {
                EmployeeId = 1,
                EmployeeArabicName = "شركة EHM",
                EmployeeEnglishName = "EHM",
                SubDepartmentId = 1,
                DepartmentId = 1,
                PhoneNumber = "",
                BranchId = 1,
                tbl_JobId = 1,
                TypeOfJobId = 1,
                ApproveStatusId = 2,
                Address = ""
            }, new tbl_Employee
             {
                 EmployeeId = 2,
                 EmployeeArabicName = "منفذ النظام",
                 EmployeeEnglishName = "Maker",
                 SubDepartmentId = 2,
                 DepartmentId = 2,
                 PhoneNumber = "",
                 BranchId = 1,
                 tbl_JobId = 1,
                 TypeOfJobId = 1,
                 ApproveStatusId = 2,
                 Address = ""
             }, new tbl_Employee
             {
                 EmployeeId = 3,
                 EmployeeArabicName = "مصرح النظام",
                 EmployeeEnglishName = "Checher",
                 SubDepartmentId = 3,
                 DepartmentId = 2,
                 PhoneNumber = "",
                 BranchId = 1,
                 tbl_JobId = 1,
                 TypeOfJobId = 1,
                 ApproveStatusId = 2,
                 Address = ""
             }
             );
            modelBuilder.Entity<tbl_Users>().HasData(
               new tbl_Users//EHM
               {
                   UserId = 1,
                   EmployeeId=1,
                   Email = "",
                   Password= "P@ssword123",
                   UserName = "AdminEHM"
               },
               new tbl_Users//Maker
               {
                   UserId = 2,
                   EmployeeId=2,
                   Email = "",
                   Password = "P@ssword123",
                   UserName = "Maker"
               },
              new tbl_Users//Checker
              {
                  UserId = 3,
                  EmployeeId=3,
                  Email = "",
                  Password = "P@ssword123",
                  UserName = "Checher",                  
              }
              );
            modelBuilder.Entity<tbl_UserRole>().HasData(
                    new tbl_UserRole
                    {
                        Id = 1,
                        EmployeeId =1,
                        UserId = 1,
                        IsAdd = true,
                        IsDelete = true,
                        IsDetails = true,
                        IsEdit = true,
                        IsMaker = true,
                        IsChecher = false,
                        IsView = true,
                        PageId = 1,
                        DepartmentId = 1,
                        SubDepartmentId = 1,
                    });
            Count = 2;
            for (int PageIdCount = 2; PageIdCount <= 13; PageIdCount++)
            {
                modelBuilder.Entity<tbl_UserRole>().HasData(
                    new tbl_UserRole
                    {
                        Id = Count++,
                        EmployeeId = 2,
                        UserId=2,
                        IsAdd = true,
                        IsDelete = true,
                        IsDetails = true,
                        IsEdit = true,
                        IsMaker = true,
                        IsChecher = false,
                        IsView = true,
                        PageId = PageIdCount,
                        DepartmentId = 2,
                        SubDepartmentId = 2,
                    },
                     new tbl_UserRole
                     {
                         Id = Count++,
                         EmployeeId = 3,
                         UserId = 3,
                         IsAdd = false,
                         IsDelete = false,
                         IsDetails = true,
                         IsEdit = false,
                         IsChecher = true,
                         IsMaker = false,
                         IsView = true,
                         PageId = PageIdCount,
                         DepartmentId = 2,
                         SubDepartmentId = 3,
                     });
            }
            modelBuilder.Entity<tbl_AdvancedSetting>().HasData(
                    new tbl_AdvancedSetting
                    {
                        Id=1,
                        CheckedData = false,
                    });
            
        }
    }
}
