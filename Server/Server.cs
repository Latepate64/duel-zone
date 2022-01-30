using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Server
    {
        private const int Port = 11000;
        private const string IPAddress = "127.0.0.1";//"192.168.1.3";

        private const int BufferSize = 256;

        private readonly List<TcpClient> _clients = new List<TcpClient>();
        private TcpListener _listener;

        private DuelMastersModels.Game _game;

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
                    var conn = new Common.ClientConnected();
                    string text = Common.Helper.ObjectToText(conn, client);
                    Program.WriteConsole(text);
                    BroadcastMessage(Common.Serializer.Serialize(conn));
                    Task.Run(() => Read(client));
                }
            }
            finally
            {
                _listener.Stop();
            }
        }

        private async Task Read(TcpClient client)
        {
            while (!client.Client.Poll(1000, SelectMode.SelectRead) || client.Available > 0)
            {
                if (client.Available > 0)
                {
                    var text = await ReadAsync(client);
                    var obj = Common.Serializer.Deserialize(text);
                    if (obj is Common.StartGame startGame)
                    {
                        _game = new();
                        var player1 = new HumanPlayer();
                        var player2 = new ComputerPlayer();
                        SetupPlayer(player1);
                        SetupPlayer(player2);
                        try
                        {
                            _game.Play(player1, player2);
                        }
                        catch (Exception e)
                        {
                            Program.WriteConsole(e.ToString());
                        }
                    }
                    Program.WriteConsole(Common.Helper.ObjectToText(obj, client));
                    BroadcastMessage(text);
                }
            }
            _clients.Remove(client);
            BroadcastMessage($"{client} disconnected.");
        }

        private static void SetupPlayer(DuelMastersModels.Player player)
        {
            var cards = GetCards(player.Id);
            player.Deck = new DuelMastersModels.Zones.Deck(cards);
        }

        private static List<DuelMastersModels.Card> GetCards(Guid player)
        {
            List<DuelMastersModels.Card> cards = DuelMastersCards.CardFactory.CreateAll().OrderBy(arg => Guid.NewGuid()).Take(40).ToList();
            foreach (var card in cards)
            {
                card.Owner = player;
            }
            return cards;
        }

        private void BroadcastMessage(string text)
        {
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
            var text = Encoding.Default.GetString(data, 0, bytesRead);
            return text;
            //var obj = Serializer.Deserialize(text);
            //return obj;
        }
    }
}
