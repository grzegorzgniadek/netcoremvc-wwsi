using DIYShop.Logic;
using DIYShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DIYShop.Controllers
{
    public class ClientsController : Controller
    {
        private readonly IClientsManager _clientsManager;

        public ClientsController(IClientsManager clientsManager)
        {
            _clientsManager = clientsManager;
        }
        public IActionResult Index()
        {
            var clients = _clientsManager.GetClients();
            return View(clients);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(ClientsModel client)
        {
            _clientsManager.AddClient(client);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Remove(int id)
        {
            var client = _clientsManager.GetClient(id);
            return View(client);
        }

        [HttpPost]
        public IActionResult RemoveConfirm(int id)
        {
            try
            {
                _clientsManager.RemoveClient(id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var client = _clientsManager.GetClient(id);
            return View(client);
        }

        [HttpPost]
        public IActionResult Edit(ClientsModel clientModel)
        {
            _clientsManager.UpdateClient(clientModel);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var client = _clientsManager.GetClient(id);
            return View(client);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
