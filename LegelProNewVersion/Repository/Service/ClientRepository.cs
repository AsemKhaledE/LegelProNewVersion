using LegelProNewVersion.Data;
using LegelProNewVersion.Models;
using LegelProNewVersion.Repository.Interface;
using System.Data.Entity;

namespace LegelProNewVersion.Repository.Service
{
    public class ClientRepository : IClientRepository
    {
        LegelProNewVersionDbContext _context;
        public ClientRepository(LegelProNewVersionDbContext context)
        {
            _context = context;
        }
        public void AddClient(tbl_Client client)
        {
            try
            {
                _context.tbl_Clients.Add(client);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public tbl_Client GetClientById(int getClientById)
        {
            try
            {
                var client = _context.tbl_Clients.Include(x => x.BankId).Include(x => x.BranchId).FirstOrDefault(c => c.ClientId == getClientById);
                return client!;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<tbl_Client> GetClients()
        {
            try
            {
                var record = _context.tbl_Clients.Include(x => x.tbl_Branch).Include(x => x.tbl_Bank).ToList();
                return record;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateClient(int clientId, tbl_Client tbl_Client)
        {
            try
            {
                _context.tbl_Clients.Update(tbl_Client);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool IsClientNameFound(string clientName)
        {
            var isAlreadyExists = _context.tbl_Clients.Any(x => x.ClientName == clientName);
            return isAlreadyExists;
        }

        public bool IsDeviceNameFound(string deviceName)
        {
            var isAlreadyExists = _context.tbl_Clients.Any(x => x.TheDeviceName == deviceName);
            return isAlreadyExists;
        }

        public bool IsIdentificationNumberFound(string identificationNumber)
        {
            var isAlreadyExists = _context.tbl_Clients.Any(x => x.IdentificationNumber == identificationNumber);
            return isAlreadyExists;
        }

        public bool IsNationalNumberFound(string nationalNumber)
        {
            var isAlreadyExists = _context.tbl_Clients.Any(x => x.NationalNumber == nationalNumber);
            return isAlreadyExists;
        }
    }
}
