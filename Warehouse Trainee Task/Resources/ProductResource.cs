using Logic.Models;

namespace Warehouse_Trainee_Task.Resources
{
    public class ProductResource
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required int DepartmentId { get; set; }

        public DepartmentResource Department { get; set; }
    }
}
