using Interceptor.Helper;
using System;

namespace Interceptor
{
    public class CachedProductService : IProductService
    {
        private readonly IProductService _innerProductService;
        private readonly ICacheStorage _cacheStorage;

        public CachedProductService(IProductService innerProductService, ICacheStorage cacheStorage)
        {
            _cacheStorage = cacheStorage ?? throw new ArgumentNullException("CacheStorage");
            _innerProductService = innerProductService ?? throw new ArgumentNullException("ProductService");
        }

        public Product GetProduct(int productId)
        {
            string key = "Product|" + productId;
            Product p = _cacheStorage.Retrieve<Product>(key);
            if (p == null)
            {
                p = _innerProductService.GetProduct(productId);
                _cacheStorage.Store(key, p);
            }

            return p;
        }
    }
}
