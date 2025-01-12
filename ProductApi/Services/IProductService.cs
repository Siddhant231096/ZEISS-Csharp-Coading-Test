using System.Collections.Generic;
using ProductApi.Models;

namespace ProductApi.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id); 
        Task<Product> CreateProductAsync(Product product);
        Task<Product> UpdateProductAsync(int id, Product product);
        Task DeleteProductAsync(int id);
        Task<string> DecrementStockAsync(int id, int quantity);
        Task<string> AddToStockAsync(int id, int quantity);
    }
}