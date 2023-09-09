using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Warehouse_Trainee_Task.Models
{
    public class Department
    {
        [Key]
        public required int Id { get; set; }
        public required string Name { get; set; }
        [ForeignKey("Worker")]
        public int WorkerId { get; set; }
        [ForeignKey("Product")]
        public int? ProductId { get; set; }

        public ICollection<Worker> Workers { get; set; }
        public Product? Product { get; set; }
    }
}
