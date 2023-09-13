using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logic.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }

        public Product? Product { get; set; }
        public ICollection<Worker> Workers { get; } = new List<Worker>();
    }
}
