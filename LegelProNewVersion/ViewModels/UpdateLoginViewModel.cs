using LegelProNewVersion.Models;
using System.ComponentModel.DataAnnotations;

namespace LegelProNewVersion.ViewModels
{
    public class UpdateLoginViewModel
    {
        public int? Id { get; set; }
        public string StyleNameArabic { get; set; }
        public string StyleNameEnglish { get; set; }
        public string TextColor { get; set; }
        public string TextFont { get; set; }
        public string LoginColor { get; set; }
        public string LoginBackground { get; set; }
        public bool ShowOtp { get; set; }
        public bool IsMultiImage { get; set; }
        public int TimeInterval { get; set; } = 10;
        public string LoginPath { get; set; }
    }
}
