using System.Linq;
using System.Collections.Generic;

using TinyCrm.Core.Model;
using TinyCrm.Core.Model.Options;
using TinyCrm.Core.Data;

namespace TinyCrm.Core.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class ProductService : IProductService
    {
        private TinyCrmDbContext dbContext;
        public ProductService(TinyCrmDbContext context)
        {
            dbContext = context;
        }
        private List<Product> ProductsList = new List<Product>();

        public List<Product> SearchProduct
            (SearchProductOptions searchProductOptions)
        {
            if (searchProductOptions == null)
            {
                return null;
            }
            
                var query = dbContext.Set<Product>().AsQueryable();

                //if (searchProductOptions.Id != null)
                //{
                //    query = query.
                //    Where(c => c.Id == searchProductOptions.Id);
                //}
                if (searchProductOptions.Description != null)
                {
                    query = query.
                    Where(c => c.Description == searchProductOptions.Description);
                }
                if (searchProductOptions != null && 
                    searchProductOptions.MaxPrice>0)
                {
                    query = query.
                    Where(c => c.Price <= searchProductOptions.MaxPrice );
                }

                if (searchProductOptions != null &&
                    searchProductOptions.MinPrice > 0)
                {
                    query = query.
                    Where(c => c.Price >= searchProductOptions.MinPrice);
                }
                List<Product> products = query.ToList();
                return products;

            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        //public bool AddProduct(AddProductOptions options)
        //{
        //    if (options == null)
        //    {
        //        return false;
        //    }

        //    var product = GetProductById(options.Id);

        //    if (product != null)
        //    {
        //        return false;
        //    }

        //    if (string.IsNullOrWhiteSpace(options.Name))
        //    {
        //        return false;
        //    }

        //    if (options.Price <= 0)
        //    {
        //        return false;
        //    }

        //    if (options.ProductCategory ==
        //      ProductCategory.Invalid)
        //    {
        //        return false;
        //    }

        //    product = new Product()
        //    {
        //        Id = options.Id,
        //        Name = options.Name,
        //        Price = options.Price,
        //        Category = options.ProductCategory
        //    };

        //    product.Id = options.Id;
        //    product.Name = options.Name;
        //    product.Price = options.Price;
        //    product.Category = options.ProductCategory;

        //    ProductsList.Add(product);

        //    return true;
        //}

        public Product CreateProduct(AddProductOptions options)
        {

            if (options == null)
            {
                return null;
            }

            //if (options.Id==null)
            //{
            //    return null;
            //}

            var product = new Product();

            
                //product.Id = options.Id;
                product.Name = options.Name;
                product.Category = options.ProductCategory;
                product.Price = options.Price;

                dbContext.Set<Product>().Add(product);
                dbContext.SaveChanges();
                return product;
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        //public bool UpdateProduct(int productId,
        //    UpdateProductOptions options)
        //{
        //    if (options == null) {
        //        return false;
        //    }

        //    var product = GetProductById(productId);
        //    if (product == null) { 
        //        return false; 
        //    }

        //    if (!string.IsNullOrWhiteSpace(options.Description)) {
        //        product.Description = options.Description;
        //    }

        //    if (options.Price != null &&
        //      options.Price <= 0) {
        //        return false;
        //    }

        //    if (options.Price != null) {
        //        if (options.Price <= 0) {
        //            return false;
        //        } else {
        //            product.Price = options.Price.Value;
        //        }
        //    }

        //    if (options.Discount != null &&
        //      options.Discount < 0) {
        //        return false;
        //    }

        //    return true;
        //}
        
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public Product GetProductById(int id)
        //{
        //    if (id == null) {
        //        return null;
        //    } 

        //    return ProductsList.
        //        SingleOrDefault(s => s.Id.Equals(id));
        //}

        public int SumOfStocks()
        {
            var sum = dbContext.Set<Product>().AsQueryable().
                Sum(c =>c.Stock);
            return sum;
         
        }
    }
}
