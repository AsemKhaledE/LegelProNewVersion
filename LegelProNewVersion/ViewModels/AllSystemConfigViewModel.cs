using LegelProNewVersion.Models;

namespace LegelProNewVersion.ViewModels
{
    public class AllSystemConfigViewModel
    {
        public tbl_SystemConfig SystemConfig { get; set; }
        public tbl_MainStyle MainStyle { get; set; }
        public tbl_LoginStyle LoginStyle { get; set; }
        public List<tbl_LoginStyleImages> LoginStyleImages { get; set; }
    }
}
