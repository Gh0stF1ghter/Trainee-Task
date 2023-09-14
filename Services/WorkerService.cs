using Logic.Models;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Services;

namespace Services
{
    public class WorkerService : IWorkerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public WorkerService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<IEnumerable<Worker>> GetWorkers() =>
    await _unitOfWork.Workers.GetAllAsync();

        public async Task<Worker> GetWorkerById(int id) =>
            await _unitOfWork.Workers.GetByIdAsync(id);

        public async Task<Worker> CreateWorker(Worker worker)
        {
            await _unitOfWork.Workers.AddAsync(worker);
            await _unitOfWork.CommitAsync();
            return worker;
        }

        public async Task UpdateWorker(Worker worker, Worker oldWorker)
        {
            oldWorker.FirstName = worker.FirstName;
            oldWorker.LastName = worker.LastName;
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteWorker(Worker worker)
        {
            _unitOfWork.Workers.Remove(worker);
            await _unitOfWork.CommitAsync();
        }


    }
}
