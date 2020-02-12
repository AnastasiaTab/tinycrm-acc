using System;
using Xunit;

using TinyCrm.Core.Data;
using TinyCrm.Core.Model;
using TinyCrm.Core.Model.Options;
using TinyCrm.Core.Services;
namespace TinyCrm.Tests
{
    public class ProductServiceTests
    {
        private TinyCrmDbContext context_;
        public ProductServiceTests()
        {
            context_ = new TinyCrmDbContext();
        }
        //[Fact]
        //public void CreateProduct_Success()
        //{
        //    IProductService productService =
        //        new ProductService(context_);
        //    var options = new AddProductOptions()
        //    {
        //        Id = 12,
        //        Price = 100,
        //        Name = "mouse",
        //        ProductCategory = Core.Model.ProductCategory.Smartphones
        //    };
        //    var product = productService.CreateProduct(options);

        //    Assert.NotNull(product);
        //    Assert.Equal(options.Id, product.Id);
        //    Assert.Equal(options.Price, product.Price);
        //    Assert.Equal(options.Name, product.Name);
        //    Assert.Equal(options.ProductCategory, product.Category);

        //}
        [Fact]
        public void AddProduct_Success()
        {
            IProductService productService = 
                new ProductService(context_);
            var options = new AddProductOptions()
            {
                
                Price = 100m,
                Name = "phone",
                ProductCategory = Core.Model.ProductCategory.Smartphones

            };

            var product= productService.CreateProduct(options);
            Assert.NotNull(product);
            Assert.Equal(options.Price, product.Price);
            Assert.Equal(options.Name, product.Name);
            Assert.Equal(options.ProductCategory, product.Category);
        }
        [Fact]
        public void AddProduct_Fail()
        {
            IProductService productService =
                new ProductService(context_);
            AddProductOptions options = new AddProductOptions();

            var product = productService.CreateProduct(null);
            Assert.Null(product);
            
        }

        [Fact]
        public void SearchProduct_Success()
        {
            IProductService productService =
               new ProductService(context_);
            var options = new SearchProductOptions()
            {
                MaxPrice = 500m,
                MinPrice = 20m
            };

            var products = productService.SearchProduct(options);
            Assert.NotEmpty(products);
        }
        [Fact]
        public void SearchProduct_Fail()
        {
            IProductService productService =
               new ProductService(context_);
            var options = new SearchProductOptions()
            {
                MaxPrice = 190m,
                MinPrice = 20m,
                Description="pp"
                
            };

            var products = productService.SearchProduct(options);
            Assert.Empty(products);
        }

        [Fact]
        public void SumOfStocks_Success()
        {
            IProductService productService = new ProductService(context_);
            var sum = productService.SumOfStocks();

            Assert.Equal(0, sum);
        }
    }
}
