using System.Net.Sockets;

namespace DuelMastersServer
{
    public class StateObject
    {
        public Socket Socket { get; set; }
        public byte[] Buffer { get; set; } = new byte[1024];

        public StateObject(Socket socket)
        {
            Socket = socket;
        }
    }
}