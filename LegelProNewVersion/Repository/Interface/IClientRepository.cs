using LegelProNewVersion.Models;

namespace LegelProNewVersion.Repository.Interface
{
    public interface IClientRepository
    {
        List<tbl_Client> GetClients();
        void AddClient(tbl_Client client);
        void UpdateClient(int clientId, tbl_Client tbl_Client);
        tbl_Client GetClientById(int getClientById);
        bool IsClientNameFound(string clientName);
        bool IsDeviceNameFound(string deviceName);
        bool IsIdentificationNumberFound(string identificationNumber);
        bool IsNationalNumberFound(string nationalNumber);
    }
}
