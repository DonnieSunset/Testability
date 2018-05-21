using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using HumbleObject.WithHumble.Source;

namespace HumbleObject.WithHumble.Test
{
    [TestClass]
    public class MessageProviderTests
    {
        /// <summary>
        /// We cannot test here without synchronizing with Thread.Sleep()
        /// </summary>
        [TestMethod]
        public void WithHumble_ArrivingMethodPublished_Test()
        {
            var fakeMessageProvider = new Mock<IMessageProvider>();
            fakeMessageProvider.Setup(foo => foo.GetNextMessage()).Returns("Hello");

            var messageHandler = new MessageHandler(fakeMessageProvider.Object);
            messageHandler.HandleNextMessage();

            // We dont need the server anymore!

            //var server = new Server(fakeMessageProvider.Object);
            //server.Start();
            //Thread.Sleep(2000);

            Assert.AreEqual("Hello", messageHandler.LastMessage);
        }
    }
}
