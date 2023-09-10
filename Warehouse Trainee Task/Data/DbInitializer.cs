using Serilog;
using Warehouse_Trainee_Task.Models;

namespace Warehouse_Trainee_Task.Data
{
    public class DbInitializer
    {
        //Test populator
        public static void Initialize(WarehouseContext context)
        {
            context.Database.EnsureCreated();

            try
            {


                //if db is already filled
                if (!context.Workers.Any())
                {
                    Worker[] workers =
                    {
                    new Worker
                    {
                        FirstName = "Joe",
                        LastName = "Doe"
                    },
                    new Worker
                    {
                        FirstName = "Jane",
                        LastName = "Doe"
                    },
                    new Worker
                    {
                        FirstName = "Charles",
                        LastName = "Johnson"
                    },
                    new Worker
                    {
                        FirstName = "Alyx",
                        LastName = "Vance"
                    },
                    new Worker
                    {
                        FirstName = "Jess",
                        LastName = "Brown"
                    }
                };
                    foreach (var w in workers)
                        context.Add(w);

                    context.SaveChanges();
                }

                if (!context.Departments.Any())
                {
                    Department[] departments =
                {
                new Department
                {
                    Name = "Receiving"
                },
                new Department
                {
                    Name = "Putaway"
                },
                new Department
                {
                    Name = "Storage"
                },
                new Department
                {
                    Name = "Picking"
                },
                new Department
                {
                    Name = "Packing"
                },
                new Department
                {
                    Name = "Shipping"
                },

            };
                    foreach (Department d in departments)
                        context.Departments.Add(d);

                    context.SaveChanges();
                }

                if (!context.Products.Any())
                {
                    Product[] products =
                {
                new Product
                {
                    Name = "Hi-Fi system",
                    DepartmentId = 5
                },
                new Product
                {
                    Name = "Constructor",
                    DepartmentId = 1
                },
                new Product
                {
                    Name = "Toolbox",
                    DepartmentId = 6
                },
                new Product
                {
                    Name = "Curtains",
                    DepartmentId = 5
                },
                new Product
                {
                    Name = "Monoblock",
                    DepartmentId = 5
                }
            };
                    foreach (Product p in products)
                        context.Products.Add(p);

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Log.Error("Failed to intialize database ", ex); 
            }
        }
    }
}
