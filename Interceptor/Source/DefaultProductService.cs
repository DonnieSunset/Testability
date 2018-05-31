namespace Interceptor.Source
{
    public class DefaultProductService : IProductService
    {
        public Product GetProduct(int productId)
        {
            return new Product();
        }
    }
}
