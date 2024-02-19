using LegelProNewVersion.Data;
using LegelProNewVersion.Models;
using LegelProNewVersion.Repository.Interface;
using System.Drawing.Drawing2D;

namespace LegelProNewVersion.Repository.Service
{
    public class AreasRepository : IAreasRepository
    {
        LegelProNewVersionDbContext _context;
        public AreasRepository(LegelProNewVersionDbContext context)
        {
            _context = context;
        }
        public void Add(tbl_Areas newAreas)
        {
            try
            {
                _context.tbl_Areas.Add(newAreas);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                var area = GetById(id);
                if (area != null)
                {
                    _context.tbl_Areas.Remove(area);
                    _context.SaveChanges();

                }
                else
                {
                    throw new Exception("Brand Not Found");
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public tbl_Areas GetById(int id)
        {
            var area = _context.tbl_Areas!.FirstOrDefault(f => f.AreaId == id);
            return area!;
        }

        public List<tbl_Areas> List()
        {
            try
            {
                var area = _context.tbl_Areas!.ToList();
                return area;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update( tbl_Areas area)
        {
            try
            {
                _context.Update(area);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public List<tbl_Areas> ApproveAll()
        {
            try
            {
                var areasToApprove = _context.tbl_Areas.Where(b => b.ApproveStatusId == 1).ToList();
                foreach (var area in areasToApprove)
                {
                    area.ApproveStatusId = 2;
                }
                _context.SaveChanges();
                return areasToApprove;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public bool AreAllApproved()
        {
            return _context.tbl_Areas.All(b => b.ApproveStatusId ==2);
        }

        public List<tbl_Areas> DenialAll()
        {
            try
            {
                var areasToDenial = _context.tbl_Areas.Where(b => b.ApproveStatusId == 1).ToList();
                foreach (var area in areasToDenial)
                {
                    area.ApproveStatusId = 3;
                }
                _context.SaveChanges();
                return areasToDenial;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public bool IsNameEnglishFound(string EnglishName)
        {
            var isAlreadyExists = _context.tbl_Areas.Any(x => x.AreaEnglishName == EnglishName);
            return isAlreadyExists;
        }

        public bool IsNameArabicFound(string ArabicName)
        {
            var isAlreadyExists = _context.tbl_Areas.Any(x => x.AreaArabicName == ArabicName);
            return isAlreadyExists;
        }
    }
}
