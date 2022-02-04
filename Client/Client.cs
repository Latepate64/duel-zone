using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Windows.Forms;

namespace Client
{
    class Client
    {
        private TcpClient _client;
        private const int BufferSize = 256 * 8;

        internal void Connect(string hostname, int port)
        {
            //_client.Connect(hostname, port);
            _client = new(hostname, port);
            //_client = new();
            //_client.BeginConnect()
        }

        internal async Task ReadLoop(Form1 form)
        {
            try
            {
                while (_client.Connected)
                {
                    if (_client.Available > 0)
                    {
                        var obj = Read();
                        if (obj is Common.CreateTable)
                        {
                            form.LobbyPage.Panel.OnCreateTable();
                        }
                        else if (obj is Common.LeaveTable)
                        {
                            form.TablePage.OnExitTable();
                        }
                        else if (obj is Common.ClientName name)
                        {
                            form.UserName = name.Name;
                        }
                        else if (obj is Common.StartGame)
                        {
                            form.TablePage.OnStartGame();
                        }
                        else if (obj is Common.GameEvents.GameEvent e)
                        {
                            form.TablePage.Process(e);
                        }
                        form.LobbyPage.Panel.ChatBox.Invoke(new MethodInvoker(delegate { form.LobbyPage.Panel.ChatBox.Text += Common.Helper.ObjectToText(obj, _client); form.LobbyPage.Panel.ChatBox.Text += Environment.NewLine; }));
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + e.StackTrace);
            }
        }

        internal void EndConnect()
        {
            _client.GetStream().Close();
            _client.Close();
        }

        internal void WriteAsync(object obj)
        {
            byte[] bytesToSend = Encoding.ASCII.GetBytes(Common.Serializer.Serialize(obj));
            if (_client.Connected)
            {
                _ = _client.GetStream().WriteAsync(bytesToSend);
            }
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

        private object Read()
        {
            byte[] data = new byte[BufferSize];
            var bytesRead = _client.GetStream().Read(data, 0, data.Length);
            var text = Encoding.Default.GetString(data, 0, bytesRead).Trim();
            return Common.Serializer.Deserialize(text);
        }
    }
}
