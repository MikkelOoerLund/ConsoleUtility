using System.Net.Sockets;
using System.Net;
using System.Text;
using System;
using System.IO;

namespace ConsoleUtility
{

    public class TCPClient
    {
        private int _port;
        private string _ipAddress;


        private TcpClient _client;


        public TCPClient(int port)
        {
            _port = port;
            _client = new TcpClient();
            _ipAddress = IPAddress.Loopback.ToString();
        }

        public TCPClient(string ipAddress, int port)
        {
            _port = port;
            _ipAddress = ipAddress;
            _client = new TcpClient();
        }

        public void Connect()
        {
            _client.Connect(IPAddress.Parse(_ipAddress), _port);
        }

        public void SendRequest(string request)
        {
            NetworkStream stream = _client.GetStream();
            byte[] data = Encoding.UTF8.GetBytes(request);
            stream.Write(data, 0, data.Length);
        }

        public string RecieveResponse()
        {
            var data = new byte[256];
            var clientStream = _client.GetStream();
            var numberOfBytesRead = clientStream.Read(data, 0, data.Length);
            var response = Encoding.UTF8.GetString(data, 0, numberOfBytesRead);
            return response;
        }


        public void Close()
        {
            _client.Close();
        }
    }
}