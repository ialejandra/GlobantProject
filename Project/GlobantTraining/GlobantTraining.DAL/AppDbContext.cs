using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using GlobantTraining.DAL.Entities;

namespace GlobantTraining.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        //Representación de mis tablas en la base de datos

        public DbSet<Store> Store { get; set; }

        public DbSet<Consumable> Consumables { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");
        }

        public DbSet<Provider> Providers { get; set; }

        public DbSet<TypeUser> TypeUsers { get; set; }

        public DbSet<TypeProduct> TypeProducts { get; set; }

        public DbSet<Invoice> Invoices { get; set; }

        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }

        public DbSet<Purchase> Purchases { get; set; }

        public DbSet<PurchaseDetail> PurchaseDetails { get; set; }

        public DbSet<User> Users { get; set; }


    }
}
