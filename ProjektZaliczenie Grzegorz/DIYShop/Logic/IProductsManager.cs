using DIYShop.Models;
using System.Collections.Generic;

namespace DIYShop.Logic
{
    public interface IProductsManager
    {
        ProductsManager AddProduct(ProductsModel productsModel);
        ProductsManager ChangeProductData(int id, string newProduct);
        ProductsModel GetProduct(int id);
        List<ProductsModel> GetProducts();
        ProductsManager RemoveProduct(int id);
        ProductsManager UpdateProduct(ProductsModel productsModel);
    }
}