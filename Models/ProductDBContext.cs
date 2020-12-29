using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Fashion.Models
{
    public class ProductDBContext : IdentityDbContext
    {
        public ProductDBContext( DbContextOptions options) : base(options)
        {
        }
        public ProductDBContext()
        {

        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order_Product> Order_Products { get; set; }
        public DbSet<Category> Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order_Product>()
                .HasKey(bc => new { bc.OrderId, bc.ProductId });
            modelBuilder.Entity<Order_Product>()
                .HasOne(bc => bc.Orders)
                .WithMany(b => b.Order_Products)
                .HasForeignKey(bc => bc.OrderId);
            modelBuilder.Entity<Order_Product>()
                .HasOne(bc => bc.Products)
                .WithMany(c => c.Order_Products)
                .HasForeignKey(bc => bc.ProductId);
        }
    }
}
