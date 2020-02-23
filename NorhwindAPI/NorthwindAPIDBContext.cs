using Microsoft.EntityFrameworkCore;
using NorhwindAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorhwindAPI
{
    public class NorthwindAPIDBContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }

        public NorthwindAPIDBContext(DbContextOptions<NorthwindAPIDBContext> options)
            : base(options)
        {
        }
    }
}
