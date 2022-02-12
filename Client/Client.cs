using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using Common;

namespace Client
{
    internal class Client
    {
        internal string _userName;

        private TcpClient _client;
        private const int BufferSize = 256 * 256 * 16;
        internal LobbyPanel _lobbyPanel;
        internal TablePage _tablePage;

        internal Client()
        {
        }

        internal void Connect(string hostname, int port)
        {
            //_client.Connect(hostname, port);
            _client = new(hostname, port);
            //_client = new();
            //_client.BeginConnect()
        }

        internal async Task ReadLoop()
        {
            try
            {
                while (_client.Connected)
                {
                    if (_client.Available > 0)
                    {
                        var objects = Read();
                        foreach (var obj in objects)
                        {
                            Process(obj);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + e.StackTrace);
            }
        }

        private void Process(object obj)
        {
            if (obj is CreateTable)
            {
                _lobbyPanel.OnCreateTable();
            }
            else if (obj is LeaveTable)
            {
                _tablePage.OnExitTable();
            }
            else if (obj is ClientName name)
            {
                _userName = name.Name;
            }
            else if (obj is StartGame startGame)
            {
                _tablePage.OnStartGame(startGame);
            }
            else if (obj is Common.GameEvents.GameEvent e)
            {
                _tablePage.Process(e);
            }
            else if (obj is Common.Choices.Choice c)
            {
                _tablePage.Process(c);
            }
            _lobbyPanel._chatBox.Invoke(new MethodInvoker(delegate { _lobbyPanel._chatBox.Text += Common.Helper.ObjectToText(obj, _client); _lobbyPanel._chatBox.Text += Environment.NewLine; }));
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

        private List<object> Read()
        {
            List<object> objects = new();
            byte[] data = new byte[BufferSize];
            var bytesRead = _client.GetStream().Read(data, 0, data.Length);
            var text = Encoding.Default.GetString(data, 0, bytesRead).Trim();
            return Common.Serializer.Deserialize(text);
        }

        //private List<object> Read()
        //{
        //    List<object> objects = new();
        //    int totalBytesRead = 0;
        //    int bytesRead;
        //    byte[] readBuffer = new byte[BufferSize];

        //    while ((bytesRead = _client.GetStream().Read(readBuffer, totalBytesRead, readBuffer.Length - totalBytesRead)) > 0)
        //    {
        //        totalBytesRead += bytesRead;

        //        if (totalBytesRead == readBuffer.Length)
        //        {
        //            int nextByte = _client.GetStream().ReadByte();
        //            if (nextByte != -1)
        //            {
        //                byte[] temp = new byte[readBuffer.Length * 2];
        //                Buffer.BlockCopy(readBuffer, 0, temp, 0, readBuffer.Length);
        //                Buffer.SetByte(temp, totalBytesRead, (byte)nextByte);
        //                readBuffer = temp;
        //                totalBytesRead++;
        //            }
        //        }
        //    }
        //}
    }
}
