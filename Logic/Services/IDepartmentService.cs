using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
