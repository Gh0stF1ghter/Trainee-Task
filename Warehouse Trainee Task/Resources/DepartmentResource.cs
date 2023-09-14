using Logic.Models;
using System.Collections.ObjectModel;

namespace Warehouse_Trainee_Task.Resources
{
    public class DepartmentResource
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public ProductResource? Product { get; set; }
        public ICollection<WorkerResource> Workers { get; set; } = new Collection<WorkerResource>();
    }
}
