using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Warehouse_Trainee_Task.Models
{
    public class Worker
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }

        public ICollection<Department> Departments { get; set; }
    }
}
