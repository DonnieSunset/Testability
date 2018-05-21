using System.Threading;

namespace HumbleObject.Before.Source
{
    public class Server
    {
        Thread _worker;
        bool _isAlive = true;
        IMessageProvider _messageProvider;

        public Server(IMessageProvider messageProvider)
        {
            _messageProvider = messageProvider;
        }

        public string LastMessage { get; set; }

        public void Start()
        {
            _worker = new Thread(() =>
            {
                while (_isAlive)
                {
                    Thread.Sleep(1000);

                    var msg = _messageProvider.GetNextMessage();

                    //Do stuff with message

                    LastMessage = msg;
                }
            });

            _worker.Start();
        }
    }
}
