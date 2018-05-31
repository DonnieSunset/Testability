using Interceptor.Source;
using System;

namespace Interceptor.Test
{
    public class LoggingProductService : IProductService
    {
        private readonly IProductService _innerProductService;

        public LoggingProductService(IProductService innerProductService)
        {
            _innerProductService = innerProductService ?? throw new ArgumentNullException("ProductService");
        }

        /// <summary>
        /// Here the interception happens.
        /// </summary>
        public Product GetProduct(int productId)
        {
            Product p = _innerProductService.GetProduct(productId);

            Console.WriteLine($"Info: {p}");

            return p;
        }
    }
}
