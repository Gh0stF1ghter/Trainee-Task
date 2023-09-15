using Data.Repositories;
using Logic;
using Logic.Repositories;

namespace Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WarehouseContext _context;
        private DepartmentRepository _departmentRepository;
        private WorkerRepository _workerRepository;
        private ProductRepository _productRepository;

        public UnitOfWork(WarehouseContext context) =>
            _context = context;

        public IDepartmentRepository Departments => _departmentRepository ??= new DepartmentRepository(_context);
        public IWorkerRepository Workers => _workerRepository ??= new WorkerRepository(_context);
        public IProductRepository Products => _productRepository ??= new ProductRepository(_context);

        public async Task<int> CommitAsync() => await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();
    }
}
