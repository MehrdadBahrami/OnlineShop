using OnlineShop.DomainLayer.Models;
using OnlineShop.RepositoryLayer.Contracts;
using OnlineShop.ServiceLayer.Contract;

namespace OnlineShop.ServiceLayer.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

         public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        async Task IProductService.AddProductAsync(Product product)=>
        await Task.Run(() => _productRepository.AddProduct(product));
        

        async Task IProductService.DeleteProductAsync(int productId)=>
        await Task.Run(() => _productRepository.DeleteProduct(productId));

        async Task<IEnumerable<Product>> IProductService.GetAllProductsAsync()=>
        await Task.Run(() => _productRepository.GetAllProducts());

        async Task<Product> IProductService.GetProductByIdAsync(int productId) =>
        await Task.Run(() => _productRepository.GetProductById(productId));


        async Task IProductService.UpdateProductAsync(Product product)=>
        await Task.Run(() => _productRepository.UpdateProduct(product));
        
    }
}
