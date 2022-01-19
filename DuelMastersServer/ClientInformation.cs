using System.Net.Sockets;

namespace DuelMastersServer
{
    public enum ClientState
    {
        Available,
        Challenge,
        Duel,
    }

    public class ClientInformation
    {
        public Socket Socket { get; private set; }
        public string Name { get; set; }

        /// <summary>
        /// 0 means unknown.
        /// </summary>
        public int Id { get; private set; }
        public ClientState State { get; private set; } = ClientState.Available;

        /// <summary>
        /// The id of the other client in case of state being challenge or game.
        /// </summary>
        public int OtherClientId { get; private set; }

        public ClientInformation(Socket socket, string name, int id)
        {
            Socket = socket;
            Name = name;
            Id = id;
        }

        public void ChangeStateToAvailable()
        {
            State = ClientState.Available;
            OtherClientId = 0;
        }

        public void ChangeStateToChallenge(int otherClientId)
        {
            State = ClientState.Challenge;
            OtherClientId = otherClientId;
        }

        public void ChangeStateToDuel(int otherClientId)
        {
            State = ClientState.Duel;
            OtherClientId = otherClientId;
        }
    }
}
