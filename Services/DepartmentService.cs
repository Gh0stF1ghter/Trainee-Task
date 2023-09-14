using Logic;
using Logic.Models;
using Logic.Services;
using System.Data;

namespace Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;
        
        public async Task<IEnumerable<Department>> GetDepartments() =>
            await _unitOfWork.Departments.GetAllAsync();

        public async Task<Department> GetDepartmentById(int id) =>
            await _unitOfWork.Departments.GetByIdAsync(id);

        public async Task<Department> CreateDepartment(Department department)
        {
            await _unitOfWork.Departments.AddAsync(department);
            await _unitOfWork.CommitAsync();
            return department;
        }

        public async Task UpdateDepartment(Department department, Department oldDepartment)
        {
            oldDepartment.Name = department.Name;
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteDepartment(Department department)
        {
            _unitOfWork.Departments.Remove(department);
            await _unitOfWork.CommitAsync();
        }
    }
}