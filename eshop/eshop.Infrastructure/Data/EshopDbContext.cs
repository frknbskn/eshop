using eshop.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Infrastructure.Data
{
    public class EshopDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public EshopDbContext(DbContextOptions<EshopDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseSqlServer("Data Source=(localdb)\\Mssqllocaldb;Initial Catalog=eshopDatabase; Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(p => p.Name).IsRequired()
                                                              .HasMaxLength(200);
            modelBuilder.Entity<Category>().HasMany(c => c.Products)
                                         .WithOne(p => p.Category)
                                         .HasForeignKey(p => p.CategoryId)
                                         .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Elektronik" },
                new Category { Id = 2, Name = "Kırtasiye" },
                new Category { Id = 3, Name = "Giyim" }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product() { Id = 1, Name = "Bluetooth kulaklık", Price = 500, CategoryId = 1, Description = "Kulaklık", Rating = 4.2 },
                new Product { Id = 2, Name = "Yazı tahtası", Price = 1000, CategoryId = 2, Description = "150 x 250", Rating = 4.8 },
                new Product { Id = 3, Name = "Şort", Price = 400, CategoryId = 3, Description = "Şort işte", Rating = 4.2 }
                );
        }
    }
}
