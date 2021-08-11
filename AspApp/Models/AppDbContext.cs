using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using AspApp.Models;

#nullable disable

namespace AspApp.Models
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
       
            modelBuilder.Entity<Category>().HasData(
            new Category{ Id = 1, CategoryName = "Utrustning"},
            new Category { Id = 2,  CategoryName = "Skötsel" },
            new Category { Id = 3, CategoryName = "Foder" }
            );
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<AspApp.Models.ProductCreateViewModel> ProductCreateViewModel { get; set; }
    }
}
