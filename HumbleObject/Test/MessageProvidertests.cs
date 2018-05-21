using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using Moq;

namespace HumbleObject.Test
{
    [TestClass]
    public class MessageProviderTests
    {
        [TestMethod]
        public void ArrivingmMethodPublishedTest()
        {
            var fakeMessageProvider = new Mock<IMessageProvider>();

            //var fakeMessageProvider = A.Fake<IMessageProvider>();
            //A.CallTo(() => 
            //    fakeMessageProvider.GetNextMessage())
            //    .Returns("Hello");

            fakeMessageProvider.Setup(foo => foo.GetNextMessage()).Returns("Hello");

            var server = new Server(fakeMessageProvider.Object);
            server.Start();

            Thread.Sleep(2000);

            Assert.AreEqual("Hello", server.LastMessage);
        }
    }
}
