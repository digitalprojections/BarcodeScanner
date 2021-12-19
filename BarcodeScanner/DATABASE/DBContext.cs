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

            //modelBuilder.Entity<Product>().HasData(GetProducts());
        }

        private object[] GetProducts()
        {
            object[] cl = new object[10];
            for (int i = 0; i < 5; i++)
            {
                cl[i] = new
                {                    
                    Name = "object no-" + (i + 1),
                    BarCode = "",
                    CategoryID = 1,
                    Category = new {CategoryID=i+1}
                };
            }
            return cl;
        }

        private object[] GetCategories()
        {
            object[] cl = new object[40];
            for (int i = 0; i < 40; i++)
            {
                cl[i] = new
                {
                    CategoryID = i + 1,
                    Name = "object no-" + (i + 1)
                    
                };
            }

            return cl;
        }
    }
}
