using OnlineShop.DomainLayer.Models;

namespace OnlineShop.RepositoryLayer.Contracts
{
    public interface IProductRepository
    {
        Product GetProductById(int productId);
        IEnumerable<Product> GetAllProducts();
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int productId);
    }
}
