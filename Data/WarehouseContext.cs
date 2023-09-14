using Logic.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
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
            modelBuilder.Entity<Worker>().ToTable(nameof(Worker));
            modelBuilder.Entity<Department>().ToTable(nameof(Department));
            modelBuilder.Entity<Product>().ToTable(nameof(Product));
        }
    }
}
