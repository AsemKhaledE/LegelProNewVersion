using LegelProNewVersion.Data;
using LegelProNewVersion.Models;
using LegelProNewVersion.Repository.Interface;
using System.Drawing.Drawing2D;

namespace LegelProNewVersion.Repository.Service
{
    public class MailerRepository : IMailerRepository
    {
        LegelProNewVersionDbContext _context;
        public MailerRepository(LegelProNewVersionDbContext context)
        {
            _context = context;
        }
        public void Add(tbl_Mailer tbl_Mailer)
        {
            try
            {
                _context.tbl_Mailers.Add(tbl_Mailer);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Delete(int mailerId)
        {
            try
            {
                var mailer = GetById(mailerId);
                if (mailer != null)
                {
                    _context.tbl_Mailers.Remove(mailer);
                    _context.SaveChanges();

                }
                else
                {
                    throw new Exception("Mailer Not Found");
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public tbl_Mailer GetById(int mailerId)
        {
            var mailer = _context.tbl_Mailers!.FirstOrDefault(f => f.MailerId == mailerId);
            return mailer!;
        }

        public List<tbl_Mailer> List()
        {
            try
            {
                var mailer = _context.tbl_Mailers!.ToList();
                return mailer;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(int mailerId, tbl_Mailer mailer)
        {
            try
            {
                _context.Update(mailer);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public bool AreAllApproved()
        {
            return _context.tbl_Mailers.All(b => b.ApproveStatusId ==2);
        }
        public List<tbl_Mailer> DenialAll()
        {
            try
            {
                var mailersToDenial = _context.tbl_Mailers.Where(b => b.ApproveStatusId == 1).ToList();
                foreach (var mailer in mailersToDenial)
                {
                    mailer.ApproveStatusId = 3;
                }
                _context.SaveChanges();
                return mailersToDenial;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public List<tbl_Mailer> ApproveAll()
        {
            try
            {
                var mailersToApprove = _context.tbl_Mailers.Where(b => b.ApproveStatusId == 1).ToList();
                foreach (var mailer in mailersToApprove)
                {
                    mailer.ApproveStatusId = 2;
                }
                _context.SaveChanges();
                return mailersToApprove;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public bool IsNameEnglishFound(string EnglishName)
        {
            var isAlreadyExists = _context.tbl_Mailers.Any(x => x.MailerEnglishName == EnglishName);
            return isAlreadyExists;
        }

        public bool IsNameArabicFound(string ArabicName)
        {
            var isAlreadyExists = _context.tbl_Mailers.Any(x => x.MailerArabicName == ArabicName);
            return isAlreadyExists;
        }
    }
}
