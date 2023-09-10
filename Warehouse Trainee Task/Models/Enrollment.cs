using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Warehouse_Trainee_Task.Models
{
    public class Enrollment
    {
        [ForeignKey("Worker")]
        public int WorkerId { get; set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }

        public Worker Worker { get; set; } = null!;
        public Department Department { get; set; } = null!;
    }
}
