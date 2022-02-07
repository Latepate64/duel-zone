using Common.Choices;
using Common;
using System.Net.Sockets;
using System.Linq;
using Engine;

namespace Server
{
    class HumanPlayer : Engine.Player
    {
        public Server Server { get; set; }
        public TcpClient Client { get; internal set; }

        public HumanPlayer() : base()
        {
        }

        public override YesNoDecision Choose(YesNoChoice yesNoChoice)
        {
            Server.BroadcastMessage(Serializer.Serialize(yesNoChoice));
            return Serializer.Deserialize(Server.ReadAsync(Client).Result).First() as YesNoDecision;
        }

        public override GuidDecision ClientChoose(GuidSelection guidSelection)
        {
            Server.BroadcastMessage(Serializer.Serialize(guidSelection));
            return Serializer.Deserialize(Server.ReadAsync(Client).Result).First() as GuidDecision;
        }
    }
}
