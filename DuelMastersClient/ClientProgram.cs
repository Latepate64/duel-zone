using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using System.Xml.Linq;

namespace DuelMastersClient
{
    /// <summary>
    /// State object for receiving data from remote device.
    /// </summary>
    public class StateObject
    {
        /// <summary>
        /// Client socket.  
        /// </summary>
        public Socket ClientSocket = null;

        /// <summary>
        /// Size of receive buffer.
        /// </summary>
        public const int BufferSize = 256;

        /// <summary>
        /// Receive buffer.
        /// </summary>
        public byte[] Buffer = new byte[BufferSize];

        /// <summary>
        /// Received data string.
        /// </summary>
        public StringBuilder StringBuilder = new StringBuilder();
    }

    class ClientProgram
    {
        private const int Port = 11000;

        #region Fields
        private static ManualResetEvent _connectDone = new ManualResetEvent(false);
        private static ManualResetEvent _sendDone = new ManualResetEvent(false);
        private static ManualResetEvent _receiveDone = new ManualResetEvent(false);
        private static string _response = String.Empty;
        //private static string _name;
        #endregion Fields

        static void Main(string[] args)
        {
            Console.WriteLine("Started Duel Masters Client.");
            var name = EnterName();
            StartClient(name);
        }

        #region Callbacks
        private static void DisconnectCallback(IAsyncResult ar)
        {
        }

        private static void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.  
                var clientSocket = (Socket)ar.AsyncState;

                // Complete the connection.  
                clientSocket.EndConnect(ar);

                Console.WriteLine("Socket connected to {0}", clientSocket.RemoteEndPoint.ToString());

                // Signal that the connection has been made.  
                _connectDone.Set();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the state object and the client socket from the asynchronous state object.  
                var state = (StateObject)ar.AsyncState;

                // Read data from the remote device.  
                var bytesRead = state.ClientSocket.EndReceive(ar);
                if (bytesRead > 0)
                {
                    // There might be more data, so store the data received so far.  
                    state.StringBuilder.Append(Encoding.ASCII.GetString(state.Buffer, 0, bytesRead));

                    // Get the rest of the data.  
                    state.ClientSocket.BeginReceive(state.Buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReceiveCallback), state);
                }
                else
                {
                    // All the data has arrived; put it in response.  
                    if (state.StringBuilder.Length > 1)
                    {
                        _response = state.StringBuilder.ToString();
                    }

                    // Signal that all bytes have been received.  
                    _receiveDone.Set();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        #endregion Callbacks

        private static string EnterName()
        {
            Console.WriteLine("Please enter your name.");
            Console.Write("> ");
            return Console.ReadLine();
        }

        private static void StartClient(string name)
        {
            Socket clientSocket = null;
            try
            {
                var ipAddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0];
                clientSocket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                clientSocket.BeginConnect(new IPEndPoint(ipAddress, Port), new AsyncCallback(ConnectCallback), new StateObject() { ClientSocket = clientSocket, Buffer = Encoding.ASCII.GetBytes(name) });
                _connectDone.WaitOne();
                //SendConnectionRequest(client);
                //_sendDone.WaitOne();
                Receive(clientSocket);
                _receiveDone.WaitOne();
                Console.WriteLine("Response received : {0}", _response);
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void Receive(Socket client)
        {
            try
            {
                // Create the state object.  
                var state = new StateObject() { ClientSocket = client };

                // Begin receiving the data from the remote device.  
                client.BeginReceive(state.Buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReceiveCallback), state);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void Send(Socket client, string data)
        {
            // Convert the string data to byte data using ASCII encoding.  
            var byteData = Encoding.ASCII.GetBytes(data);

            // Begin sending the data to the remote device.  
            client.BeginSend(byteData, 0, byteData.Length, 0, new AsyncCallback(SendCallback), client);
        }

        private static void SendConnectionRequest(Socket client)
        {
            //Send(client, new XElement("ConnectionRequest", _name).ToString());
        }

        private static void SendDisconnectRequest(Socket client)
        {
            //Send(client, new XElement("DisconnectRequest", _name).ToString());
        }

        private static void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Complete sending the data to the remote device.  
                var bytesSent = ((Socket)ar.AsyncState).EndSend(ar);
                Console.WriteLine("Sent {0} bytes to server.", bytesSent);

                // Signal that all bytes have been sent.  
                _sendDone.Set();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
