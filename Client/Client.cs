using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Windows.Forms;

namespace Client
{
    class Client
    {
        private readonly TcpClient _client = new();
        private const int BufferSize = 256;

        internal void Connect(string hostname, int port)
        {
            _client.Connect(hostname, port);
        }

        internal async Task ReadLoop(Form1 form)
        {
            while (_client.Connected)
            {
                if (_client.Available > 0)
                {
                    //var text = await ReadAsync();
                    var text = Read();
                    try
                    {
                        //form.LobbyPage.ChatBox.AppendText(text + "\r\n");
                        form.LobbyPage.ChatBox.Invoke(new MethodInvoker(delegate { form.LobbyPage.ChatBox.Text += text; form.LobbyPage.ChatBox.Text += Environment.NewLine; }));
                        //SetTextCallback d = new SetTextCallback(SetText);
                        //this.Invoke(d, new object[] { text });
                        //form.LobbyPage.ChatBox.Invoke(() => AppendText, text + "\r\n");
                    }
                    catch (Exception e)
                    {

                    }
                }
            }
        }

        internal void EndConnect()
        {
            _client.EndConnect(null);
            _client.Close();
        }

        internal void WriteAsync(string text)
        {
            byte[] bytesToSend = Encoding.ASCII.GetBytes(text);
            _ = _client.GetStream().WriteAsync(bytesToSend);
        }

        private async Task<string> ReadAsync()
        {
            byte[] data = new byte[BufferSize];
            int bytesRead = 0;
            int chunkSize = 1;
            NetworkStream stream = _client.GetStream();
            while (bytesRead < data.Length && chunkSize > 0)
            {
                bytesRead += chunkSize = await stream.ReadAsync(data.AsMemory(bytesRead, data.Length - bytesRead));
            }
            return Encoding.Default.GetString(data);
        }

        private string Read()
        {
            byte[] data = new byte[BufferSize];
            int bytesRead = 0;
            int chunkSize = 1;
            NetworkStream stream = _client.GetStream();
            bytesRead = stream.Read(data, 0, data.Length);
            return Encoding.Default.GetString(data).Trim();
        }
    }
}
