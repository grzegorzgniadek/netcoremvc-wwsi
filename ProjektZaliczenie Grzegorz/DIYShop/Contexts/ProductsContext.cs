using DIYShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIYShop.Contexts
{
    public class ProductsContext : DbContext
    {
        public DbSet<ProductsModel> Products { get; set; }
        public ProductsContext(DbContextOptions<ProductsContext> options) : base(options)
        {
        }
    }
}
