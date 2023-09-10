using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Warehouse_Trainee_Task.Models
{
    public class Worker
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Enrollment> Enrollments { get; }
    }
}
