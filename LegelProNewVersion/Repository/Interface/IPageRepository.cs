using LegelProNewVersion.Models;
using LegelProNewVersion.ViewModels;

namespace LegelProNewVersion.Repository.Interface
{
    public interface  IPageRepository
    {
       tbl_Pages GetById(int id);
        tbl_Pages Edit(tbl_Pages tbl_Pages,out string Error);
        List<tbl_Pages> ListPages();
        List<ListPage> ListPagesVM(List<tbl_Pages> listPages);
    }
}
