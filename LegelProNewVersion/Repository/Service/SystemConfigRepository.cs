using LegelProNewVersion.Data;
using LegelProNewVersion.Models;
using LegelProNewVersion.Repository.Interface;
using LegelProNewVersion.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;

namespace LegelProNewVersion.Repository.Service
{
    public class SystemConfigRepository : ISystemConfigRepository
    {
        LegelProNewVersionDbContext _context;
        public SystemConfigRepository(LegelProNewVersionDbContext context)
        {
            _context = context;
        }

  
        //create config system 
        public void CreateConfigSystem(tbl_SystemConfig SystemConfig)
        {
            try
            {
                _context.tbl_SystemConfigs.Add(SystemConfig);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
        //create login style
        public void CreateLoginStyle(List<tbl_LoginStyle> LoginStyles)
        {
            try
            {
                foreach (var tbl_LoginStyle in LoginStyles)
                {
                    _context.tbl_LoginStyles.Add(tbl_LoginStyle);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        //craete login style Image
        public void CreateLoginStyleImage(List<tbl_LoginStyleImages> loginStyleImages)
        {
            try
            {
                foreach (var tbl_LoginStyleImage in loginStyleImages)
                {
                    _context.tbl_LoginStyleImages.Add(tbl_LoginStyleImage);
                    _context.SaveChanges();

                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
        // create main style
        public void CreateMainStyle(List<tbl_MainStyle> MainStyles)
        {
            try
            {
                foreach (var tbl_MainStyle in MainStyles)
                {
                    _context.tbl_MainStyles.Add(tbl_MainStyle);
                    _context.SaveChanges();
                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        //get All data System Config , create (login style ,Main Style,System Config) when all data == null
        public AllSystemConfigViewModel GetAllConfigData()
        {
            try
            {

                var data = _context.tbl_SystemConfigs
                 .Include(x => x.tbl_LoginStyle)
                 .Include(x => x.tbl_LoginStyle.tbl_LoginStyleImages)
                 .Include(x => x.tbl_MainStyle).FirstOrDefault();
                var allSystemConfig = new AllSystemConfigViewModel();
                if (data != null)
                {
                    allSystemConfig = new AllSystemConfigViewModel
                    {
                        SystemConfig = new tbl_SystemConfig
                        {
                            WelcomeScreenImage = data.WelcomeScreenImage,
                            WelcomeScreenTextArabic = data.WelcomeScreenTextArabic,
                            WelcomeScreenTextEnglish = data.WelcomeScreenTextEnglish,
                            WelcomeScreenTimeInterval = data.WelcomeScreenTimeInterval,
                            ActiveDirectoryDomain = data.ActiveDirectoryDomain,
                            ActiveDirectoryEnable = data.ActiveDirectoryEnable,
                            ActiveDirectoryIbmLink = data.ActiveDirectoryIbmLink,
                            ActiveDirectoryPassword = data.ActiveDirectoryPassword,
                            ActiveDirectoryIsAttachment = data.ActiveDirectoryIsAttachment,
                            ActiveDirectoryIsIbmAttachment = data.ActiveDirectoryIsIbmAttachment,
                            ActiveDirectoryIsSendMail = data.ActiveDirectoryIsSendMail,
                            ActiveDirectoryUserName = data.ActiveDirectoryUserName,
                            BankBranchNumber = data.BankBranchNumber,
                            BankImagePath = data.BankImagePath,
                            BankLogoPath = data.BankLogoPath,
                            BankNameArabic = data.BankNameArabic,
                            BankNameEnglish = data.BankNameEnglish,
                            EnableMultiLanguage = data.EnableMultiLanguage,
                            NumberOfMaxCreateUser = data.NumberOfMaxCreateUser,
                            NumberOfMaxUserLoginAtTime = data.NumberOfMaxUserLoginAtTime,
                            tbl_LoginStyle = data.tbl_LoginStyle,
                            tbl_LoginStyleId = data.tbl_LoginStyleId,
                            tbl_MainStyle = data.tbl_MainStyle,
                            tbl_MainStyleId = data.tbl_MainStyleId,
                        },
                    };
                    allSystemConfig.LoginStyle = new tbl_LoginStyle
                    {
                        LoginPath = data.tbl_LoginStyle.LoginPath
                    };
                    allSystemConfig.LoginStyleImages = data.tbl_LoginStyle.tbl_LoginStyleImages.Select(x => new tbl_LoginStyleImages
                    {
                        ImagePath = x.ImagePath,
                    }).ToList();
                    allSystemConfig.MainStyle = new tbl_MainStyle
                    {
                        DashboardPath = data.tbl_MainStyle.DashboardPath
                    };
                }


                return allSystemConfig;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public WelcomeScreenAPIResponse GetAPIConfigData()
        {
            var data = _context.tbl_SystemConfigs.Include(x => x.tbl_LoginStyle).FirstOrDefault();
            return new WelcomeScreenAPIResponse
            {
                LoginPath = data.tbl_LoginStyle.LoginPath,
                WelcomeScreenTimeInterval = data.WelcomeScreenTimeInterval,
            };
        }
        //public GetMenuStyleViewModel GetMenuStyle()
        //{
        //    var data = _context.tbl_SystemConfigs.Include(x => x.tbl_MainStyle).FirstOrDefault();
        //    return new GetMenuStyleViewModel
        //    {
        //        DashboardPath=data.tbl_MainStyle.DashboardPath
        //    };
        //}

        public tbl_SystemConfig GetOneOfDetails(int id)
        {
            try
            {
                //var getDetails = _context.tbl_SystemConfigs
                //     .Include(x => x.tbl_LoginStyle)
                //     .Include(x => x.tbl_MainStyle)
                //     .OrderByDescending(x => x.Id == id).FirstOrDefault();
                //if (getDetails == null || getDetails.tbl_LoginStyle == null)
                //{
                //    List<tbl_LoginStyle> loginStyles;
                //    List<tbl_MainStyle> mainStyles;
                //    List<tbl_LoginStyleImages> loginStyleImages;
                //    tbl_SystemConfig systemConfig;
                //    loginStyles = new List<tbl_LoginStyle>()
                //{
                //new tbl_LoginStyle
                //{
                //     LoginBackground="white", StyleNameArabic="النمط الاول",StyleNameEnglish="Style1",TextFont="cursive",TextColor="White",LoginColor="black",LoginPath="/LoginStyle/style1",IsMultiImage=false
                //},
                //new tbl_LoginStyle
                //{
                //     LoginBackground="white", StyleNameArabic="النمط الثاني",StyleNameEnglish="Style2",TextFont="cursive",TextColor="black",LoginColor="White",LoginPath="/LoginStyle/style2",IsMultiImage=false
                //},
                //new tbl_LoginStyle
                //{
                //     LoginBackground="white", StyleNameArabic="النمط الثالث",StyleNameEnglish="Style3",TextFont="cursive",TextColor="black",LoginColor="White",LoginPath="/LoginStyle/style3",IsMultiImage=true
                //}

                //};
                //    CreateLoginStyle(loginStyles);

                //    mainStyles = new List<tbl_MainStyle>()
                //{
                //    new tbl_MainStyle
                //    {
                //        StyleNameArabic="لوحة التحكم 1",StyleNameEnglish="Dashboard 1", DescriptionArabic="لوحة التحكم", DescriptionEnglish="Dashboard",DashboardPath="_dashboard",WelcomePageImagePath="/img/logoo.png"
                //    },
                //};
                //    CreateMainStyle(mainStyles);

                //    loginStyleImages = new List<tbl_LoginStyleImages>()
                //{
                //     new tbl_LoginStyleImages
                //     {
                //            ImagePath= "/img1 style 3.jpg", tbl_LoginStyleId = 3
                //     }
                //};
                //    CreateLoginStyleImage(loginStyleImages);

                //    systemConfig = new tbl_SystemConfig()
                //    {
                //        ActiveDirectoryEnable = true,
                //        ActiveDirectoryDomain = "Active",
                //        ActiveDirectoryIbmLink = "Active",
                //        ActiveDirectoryIsAttachment = true,
                //        ActiveDirectoryIsIbmAttachment = true,
                //        ActiveDirectoryIsSendMail = true,
                //        ActiveDirectoryPassword = "123",
                //        ActiveDirectoryUserName = "Active@gmail.com",
                //        BankBranchNumber = 1,
                //        BankImagePath = "/img/BankImage.jpg",
                //        BankLogoPath = "/img/Banklogo.jpg",
                //        BankNameArabic = "بنك مصر",
                //        EnableMultiLanguage = true,
                //        EnableOTP= true,
                //        BankNameEnglish = "bank misr",
                //        WelcomeScreenImage = "/img/logoo.jpg",
                //        WelcomeScreenTimeInterval = 10,
                //        NumberOfMaxCreateUser = 1,
                //        NumberOfMaxUserLoginAtTime = 1,
                //        tbl_LoginStyleId = 3,
                //        tbl_MainStyleId = 1,
                //        WelcomeScreenTextArabic = "مرحبا",
                //        WelcomeScreenTextEnglish = "Welcome"
                //    };
                //    CreateConfigSystem(systemConfig);
                //}
                var getDetails = _context.tbl_SystemConfigs
                   .Include(x => x.tbl_LoginStyle)
                   .Include(x => x.tbl_MainStyle)
                   .OrderByDescending(x => x.Id == id).First();
                return getDetails;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //get one record in table system config
        public UpdateSystemConfigViewModel GetOneOfUpdate(int id)
        {
            try
            {
                var systemConfig = _context.tbl_SystemConfigs
                    .Include(x => x.tbl_MainStyle)
                    .Include(x => x.tbl_LoginStyle)
                    .OrderByDescending(x => x.Id == id)
                    .Select(x => new UpdateSystemConfigViewModel(x)).First();
                return systemConfig;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        //update config system 
        public void UpdateConfigSystem(int id, UpdateSystemConfigViewModel U_SystemConfig)
        {
            try
            {
                _context.Update(U_SystemConfig.ToEntity());
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
