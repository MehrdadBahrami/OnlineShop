using OnlineShop.DomainLayer.Models;
using OnlineShop.RepositoryLayer.Contracts;

namespace OnlineShop.RepositoryLayer.Repositories
{
    public class ProductRepository : IProductRepository
    {
        // List acting as an in-memory data store
        private readonly List<Product> _products;

        public ProductRepository()
        {
            // Initialize the list (simulating a database)
            _products = new List<Product>
        {
            new Product { ProductId = 1, Name = "Xiamoi Note 11 Pro Plus", Price = 10.99M },
            new Product { ProductId = 2, Name = "Apple watch 4", Price = 20.99M },
            // Add more sample data as needed
        };
        }

        void IProductRepository.AddProduct(Product product)
        {
            // Simulating auto-increment for a new product
            product.ProductId = _products.Count + 1;
            _products.Add(product);
        }

        void IProductRepository.DeleteProduct(int productId)
        {
            var product = _products.FirstOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                _products.Remove(product);
            }
        }

        IEnumerable<Product> IProductRepository.GetAllProducts()
        {
            // Return a copy to avoid external modifications
            return _products.ToList();
        }

        Product IProductRepository.GetProductById(int productId)
        {
            return _products.FirstOrDefault(p => p.ProductId == productId) ??
                new Product()
                {
                    ProductId = 0,
                    Name = "Null value",
                    Price = 0
                };

        }

        void IProductRepository.UpdateProduct(Product product)
        {
            var existingProduct = _products.FirstOrDefault(p => p.ProductId == product.ProductId);
            if (existingProduct != null)
            {
                // Update properties as needed
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
            }
        }
    }
}
