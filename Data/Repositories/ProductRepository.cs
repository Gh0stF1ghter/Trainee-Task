using Logic.Models;
using Logic.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    internal class ProductRepository : Repository<Product>, IProductRepository 
    {
        public ProductRepository(WarehouseContext context) : base(context) { }
        
    }
}
