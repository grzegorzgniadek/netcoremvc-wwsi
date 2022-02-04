using DIYShop.Contexts;
using DIYShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIYShop.Logic
{
    public class ProductsManager : IProductsManager
    {
        private readonly ProductsContext _productsContext;
        public ProductsManager(ProductsContext productsContext)
        {
            _productsContext = productsContext;
        }
        public ProductsModel Products { get; set; }
        public ProductsManager AddProduct(ProductsModel productsModel)
        {
            _productsContext.Add(productsModel);
            try
            {
                _productsContext.SaveChanges();
            }
            catch (Exception)
            {
                if (productsModel.ID != 0)
                {
                    productsModel.ID = 0;
                    _productsContext.SaveChanges();
                }
            }
            return this;
        }

        public ProductsManager RemoveProduct(int id)
        {
            var product = _productsContext.Products.Single(x => x.ID == id);
            _productsContext.Products.Remove(product);
            _productsContext.SaveChanges();
            return this;
        }

        public ProductsManager UpdateProduct(ProductsModel productsModel)
        {
            _productsContext.Products.Update(productsModel);
            _productsContext.SaveChanges();
            return this;
        }

        public ProductsManager ChangeProductData(int id, string newProduct)
        {
            GetProduct(id);
            if (String.IsNullOrEmpty(newProduct))
            {
                Products.Name = "No Name";
            }
            else
            {
                Products.Name = newProduct;

            }
            UpdateProduct(Products);
            return this;
        }

        public ProductsModel GetProduct(int id)
        {
            var product = _productsContext.Products.Single(x => x.ID == id);
            return product;

        }

        public List<ProductsModel> GetProducts()
        {
            return _productsContext.Products.ToList();
        }
    }
}
