using Logic.Models;

namespace Logic.Services
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department>> GetDepartments();
        Task<Department> GetDepartmentById(int id);
        Task<Department> CreateDepartment(Department department);
        Task UpdateDepartment(Department department, Department oldDepartment);
        Task DeleteDepartment(Department department);
    }
}
