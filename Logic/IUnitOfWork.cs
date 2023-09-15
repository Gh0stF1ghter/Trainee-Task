using Logic.Repositories;

namespace Logic
{
    public interface IUnitOfWork : IDisposable
    {
        IDepartmentRepository Departments { get; }
        IWorkerRepository Workers { get; }
        IProductRepository Products { get; }

        Task<int> CommitAsync();
    }
}
