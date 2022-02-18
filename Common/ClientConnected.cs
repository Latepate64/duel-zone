using System.Collections.Generic;

namespace Common
{
    public class ClientConnected
    {
        public List<Table> Tables { get; set; }

        public Player ConnectedPlayer { get; set; }
    }
}
