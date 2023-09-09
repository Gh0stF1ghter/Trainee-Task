namespace Warehouse_Trainee_Task.Models
{
    public class Department
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public int WorkerId { get; set; }
        public int? ProductId { get; set; }

        public ICollection<Worker> Workers { get; set; }
        public Product? Product { get; set; }
    }
}
