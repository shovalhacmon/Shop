using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shop.Models;

namespace Shop.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Shop.Models.Product> Product { get; set; }
        public DbSet<Shop.Models.Customer> Customer { get; set; }
        public DbSet<Shop.Models.Order> Order { get; set; }
        public DbSet<Shop.Models.Season> Season { get; set; }
    }
}
