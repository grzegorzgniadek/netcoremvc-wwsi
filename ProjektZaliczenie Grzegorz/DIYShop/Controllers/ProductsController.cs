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
    public class ProductsController : Controller
    {
        private readonly IProductsManager _productsManager;

        public ProductsController(IProductsManager productsManager)
        {
            _productsManager = productsManager;
        }

        public IActionResult Index()
        {
            var products = _productsManager.GetProducts();
            return View(products);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(ProductsModel product)
        {
            _productsManager.AddProduct(product);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Remove(int id)
        {
            var product = _productsManager.GetProduct(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult RemoveConfirm(int id)
        {
            try
            {
                _productsManager.RemoveProduct(id);
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
            var product = _productsManager.GetProduct(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(ProductsModel productModel)
        {
            _productsManager.UpdateProduct(productModel);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var product = _productsManager.GetProduct(id);
            return View(product);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
