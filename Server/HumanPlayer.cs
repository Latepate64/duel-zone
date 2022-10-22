using Common.Choices;
using Common;
using System.Net.Sockets;
using System.Linq;
using System;

namespace Server
{
    class HumanPlayer : Engine.Player
    {
        public Server Server { get; }
        public TcpClient Client { get; }

        public HumanPlayer(Server server, TcpClient client) : base()
        {
            Server = server;
            Client = client;
        }

        public override T ChooseAbstractly<T>(T choice)
        {
            throw new NotImplementedException();
        }

        public override Engine.IPlayer Copy()
        {
            throw new NotImplementedException();
        }
    }
}
