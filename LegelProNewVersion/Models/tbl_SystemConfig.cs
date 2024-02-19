using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LegelProNewVersion.Models
{
    public class tbl_SystemConfig
    {
        public int Id { get; set; }
        public bool ActiveDirectoryEnable { get; set; }
        public string? ActiveDirectoryDomain { get; set; }
        public string? ActiveDirectoryIbmLink { get; set; }
        [MaxLength(75)]
        public bool ActiveDirectoryIsAttachment { get; set; }
        public bool ActiveDirectoryIsIbmAttachment { get; set; }
        public bool ActiveDirectoryIsSendMail { get; set; }
        [MaxLength(75)]
        public string? ActiveDirectoryUserName { get; set; }
        [MaxLength(40)]
        public string? ActiveDirectoryPassword { get; set; }
        [MaxLength(75)]
        public string BankNameArabic { get; set; }
        [MaxLength(75)]
        public string BankNameEnglish { get; set; }
        public int BankBranchNumber { get; set; }
        [MaxLength(600)]
        public string BankLogoPath { get; set; }
        [MaxLength(400)]
        public string BankImagePath { get; set; }
        public bool EnableMultiLanguage { get; set; }
        public bool EnableOTP { get; set; }
        public int tbl_LoginStyleId { get; set; }
        [ForeignKey(nameof(tbl_LoginStyleId))]
        public tbl_LoginStyle tbl_LoginStyle { get; set; }
        public int tbl_MainStyleId { get; set; }
        [ForeignKey(nameof(tbl_MainStyleId))]
        public tbl_MainStyle tbl_MainStyle { get; set; }       
        public int NumberOfMaxCreateUser{ get; set; }
        public int NumberOfMaxUserLoginAtTime{ get; set; }
        [MaxLength(300)]
        public string WelcomeScreenImage { get; set; }
        public int WelcomeScreenTimeInterval { get; set; }
        [MaxLength(250)]
        public string WelcomeScreenTextArabic { get; set; }
        [MaxLength(250)]
        public string WelcomeScreenTextEnglish { get; set; }
        public int? LastUpdateBy { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public int CreationBy { get; set; }
        public DateTime CreationDate { get; set; }
        public int ApproveBy { get; set; }
        public DateTime ApproveDate { get; set; }
        public bool IsDelete { get; set; }
        public int IsDeleteBy { get; set; }
        public DateTime IsDeleteDate { get; set; }
    }
}
