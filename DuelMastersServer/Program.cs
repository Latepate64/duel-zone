using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using DuelMastersServer.XMLMessages;

namespace DuelMastersServer
{
    enum ErrorCode
    {
        Success = 0,
        NameAlreadyExists = 1,
        InvalidName = 2,
        ClientAlreadyChallenged = 3,
        ClientAlreadyInDuel = 4,
    }

    class Program
    {
        const int Port = 11000;
        const string IPAddress = "127.0.0.1";//"192.168.1.3";

        static List<ClientInformation> _clients = new List<ClientInformation>();
        static Server _server;

        static void Main(string[] args)
        {
            WriteConsole("Started server.");
            _server = new Server();
            _server.RunServerAsync();
            while (true) { }

            //TcpClient client = 

            //Socket serverSocket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            //serverSocket.Bind(new IPEndPoint(ipAddress, Port));
            //serverSocket.Listen(100);
            //WriteConsole(string.Format("Server is running on {0} on port {1}.", ipAddress, Port));
            //BeginAccept(serverSocket);
            //
        }

        internal static void WriteConsole(string text)
        {
            Console.Write(string.Format("[{0}] {1}\r\n", DateTime.Now, text));
        }

        static void BeginAccept(Socket serverSocket)
        {
            serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), serverSocket);
            WriteConsole("Accepting new connections...");
        }

        static void BeginSend(ClientInformation clientSocket, string text)
        {
            byte[] dataToSend = Encoding.UTF8.GetBytes(text);
            clientSocket.Socket.BeginSend(dataToSend, 0, dataToSend.Length, SocketFlags.None, new AsyncCallback(SendCallback), clientSocket.Socket);
            WriteConsole(string.Format("Sending data to client {0}: {1}", clientSocket.Name, text));
        }

        static void BeginReceive(Socket clientSocket)
        {
            StateObject state = new StateObject(clientSocket);
            clientSocket.BeginReceive(state.Buffer, 0, state.Buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallBack), state);
            WriteConsole("Receiving data from client...");
        }

        static string GenerateClientName()
        {
            return string.Format("client-{0}", Math.Abs(DateTime.Now.GetHashCode()).ToString().Substring(0, 3));
        }

        static bool IsNameUnique(string name)
        {
            return _clients.Count(c => c.Name == name) == 0;
        }

        static string GetUniqueName()
        {
            while (true)
            {
                string clientName = GenerateClientName();
                if (IsNameUnique(clientName))
                {
                    return clientName;
                }
            }
            throw new Exception("Couldn't get unique name.");
        }

        static ClientInformation GetClientInformation(Socket socket)
        {
            IEnumerable<ClientInformation> sockets = _clients.Where(c => c.Socket == socket);
            if (sockets.Count() == 1)
            {
                return sockets.First();
            }
            else
            {
                throw new ArgumentOutOfRangeException("socket");
            }
        }

        static ClientInformation GetClientInformation(string clientName)
        {
            IEnumerable<ClientInformation> sockets = _clients.Where(c => c.Name == clientName);
            if (sockets.Count() == 1)
            {
                return sockets.First();
            }
            else
            {
                throw new ArgumentOutOfRangeException("clientName");
            }
        }

        static ClientInformation GetClientInformation(int id)
        {
            IEnumerable<ClientInformation> sockets = _clients.Where(c => c.Id == id);
            if (sockets.Count() == 1)
            {
                return sockets.First();
            }
            else
            {
                throw new ArgumentOutOfRangeException("id");
            }
        }

        static int GetFirstUnusedClientId()
        {
            int id = 1;
            while (id < 999)
            {
                if (_clients.Count(c => c.Id == id) == 0)
                {
                    return id;
                }
                ++id;
            }
            throw new InvalidOperationException();
        }

        #region Callback
        static void AcceptCallback(IAsyncResult ar)
        {
            Socket serverSocket = (Socket)ar.AsyncState;
            Socket clientSocket = serverSocket.EndAccept(ar);
            WriteConsole("Accepted connection.");
            BeginReceive(clientSocket);
            BeginAccept(serverSocket);
            string clientName = GetUniqueName();
            ClientInformation clientInformation = new ClientInformation(clientSocket, clientName, GetFirstUnusedClientId());

            string connectionResponse = XMLManager.Serialize(new ConnectionResponse(clientName, _clients.Select(c => c.Name).ToList()));
            BeginSend(clientInformation, connectionResponse);

            string clientConnect = XMLManager.Serialize(new ClientConnect(clientName));
            foreach (ClientInformation client in _clients)
            {
                BeginSend(client, clientConnect);
            }
            _clients.Add(clientInformation);
        }

        static void SendCallback(IAsyncResult ar)
        {
            Socket serverSocket = (Socket)ar.AsyncState;
            int bytesSent = serverSocket.EndSend(ar);
            WriteConsole(string.Format("Sent {0} bytes to client.", bytesSent));
        }

        static void ReceiveCallBack(IAsyncResult ar)
        {
            StateObject state = (StateObject)ar.AsyncState;
            Socket clientSocket = state.Socket;
            int bytesRead = clientSocket.EndReceive(ar);
            string text = Encoding.UTF8.GetString(state.Buffer, 0, bytesRead);
            ClientInformation senderClient = GetClientInformation(clientSocket);
            WriteConsole(string.Format("Received data from client {0}: {1}", senderClient.Name, text));
            if (!string.IsNullOrEmpty(text))
            {
                object element = XMLManager.Deserialize(text);
                if (element is SendMessage sendMessage)
                {
                    BroadcastMessage broadcastMessage = new BroadcastMessage(senderClient.Name, sendMessage.Text);
                    string broadcastMessageText = XMLManager.Serialize(broadcastMessage);
                    foreach (ClientInformation client in _clients)
                    {
                        BeginSend(client, broadcastMessageText);
                    }
                }
                else if (element is ChangeNameRequest cnr)
                {
                    if (string.IsNullOrEmpty(cnr.Name))
                    {
                        BeginSend(senderClient, XMLManager.Serialize(new ErrorResponse((int)ErrorCode.InvalidName)));
                    }
                    else if (IsNameUnique(cnr.Name))
                    {
                        string changeNameResponseText = XMLManager.Serialize(new ChangeNameResponse(senderClient.Name, cnr.Name));
                        foreach (ClientInformation client in _clients)
                        {
                            BeginSend(client, changeNameResponseText);
                        }
                        senderClient.Name = cnr.Name;
                    }
                    else
                    {
                        BeginSend(senderClient, XMLManager.Serialize(new ErrorResponse((int)ErrorCode.NameAlreadyExists)));
                    }
                }
                else if (element is ChallengeRequest challengeRequest)
                {
                    ClientInformation challengeeClient = GetClientInformation(challengeRequest.ChallengeeName);
                    if (challengeeClient.State == ClientState.Available)
                    {
                        senderClient.ChangeStateToChallenge(challengeeClient.Id);
                        challengeeClient.ChangeStateToChallenge(senderClient.Id);
                        BeginSend(senderClient, XMLManager.Serialize(new ChallengePendingResponse() { ChallengeeName = challengeRequest.ChallengeeName }));
                        BeginSend(challengeeClient, XMLManager.Serialize(new ChallengeRequest(senderClient.Name)));
                    }
                    else if (challengeeClient.State == ClientState.Challenge)
                    {
                        BeginSend(senderClient, XMLManager.Serialize(new ErrorResponse((int)ErrorCode.ClientAlreadyChallenged)));
                    }
                    else if (challengeeClient.State == ClientState.Duel)
                    {
                        BeginSend(senderClient, XMLManager.Serialize(new ErrorResponse((int)ErrorCode.ClientAlreadyInDuel)));
                    }
                    else
                    {
                        throw new InvalidOperationException("Unknown client state.");
                    }
                    
                }
                else if (element is CancelChallengeRequest)
                {
                    ClientInformation challengeeClient = GetClientInformation(senderClient.OtherClientId);
                    senderClient.ChangeStateToAvailable();
                    challengeeClient.ChangeStateToAvailable();
                    BeginSend(senderClient, XMLManager.Serialize(new CancelChallengeRequest()));
                    BeginSend(challengeeClient, XMLManager.Serialize(new CancelChallengeResponse() { Challenger = senderClient.Name }));
                }
                else if (element is DeclineChallengeRequest)
                {
                    ClientInformation challengerClient = GetClientInformation(senderClient.OtherClientId);
                    senderClient.ChangeStateToAvailable();
                    challengerClient.ChangeStateToAvailable();
                    BeginSend(senderClient, XMLManager.Serialize(new DeclineChallengeRequest()));
                    BeginSend(challengerClient, XMLManager.Serialize(new DeclineChallengeResponse() { Challengee = senderClient.Name }));
                }
                else if (element is AcceptChallengeRequest)
                {
                    //TODO: implement properly
                    ClientInformation challengerClient = GetClientInformation(senderClient.OtherClientId);
                    senderClient.ChangeStateToAvailable();
                    challengerClient.ChangeStateToAvailable();
                    BeginSend(senderClient, XMLManager.Serialize(new AcceptChallengeRequest()));
                    BeginSend(challengerClient, XMLManager.Serialize(new AcceptChallengeResponse() { Challengee = senderClient.Name }));
                }
                else
                {
                    throw new ArgumentOutOfRangeException("element");
                }
                BeginReceive(clientSocket);
            }
            else
            {
                senderClient.Socket.Shutdown(SocketShutdown.Both);
                senderClient.Socket.Close();
                _clients.Remove(senderClient);
                WriteConsole(string.Format("{0} disconnected.", senderClient.Name));
                ClientDisconnect clientDisconnect = new ClientDisconnect(senderClient.Name);
                string clientDisconnectText = XMLManager.Serialize(clientDisconnect);
                foreach (ClientInformation client in _clients)
                {
                    BeginSend(client, clientDisconnectText);
                }
            }
        }
        #endregion Callback
    }
}
