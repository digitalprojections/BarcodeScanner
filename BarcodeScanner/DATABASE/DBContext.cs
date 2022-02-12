using BarcodeScanner.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace BarcodeScanner.DATABASE
{
    public class DBContext : DbContext
    {
        public DBContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ProductShelf> ProductShelves { get; set; }        
        public DbSet<ProductShelfSelector> ProductShelvesSelectors { get; set; }


        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(
                "Data Source=products.db");
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            modelBuilder.Entity<Category>().HasData(GetCategories());

            modelBuilder.Entity<Product>().HasData(GetProducts());
            modelBuilder.Entity<ProductShelfSelector>().HasData(GetShelfSels());
            
        }

        private ProductShelfSelector[] GetShelfSels()
        {
            ProductShelfSelector[] cl = new ProductShelfSelector[10];
            for (int i = 0; i < cl.Length; i++)
            {
                cl[i] = new ProductShelfSelector
                {
                    ProductShelfSelectorID = i+1,
                };
            }
            return cl;
        }

        private Product[] GetProducts()
        {
            Product[] cl = new Product[100];
            for (int i = 0; i < cl.Length; i++)
            {
                cl[i] = new Product
                {
                    ProductID = i+1,
                    Name = "product",
                    BarCode = ""
                };
            }
            return cl;
        }

        private Category[] GetCategories()
        {
            Category[] cl = new Category[20];
            for (int i = 0; i < cl.Length; i++)
            {
                cl[i] = new Category
                {
                    CategoryID = i + 1,
                    Name = "category",
                };
            }

            return cl;
        }
    }
}
