using Logic.Models;
using Logic.Repositories;

namespace Data.Repositories
{
    internal class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(WarehouseContext context) : base(context) { }


    }
}
