using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Logic.Models
{
    public class Worker
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string FirstName { get; set; }
        public string? LastName { get; set; }

        [JsonIgnore]
        public ICollection<Department> Departments { get; } = new Collection<Department>();
    }
}
