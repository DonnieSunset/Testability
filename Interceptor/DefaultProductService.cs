using Interceptor.Helper;

namespace Interceptor
{
    public class DefaultProductService : IProductService
    {
        public Product GetProduct(int productId)
        {
            return new Product();
        }
    }
}
