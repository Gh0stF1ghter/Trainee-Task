namespace Warehouse_Trainee_Task.Models
{
    public class Product
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required int DepartmentId { get; set; }

        //Reference navigation to Department
        public Department Department { get; private set; } = null!;
    }
}
