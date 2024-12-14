using Microsoft.EntityFrameworkCore;
using ProductShipmentAPI.Models;

namespace ProductShipmentAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Shipment> Shipments { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, Name = "Товар1", Price = 100 },
                new Product { ProductId = 2, Name = "Товар2", Price = 200 },
                new Product { ProductId = 3, Name = "Товар3", Price = 300 }
            );

            modelBuilder.Entity<Shipment>().HasData(
                new Shipment { ShipmentId = 1, ProductId = 1, Store = "name1", BatchSize = 50, ShipmentDate = DateTime.Parse("2024-10-01"), BatchCost = 5000 },
                new Shipment { ShipmentId = 2, ProductId = 1, Store = "name2", BatchSize = 30, ShipmentDate = DateTime.Parse("2024-10-02"), BatchCost = 6000 },
                new Shipment { ShipmentId = 3, ProductId = 1, Store = "name3", BatchSize = 20, ShipmentDate = DateTime.Parse("2024-10-03"), BatchCost = 6000 }
            );
        }
    }
}
