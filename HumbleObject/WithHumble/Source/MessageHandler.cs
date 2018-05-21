using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumbleObject.WithHumble.Source
{
    /// <summary>
    /// This is our easy-to-test component
    /// </summary>
    public class MessageHandler
    {
        private IMessageProvider _messageProvider;

        public MessageHandler(IMessageProvider messageProvider)
        {
            _messageProvider = messageProvider;
        }

        public string LastMessage { get; private set; }

        public void HandleNextMessage()
        {
            #region Here is the logic we want to test

            var msg = _messageProvider.GetNextMessage();

            //Do stuff with message

            LastMessage = msg;

            #endregion
        }
    }
}
