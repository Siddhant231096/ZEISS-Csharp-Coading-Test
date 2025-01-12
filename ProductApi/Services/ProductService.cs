using ProductApi.Models;
using ProductApi.Data;
using Microsoft.EntityFrameworkCore;

namespace ProductApi.Services
{
    public class ProductService: IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateProductAsync(int id, Product product)
        {
            var existingProduct = await _context.Products.FindAsync(id);
            if (existingProduct == null) return null;

            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
            existingProduct.StockAvailable = product.StockAvailable;

            await _context.SaveChangesAsync();
            return existingProduct;
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<string> DecrementStockAsync(int id, int quantity)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null && product.StockAvailable >= quantity)
            {
                product.StockAvailable -= quantity;
                await _context.SaveChangesAsync();
                return "StockAvailable "+ product.StockAvailable;
            }
            return "Quantity should be less then or equal to In Stock Quantity";
        }

        public async Task<string> AddToStockAsync(int id, int quantity)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                product.StockAvailable += quantity;
                await _context.SaveChangesAsync();
                return "StockAvailable "+ product.StockAvailable;
            }
            return "Please provide correct Product Id";
        }
    }
}
