using Logic.Models;
using Logic.Repositories;

namespace Data.Repositories
{
    internal class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(WarehouseContext context) : base(context) { }

    }
}
