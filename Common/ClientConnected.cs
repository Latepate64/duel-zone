using System.Collections.Generic;

namespace Common
{
    public class ClientConnected
    {
        public List<Table> Tables { get; set; }

        public IPlayer ConnectedPlayer { get; set; }

        public override string ToString()
        {
            return $"{ConnectedPlayer} connected to server.";
        }
    }
}
