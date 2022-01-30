using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DuelMastersServer
{
    class Server
    {
        private const int Port = 11000;
        private const string IPAddress = "127.0.0.1";//"192.168.1.3";

        private const int BufferSize = 256;

        private readonly List<TcpClient> _clients = new List<TcpClient>();
        private TcpListener _listener;

        internal async void RunServerAsync()
        {
            IPAddress ipAddress = System.Net.IPAddress.Parse(IPAddress);
            _listener = new TcpListener(ipAddress, Port);
            try
            {
                _listener.Start();
                while (true)
                {
                    var client = await _listener.AcceptTcpClientAsync();
                    _clients.Add(client);
                    BroadcastMessage($"{client} connected.");
                    Task.Run(() => Foo(client));

                    //OnConnect(await _listener.AcceptTcpClientAsync());
                }

                //var task1 = _listener.AcceptTcpClientAsync();
                //var task2 = ReadAsync();
                //var tasks = new List<Task> { task1, task2 };
                //while (true)
                //{
                //    Task finishedTask = await Task.WhenAny(tasks);
                //    if (finishedTask == task1)
                //    {
                //        OnConnect(task1.Result);
                //    }
                //    else if (finishedTask == task2)
                //    {
                //        var text = task2.Result;
                //    }
                //    else
                //    {
                //        throw new NotImplementedException(finishedTask.ToString());
                //    }
                //    _clients.RemoveAll(x => !x.Connected);
                //    //if (_client.Available > 0)
                //    //{
                //    //    var text = await ReadAsync();
                //    //}

                //    //OnConnect(await _listener.AcceptTcpClientAsync());
                //}
            }
            finally
            {
                _listener.Stop();
            }
        }

        private async Task Foo(TcpClient client)
        {
            while (!client.Client.Poll(1000, SelectMode.SelectRead) || client.Available > 0)
            {
                if (client.Available > 0)
                {
                    var text = await ReadAsync(client);
                    if (text.StartsWith("name: "))
                    {
                        text = text.Replace("name: ", "") + " connected.";
                    }
                    BroadcastMessage(text);
                }
            }
            _clients.Remove(client);
            BroadcastMessage($"{client} disconnected.");
        }

        private void BroadcastMessage(string text)
        {
            Program.WriteConsole(text);
            foreach (var client in _clients)
            {
                byte[] bytesToSend = Encoding.ASCII.GetBytes(text);
                if (client.Connected)
                {
                    client.GetStream().Write(bytesToSend, 0, bytesToSend.Length);
                }
            }
        }

        private async Task<string> ReadAsync(TcpClient client)
        {
            byte[] data = new byte[BufferSize];
            int bytesRead = 0;
            int chunkSize = 1;
            NetworkStream stream = client.GetStream();
            //while (bytesRead < data.Length && chunkSize > 0)
            //{
            //    //bytesRead += chunkSize = await stream.ReadAsync(data, bytesRead, data.Length - bytesRead);
            //    bytesRead += chunkSize = stream.Read(data, bytesRead, data.Length - bytesRead);
            //}
            bytesRead = stream.Read(data, 0, data.Length);
            return Encoding.Default.GetString(data, 0, bytesRead);
        }

        private async Task Accept2(TcpClient client)
        {
            // https://stackoverflow.com/questions/22190536/accept-tcp-client-async
            await Task.Yield();
            try
            {
                using (client)
                using (NetworkStream stream = client.GetStream())
                {
                    byte[] data = new byte[BufferSize];
                    int bytesRead = 0;
                    int chunkSize = 1;

                    while (bytesRead < data.Length && chunkSize > 0)
                    {
                        bytesRead += chunkSize = await stream.ReadAsync(data, bytesRead, data.Length - bytesRead);
                    }
                    await stream.ReadAsync(data, 0, data.Length);
                        
                    // get data
                    string str = Encoding.Default.GetString(data);
                    Console.WriteLine("[server] received : {0}", str);

                    // To do
                    // ...

                    // send the result to client
                    string send_str = "server_send_test";
                    byte[] send_data = Encoding.ASCII.GetBytes(send_str);
                    await stream.WriteAsync(send_data, 0, send_data.Length);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
