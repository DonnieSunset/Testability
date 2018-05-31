using Interceptor.Source;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Interceptor.Test
{
    [TestClass]
    public class ProductServiceTests
    {
        [TestMethod]
        public void GetService_Test()
        {
            IProductService cut1 = new DefaultProductService();

            // our interceptor
            IProductService cut2 = new LoggingProductService(cut1);

            Assert.IsNotNull(cut2.GetProduct(123));
        }
    }
}
