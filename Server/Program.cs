using System;

namespace Server
{
    class Program
    {
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
    }
}
