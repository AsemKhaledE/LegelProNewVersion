using LegelProNewVersion.Data;
using LegelProNewVersion.Models;
using LegelProNewVersion.Repository.Interface;
using LegelProNewVersion.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Net.Mail;

namespace LegelProNewVersion.Repository.Service
{
    public class LoginStyleRepository : ILoginStyleRepository
    {
        LegelProNewVersionDbContext _context;
        public LoginStyleRepository(LegelProNewVersionDbContext context)
        {
            _context = context;
        }

        public tbl_SystemConfig BackgroundStyle()
        {
            try
            {
                var data = _context.tbl_SystemConfigs.Include(x => x.tbl_LoginStyle).FirstOrDefault();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void CreateLoginStyle(tbl_LoginStyle A_loginStyle)
        {
            try
            {
                _context.Add(A_loginStyle);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public tbl_LoginStyle GetOne(int id)
        {
            try
            {
                var loginStyle = _context.tbl_LoginStyles.FirstOrDefault(s => s.Id == id);
                if (loginStyle == null)
                {
                    throw new Exception("Login Style Not Fount");
                }
                return loginStyle;


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public UserViewModel GetUser(LoginViewModel loginViewModel,out string Error)
        {
            Error = string.Empty;
            tbl_Users user=new tbl_Users();
            try
            {
                
                user  = _context.tbl_Users.Where(u => u.Email == loginViewModel.Email || u.UserName == loginViewModel.Email).FirstOrDefault();

                if (user != null)
                {
                    if(loginViewModel.Password== user.Password)
                    {
                        return new UserViewModel(user,"");
                    }
                    else if(loginViewModel.Password != user.Password)
                    {
                        return new UserViewModel(user, "User Password Not Correct");
                    }
                }
                
            }
            catch (Exception ex)
            {

                Error = ex.Message;
            }
            return new UserViewModel(null, "User Not Found");
            //try
            //{
            //    var username = new EmailAddressAttribute().IsValid(loginViewModel.Email) ? new MailAddress(loginViewModel.Email).User : loginViewModel.Email;
            //    var user = _context.tbl_Users?.Where(u => u.UserName == username
            //    & u.Password == loginViewModel.Password).FirstOrDefault();
            //    if (user != null )
            //    {
            //        return new UserViewModel(user);
            //    }
            //    return new UserViewModel();
            //}
            //catch (Exception ex)
            //{

            //    throw new Exception(ex.Message);
            //}
        }

        public UserViewModel GetUser(LoginViewModel loginViewModel)
        {
            throw new NotImplementedException();
        }

        public List<tbl_LoginStyle> ListLoginStyle()    
        {
            try
            {
                var list = _context.tbl_LoginStyles.ToList();
                return list;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void UpdateLoginStyle(EditLoginStyleViewModel updateLoginStyle)
        {
            try
            {
                _context.Update(updateLoginStyle.ToEntity());
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
