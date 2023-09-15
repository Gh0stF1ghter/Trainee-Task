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

            modelBuilder.Entity<Worker>()
                .HasData(
                    new Worker
                    {
                        Id = 1,
                        FirstName = "Joe",
                        LastName = "Doe"
                    },
                    new Worker
                    {
                        Id = 2,
                        FirstName = "Jane",
                        LastName = "Doe"
                    },
                    new Worker
                    {
                        Id = 3,
                        FirstName = "Charles",
                        LastName = "Johnson"
                    },
                    new Worker
                    {
                        Id = 4,
                        FirstName = "Alyx",
                        LastName = "Vance"
                    },
                    new Worker
                    {
                        Id = 5,
                        FirstName = "Jess",
                        LastName = "Brown"
                    });
            modelBuilder.Entity<Department>()
                .HasData(
                new Department
                {
                    Id = 1,
                    Name = "Receiving"
                },
                new Department
                {
                    Id = 2,
                    Name = "Putaway"
                },
                new Department
                {
                    Id = 3,
                    Name = "Storage"
                },
                new Department
                {
                    Id = 4,
                    Name = "Picking"
                },
                new Department
                {
                    Id = 5,
                    Name = "Packing"
                },
                new Department
                {
                    Id = 6,
                    Name = "Shipping"
                });
            modelBuilder.Entity<Product>()
                .HasData(
                new Product
                {
                    Id = 1,
                    Name = "Hi-Fi system",
                    DepartmentId = 5
                },
                new Product
                {
                    Id = 2,
                    Name = "Constructor",
                    DepartmentId = 1
                },
                new Product
                {
                    Id = 3,
                    Name = "Toolbox",
                    DepartmentId = 6
                },
                new Product
                {
                    Id = 4,
                    Name = "Curtains",
                    DepartmentId = 5
                },
                new Product
                {
                    Id = 5,
                    Name = "Monoblock",
                    DepartmentId = 5
                });
        }
    }
}
