using LegelProNewVersion.Data;
using LegelProNewVersion.Models;
using LegelProNewVersion.Repository.Interface;
using System.Drawing.Drawing2D;

namespace LegelProNewVersion.Repository.Service
{
    public class ImportanceOfMailRepository : IImportanceOfMailRepository
    {
        LegelProNewVersionDbContext _context;
        public ImportanceOfMailRepository(LegelProNewVersionDbContext context)
        {
            _context = context;
        }
        public void Add(tbl_TheImportanceOfMail importanceOfMail)
        {
            try
            {
                _context.TheImportanceOfMails.Add(importanceOfMail);
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
                var importanceOfMail = GetById(id);
                if (importanceOfMail != null)
                {
                    _context.TheImportanceOfMails.Remove(importanceOfMail);
                    _context.SaveChanges();

                }
                else
                {
                    throw new Exception("Importance Of Mail Not Found");
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public tbl_TheImportanceOfMail GetById(int id)
        {
            var importanceOfMail = _context.TheImportanceOfMails!.FirstOrDefault(f => f.TheImportanceOfMailId == id);
            return importanceOfMail!;
        }

        public List<tbl_TheImportanceOfMail> List()
        {
            try
            {
                var importanceOfMail = _context.TheImportanceOfMails!.ToList();
                return importanceOfMail;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(int id, tbl_TheImportanceOfMail importanceOfMail)
        {
            try
            {
                _context.Update(importanceOfMail);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public List<tbl_TheImportanceOfMail> ApproveAll()
        {
            try
            {
                var mailsToApprove = _context.TheImportanceOfMails.Where(b => b.ApproveStatusId == 1).ToList();
                foreach (var mail in mailsToApprove)
                {
                    mail.ApproveStatusId = 2;
                }
                _context.SaveChanges();
                return mailsToApprove;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public bool AreAllApproved()
        {
            return _context.TheImportanceOfMails.All(b => b.ApproveStatusId ==2);
        }

        public List<tbl_TheImportanceOfMail> DenialAll()
        {
            try
            {
                var mailsToDenial = _context.TheImportanceOfMails.Where(b => b.ApproveStatusId == 1).ToList();
                foreach (var mail in mailsToDenial)
                {
                    mail.ApproveStatusId = 3;
                }
                _context.SaveChanges();
                return mailsToDenial;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public bool IsNameEnglishFound(string EnglishName)
        {
            var isAlreadyExists = _context.TheImportanceOfMails.Any(x => x.TheImportanceOfMailEnglishName == EnglishName);
            return isAlreadyExists;
        }

        public bool IsNameArabicFound(string ArabicName)
        {
            var isAlreadyExists = _context.TheImportanceOfMails.Any(x => x.TheImportanceOfMailArabicName == ArabicName);
            return isAlreadyExists;
        }
    }
}
