using System.Threading;

namespace HumbleObject.WithHumble.Source
{
    /// <summary>
    /// The Server is now the Humble object
    /// </summary>
    public class Server
    {
        Thread _worker;
        bool _isAlive = true;
        IMessageProvider _messageProvider;
        MessageHandler _messageHandler;

        public Server(IMessageProvider messageProvider)
        {
            _messageProvider = messageProvider;
            _messageHandler = new MessageHandler(_messageProvider);
        }

        public string LastMessage { get; set; }

        public void Start()
        {
            _worker = new Thread(() =>
            {
                while (_isAlive)
                {
                    Thread.Sleep(1000);

                    // We redirect to the carved-out component holding the easy-to-test logic
                    _messageHandler.HandleNextMessage();
                }
            });

            _worker.Start();
        }
    }
}
