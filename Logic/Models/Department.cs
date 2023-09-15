using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Logic.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }

        public ICollection<Product> Products { get; set; } = new Collection<Product>();
        public ICollection<Worker> Workers { get; set; } = new Collection<Worker>();
    }
}
