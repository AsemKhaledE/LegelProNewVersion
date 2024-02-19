using LegelProNewVersion.Models;

namespace LegelProNewVersion.ViewModels
{
    public class TypeOfMailViewModel
    {
        public int TypeOfMailId { get; set; }
        public string TypeOfMailArabicName { get; set; }
        public string TypeOfMailEnglishName { get; set; }
        public int DepartmentId { get; set; }
        public tbl_TypeMail tbl_TypeMail { get; set; }
    }
}
