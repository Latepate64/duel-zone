using System.Net.Sockets;

namespace Common
{
    public static class Helper
    {
        public static string ObjectToText(object obj, TcpClient client)
        {
            if (obj is ClientName name)
            {
                return $"{client.Client.RemoteEndPoint} set their name as {name.Name}";
            }
            else if (obj is ClientConnected)
            {
                return $"{client.Client.RemoteEndPoint} connected.";
            }
            else if (obj is Message message)
            {
                return $"{client.Client.RemoteEndPoint}: {message.Text}";
            }
            else if (obj is CreateTable)
            {
                return $"{client.Client.RemoteEndPoint} created table.";
            }
            else if (obj is LeaveTable)
            {
                return $"{client.Client.RemoteEndPoint} left table.";
            }
            else
            {
                return obj.ToString();
            }
        }
    }
}
