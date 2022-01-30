using System;
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
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
