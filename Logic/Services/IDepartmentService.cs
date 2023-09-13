using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Models;

namespace Logic.Services
{
    internal interface IDepartmentService
    {
        Task<IEnumerable<Department>> GetDepartments();
        Task<Department> GetDepartmentById(int id);
        Task<Department> CreateDepartment(Department department);
        Task<Department> UpdateDepartment(Department department, Department oldDepartment);
        Task<Department> DeleteDepartment(Department department);
    }
}
