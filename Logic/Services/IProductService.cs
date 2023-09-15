using Logic.Models;

namespace Logic.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProductById(int id);
        Task<Product> CreateProduct(Product product);
        Task UpdateProduct(Product product, Product oldProduct);
        Task DeleteProduct(Product product);

    }
}
