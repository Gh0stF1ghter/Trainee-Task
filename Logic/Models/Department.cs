using System.ComponentModel;
using System.Collections.ObjectModel;
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
        public ICollection<Worker> Workers { get; set; } = new Collection<Worker>();
    }
}
