using System.Collections.ObjectModel;

namespace Warehouse_Trainee_Task.Resources
{
    public class WorkerResource
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public string? LastName { get; set; }

        public ICollection<DepartmentResource> Departments { get; set; } = new Collection<DepartmentResource>();
    }
}
