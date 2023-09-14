using Logic.Models;
using Logic.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    internal class WorkerRepository : Repository<Worker>, IWorkerRepository
    {
        public WorkerRepository(WarehouseContext context) : base(context) { }
    }
}
