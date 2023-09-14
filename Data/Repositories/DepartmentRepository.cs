using Logic.Models;
using Logic.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    internal class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(WarehouseContext context) : base(context) { }


    }
}
