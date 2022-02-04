using DIYShop.Models;
using System.Collections.Generic;

namespace DIYShop.Logic
{
    public interface IClientsManager
    {
        ClientsManager AddClient(ClientsModel clientsModel);
        ClientsManager ChangeClientData(int id, string newClient);
        ClientsModel GetClient(int id);
        List<ClientsModel> GetClients();
        ClientsManager RemoveClient(int id);
        ClientsManager UpdateClient(ClientsModel clientsModel);
    }
}