using LegelProNewVersion.Models;
using System.ComponentModel.DataAnnotations;

namespace LegelProNewVersion.ViewModels
{
    public class EditLoginStyleViewModel
    {
        public int Id { get; set; }
        [MaxLength(75)]
        public string StyleNameArabic { get; set; }
        [MaxLength(75)]
        public string StyleNameEnglish { get; set; }
        [MaxLength(16)]
        public string TextColor { get; set; }
        [MaxLength(50)]
        public string TextFont { get; set; }
        [MaxLength(16)]
        public string LoginColor { get; set; }
        [MaxLength(16)]
        public string LoginBackground { get; set; }
        public bool IsMultiImage { get; set; }
        public int TimeInterval { get; set; }
        public string LoginPath { get; set; }
        public EditLoginStyleViewModel()
        {
                
        }
        public tbl_LoginStyle ToEntity()
        {

            return new tbl_LoginStyle
            {
                Id = Id,
                IsMultiImage = IsMultiImage,
                TimeInterval = TimeInterval,
                LoginPath = LoginPath,
                LoginBackground = LoginBackground,
                LoginColor = LoginColor,
                StyleNameArabic = StyleNameArabic,
                TextColor = TextColor,
                TextFont = TextFont,
                StyleNameEnglish = StyleNameEnglish,               
            };
        }
        public EditLoginStyleViewModel(tbl_LoginStyle item)
        {
            Id = item.Id;
            IsMultiImage = item.IsMultiImage;
            TimeInterval = item.TimeInterval;
            LoginPath = item.LoginPath;
            LoginBackground = item.LoginBackground;
            LoginColor = item.LoginColor;
            StyleNameArabic= item.StyleNameArabic;
            TextColor = item.TextColor;
            TextFont = item.TextFont;
            StyleNameEnglish= item.StyleNameEnglish;       
        }

    }
    
}
