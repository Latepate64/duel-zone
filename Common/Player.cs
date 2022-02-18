using System;

namespace Common
{
    public class Player
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Player()
        {
            Id = Guid.NewGuid();
        }

        public Player(Player player)
        {
            Id = player.Id;
            Name = player?.Name;
        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            return obj is Player player && Id == player.Id;
        }
    }
}
