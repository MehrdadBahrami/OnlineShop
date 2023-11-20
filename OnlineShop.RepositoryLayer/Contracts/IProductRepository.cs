using OnlineShop.DomainLayer.Model;

namespace OnlineShop.RepositoryLayer.Contracts
{
    internal interface IProductService
    {
        Product GetProductById(int productId);
        IEnumerable<Product> GetAllProducts();
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int productId);
    }
}
