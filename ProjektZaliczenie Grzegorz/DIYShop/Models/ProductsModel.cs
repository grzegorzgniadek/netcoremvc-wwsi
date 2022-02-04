using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIYShop.Models
{
    public class ProductsModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Section { get; set; }
        public string Quantity { get; set; }
    }
}
