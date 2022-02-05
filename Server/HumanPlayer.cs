using Common.Choices;
using Common;
using System.Net.Sockets;
using System.Linq;

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
            while (true);
            return null;
        }

        public override GuidDecision Choose(GuidSelection guidSelection)
        {
            Server.BroadcastMessage(Serializer.Serialize(guidSelection));
            var text = Server.ReadAsync(Client);
            var decision = Serializer.Deserialize(text.Result).First() as GuidDecision;
            return decision;
        }
    }
}
