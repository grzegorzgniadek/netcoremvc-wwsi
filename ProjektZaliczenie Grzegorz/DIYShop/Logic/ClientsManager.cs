using DIYShop.Contexts;
using DIYShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIYShop.Logic
{
    public class ClientsManager : IClientsManager
    {
        private readonly ClientsContext _clientsContext;
        public ClientsManager(ClientsContext clientsContext)
        {
            _clientsContext = clientsContext;
        }
        public ClientsModel Clients { get; set; }
        public ClientsManager AddClient(ClientsModel clientsModel)
        {
            _clientsContext.Clients.Add(clientsModel);
            {
                try
                {
                    _clientsContext.SaveChanges();
                }
                catch (Exception)
                {
                    if(clientsModel.ID != 0)
                    {
                        clientsModel.ID = 0;
                        _clientsContext.SaveChanges();
                    }
                }
            }
            return this;
        }

        public ClientsManager RemoveClient(int id)
        {
            var client = _clientsContext.Clients.Single(x => x.ID == id);
            _clientsContext.Remove(client);
            _clientsContext.SaveChanges();
            return this;
        }

        public ClientsManager UpdateClient(ClientsModel clientsModel)
        {
            _clientsContext.Update(clientsModel);
            _clientsContext.SaveChanges();
            return this;
        }

        public ClientsManager ChangeClientData(int id, string newClient)
        {
            GetClient(id);
            if (String.IsNullOrEmpty(newClient))
            {
                Clients.FirstName = "No Name";
            }
            else
            {
                Clients.FirstName = newClient;


            }
            UpdateClient(Clients);
            return this;
        }

        public ClientsModel GetClient(int id)
        {
            var client = _clientsContext.Clients.Single(x => x.ID == id);
            return client;
        }

        public List<ClientsModel> GetClients()
        {
            return _clientsContext.Clients.ToList();
        }
    }
}
