using LegelProNewVersion.Models;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LegelProNewVersion.ViewModels
{
    public class UpdateSystemConfigViewModel
    {
        public int? Id { get; set; }
        public bool ActiveDirectoryEnable { get; set; }
        public string? ActiveDirectoryDomain { get; set; }
        public string? ActiveDirectoryIbmLink { get; set; }
        public bool ActiveDirectoryIsAttachment { get; set; }
        public bool ActiveDirectoryIsIbmAttachment { get; set; }
        public bool ActiveDirectoryIsSendMail { get; set; }
        public string? ActiveDirectoryUserName { get; set; }
        public string? ActiveDirectoryPassword { get; set; }
        public string BankNameArabic { get; set; }
        public string BankNameEnglish { get; set; }
        public int BankBranchNumber { get; set; }
        public string BankLogoPath { get; set; }
        public string BankImagePath { get; set; }
        public bool EnableMultiLanguage { get; set; }
        public bool EnableOTP { get; set; }
        public int tbl_LoginStyleId { get; set; }
        public int tbl_MainStyleId { get; set; }
        public int NumberOfMaxCreateUser { get; set; }
        public int NumberOfMaxUserLoginAtTime { get; set; }
        public string WelcomeScreenImage { get; set; }
        public int WelcomeScreenTimeInterval { get; set; }
        public string WelcomeScreenTextArabic { get; set; }
        public string WelcomeScreenTextEnglish { get; set; }

        public UpdateSystemConfigViewModel()
        {
            
        }
        public UpdateSystemConfigViewModel(tbl_SystemConfig item)
        {
            Id = item.Id;
            ActiveDirectoryDomain = item.ActiveDirectoryDomain;
            ActiveDirectoryEnable = item.ActiveDirectoryEnable;
            ActiveDirectoryIsSendMail = item.ActiveDirectoryIsSendMail;
            ActiveDirectoryIbmLink = item.ActiveDirectoryIbmLink;
            ActiveDirectoryIsAttachment = item.ActiveDirectoryIsAttachment;
            ActiveDirectoryIsIbmAttachment = item.ActiveDirectoryIsIbmAttachment;
            ActiveDirectoryPassword = item.ActiveDirectoryPassword;
            ActiveDirectoryUserName = item.ActiveDirectoryUserName;
            BankBranchNumber = item.BankBranchNumber;
            BankLogoPath = item.BankLogoPath;
            BankImagePath = item.BankImagePath;
            BankNameArabic = item.BankNameArabic;
            BankNameEnglish = item.BankNameEnglish;
            EnableMultiLanguage = item.EnableMultiLanguage;
            EnableOTP = item.EnableOTP;
            NumberOfMaxCreateUser = item.NumberOfMaxCreateUser;
            NumberOfMaxUserLoginAtTime = item.NumberOfMaxUserLoginAtTime;
            tbl_LoginStyleId = item.tbl_LoginStyleId;
            tbl_MainStyleId = item.tbl_MainStyleId;
            WelcomeScreenImage = item.WelcomeScreenImage;
            WelcomeScreenTextEnglish = item.WelcomeScreenTextEnglish;
            WelcomeScreenTextArabic = item.WelcomeScreenTextArabic;
            WelcomeScreenTimeInterval = item.WelcomeScreenTimeInterval;
        }

        public tbl_SystemConfig ToEntity()
        {
            var p = new tbl_SystemConfig
            {
                WelcomeScreenImage = WelcomeScreenImage,
                WelcomeScreenTimeInterval = WelcomeScreenTimeInterval,
                WelcomeScreenTextArabic = WelcomeScreenTextArabic,
                WelcomeScreenTextEnglish = WelcomeScreenTextEnglish,
                ActiveDirectoryDomain = ActiveDirectoryDomain,
                ActiveDirectoryEnable = ActiveDirectoryEnable,
                ActiveDirectoryIbmLink = ActiveDirectoryIbmLink,
                ActiveDirectoryIsAttachment = ActiveDirectoryIsAttachment,
                ActiveDirectoryIsIbmAttachment = ActiveDirectoryIsIbmAttachment,
                ActiveDirectoryIsSendMail = ActiveDirectoryIsSendMail,
                ActiveDirectoryPassword = ActiveDirectoryPassword,
                ActiveDirectoryUserName = ActiveDirectoryUserName,
                BankBranchNumber = BankBranchNumber,
                BankImagePath = BankImagePath,
                BankLogoPath = BankLogoPath,
                BankNameArabic = BankNameArabic,
                BankNameEnglish = BankNameEnglish,
                EnableMultiLanguage = EnableMultiLanguage,
                EnableOTP = EnableOTP,
                tbl_LoginStyleId = tbl_LoginStyleId,
                tbl_MainStyleId = tbl_MainStyleId,
                NumberOfMaxCreateUser = NumberOfMaxCreateUser,
                NumberOfMaxUserLoginAtTime = NumberOfMaxUserLoginAtTime

            };
            if (Id.HasValue)
                p.Id = Id.Value;

            return p;
        }
    }



}
