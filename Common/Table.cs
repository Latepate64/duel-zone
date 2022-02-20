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

        public Table(Table table)
        {
            if (Guest != null)
            { 
                Guest = new Player(table.Guest);
            }
            GuestReady = table.GuestReady;
            if (Host != null)
            {
                Host = new Player(table.Host);
            }
            HostReady = table.HostReady;
            HumanOpponent = table.HumanOpponent;
            Id = table.Id;
        }

        public IEnumerable<Player> GetPlayers()
        {
            if (Guest != null)
            {
                return new[] { Host, Guest };
            }
            else
            {
                return new[] { Host };
            }
        }

        public override string ToString()
        {
            return $"table {Id}";
        }

        public override bool Equals(object obj)
        {
            return obj is Table table && table.Id == Id;
        }
    }
}
