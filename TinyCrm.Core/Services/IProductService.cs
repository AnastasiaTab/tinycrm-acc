using TinyCrm.Core.Model.Options;
using TinyCrm.Core.Model;
using System.Collections.Generic;

namespace TinyCrm.Core.Services
{
    /// <summary>
    /// 
    /// </summary>
    interface IProductService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        //bool AddProduct(AddProductOptions options);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        bool UpdateProduct(int productId,
            UpdateProductOptions options);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Product GetProductById(int id);
        public List<Product> SearchProduct
            (SearchProductOptions searchProductOptions);
        public Product CreateProduct(AddProductOptions options);
    }
}
