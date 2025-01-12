using NUnit.Framework;
using Moq;
using ProductApi.Models;
using ProductApi.Services;
using ProductApi.Data;
using Microsoft.EntityFrameworkCore;

namespace ProductApi.Tests
{
    public class ProductServiceTests
    {
        private Mock<ApplicationDbContext> _dbContextMock;
        private IProductService _productService;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            var dbContext = new ApplicationDbContext(options);

            _productService = new ProductService(dbContext);
        }

        [Test]
        public async Task CreateProduct_ShouldReturnProductWithId()
        {
            var product = new Product { Name = "Test Product", Description = "Test Desc", Price = 100, StockAvailable = 50 };
            var result = await _productService.CreateProductAsync(product);

            Assert.IsNotNull(result);
            Assert.AreEqual("Test Product", result.Name);
            Assert.AreEqual(100, result.Price);
        }

        [Test]
        public async Task GetProductById_ShouldReturnProduct()
        {
            var product = new Product { Name = "Test Product", Description = "Test Desc", Price = 100, StockAvailable = 50 };
            var createdProduct = await _productService.CreateProductAsync(product);

            var result = await _productService.GetProductByIdAsync(createdProduct.Id);

            Assert.IsNotNull(result);
            Assert.AreEqual("Test Product", result.Name);
        }

    }
}
