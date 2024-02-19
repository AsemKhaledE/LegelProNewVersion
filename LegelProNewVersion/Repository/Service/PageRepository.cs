using LegelProNewVersion.Data;
using LegelProNewVersion.Models;
using LegelProNewVersion.Repository.Interface;
using LegelProNewVersion.ViewModels;

namespace LegelProNewVersion.Repository.Service
{
    public class PageRepository : IPageRepository
    {
        LegelProNewVersionDbContext _context;
        public PageRepository(LegelProNewVersionDbContext context)
        {
            _context = context;
        }
        public tbl_Pages Edit(tbl_Pages _Pages, out string Error)
        {
            Error = "";
            try
            {
                _context.tbl_Pages.Update(_Pages);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                Error = ex.Message;
            }
            return _Pages;
        }

        public tbl_Pages GetById(int id)
        {
            var getById = _context.tbl_Pages.Where(x => x.PageId == id).FirstOrDefault();
            return getById!;
        }

        public List<tbl_Pages> ListPages()
        {
            var list = _context.tbl_Pages.Where(x => x.PageId >= 2).ToList();
            return list;
        }

        public List<ListPage> ListPagesVM(List<tbl_Pages> listPages)
        {
            return listPages.Where(x => x.PageId >= 2).Select(page => new ListPage
            {
                PageId = page.PageId,
                RoleNameAr = page.NameAr,
                RoleNameEn = page.NameEn,
            }).ToList();
        }
    }
}
