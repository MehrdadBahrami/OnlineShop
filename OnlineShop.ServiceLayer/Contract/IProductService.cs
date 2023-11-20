using OnlineShop.DomainLayer.Models;

namespace OnlineShop.ServiceLayer.Contract
{
    public interface IProductService
    {
        Task<Product> GetProductByIdAsync(int productId);
        Task AddProductAsync(Product productModel);
        Task UpdateProductAsync(Product productModel);
        Task DeleteProductAsync(int productId);
        Task<IEnumerable<Product>> GetAllProductsAsync();
    }
}
