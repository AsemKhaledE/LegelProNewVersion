using LegelProNewVersion.Data;
using LegelProNewVersion.Models;
using LegelProNewVersion.Repository.Interface;
using System.Data.Entity;
using System.Drawing.Drawing2D;

namespace LegelProNewVersion.Repository.Service
{
    public class TypeOfMailRepository : ITypeOfMailRepository
    {
        LegelProNewVersionDbContext _context;
        public TypeOfMailRepository(LegelProNewVersionDbContext context)
        {
            _context = context;
        }
        public void Add(tbl_TypeOfMail tbl_TypeOfMail)
        {
            try
            {
                _context.tbl_TypeOfMail.Add(tbl_TypeOfMail);
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
                var typeOfMail = GetById(id);
                if (typeOfMail != null)
                {
                    _context.tbl_TypeOfMail.Remove(typeOfMail);
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

        public tbl_TypeOfMail GetById(int id)
        {
            var typeOfMail = _context.tbl_TypeOfMail!.Include(x => x.tbl_Department).Include(x => x.tbl_TypeMail).FirstOrDefault(f => f.TypeOfMailId == id);
            return typeOfMail!;
        }

        public List<tbl_TypeOfMail> List()
        {
            try
            {
                var typeOfMail = _context.tbl_TypeOfMail.Include(x => x.tbl_Department).Include(x=>x.tbl_TypeMail).ToList();
                return typeOfMail;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(int id, tbl_TypeOfMail tbl_TypeOfMail)
        {
            try
            {
                _context.Update(tbl_TypeOfMail);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool IsNameEnglishFound(string EnglishName)
        {
            var isAlreadyExists = _context.tbl_TypeOfMail.Any(x => x.TypeOfMailEnglishName == EnglishName);
            return isAlreadyExists;
        }

        public bool IsNameArabicFound(string ArabicName)
        {
            var isAlreadyExists = _context.tbl_TypeOfMail.Any(x => x.TypeOfMailArabicName == ArabicName);
            return isAlreadyExists;
        }
    }
}
