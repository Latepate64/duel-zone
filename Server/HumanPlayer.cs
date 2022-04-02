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

        public override YesNoDecision ClientChoose(YesNoChoice yesNoChoice)
        {
            Server.Write(Serializer.Serialize(yesNoChoice), Client);
            return Serializer.Deserialize(Server.ReadAsync(Client).Result).First() as YesNoDecision;
        }

        public override GuidDecision ClientChoose(GuidSelection guidSelection)
        {
            try
            {
                Server.Write(Serializer.Serialize(guidSelection), Client);
                return Serializer.Deserialize(Server.ReadAsync(Client).Result).First() as GuidDecision;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public override Subtype ChooseRace(params Subtype[] excluded)
        {
            throw new NotImplementedException();
        }
    }
}
