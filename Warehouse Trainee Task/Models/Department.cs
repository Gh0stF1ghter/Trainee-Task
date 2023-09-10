using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Warehouse_Trainee_Task.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }

        public Product? Product { get; set; }
        public ICollection<Enrollment> Enrollments { get; }
    }
}
