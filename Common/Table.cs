using System;
using System.Collections.Generic;

namespace Common
{
    public class Table
    {
        public Guid Id { get; set; }

        public Player Host { get; set; }

        public Player Guest { get; set; }

        public bool HostReady { get; set; }

        public bool GuestReady { get; set; }

        public bool HumanOpponent { get; set; }

        public Table()
        {
            Id = Guid.NewGuid();
        }

        public IEnumerable<Player> GetPlayers()
        {
            return new[] { Host, Guest };
        }

        public override string ToString()
        {
            return $"table {Id}";
        }
    }
}
