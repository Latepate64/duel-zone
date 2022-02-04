using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Client
{
    class Client
    {
        private TcpClient _client;
        private const int BufferSize = 256 * 256 * 16;

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
                        var objects = Read();
                        foreach (var obj in objects)
                        {
                            Process(form, obj);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + e.StackTrace);
            }
        }

        private void Process(Form1 form, object obj)
        {
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
