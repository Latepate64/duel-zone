using DuelMastersModels;
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
        public string Name { get; private set; }

        public SocketWithName(Socket socket, string name)
        {
            Socket = socket;
            Name = name;
        }
    }

    class ServerProgram
    {
        public static ManualResetEvent _allDone = new ManualResetEvent(false);
        //public static ObservableCollection<string> _clientNames = new ObservableCollection<string>();
        public static ObservableCollection<SocketWithName> _clientSockets = new ObservableCollection<SocketWithName>();

        static void Main(string[] args)
        {
            Console.WriteLine("Started Duel Masters Server.");
            //_clientNames.CollectionChanged += CollectionChangedClientNames;
            _clientSockets.CollectionChanged += CollectionChangedClientSockets;
            CollectionChangedClientSockets(null, null);
            //CollectionChangedClientNames(null, null);
            StartListening();
        }

        private static void CollectionChangedClientSockets(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (_clientSockets.Count == 0)
            {
                Console.WriteLine("Waiting for two clients to connect...");
            }
            else if (_clientSockets.Count == 1)
            {
                Console.WriteLine("Waiting for one more client to connect...");
            }
            else if (_clientSockets.Count == 2)
            {
                Console.WriteLine("Two clients connected!");
            }
            else
            {
                throw new Exception("Too many clients.");
            }
            if (_clientSockets.Count > 0)
            {
                Console.WriteLine("Connected clients:");
                foreach (var clientSocket in _clientSockets)
                {
                    Console.WriteLine("- {0}", clientSocket.Name);
                }
            }
        }

        /*
        private static void CollectionChangedClientNames(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (_clientNames.Count == 0)
            {
                Console.WriteLine("Waiting for two clients to connect...");
            }
            else if (_clientNames.Count == 1)
            {
                Console.WriteLine("Waiting for one more client to connect...");
            }
            else if (_clientNames.Count == 2)
            {
                Console.WriteLine("Two clients connected!");
            }
            else
            {
                throw new Exception("Too many clients.");
            }
        }*/

        private static void StartListening()
        {
            var ipAddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0];
            var serverSocket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                serverSocket.Bind(new IPEndPoint(ipAddress, 11000));
                serverSocket.Listen(100);
                while (true)
                {
                    _allDone.Reset();

                    // Start an asynchronous socket to listen for connections.  
                    serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), serverSocket);
                    _allDone.WaitOne();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine("\nPress ENTER to continue...");
            Console.Read();
        }

        public static void AcceptCallback(IAsyncResult ar)
        {
            // Signal the main thread to continue.  
            _allDone.Set();

            // Get the socket that handles the client request.
            var serverState = (StateObject)ar.AsyncState;
            var clientSocket = serverState.ClientSocket.EndAccept(ar);
            _clientSockets.Add(new SocketWithName(clientSocket, serverState.StringBuilder.ToString()));

            // Create the state object.  
            var state = new StateObject() { ClientSocket = clientSocket };
            clientSocket.BeginReceive(state.Buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReadCallback), state);
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
                    var text = Encoding.ASCII.GetString(state.Buffer, 0, bytesRead);
                    var xmlElement = XElement.Parse(text);

                    /*
                    if (xmlElement.Name == "ConnectionRequest")
                    {
                        _clientNames.Add(xmlElement.Value);
                    }
                    else if (xmlElement.Name == "DisconnectRequest")
                    {
                        _clientNames.Remove(xmlElement.Value);
                    }
                    else
                    {
                        throw new NotSupportedException("xmlElement.Name");
                    }*/

                    // There might be more data, so store the data received so far.  
                    state.StringBuilder.Append(text);

                    // Check for end-of-file tag. If it is not there, read more data.  
                    var content = state.StringBuilder.ToString();

                    // All the data has been read from the client. Display it on the console.  
                    Console.WriteLine("Read {0} bytes from socket. \n Data : {1}", content.Length, content);

                    // Echo the data back to the client.  
                    Send(state.ClientSocket, content);
                }
            }
            catch (SocketException se)
            {
                foreach (var clientSocket in _clientSockets)
                {
                    if (clientSocket.Socket == state.ClientSocket)
                    {
                        _clientSockets.Remove(clientSocket);
                        return;
                    }
                }
                Console.WriteLine("Client not found.");
            }
        }

        private static void Send(Socket handler, String data)
        {
            // Convert the string data to byte data using ASCII encoding.  
            var byteData = Encoding.ASCII.GetBytes(data);

            // Begin sending the data to the remote device.  
            handler.BeginSend(byteData, 0, byteData.Length, 0, new AsyncCallback(SendCallback), handler);
        }

        private static void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.  
                var handler = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.  
                int bytesSent = handler.EndSend(ar);
                Console.WriteLine("Sent {0} bytes to client.", bytesSent);

                handler.Shutdown(SocketShutdown.Both);
                handler.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
