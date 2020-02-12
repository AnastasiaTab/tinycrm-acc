using System;

namespace TinyCrm.Core.Model.Options
{
    /// <summary>
    /// 
    /// </summary>
    public class AddProductOptions
    {
        /// <summary>
        /// 
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ProductCategory ProductCategory { get; set; }
    }
}
