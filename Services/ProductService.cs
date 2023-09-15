using Logic;
using Logic.Models;
using Logic.Services;

namespace Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<IEnumerable<Product>> GetProducts() =>
    await _unitOfWork.Products.GetAllAsync();

        public async Task<Product> GetProductById(int id) =>
            await _unitOfWork.Products.GetByIdAsync(id);

        public async Task<Product> CreateProduct(Product product)
        {
            await _unitOfWork.Products.AddAsync(product);
            await _unitOfWork.CommitAsync();
            return product;
        }

        public async Task UpdateProduct(Product product, Product oldProduct)
        {
            oldProduct.Name = product.Name;
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteProduct(Product product)
        {
            _unitOfWork.Products.Remove(product);
            await _unitOfWork.CommitAsync();
        }

    }
}
