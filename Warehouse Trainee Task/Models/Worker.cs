namespace Warehouse_Trainee_Task.Models
{
    public class Worker
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int DepartmentId { get; set; }

        public ICollection<Department> Departments { get; set; }
    }
}
