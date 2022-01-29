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
        const int Port = 11000;
        const string IPAddress = "127.0.0.1";//"192.168.1.3";

        List<TcpClient> _clients = new List<TcpClient>();
        TcpListener _listener;

        internal async void RunServerAsync()
        {
            IPAddress ipAddress = System.Net.IPAddress.Parse(IPAddress);
            _listener = new TcpListener(ipAddress, Port);
            try
            {
                _listener.Start();
                while (true)
                {
                    await OnConnect(await _listener.AcceptTcpClientAsync());
                    _clients.RemoveAll(x => !x.Connected);
                    //await Accept();
                }
            }
            finally
            {
                _listener.Stop();
            }
        }

        const int packet_length = 256;  // user defined packet length

        async Task OnConnect(TcpClient client)
        {
            Program.WriteConsole($"{client} connected.");
            _clients.Add(client);

            //_listener.
        }

        async Task Accept2(TcpClient client)
        {
            // https://stackoverflow.com/questions/22190536/accept-tcp-client-async
            await Task.Yield();
            try
            {
                using (client)
                using (NetworkStream stream = client.GetStream())
                {
                    byte[] data = new byte[packet_length];
                    int bytesRead = 0;
                    int chunkSize = 256;

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
