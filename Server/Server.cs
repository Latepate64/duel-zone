using Common;
using Common.GameEvents;
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

        private const int BufferSize = 256 * 256;

        private readonly List<TcpClient> _clients = new();
        private TcpListener _listener;

        private Engine.Game _game;

        private readonly Dictionary<Player, TcpClient> _playerClients = new();

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
                    var conn = new ClientConnected();
                    string text = Helper.ObjectToText(conn, client);
                    Program.WriteConsole(text);
                    BroadcastMessage(Serializer.Serialize(conn));
                    Task.Run(() => Read(client));
                }
            }
            finally
            {
                _listener.Stop();
            }
        }

        internal async Task Read(TcpClient client)
        {
            while (!client.Client.Poll(1000, SelectMode.SelectRead) || client.Available > 0)
            {
                if (client.Available > 0)
                {
                    var text = await ReadAsync(client);
                    var objects = Serializer.Deserialize(text);
                    foreach (var obj in objects)
                    {
                        Process(client, text, obj);
                    }
                }
            }
            _clients.Remove(client);
            BroadcastMessage($"{client} disconnected.");
        }

        private void Process(TcpClient client, string text, object obj)
        {
            Program.WriteConsole(Helper.ObjectToText(obj, client));
            if (obj is StartGame)
            {
                StartGame(client);
            }
            else
            {
                BroadcastMessage(text);
            }
        }

        private void StartGame(TcpClient client)
        {
            _game = new();
            _game.OnGameEvent += OnGameEvent;
            var player1 = new HumanPlayer { Name = "Shobu", Server = this, Client = client };
            var player2 = new ComputerPlayer { Name = "Kokujo", };
            SetupPlayer(player1);
            SetupPlayer(player2);
            var players = new List<Engine.Player> { player1, player2 };
            _playerClients.Add(player1, client);

            var startEvent = new StartGame
            {
                Players = players.Select(x => new PlayerDeck
                {
                    Player = x.Convert(),
                    Deck = x.Deck.Cards.Select(x => x.Convert(true)).ToList()
                }).ToList(),
            };
            BroadcastMessage(Serializer.Serialize(startEvent));

            //Players.SelectMany(x => x.Deck.Cards).ToList().ForEach(x => x.KnownBy = new List<Guid>());

            try
            {
                _game.Play(player1, player2);
            }
            catch (Exception e)
            {
                Program.WriteConsole(e.ToString());
            }
        }

        private void OnGameEvent(GameEvent gameEvent)
        {
            foreach (var player in _playerClients)
            {
                var eventToSend = gameEvent;
                if (gameEvent is CardMovedEvent e && e.CardInDestinationZone != null && !e.CardInDestinationZone.KnownBy.Contains(player.Key.Id))
                {
                    (eventToSend as CardMovedEvent).CardInDestinationZone = new Card((eventToSend as CardMovedEvent).CardInDestinationZone, true);
                }
                var text = Serializer.Serialize(eventToSend);
                Program.WriteConsole(text);
                Write(text, player.Value);
            } 
        }

        private static void SetupPlayer(Engine.Player player)
        {
            var cards = GetCards(player.Id);
            player.Deck = new Engine.Zones.Deck(cards);
        }

        private static List<Engine.Card> GetCards(Guid player)
        {
            List<Engine.Card> cards = Cards.CardFactory.CreateAll().OrderBy(arg => Guid.NewGuid()).Take(40).ToList();
            foreach (var card in cards)
            {
                card.Owner = player;
            }
            return cards;
        }

        internal void BroadcastMessage(string text)
        {
            foreach (var client in _clients)
            {
                Write(text, client);
            }
        }

        private static void Write(string text, TcpClient client)
        {
            byte[] bytesToSend = Encoding.ASCII.GetBytes(text);
            if (client.Connected)
            {
                client.GetStream().Write(bytesToSend, 0, bytesToSend.Length);
            }
        }

        internal async Task<string> ReadAsync(TcpClient client)
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
