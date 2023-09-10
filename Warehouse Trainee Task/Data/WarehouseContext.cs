using Microsoft.EntityFrameworkCore;
using Warehouse_Trainee_Task.Models;

namespace Warehouse_Trainee_Task.Data
{
    public class WarehouseContext : DbContext
    {
        public WarehouseContext(DbContextOptions<WarehouseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Worker> Workers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Worker>();
            modelBuilder.Entity<Department>();
            modelBuilder.Entity<Product>();
        }
    }
}
