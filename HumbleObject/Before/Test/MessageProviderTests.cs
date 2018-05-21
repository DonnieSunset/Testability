using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using Moq;
using HumbleObject.Before.Source;

namespace HumbleObject.Berfore.Test
{
    [TestClass]
    public class MessageProviderTests
    {
        /// <summary>
        /// We cannot test here without synchronizing with Thread.Sleep()
        /// </summary>
        [TestMethod]
        public void ArrivingmMethodPublishedTest()
        {
            var fakeMessageProvider = new Mock<IMessageProvider>();
            fakeMessageProvider.Setup(foo => foo.GetNextMessage()).Returns("Hello");

            var server = new Server(fakeMessageProvider.Object);
            server.Start();

            Thread.Sleep(2000);

            Assert.AreEqual("Hello", server.LastMessage);
        }
    }
}
