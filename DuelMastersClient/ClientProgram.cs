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
        #endregion Fields

        static void Main(string[] args)
        {
            Console.WriteLine("Started Duel Masters Client.");
            StartClient(EnterName());
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
                    try
                    {
                        var xElement = XmlUtility.GetXElement(state.StringBuilder.ToString());
                        Console.WriteLine("Response received: {0}", xElement);

                        // Signal that all bytes have been received.  
                        _receiveDone.Set();
                    }
                    catch (System.Xml.XmlException e)
                    {
                        // Get the rest of the data.  
                        state.ClientSocket.BeginReceive(state.Buffer, 0, StateObject.BufferSize, SocketFlags.None, new AsyncCallback(ReceiveCallback), state);
                    }
                }
                else
                {
                    throw new Exception("ReceiveCallback: Expected bytes.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
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
                clientSocket.BeginConnect(new IPEndPoint(ipAddress, Port), new AsyncCallback(ConnectCallback), clientSocket);
                _connectDone.WaitOne();

                Send(clientSocket, new XElement("Name", name).ToString());
                _sendDone.WaitOne();

                while (true)
                {
                    _receiveDone.Reset();
                    Receive(clientSocket);
                    _receiveDone.WaitOne();
                }
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
                client.BeginReceive(state.Buffer, 0, StateObject.BufferSize, SocketFlags.None, new AsyncCallback(ReceiveCallback), state);
                Console.WriteLine("Waiting for data from the server...");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void Send(Socket client, string data)
        {
            Console.WriteLine(String.Format("Sending data to server: {0}", data));

            // Convert the string data to byte data using ASCII encoding.  
            var byteData = Encoding.ASCII.GetBytes(data);

            // Begin sending the data to the remote device.  
            client.BeginSend(byteData, 0, byteData.Length, 0, new AsyncCallback(SendCallback), client);
        }
    }
}
