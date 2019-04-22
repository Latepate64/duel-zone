using DuelMastersModels;
using DuelMastersModels.Cards;
using DuelMastersModels.Factories;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Xml.Linq;

namespace DuelMastersServer
{
    /// <summary>
    /// State object for reading client data asynchronously
    /// </summary>
    public class StateObject
    {
        /// <summary>
        /// Client  socket.  
        /// </summary>
        public Socket ClientSocket = null;

        /// <summary>
        /// Size of receive buffer.
        /// </summary>
        public const int BufferSize = 1024;

        /// <summary>
        /// Receive buffer.
        /// </summary>
        public byte[] Buffer = new byte[BufferSize];

        /// <summary>
        /// Received data string.  
        /// </summary>
        public StringBuilder StringBuilder = new StringBuilder();
    }

    public class SocketWithName
    {
        public Socket Socket { get; private set; }
        public string Name { get; set; } = "Anonym";
        public int Id { get; set; }

        public SocketWithName(Socket socket, int id)
        {
            Socket = socket;
            Id = id;
        }
    }

    class ServerProgram
    {
        private static ManualResetEvent _allDone = new ManualResetEvent(false);
        private static ManualResetEvent _clientDone = new ManualResetEvent(false);
        private static ObservableCollection<SocketWithName> _clientSocketsWithNames = new ObservableCollection<SocketWithName>();

        static void Main(string[] args)
        {
            Console.WriteLine("Started Duel Masters Server.");
            //_clientNames.CollectionChanged += CollectionChangedClientNames;
            _clientSocketsWithNames.CollectionChanged += CollectionChangedClientSockets;
            CollectionChangedClientSockets(null, null);
            //CollectionChangedClientNames(null, null);
            StartListening();
        }

        private static void CollectionChangedClientSockets(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (_clientSocketsWithNames.Count == 0)
            {
                Console.WriteLine("Waiting for two clients to connect...");
            }
            else if (_clientSocketsWithNames.Count == 1)
            {
                Console.WriteLine("Waiting for one more client to connect...");
            }
            else if (_clientSocketsWithNames.Count == 2)
            {
                Console.WriteLine("Two clients connected!");
            }
            else
            {
                throw new Exception("Too many clients.");
            }
            if (_clientSocketsWithNames.Count > 0)
            {
                Console.WriteLine("Connected clients:");
                foreach (var clientSocketWithName in _clientSocketsWithNames)
                {
                    Console.WriteLine("- {0}", clientSocketWithName.Name);
                }
            }
        }

        private static void StartListening()
        {
            var ipAddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0];
            var serverSocket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                serverSocket.Bind(new IPEndPoint(ipAddress, 11000));
                serverSocket.Listen(100);
                while (_clientSocketsWithNames.Count < 2)
                {
                    _allDone.Reset();

                    // Start an asynchronous socket to listen for connections.  
                    serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), serverSocket);
                    _allDone.WaitOne();
                }
                LaunchDuel();
                while (true)
                {
                    _clientDone.Reset();
                    Console.WriteLine("Waiting for client's response...");
                    _clientDone.WaitOne();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine("\nServer has shut down. Press ENTER to continue...");
            Console.Read();
        }

        private static void LaunchDuel()
        {
            var jsonPath = "C:\\duel-masters-json\\DuelMastersCards.json";
            var jsonCards = JsonCardFactory.GetJsonCards(jsonPath);
            var cards = CardFactory.GetCardsFromJsonCards(jsonCards);
            var duel = new Duel()
            {
                Player1 = new Player()
                {
                    Id = 0,
                    Name = _clientSocketsWithNames[0].Name,
                },
                Player2 = new AIPlayer()
                {
                    Id = 1,
                    Name = _clientSocketsWithNames[1].Name,
                },
            };

            //duel.Turns.CollectionChanged += TurnChanged;

            var count = 20;
            duel.Player1.SetDeckBeforeDuel(new Collection<Card>(cards.ToList().GetRange(0, count)));
            duel.Player2.SetDeckBeforeDuel(new Collection<Card>(cards.ToList().GetRange(count, count)));
            duel.Player1.SetupDeck();
            duel.Player2.SetupDeck();
            var playerAction = duel.StartDuel();

            var xmlAction = XmlUtility.SerializeToString(playerAction);
            Send(GetSocket(playerAction.Player.Id), xmlAction);
            Send(GetSocketOpponent(playerAction.Player.Id), new XElement("Message", "Opponent is performing an action.").ToString());
        }

        private static Socket GetSocket(int id)
        {
            return _clientSocketsWithNames.First(s => s.Id == id).Socket;
        }

        private static Socket GetSocketOpponent(int id)
        {
            var opponents = _clientSocketsWithNames.Where(s => s.Id != id);
            if (opponents.Count() == 1)
            {
                return opponents.First().Socket;
            }
            else
            {
                throw new Exception("Expected one opponent.");
            }
        }
        
        private static void Send(Socket socket, string data)
        {
            Console.WriteLine(String.Format("Sending data to client: {0}", data));

            // Convert the string data to byte data using ASCII encoding.
            var byteData = Encoding.ASCII.GetBytes(data);

            // Begin sending the data to the remote device.
            socket.BeginSend(byteData, 0, byteData.Length, 0, new AsyncCallback(SendCallback), socket);
        }

        #region Callbacks
        public static void AcceptCallback(IAsyncResult ar)
        {
            // Signal the main thread to continue.  
            _allDone.Set();

            // Get the socket that handles the client request.
            var serverSocket = (Socket)ar.AsyncState;
            var clientSocket = serverSocket.EndAccept(ar);
            _clientSocketsWithNames.Add(new SocketWithName(clientSocket, _clientSocketsWithNames.Count));

            // Create the state object.  
            var state = new StateObject() { ClientSocket = clientSocket };
            clientSocket.BeginReceive(state.Buffer, 0, StateObject.BufferSize, SocketFlags.None, new AsyncCallback(ReadCallback), state);
        }

        public static void ReadCallback(IAsyncResult ar)
        {
            // Retrieve the state object and the handler socket from the asynchronous state object.  
            var state = (StateObject)ar.AsyncState;
            try
            {
                // Read data from the client socket.   
                var bytesRead = state.ClientSocket.EndReceive(ar);

                if (bytesRead > 0)
                {
                    // There might be more data, so store the data received so far.  
                    state.StringBuilder.Append(Encoding.ASCII.GetString(state.Buffer, 0, bytesRead));
                    var content = state.StringBuilder.ToString();

                    // TODO: If more to read, read more.
                    if (true/*content.IndexOf("<EOF>") > -1*/)
                    {
                        var xElement = XElement.Parse(content);
                        if (xElement.Name == "Name")
                        {
                            _clientSocketsWithNames.First(cs => cs.Socket == state.ClientSocket).Name = xElement.Value;

                            // Echo the data back to the client.  
                            Send(state.ClientSocket, String.Format("<Message>Hello {0}!</Message>", xElement.Value)); //TODO: uncomment
                            //Send(state.ClientSocket, "<Testi>I sexually Identify as Johny. Ever since I was a boy I dreamed of eating lollipops with chiya and lying to papa about eating sugar. People say to me that a person being Johny is Impossible and I'm fucking retarded but to that I say, \"no papa\". I'm having a plastic surgeon shrink me down to the size of a baby, severely elongate my arms and make my head the size of a fucking beach ball. From now on I want you guys to always follow my name with \"doo doo doo doo doo doo doo and respect my right to If you can't accept me you\'re a Johnyphobe and need to check your papa privilege.Thank you for being so understanding.</Testi>");
                        }
                        else
                        {
                            throw new Exception("Expected name.");

                        }

                        // All the data has been read from the client. Display it on the console.
                        Console.WriteLine("Read {0} bytes from socket. \n Data : {1}", content.Length, content);
                    }
                    else
                    {
                        // Not all data received. Get more.  
                        state.ClientSocket.BeginReceive(state.Buffer, 0, StateObject.BufferSize, SocketFlags.None, new AsyncCallback(ReadCallback), state);
                    }
                }
            }
            catch (SocketException)
            {
                foreach (var clientSocket in _clientSocketsWithNames)
                {
                    if (clientSocket.Socket == state.ClientSocket)
                    {
                        _clientSocketsWithNames.Remove(clientSocket);
                        return;
                    }
                }
                Console.WriteLine("Client not found.");
            }
        }

        /// <summary>
        /// Complete sending the data to the remote device.
        /// </summary>
        private static void SendCallback(IAsyncResult ar)
        {
            try
            {
                Console.WriteLine("Sent {0} bytes to client.", ((Socket)ar.AsyncState).EndSend(ar));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        #endregion Callbacks
    }
}
