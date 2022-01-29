using System.Net.Sockets;
using System.Text;
using System;

namespace Client
{
    class Client
    {
        private readonly TcpClient _client = new();
        private const int BufferSize = 256;

        internal async void ConnectAsync(string hostname, int port, MenuPage menuPage, string username)
        {
            await _client.ConnectAsync(hostname, port);
            menuPage.OnConnect();
            WriteAsync(username);
            while (_client.Connected)
            {
                ReadAsync();
            }
        }

        internal void EndConnect()
        {
            _client.EndConnect(null);
            _client.Close();
        }

        private async void WriteAsync(string text)
        {
            byte[] bytesToSend = Encoding.ASCII.GetBytes(text);
            using NetworkStream stream = _client.GetStream();
            await stream.WriteAsync(bytesToSend);
        }

        private async void ReadAsync()
        {
            byte[] data = new byte[BufferSize];
            using NetworkStream stream = _client.GetStream();
            int bytes = await stream.ReadAsync(data.AsMemory(0, data.Length));
            string str = Encoding.Default.GetString(data);
        }
    }
}
