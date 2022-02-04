using DIYShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIYShop.Contexts
{
    public class ClientsContext : DbContext
    {
        public DbSet<ClientsModel> Clients { get; set; }
        public ClientsContext(DbContextOptions<ClientsContext> options) : base(options)
        {
        }
    }
}
