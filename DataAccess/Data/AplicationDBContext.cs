using Microsoft.EntityFrameworkCore;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class AplicationDBContext: DbContext
    {
        public DbSet<Product> Products {  get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Purchase> Purchase { get; set; }
        public DbSet<Inventory> Inventory { get; set; }


        public AplicationDBContext(DbContextOptions<AplicationDBContext> options):base(options) 
        { 

        }

        protected override void OnConfiguring (DbContextOptionsBuilder options)
        {
           // options.UseSqlServer("Server=USQROJDELGADOS1;Database=Practice5;TrustServerCertificate=True;Trusted_Connection=True;");

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 101, Name = "Totis", Price = 15},
                new Product { Id = 102, Name = "Cheetos", Price = 23},
                new Product { Id = 103, Name = "Doritos", Price = 20},
                new Product { Id = 104, Name = "Sabritones", Price = 30},
                new Product { Id = 105, Name = "Arizona", Price = 14},
                new Product { Id = 106, Name = "Chokis", Price = 20},
                new Product { Id = 107, Name = "Emperador", Price = 21},
                new Product { Id = 108, Name = "Boing", Price = 16},
                new Product { Id = 109, Name = "Takis", Price = 19},
                new Product { Id = 110, Name = "Oreo", Price = 25});


            modelBuilder.Entity<Sale>().HasData(
                new Sale { SaleId = 201, Name = "Boing", Quantity = 100 },
                new Sale { SaleId = 202, Name = "Oreo", Quantity = 230 },
                new Sale { SaleId = 203, Name = "Totis", Quantity = 210 },
                new Sale { SaleId = 204, Name = "Arizona", Quantity = 140 },
                new Sale { SaleId = 205, Name = "Oreo", Quantity = 180 },
                new Sale { SaleId = 206, Name = "Arizona", Quantity = 258 },
                new Sale { SaleId = 207, Name = "Totis", Quantity = 305 },
                new Sale { SaleId = 208, Name = "Boing", Quantity = 179 },
                new Sale { SaleId = 209, Name = "Totis", Quantity = 250 },
                new Sale { SaleId = 210, Name = "Cheetos", Quantity = 289 });


            modelBuilder.Entity<Purchase>().HasData(
               new Purchase {PurchaseId = 301, Name = "Arizona", Quantity = 400}, 
               new Purchase {PurchaseId = 302, Name = "Cheetos", Quantity = 500},
               new Purchase {PurchaseId = 303, Name = "Sabritones", Quantity = 200},
               new Purchase {PurchaseId = 304, Name = "Boing", Quantity = 400},
               new Purchase {PurchaseId = 305, Name = "Chokis", Quantity = 300},
               new Purchase {PurchaseId = 306, Name = "Sabritones", Quantity = 500},
               new Purchase {PurchaseId = 307, Name = "Chokis", Quantity = 450},
               new Purchase {PurchaseId = 308, Name = "Totis", Quantity = 300},
               new Purchase {PurchaseId = 309, Name = "Cheetos", Quantity = 250},
               new Purchase {PurchaseId = 310, Name = "Totis", Quantity = 350});


            modelBuilder.Entity<Inventory>().HasData(
                new Inventory { Id = 101, Name = "Totis", Price = 15, Quantity = 900},
                new Inventory { Id = 102, Name = "Cheetos", Price = 23, Quantity = 800},
                new Inventory { Id = 103, Name = "Doritos", Price = 20, Quantity = 860},
                new Inventory { Id = 104, Name = "Sabritones", Price = 30, Quantity = 970},
                new Inventory { Id = 105, Name = "Arizona", Price = 14, Quantity = 750},
                new Inventory { Id = 106, Name = "Chokis", Price = 20, Quantity = 870},
                new Inventory { Id = 107, Name = "Emperador", Price = 21, Quantity = 790},
                new Inventory { Id = 108, Name = "Boing", Price = 16, Quantity = 940},
                new Inventory { Id = 109, Name = "Takis", Price = 19, Quantity = 780},
                new Inventory { Id = 110, Name = "Oreo", Price = 25, Quantity = 890});
        }
    }
}
