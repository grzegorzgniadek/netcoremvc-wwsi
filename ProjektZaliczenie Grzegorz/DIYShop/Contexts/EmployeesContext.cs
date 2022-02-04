using DIYShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIYShop.Contexts
{
    public class EmployeesContext : DbContext
    {
        public DbSet<EmployeesModel> Employees { get; set; }
        public EmployeesContext(DbContextOptions<EmployeesContext> options) : base(options)
        {
        }
    }
}
