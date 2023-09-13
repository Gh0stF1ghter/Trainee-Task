using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Services
{
    internal interface IWorkerService
    {
        Task<IEnumerable<Worker>> GetWorkers();
        Task<Worker> GetWorkerById(int id);
        Task<Worker> CreateWorker(Worker worker);
        Task<Worker> UpdateWorker(Worker worker, Worker oldWorker);
        Task<Worker> DeleteWorker(Worker worker);
    }
}
