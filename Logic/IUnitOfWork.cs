using Logic.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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
