using Logic.Models;
using Logic.Repositories;

namespace Data.Repositories
{
    internal class WorkerRepository : Repository<Worker>, IWorkerRepository
    {
        public WorkerRepository(WarehouseContext context) : base(context) { }
    }
}
