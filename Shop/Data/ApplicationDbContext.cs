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
        public DbSet<Shop.Models.OrderProduct> OrderProducts{ get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<OrderProduct>()
                .HasKey(orderProduct => new { orderProduct.OrderId, orderProduct.ProductId });

            builder.Entity<OrderProduct>()
                .HasOne(orderProduct => orderProduct.Product)
                .WithMany(product => product.OrderProduct)
                .HasForeignKey(orderProduct => orderProduct.ProductId);

            builder.Entity<OrderProduct>()
                .HasOne(orderProduct => orderProduct.Order)
                .WithMany(order => order.OrderProduct)
                .HasForeignKey(orderProduct => orderProduct.OrderId);
        }
    }
}
