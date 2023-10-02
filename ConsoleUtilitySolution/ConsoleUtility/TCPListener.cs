using System.Net.Sockets;
using System.Net;
using System.Text;
using System.IO;

namespace ConsoleUtility
{
    public class TCPListener
    {
        private string request;
        private byte[] _bytes;


        private TcpListener _listener;

        public TCPListener(int port)
        {
            _listener = new TcpListener(IPAddress.Any, port);
        }

        private void HandleClient(TcpClient client)
        {
            var clientStream = client.GetStream();
            _bytes = new byte[256];

            Console.WriteLine("Handling client");


            while (true)
            {
                var numberOfBytesRead = clientStream.Read(_bytes, 0, _bytes.Length);

                if (numberOfBytesRead == 0)
                {
                    return;
                }

                request = Encoding.UTF8.GetString(_bytes, 0, numberOfBytesRead);


                Console.WriteLine($"Request: {request}");



                var responseBytes = Encoding.UTF8.GetBytes(request);




                clientStream.Write(responseBytes, 0, responseBytes.Length);
            }
        }

        public void Start()
        {
            _listener.Start();
        }


        public void AcceptClientLoop()
        {
            while (true)
            {
                Console.WriteLine("Here");
                var client = _listener.AcceptTcpClient();
                HandleClient(client);

                Console.WriteLine("Here");

            }
        }

        public void Stop()
        {
            _listener.Stop();
        }
    }
}