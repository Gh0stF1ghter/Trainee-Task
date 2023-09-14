using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Services
{
    public interface IWorkerService
    {
        Task<IEnumerable<Worker>> GetWorkers();
        Task<Worker> GetWorkerById(int id);
        Task<Worker> CreateWorker(Worker worker);
        Task UpdateWorker(Worker worker, Worker oldWorker);
        Task DeleteWorker(Worker worker);
    }
}
