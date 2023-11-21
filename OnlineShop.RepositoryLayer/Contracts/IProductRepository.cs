using OnlineShop.DomainLayer.Models;
using System.Collections.Generic;

namespace OnlineShop.RepositoryLayer.Contracts
{
    /// <summary>
    /// Repository interface for managing product data.
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Get a product by its unique identifier.
        /// </summary>
        /// <param name="productId">The unique identifier of the product.</param>
        /// <returns>The product entity if found; otherwise, null.</returns>
        Product GetProductById(int productId);

        /// <summary>
        /// Get all products in the repository.
        /// </summary>
        /// <returns>An enumerable collection of all products.</returns>
        IEnumerable<Product> GetAllProducts();

        /// <summary>
        /// Add a new product to the repository.
        /// </summary>
        /// <param name="product">The product entity to add.</param>
        void AddProduct(Product product);

        /// <summary>
        /// Update an existing product in the repository.
        /// </summary>
        /// <param name="product">The updated product entity.</param>
        void UpdateProduct(Product product);

        /// <summary>
        /// Delete a product from the repository by its unique identifier.
        /// </summary>
        /// <param name="productId">The unique identifier of the product to delete.</param>
        void DeleteProduct(int productId);
    }
}
